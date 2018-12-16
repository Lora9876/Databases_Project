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
using NHibernate.Linq;

namespace Fashion_Show.Forme
{
    public partial class Form_Agencija : Form
    {
        public Form_Agencija()
        {
            InitializeComponent();
        }

        private void Kreiraj_Agencijubutton_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                if (Domaca.Checked == true)
                {
                    Domaca_Agencija dagencija = new Domaca_Agencija();
                    dagencija.PIB=Convert.ToInt32(this.textBox2.Text);
                    dagencija.Naziv = this.textBox3.Text;
                    dagencija.Datum_Osnivanja = Convert.ToDateTime(this.textBox4.Text);
                    dagencija.Sediste = this.textBox5.Text;
                    s.Save(dagencija);
                    s.Flush();
                    s.Close();
                    MessageBox.Show("Stavka uspesno dodata");
                    this.Prikazbutton.PerformClick();
                   
                }
                else if (Internacionalna.Checked == true)
                {
                    Internacionalna_Agencija iagencija = new Internacionalna_Agencija();
                    iagencija.PIB = Convert.ToInt32(this.textBox2.Text);
                    iagencija.Naziv = this.textBox3.Text;
                    iagencija.Datum_Osnivanja = Convert.ToDateTime(this.textBox4.Text);
                    iagencija.Sediste = this.textBox5.Text;
                    s.Save(iagencija);
                    s.Flush();
                    s.Close();
                    MessageBox.Show("Stavka uspesno dodata");
                    this.button2.PerformClick();

                }
                else
                {
                    MessageBox.Show("Niste pravilno izabrali agencije!");
                    return;
                }

            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)//Zemlje intern. agencije
        {
            int brSelektovanih = this.listBox1.SelectedItems.Count;
            if (brSelektovanih == 0)
            {
                MessageBox.Show("Niste selektovali agenciju!");
                return;
            }
            string z = this.listBox1.SelectedItem.ToString();
            char[] param = { ' ' };
            string[] rez = z.Split(param);
            int p = Convert.ToInt32(rez[0]);//izvlaci ID Agencije

            Form_Zemlje_IAgencije zemlja = new Form_Zemlje_IAgencije(p);
            zemlja.Show();
        }

        private void Prikazbutton_Click(object sender, EventArgs e)//prikaz domacih agencija
        {
            groupBox3.Visible = false;
            try
            {
                ISession s = DataLayer.GetSession();
                //posto se tip ne mapira mora ovako
                //IQuery q2 = s.CreateQuery("from Agencija as a where a.Tip='domaca' ");
                //IList<Agencija> ucesnici2 = q2.List<Agencija>();
                IList<Agencija> ucesnici = (from a in s.Query<Agencija>() orderby a.ID select a).ToList<Agencija>();

                listBox1.Items.Clear();
                foreach (Agencija u in ucesnici)
                {
                    if (u.GetType() == typeof(Domaca_Agencija))
                    {
                        Domaca_Agencija agencija = (Domaca_Agencija)u;
                        this.listBox1.Items.Add(agencija.ID + " " + agencija.PIB + " " + agencija.Naziv + " " + agencija.Datum_Osnivanja + " " + agencija.Sediste);
                    }
                }

                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }

        }

        private void button2_Click(object sender, EventArgs e)//prikaz internacionalnih
        {
            groupBox3.Visible = true;
            try
            {
                ISession s = DataLayer.GetSession();
                IList<Agencija> ucesnici = (from a in s.Query<Agencija>() orderby a.ID select a).ToList<Agencija>();
                
                listBox1.Items.Clear();
                foreach (Agencija u in ucesnici)
                {
                    if (u.GetType() == typeof(Internacionalna_Agencija))
                    {
                        Internacionalna_Agencija agencija = (Internacionalna_Agencija)u;
                        this.listBox1.Items.Add(agencija.ID + " " + agencija.PIB + " " + agencija.Naziv + " " + agencija.Datum_Osnivanja + " " + agencija.Sediste);
                    }
                }

                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }

        }

        private void Obrisi_Agencijubutton_Click(object sender, EventArgs e)//moze da brise i agen. manekena koji je i kreator
        {
            int broj_selektovanih = this.listBox1.SelectedItems.Count;
            if (broj_selektovanih == 0)
            {
                MessageBox.Show("Niste selektovali agenciju za brisanje");
                return;
            }
            string z = this.listBox1.SelectedItem.ToString();// vadi ID agencije
            char[] param = { ' ' };
            string[] rez = z.Split(param);
            int p = Convert.ToInt32(rez[0]);
            try
            {
                ISession s = DataLayer.GetSession();
                Fashion_Show.Entiteti.Agencija agencija = s.Load<Fashion_Show.Entiteti.Agencija>(p);

                // da li agencija ima agen manekena koji je i kreator
                //brise agen manekena agencije koji je samo a maneken
               IQuery q = s.CreateQuery("select a.AManekeni from Agencija as a where a.ID  = ? ");
               q.SetInt32(0, p);
               IList<Agencijski_Maneken> amanekeni=q.List<Agencijski_Maneken>();
               IQuery q2=s.CreateQuery("from Kreator");
               IList<Kreator> kreatori=q2.List<Kreator>();

                foreach (Agencijski_Maneken am in amanekeni)
                {
                    foreach (Kreator k in kreatori)
                    {
                        if (am.ID == k.ID)
                        {
                            IQuery q3 = s.CreateQuery("delete from Kreator k where k.ID = ?");
                            q3.SetInt32(0, k.ID);
                            q3.ExecuteUpdate();

                        }
                    }
                }

                bool inter=true;
                if (agencija.GetType() == typeof(Internacionalna_Agencija))
                    inter = true;
                else if (agencija.GetType() == typeof(Domaca_Agencija))
                    inter = false;
                  s.Delete(agencija);
                    s.Flush();
                    s.Close();
                if (inter)
                    this.button2.PerformClick();
                else
                    this.Prikazbutton.PerformClick();
               
                MessageBox.Show("Uspesno brisanje stavke");

            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void DetaljiNastupa_Click(object sender, EventArgs e)// detalji AManekena
        {
            int broj_selektovanih = this.listBox1.SelectedItems.Count;
            if (broj_selektovanih == 0)
            {
                MessageBox.Show("Niste selektovali agenciju!");
                return;
            }
            string z = this.listBox1.SelectedItem.ToString();// vadi ID agencije
            char[] param = { ' ' };
            string[] rez = z.Split(param);
            int p = Convert.ToInt32(rez[0]);
            Form_DetaljiManekeniAgencijecs f = new Form_DetaljiManekeniAgencijecs(p);
            f.ShowDialog();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int broj_selektovanih = this.listBox1.SelectedItems.Count;
            if (broj_selektovanih == 0)
            {
                MessageBox.Show("Niste selektovali agenciju!");
                return;
            }
            string z = this.listBox1.SelectedItem.ToString();// vadi ID agencije
            char[] param = { ' ' };
            string[] rez = z.Split(param);
            int p = Convert.ToInt32(rez[0]);
            Form_Azuriraj_Agenciju f = new Form_Azuriraj_Agenciju(p);
            f.ShowDialog();

        }

       

        
    }
}
