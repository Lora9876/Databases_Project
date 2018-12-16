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
    public partial class Form_Specijalan_Gost : Form
    {
        public Form_Specijalan_Gost()
        {
            InitializeComponent();
        }

        private void Obrisi_Click(object sender, EventArgs e)
        {
            int broj_selektovanih = this.listBox1.SelectedItems.Count;
            if (broj_selektovanih == 0)
            {
                MessageBox.Show("Niste selektovali specijalnog gosta za brisanje");
                return;
            }
            string z = this.listBox1.SelectedItem.ToString();
            char[] param = { ' ' };
            string[] rez = z.Split(param);
            int p = Convert.ToInt32(rez[0]);
            try
            {
                ISession s = DataLayer.GetSession();
                Fashion_Show.Entiteti.Specijalan_Gost ucesnik = s.Load<Fashion_Show.Entiteti.Specijalan_Gost>(p);
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

        private void Prikazbutton_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                if (this.radioButton1.Checked == true)//svi specijalni gosti
                {
                    IQuery q = s.CreateQuery("select a.ID, a.Maticni_Broj, a.Licno_Ime, a.Prezime, a.Visina, a.Tezina, a.Zanimanje from Specijalan_Gost a");
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
                        string zanimanje = (string)r[6];

                        this.listBox1.Items.Add(id.ToString() + " " + mbr.ToString() + " " + ime + " " + prezime + " " + visina + " " + tezina + " " + zanimanje);

                    }
                }
                else if (this.radioButton2.Checked == true)//specijalni gosti koji su i kreatori
                {
                    listBox1.Items.Clear();
                    IList<Specijalan_Gost> sgosti = (from sgost in s.Query<Specijalan_Gost>() join k in s.Query<Kreator>() on sgost.ID equals k.ID select sgost).ToList<Specijalan_Gost>();
                    listBox1.Items.Clear();
                    foreach (Specijalan_Gost sg in sgosti)
                    {
                        this.listBox1.Items.Add(sg.ID + " " + sg.Maticni_Broj + " " + sg.Licno_Ime + " " + sg.Prezime + " " + sg.Visina + " " + sg.Tezina + " " + sg.Zanimanje);
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

        private void Casopisibutton_Click(object sender, EventArgs e)
        {
            int broj_selektovanih = this.listBox1.SelectedItems.Count;
            if (broj_selektovanih == 0)
            {
                MessageBox.Show("Niste selektovali specijalnog gosta!");
                return;
            }
            string z = this.listBox1.SelectedItem.ToString();
            char[] param = { ' ' };
            string[] rez = z.Split(param);
            int p = Convert.ToInt32(rez[0]);
            Form_CasopisiManekena fc = new Form_CasopisiManekena(p);
            fc.ShowDialog();
        }

        private void Kreirajbutton_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Specijalan_Gost sgost = new Specijalan_Gost();
                sgost.Maticni_Broj = Convert.ToInt64(this.textBox2.Text);
                sgost.Licno_Ime = this.textBox3.Text;
                sgost.Prezime = this.textBox4.Text;
                sgost.Datum_Rodjenja = Convert.ToDateTime(this.textBox5.Text);
                sgost.Pol = this.textBox1.Text;
                sgost.Boja_Kose = this.textBox6.Text;
                sgost.Boja_Ociju = this.textBox7.Text;
                sgost.Visina = Convert.ToInt32(this.textBox8.Text);
                sgost.Tezina = Convert.ToInt32(this.textBox9.Text);
                sgost.Konfekcijski_Broj = Convert.ToInt32(this.textBox10.Text);
                sgost.Zanimanje = this.textBox11.Text;
                s.Save(sgost);
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
        private void DetaljiNastupa_Click(object sender, EventArgs e)
        {
            int broj_selektovanih = this.listBox1.SelectedItems.Count;
            if (broj_selektovanih == 0)
            {
                MessageBox.Show("Niste selektovali specijalnog gosta!");
                return;
            }
            string z = this.listBox1.SelectedItem.ToString();
            char[] param = { ' ' };
            string[] rez = z.Split(param);
            int p = Convert.ToInt32(rez[0]);

            Form_DetaljiNastupaManekena child = new Form_DetaljiNastupaManekena(p);
            child.ShowDialog();

        }

        private void button3_Click(object sender, EventArgs e)//Azuriraj specijalnog gosta
        {
            int broj_selektovanih = this.listBox1.SelectedItems.Count;
            if (broj_selektovanih == 0)
            {
                MessageBox.Show("Niste selektovali specijalnog gosta!");
                return;
            }
            string z = this.listBox1.SelectedItem.ToString();
            char[] param = { ' ' };
            string[] rez = z.Split(param);
            int p = Convert.ToInt32(rez[0]);
            Form_AzurirajSpecijalnogGosta fa = new Form_AzurirajSpecijalnogGosta(p);
            fa.ShowDialog();

        }
    }
}
