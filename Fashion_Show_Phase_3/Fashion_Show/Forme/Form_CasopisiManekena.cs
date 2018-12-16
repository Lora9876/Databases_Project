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

namespace Fashion_Show.Forme
{
    public partial class Form_CasopisiManekena : Form
    {
        int ID_Manekena;
        public Form_CasopisiManekena()
        {
            InitializeComponent();
        }
        public Form_CasopisiManekena(int ID)
        {
            InitializeComponent();
            this.ID_Manekena = ID;
            this.prikazi();
      
        }
        private void prikazi()
        {
            try
            {
                ISession s = DataLayer.GetSession();
                IQuery q = s.CreateQuery("from Casopic as c where c.PripadaManekenu.ID = :broj");
                q.SetInt32("broj", ID_Manekena);

                IList<Casopic> casopisi = q.List<Entiteti.Casopic>();
                this.listBox1.Items.Clear();
                foreach (Casopic c in casopisi)
                {
                    this.listBox1.Items.Add(c.ID_Casopis + " " + c.Naziv_Casopisa);
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
                Fashion_Show.Entiteti.Maneken m = s.Load<Fashion_Show.Entiteti.Maneken>(ID_Manekena);
                Casopic casopis = new Casopic();
                casopis.Naziv_Casopisa = this.CasopisText.Text;

                casopis.PripadaManekenu = m;
                s.Save(casopis);
                m.Casopisi.Add(casopis);
                s.SaveOrUpdate(m);
                s.Flush();
                s.Close();
                this.listBox1.Items.Add(casopis.ID_Casopis + " " + casopis.Naziv_Casopisa);
                this.listBox1.Refresh();
                MessageBox.Show("Uspesno dodavanje casopisa manekenu!");

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
                MessageBox.Show("Niste selektovali casopis");
                return;
            }
            string z = this.listBox1.SelectedItem.ToString();
            char[] param = { ' ' };
            string[] rez = z.Split(param);
            int p = Convert.ToInt32(rez[0]);
            try
            {
                ISession s = DataLayer.GetSession();
                Fashion_Show.Entiteti.Maneken m = s.Load<Fashion_Show.Entiteti.Maneken>(ID_Manekena);
                Casopic casopis = s.Load<Casopic>(p);// ID Casopis
                m.Casopisi.Remove(casopis);
                casopis.PripadaManekenu=null;
                s.SaveOrUpdate(m);
                s.Delete(casopis);
                s.Flush();
                this.listBox1.Items.Remove(this.listBox1.SelectedItem);
                this.listBox1.Refresh();
                MessageBox.Show("Uspesno brisanje!");
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
                MessageBox.Show("Niste selektovali casopis");
                return;
            }
            string z = this.listBox1.SelectedItem.ToString();
            char[] param = { ' ' };
            string[] rez = z.Split(param);
            int p = Convert.ToInt32(rez[0]);
            try
            {
                ISession s = DataLayer.GetSession();
                Fashion_Show.Entiteti.Maneken m = s.Load<Fashion_Show.Entiteti.Maneken>(ID_Manekena);
                Casopic casopis = s.Load<Casopic>(p);// ID Casopis
                casopis.Naziv_Casopisa = this.CasopisText.Text;
                s.SaveOrUpdate(m);
                s.SaveOrUpdate(casopis);
                s.Flush();
                this.prikazi();
                MessageBox.Show("Uspesno azuriranje naziva casopisa!");
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }

        }
        
        
    }
}
