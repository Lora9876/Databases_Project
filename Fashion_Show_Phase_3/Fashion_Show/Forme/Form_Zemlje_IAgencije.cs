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
    public partial class Form_Zemlje_IAgencije : Form
    {
        int ID_Agencije;
        public Form_Zemlje_IAgencije()
        {
            InitializeComponent();
        }
        public Form_Zemlje_IAgencije(int ID)
        {
            InitializeComponent();
            ID_Agencije = ID;
            this.prikazi();
         }
        private void prikazi()
        {
            try
            {
                ISession s = DataLayer.GetSession();
                //Fashion_Show.Entiteti.Internacionalna_Agencija ucesnik = s.Load<Fashion_Show.Entiteti.Internacionalna_Agencija>(ID);
                //IList<Zemlja> zemlje = ucesnik.Zemlje;
                IQuery q = s.CreateQuery("from Zemlja as z where z.PripadaAgenciji.ID = :broj");
                q.SetInt32("broj", ID_Agencije);
                IList<Zemlja> zemlje = q.List<Entiteti.Zemlja>();
                this.listBox1.Items.Clear();
                foreach (Zemlja z in zemlje)
                {
                    this.listBox1.Items.Add(z.ID_Zemlja + "  " + z.Naziv_Zemlje);
                }

                listBox1.Refresh();
                s.Close();

            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }

        }

        private void Dodajbutton_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Fashion_Show.Entiteti.Internacionalna_Agencija agencija = s.Load<Fashion_Show.Entiteti.Internacionalna_Agencija>(ID_Agencije);
                Zemlja zemlja = new Zemlja();
                zemlja.Naziv_Zemlje = this.ZemljaText.Text;

                zemlja.PripadaAgenciji = agencija;
                s.Save(zemlja);
                agencija.Zemlje.Add(zemlja);
                s.SaveOrUpdate(agencija);
                s.Flush();
                s.Close();
                this.listBox1.Items.Add(zemlja.ID_Zemlja + " " + zemlja.Naziv_Zemlje);
                this.listBox1.Refresh();
                MessageBox.Show("Uspesno dodavanje zemlje internacionalnoj agenciji!");

            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }

        }

        private void Obrisibutton_Click(object sender, EventArgs e)
        {
            int broj_selektovanih = this.listBox1.SelectedItems.Count;
            if (broj_selektovanih == 0)
            {
                MessageBox.Show("Niste selektovali zemlju.");
                return;
            }
            string z = this.listBox1.SelectedItem.ToString();
            char[] param = { ' ' };
            string[] rez = z.Split(param);
            int p = Convert.ToInt32(rez[0]);// ID Zemlje
            try
            {
                ISession s = DataLayer.GetSession();
                Fashion_Show.Entiteti.Internacionalna_Agencija agencija = s.Load<Fashion_Show.Entiteti.Internacionalna_Agencija>(ID_Agencije);
                Zemlja zemlja = s.Load<Zemlja>(p);// ID ZEMLJE
                agencija.Zemlje.Remove(zemlja);
                zemlja.PripadaAgenciji=null;
                s.SaveOrUpdate(agencija);
                s.Delete(zemlja);
                s.Flush();
                this.prikazi();
                MessageBox.Show("Uspesno brisanje!");

            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void Azurirajbutton_Click(object sender, EventArgs e)
        {
            int broj_selektovanih = this.listBox1.SelectedItems.Count;
            if (broj_selektovanih == 0)
            {
                MessageBox.Show("Niste selektovali zemlju.");
                return;
            }
            string z = this.listBox1.SelectedItem.ToString();
            char[] param = { ' ' };
            string[] rez = z.Split(param);
            int p = Convert.ToInt32(rez[0]);// ID Zemlje
            try
            {
                ISession s = DataLayer.GetSession();
                Fashion_Show.Entiteti.Internacionalna_Agencija agencija = s.Load<Fashion_Show.Entiteti.Internacionalna_Agencija>(ID_Agencije);
                Zemlja zemlja = s.Load<Zemlja>(p);// ID ZEMLJE
                zemlja.Naziv_Zemlje = this.ZemljaText.Text;     
                s.SaveOrUpdate(agencija);
                s.SaveOrUpdate(zemlja);
                s.Flush();
                this.prikazi();
                MessageBox.Show("Uspesno azuriranje naziva zemlje!");

            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }

        }
        
    }
}
