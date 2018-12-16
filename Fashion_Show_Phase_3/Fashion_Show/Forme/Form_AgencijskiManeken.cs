using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FluentNHibernate;
using NHibernate;
using Fashion_Show.Entiteti;
using Fashion_Show;
using NHibernate.Linq;

namespace Fashion_Show.Forme
{
    public partial class Form_AgencijskiManeken : Form
    {
        public Form_AgencijskiManeken()
        {
            InitializeComponent();
            try
            {
                ISession s = DataLayer.GetSession();
                IQuery q = s.CreateQuery("from Agencija");//sve agencije 
                IList<Agencija> ucesnici = q.List<Agencija>();

                listBox2.Items.Clear();
                foreach (Agencija agencija in ucesnici)
                {
                    
                        this.listBox2.Items.Add(agencija.ID + " " + agencija.PIB + " " + agencija.Naziv +  " " + agencija.Sediste);
                }
                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void Prikazbutton_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                if (this.radioButton1.Checked == true)//svi agencijski manekeni
                {
                    IQuery q = s.CreateQuery("select a.ID, a.Maticni_Broj, a.Licno_Ime, a.Prezime, a.Visina, a.Tezina, a.PripadaAgeciji.Naziv from Agencijski_Maneken a");
                    IList<object[]> result = q.List<object[]>();

                    listBox1.Items.Clear();
                    foreach (object[] r in result)
                    {
                        int id = (int)r[0];
                        long mbr = (long)r[1];
                        string ime = (string)r[2];
                        string prezime = (string)r[3];
                        int visina = (int)r[4];
                        int tezina = (int)r[5];
                        string agencija= (string) r[6];

                        this.listBox1.Items.Add(id.ToString() + " " + mbr.ToString() + " " + ime + " " + prezime + " " + visina + " " + tezina + " " + agencija);

                    }
                }
                else if (this.radioButton2.Checked == true)//agenc. manekeni koji su i kreatori
                {
                    listBox1.Items.Clear();
                    IList<Agencijski_Maneken> amanekeni = (from amaneken in s.Query<Agencijski_Maneken>() join k in s.Query<Kreator>() on amaneken.ID equals k.ID select amaneken).ToList<Agencijski_Maneken>();
                    listBox1.Items.Clear();
                    foreach (Agencijski_Maneken a in amanekeni)
                    {
                        this.listBox1.Items.Add(a.ID + " " + a.Maticni_Broj + " " + a.Licno_Ime + " " + a.Prezime + " " + a.Visina + " " + a.Tezina + " "+ a.PripadaAgeciji.Naziv);
                    }
                }
                else
                {
                    MessageBox.Show("Niste izabrali prikaz!");
                    return;
                }
                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void Obrisi_Click(object sender, EventArgs e)
        {
            int broj_selektovanih = this.listBox1.SelectedItems.Count;
            if (broj_selektovanih == 0)
            {
                MessageBox.Show("Niste selektovali agenc manekena za brisanje");
                return;
            }
            string z = this.listBox1.SelectedItem.ToString();
            char[] param = { ' ' };
            string[] rez = z.Split(param);
            int p = Convert.ToInt32(rez[0]);
            try
            {
                ISession s = DataLayer.GetSession();
                Fashion_Show.Entiteti.Agencijski_Maneken ucesnik = s.Load<Fashion_Show.Entiteti.Agencijski_Maneken>(p);
                s.Delete(ucesnik);
                s.Flush();
                s.Close();
                MessageBox.Show("Uspesno brisanje stavke");

            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }

        }

        private void Kreirajbutton_Click(object sender, EventArgs e)
        {
            int broj_selektovanih = this.listBox2.SelectedItems.Count;
            if (broj_selektovanih == 0)
            {
                MessageBox.Show("Niste selektovali agenciju kojoj pripada!");
                return;
            }
            string z = this.listBox2.SelectedItem.ToString();
            char[] param = { ' ' };
            string[] rez = z.Split(param);
            int p = Convert.ToInt32(rez[0]);
            try
            {
                ISession s = DataLayer.GetSession();
                Fashion_Show.Entiteti.Agencija agencija = s.Load<Fashion_Show.Entiteti.Agencija>(p);//agencija kojoj pripada
                Agencijski_Maneken amaneken=new Agencijski_Maneken();

                amaneken.Maticni_Broj = Convert.ToInt64(this.textBox2.Text);
                amaneken.Licno_Ime = this.textBox3.Text;
                amaneken.Prezime = this.textBox4.Text;
                amaneken.Datum_Rodjenja = Convert.ToDateTime(this.textBox5.Text);
                amaneken.Pol = this.textBox1.Text;
                amaneken.Boja_Kose = this.textBox6.Text;
                amaneken.Boja_Ociju = this.textBox7.Text;
                amaneken.Visina = Convert.ToInt32(this.textBox8.Text);
                amaneken.Tezina = Convert.ToInt32(this.textBox9.Text);
                amaneken.Konfekcijski_Broj = Convert.ToInt32(this.textBox10.Text);
                amaneken.PripadaAgeciji = agencija;
                s.Save(amaneken);
                agencija.AManekeni.Add(amaneken);
                s.SaveOrUpdate(agencija);
                s.Flush();
                s.Close();
                MessageBox.Show("Stavka uspesno dodata");
                this.Prikazbutton.PerformClick();
               
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void Casopisibutton_Click(object sender, EventArgs e)
        {

            int broj_selektovanih = this.listBox1.SelectedItems.Count;
            if (broj_selektovanih == 0)
            {
                MessageBox.Show("Niste selektovali agencijskog manekena!");
                return;
            }
            string z = this.listBox1.SelectedItem.ToString();
            char[] param = { ' ' };
            string[] rez = z.Split(param);
            int p = Convert.ToInt32(rez[0]);
            Form_CasopisiManekena fc = new Form_CasopisiManekena(p);
            fc.ShowDialog();
             
        }

        private void DetaljiNastupa_Click(object sender, EventArgs e)
        {
            int broj_selektovanih = this.listBox1.SelectedItems.Count;
            if (broj_selektovanih == 0)
            {
                MessageBox.Show("Niste selektovali agencijskog manekena!");
                return;
            }
            string z = this.listBox1.SelectedItem.ToString();
            char[] param = { ' ' };
            string[] rez = z.Split(param);
            int p = Convert.ToInt32(rez[0]);

            Form_DetaljiNastupaManekena child = new Form_DetaljiNastupaManekena(p);
            child.ShowDialog();

        }

        private void Azurirajbutton3_Click(object sender, EventArgs e)
        {
            int broj_selektovanih = this.listBox1.SelectedItems.Count;
            if (broj_selektovanih == 0)
            {
                MessageBox.Show("Niste selektovali agencijskog manekena!");
                return;
            }
            string z = this.listBox1.SelectedItem.ToString();
            char[] param = { ' ' };
            string[] rez = z.Split(param);
            int p = Convert.ToInt32(rez[0]);

            Form_AzurirajAgencijskogManekena fa = new Form_AzurirajAgencijskogManekena(p);
            fa.Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int broj_selektovanih = this.listBox1.SelectedItems.Count;
            if (broj_selektovanih == 0)
            {
                MessageBox.Show("Niste selektovali agencijskog manekena!");
                return;
            }
            string z = this.listBox1.SelectedItem.ToString();
            char[] param = { ' ' };
            string[] rez = z.Split(param);
            int p = Convert.ToInt32(rez[0]);
            Form_DetaljiAgencije fd = new Form_DetaljiAgencije(p);
            fd.ShowDialog();

        }

        
    }
}
