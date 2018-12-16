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
    public partial class Form_Nastupa : Form
    {
        private IList<Nastupa> nastupi;

        public Form_Nastupa()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.listBox1.Items.Clear();
            ISession s = DataLayer.GetSession();
            try
            {
                IQuery q = s.CreateQuery("from Nastupa");
                this.nastupi = q.List<Nastupa>();
                foreach (Nastupa n in nastupi)
                {
                    this.listBox1.Items.Add( n.ID_Nastupa + " " + n.NastupaManeken.Licno_Ime
                        + " " + n.NastupaManeken.Prezime + " " + n.NastupaModna_Revija.Naziv + " " + n.NastupaModna_Revija.Mesto_Odrzavanja);
                }
                s.Close();

            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void bDodaj_Click(object sender, EventArgs e)
        {
            Form_Dodaj_Nastupa fd = new Form_Dodaj_Nastupa();
            fd.Show();

        }

        private void bObrisi_Click(object sender, EventArgs e)
        {
            int broj_selektovanih1 = this.listBox1.SelectedItems.Count;
            if (broj_selektovanih1 == 0)
            {
                MessageBox.Show("Niste selektovali nastup koji zelite da brisete!");
                return;
            }
            string z1 = this.listBox1.SelectedItem.ToString();
            char[] param1 = { ' ' };
            string[] rez1 = z1.Split(param1);
            int p1 = Convert.ToInt32(rez1[0]);
            try
            {
                ISession s = DataLayer.GetSession();
                Nastupa nastup = s.Load<Nastupa>(p1);// da li ce to da smakne i nastupe ovih?

                s.Delete(nastup);
                s.Flush();
                s.Close();
                MessageBox.Show("Uspesno brisanje stavke");
                this.button1.PerformClick();

            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }
    }
}
