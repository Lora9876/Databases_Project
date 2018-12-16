using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NHibernate;
using Fashion_Show.Entiteti;
using Fashion_Show;

namespace Fashion_Show.Forme
{
    public partial class Form_AzurirajAgencijskogManekena : Form
    {
        int ID_AManekena;
        public Form_AzurirajAgencijskogManekena()
        {
            InitializeComponent();
        }
        public Form_AzurirajAgencijskogManekena(int ID)
        {
            InitializeComponent();
            this.ID_AManekena = ID;
            try
            {
                ISession s = DataLayer.GetSession();
                IQuery q = s.CreateQuery("from Agencija");//sve agencije 
                IList<Agencija> ucesnici = q.List<Agencija>();

                listBox1.Items.Clear();
                foreach (Agencija agencija in ucesnici)
                {

                    this.listBox1.Items.Add(agencija.ID + " " + agencija.PIB + " " + agencija.Naziv  + " " + agencija.Sediste);
                }
                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int broj_selektovanih = this.listBox1.SelectedItems.Count;
            if (broj_selektovanih == 0)
            {
                MessageBox.Show("Niste selektovali agenciju kojoj pripada!");
                return;
            }
            string z = this.listBox1.SelectedItem.ToString();
            char[] param = { ' ' };
            string[] rez = z.Split(param);
            int p = Convert.ToInt32(rez[0]);
            try
            {
                ISession s = DataLayer.GetSession();
                Fashion_Show.Entiteti.Agencijski_Maneken am = s.Load<Fashion_Show.Entiteti.Agencijski_Maneken>(ID_AManekena);
                //IQuery q = s.CreateQuery("select a.PripadaAgeciji  from Agencijski_Maneken as a where a.ID  = ? ");
               // q.SetInt32(0, ID_AManekena);
               // Agencija stara_agencija = q.UniqueResult<Agencija>();
                Agencija stara_agencija = am.PripadaAgeciji;
                stara_agencija.AManekeni.Remove(am);

                Fashion_Show.Entiteti.Agencija agencija = s.Load<Fashion_Show.Entiteti.Agencija>(p);
                am.Maticni_Broj = Convert.ToInt64(this.textBox2.Text);
                am.Licno_Ime = this.textBox3.Text;
                am.Prezime = this.textBox4.Text;
                am.Datum_Rodjenja = Convert.ToDateTime(this.textBox5.Text);
                am.Pol = this.textBox1.Text;
                am.Boja_Kose = this.textBox6.Text;
                am.Boja_Ociju = this.textBox7.Text;
                am.Visina = Convert.ToInt32(this.textBox8.Text);
                am.Tezina = Convert.ToInt32(this.textBox9.Text);
                am.Konfekcijski_Broj = Convert.ToInt32(this.textBox10.Text);
                am.PripadaAgeciji = agencija;
                s.SaveOrUpdate(am);
                agencija.AManekeni.Add(am);
                s.SaveOrUpdate(agencija);
                s.Flush();
                s.Close();
                MessageBox.Show("Azurirali ste stavku idite na prikaz agencijskih manekena za refresh!");
                Close();

            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }


        }
    }
}
