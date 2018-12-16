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
    public partial class Form_Dodaj_Nastupa : Form
    {
        public Form_Dodaj_Nastupa()
        {
            
            InitializeComponent();
            try
            {
                ISession s = DataLayer.GetSession();
                IQuery q1 = s.CreateQuery("from Modna_Revija ");
                IList< Modna_Revija > revije= q1.List<Modna_Revija>();
                IQuery q2 = s.CreateQuery("from Maneken ");
                IList<Maneken> manekeni = q2.List<Maneken>();

                foreach (Modna_Revija m in revije)
                {
                    this.listBox1.Items.Add(m.Redni_Broj + " " + m.Naziv + " " + m.Mesto_Odrzavanja);
                }

                foreach (Maneken m in manekeni)
                {
                    this.listBox2.Items.Add(m.ID + " " + m.Licno_Ime + " " + m.Prezime);
                }

                s.Close();
               
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
            
        }

        private void button3_Click(object sender, EventArgs e)//Dodavanje nastupa
        {
            int broj_selektovanih1 = this.listBox1.SelectedItems.Count;
            if (broj_selektovanih1== 0)
            {
                MessageBox.Show("Niste selektovali reviju");
                return;
            }
            string z1 = this.listBox1.SelectedItem.ToString();
            char[] param1 = { ' ' };
            string[] rez1 = z1.Split(param1);
            int p1 = Convert.ToInt32(rez1[0]);

            int broj_selektovanih2 = this.listBox2.SelectedItems.Count;
            if (broj_selektovanih2 == 0)
            {
                MessageBox.Show("Niste selektovali manekena");
                return;
            }
            string z2 = this.listBox2.SelectedItem.ToString();// vadi ID agencije
            char[] param2 = { ' ' };
            string[] rez2 = z2.Split(param2);
            int p2 = Convert.ToInt32(rez2[0]);
            try
            {
                ISession s = DataLayer.GetSession();
                Modna_Revija mr = s.Load<Modna_Revija>(p1);
                Maneken man = s.Load<Maneken>(p2);
                IList<Nastupa> svi_nastupi_revije = mr.NastupaManekeni;
                foreach (Nastupa nas in svi_nastupi_revije)
                {
                    if (nas.NastupaManeken == man)
                    {
                        MessageBox.Show("U pitanju su modna_revija i maneken tako da taj maneken vec nastupa na toj reviji!");
                        return;

                    }
                }

                Nastupa n = new Nastupa();
                n.NastupaManeken = man;
                n.NastupaModna_Revija = mr;
                s.Save(n);
                mr.NastupaManekeni.Add(n);
                man.NastupaModna_Revija.Add(n);
                s.SaveOrUpdate(mr);
                s.SaveOrUpdate(man);
                s.Flush();
                s.Close();
                MessageBox.Show("Dodat je nastup idite na prikaz za refresh");
                Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }

        }
    }
}
