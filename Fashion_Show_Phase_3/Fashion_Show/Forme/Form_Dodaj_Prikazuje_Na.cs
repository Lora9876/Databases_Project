using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NHibernate;
using Fashion_Show;
using Fashion_Show.Entiteti;
using NHibernate.Linq;

namespace Fashion_Show.Forme
{
    public partial class Form_Dodaj_Prikazuje_Na : Form
    {
        public Form_Dodaj_Prikazuje_Na()
        {
            InitializeComponent();
            try
            {
                ISession s = DataLayer.GetSession();
                IQuery q1 = s.CreateQuery("from Modna_Revija ");
                IList<Modna_Revija> revije = q1.List<Modna_Revija>();
                IQuery q2 = s.CreateQuery("from Kreator ");
                IList<Kreator> kreatori = q2.List<Kreator>();

                foreach (Modna_Revija m in revije)
                {
                    this.listBox1.Items.Add(m.Redni_Broj + " " + m.Naziv + " " + m.Mesto_Odrzavanja);
                }

                foreach (Kreator k in kreatori)
                {
                    this.listBox2.Items.Add(k.ID + " " + k.Licno_Ime + " " + k.Prezime);
                }

                s.Close();

            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
            
        }

        private void button3_Click(object sender, EventArgs e)//dodavanje Prikaza
        {
            int broj_selektovanih1 = this.listBox1.SelectedItems.Count;
            if (broj_selektovanih1 == 0)
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
                MessageBox.Show("Niste selektovali kreatora");
                return;
            }
            string z2 = this.listBox2.SelectedItem.ToString();
            char[] param2 = { ' ' };
            string[] rez2 = z2.Split(param2);
            int p2 = Convert.ToInt32(rez2[0]);
            try
            {
                ISession s = DataLayer.GetSession();
                Modna_Revija mrevija = s.Load<Modna_Revija>(p1);
                Kreator kreator = s.Load<Kreator>(p2);

                //provera da li je sa 1 kreatorom-moze prikazivati samo 1 kreator
                IList<Modna_Revija_Sa_Jednim_Kreatorom> ucesnici = (from m in s.Query<Modna_Revija_Sa_Jednim_Kreatorom>() where (m.Redni_Broj == p1) select m).ToList<Modna_Revija_Sa_Jednim_Kreatorom>();
                if (ucesnici.Count()==1)
                {
                    if ((ucesnici[0].Prikazuje_NaKreator.Count() == 1))
                    {
                        MessageBox.Show("U pitanju je modna revija sa jednim kreatorom i vec 1 prikazuje svoje kreacije na njoj!");
                        return;
                    }
                }
                IList<Prikazuje_Na> svi_prikazi_revije=mrevija.Prikazuje_NaKreator;
                foreach (Prikazuje_Na p in svi_prikazi_revije)
                {
                    if (p.PrikazujeKreator == kreator)
                    {
                        MessageBox.Show("U pitanju su modna_revija i kreator tako da taj kreator vec prikazuje na toj reviji!");
                        return;

                    }
                }
                Prikazuje_Na prikazuje= new Prikazuje_Na();
                prikazuje.PrikazujeModna_Revija = mrevija;
                prikazuje.PrikazujeKreator = kreator;
                s.Save(prikazuje);
                mrevija.Prikazuje_NaKreator.Add(prikazuje);
                kreator.Prikazuje_NaMRevija.Add(prikazuje);
                s.SaveOrUpdate(mrevija);
                s.SaveOrUpdate(kreator);
                s.Flush();
                s.Close();
                MessageBox.Show("Dodat je prikaz idite na pregled svih prikaza za refresh!");
                Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }

        }
    }
}
