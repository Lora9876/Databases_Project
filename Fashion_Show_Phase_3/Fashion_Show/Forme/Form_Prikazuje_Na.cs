using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NHibernate;
using NHibernate.Linq;
using Fashion_Show.Entiteti;

namespace Fashion_Show.Forme
{
    public partial class Form_Prikazuje_Na : Form
    {
        public Form_Prikazuje_Na()
        {
            InitializeComponent();
        }

        private void bPrikazi_Click(object sender, EventArgs e)
        {
            this.listBox1.Items.Clear();
            ISession s = DataLayer.GetSession();
            try
            {
                IQuery q = s.CreateQuery("from Prikazuje_Na");
                IList<Prikazuje_Na> prikazi = q.List<Prikazuje_Na>();
                foreach (Prikazuje_Na p in prikazi)
                {
                    this.listBox1.Items.Add(p.ID_Prikazuje + " " + p.PrikazujeKreator.Licno_Ime + " " + p.PrikazujeKreator.Prezime
                        + " "+ p.PrikazujeModna_Revija.Naziv + " " + p.PrikazujeModna_Revija.Mesto_Odrzavanja);
                }
                s.Close();

            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void bObrisi_Click(object sender, EventArgs e)
        {
            int broj_selektovanih1 = this.listBox1.SelectedItems.Count;
            if (broj_selektovanih1 == 0)
            {
                MessageBox.Show("Niste selektovali prikaz koji zelite da brisete!");
                return;
            }
            string z1 = this.listBox1.SelectedItem.ToString();
            char[] param1 = { ' ' };
            string[] rez1 = z1.Split(param1);
            int p1 = Convert.ToInt32(rez1[0]);
            try
            {
                ISession s = DataLayer.GetSession();
                Prikazuje_Na prikaz = s.Load<Prikazuje_Na>(p1);

                s.Delete(prikaz);
                s.Flush();
                s.Close();
                MessageBox.Show("Uspesno brisanje stavke");
                this.bPrikazi.PerformClick();

            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void bDodaj_Click(object sender, EventArgs e)
        {
            Form_Dodaj_Prikazuje_Na fd = new Form_Dodaj_Prikazuje_Na();
            fd.Show();
        }
    }
}
