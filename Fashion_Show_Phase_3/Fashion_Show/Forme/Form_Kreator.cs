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
    public partial class Form_Kreator : Form
    {
        public Form_Kreator()
        {
            InitializeComponent();
        }

        private void Prikazbutton_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                if (this.radioButton1.Checked == true)//svi kreatori
                {
                    IQuery q = s.CreateQuery("select k.ID, k.Maticni_Broj, k.Licno_Ime, k.Prezime, k.Zemlja_Porekla from Kreator k");
                    IList<object[]> result = q.List<object[]>();

                    listBox1.Items.Clear();
                    foreach (object[] r in result)
                    {
                        int id = (int)r[0];
                        long mbr = (long)r[1];
                        string ime = (string)r[2];
                        string prezime = (string)r[3];
                        string zemlja = (string)r[4];

                        this.listBox1.Items.Add(id.ToString() + " " + mbr.ToString() + " " + ime + " " + prezime + " " + zemlja);

                    }
                }
                else if ( this.radioButton2.Checked == true)//kreatori koji su i specijalni gosti
                {
                    IList<Kreator> kreatori = (from kreator in s.Query<Kreator>() join sp in s.Query<Specijalan_Gost>() on kreator.ID equals sp.ID select kreator).ToList<Kreator>();
                    listBox1.Items.Clear();
                    foreach (Kreator k in kreatori)
                    {
                        this.listBox1.Items.Add(k.ID + " " + k.Maticni_Broj + " " + k.Licno_Ime + " " + k.Prezime + " " + k.Zemlja_Porekla);
                    }
                }
                else if (this.radioButton3.Checked == true)//kreatori koji su i agencijski manekeni
                {
                    IList<Kreator> kreatori = (from kreator in s.Query<Kreator>() join sp in s.Query<Agencijski_Maneken>() on kreator.ID  equals sp.ID select kreator).ToList<Kreator>();
                    listBox1.Items.Clear();
                    foreach (Kreator k in kreatori)
                    {
                        this.listBox1.Items.Add(k.ID + " " + k.Maticni_Broj + " " + k.Licno_Ime + " " + k.Prezime + " " + k.Zemlja_Porekla);
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
                MessageBox.Show("Niste selektovali kreatora za brisanje");
                return;
            }
            string z = this.listBox1.SelectedItem.ToString();
            char[] param = { ' ' };
            string[] rez = z.Split(param);
            int p = Convert.ToInt32(rez[0]);
            try
            {
                ISession s = DataLayer.GetSession();
                Fashion_Show.Entiteti.Kreator ucesnik = s.Load<Fashion_Show.Entiteti.Kreator>(p);
                IList<Specijalan_Gost> sgosti = (from sgost in s.Query<Specijalan_Gost>() join k in s.Query<Kreator>() on sgost.ID equals k.ID select sgost).ToList<Specijalan_Gost>();
                foreach(Specijalan_Gost sg in sgosti)
                {
                    if (sg.ID==p)
                    {
                        MessageBox.Show("Izabrali ste da brisete kreatora koji je i specijalan gost.");
                        s.Delete(sg);// ovim se brise specijalan i exception ide
                        s.Flush();
                        MessageBox.Show("Ovim se izbrisao specijalan gost i sve vezano za njega .");
                    }
                }
               

                s.Delete(ucesnik);
                s.Flush();
                s.Close();
                MessageBox.Show("Uspesno brisanje stavke");
                this.Prikazbutton.PerformClick();

            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }


        private void Kreiraj_Click(object sender, EventArgs e)// Kreiranje kreatora
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Kreator k=new Kreator();
                k.Maticni_Broj=Convert.ToInt64(this.textBox2.Text);
                k.Licno_Ime=this.textBox3.Text;
                k.Prezime=this.textBox4.Text;
                k.Datum_Rodjenja=Convert.ToDateTime(this.textBox5.Text);
                k.Pol=this.textBox1.Text;
                k.Zemlja_Porekla=this.textBox6.Text;
                k.Naziv_Modne_Kuce=this.textBox7.Text;
                s.Save(k);
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

        private void Azurirajbutton_Click(object sender, EventArgs e)//Azuriranje Kreatora
        {
            int broj_selektovanih = this.listBox1.SelectedItems.Count;
            if (broj_selektovanih == 0)
            {
                MessageBox.Show("Niste selektovali kreatora.");
                return;
            }
            string z = this.listBox1.SelectedItem.ToString();
            char[] param = { ' ' };
            string[] rez = z.Split(param);
            int p = Convert.ToInt32(rez[0]);

            Form_AzurirajKreatora f = new Form_AzurirajKreatora(p);
            f.ShowDialog();

        }

        private void DetaljiPrikaza_Click(object sender, EventArgs e)//na kojim revijama kreator prikazuje
        {
            int broj_selektovanih = this.listBox1.SelectedItems.Count;
            if (broj_selektovanih == 0)
            {
                MessageBox.Show("Niste selektovali kreatora.");
                return;
            }
            string z = this.listBox1.SelectedItem.ToString();// vadi ID agencije
            char[] param = { ' ' };
            string[] rez = z.Split(param);
            int p = Convert.ToInt32(rez[0]);
            Form_DetaljiPrikazaZaKreatora f = new Form_DetaljiPrikazaZaKreatora(p);
            f.Show();
        }

     

       
    }
}
