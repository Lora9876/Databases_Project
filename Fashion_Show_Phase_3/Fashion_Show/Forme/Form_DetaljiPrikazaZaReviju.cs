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
    public partial class Form_DetaljiPrikazaZaReviju : Form
    {
        int ID_Modne_Revije;
        public Form_DetaljiPrikazaZaReviju()
        {
            InitializeComponent();
        }
        public Form_DetaljiPrikazaZaReviju(int ID)
        {
            InitializeComponent();
            this.ID_Modne_Revije = ID;
            this.prikazi();
        }
        private void prikazi()
        {
            try
            {

                ISession s = DataLayer.GetSession();
                Modna_Revija m = s.Load<Modna_Revija>(ID_Modne_Revije);
                this.label1.Text = "Modna revija: " + m.Naziv + " " + m.Mesto_Odrzavanja;
                IQuery q = s.CreateQuery("select m.Prikazuje_NaKreator from Modna_Revija as m where m.Redni_Broj  = ? ");
                q.SetInt32(0, ID_Modne_Revije);
                IList<Prikazuje_Na> akc = q.List<Prikazuje_Na>();

                this.listBox1.Items.Clear();
                foreach (Prikazuje_Na p in akc)
                {
                    this.listBox1.Items.Add(p.PrikazujeKreator.ID + "   " + p.PrikazujeKreator.Licno_Ime + "   " + p.PrikazujeKreator.Prezime);
                }

                this.listBox2.Items.Clear();
                IQuery q2 = s.CreateQuery("from Kreator ");
                IList<Kreator> Svi_Kreatori = q2.List<Kreator>();
                foreach (Kreator k in Svi_Kreatori)
                {
                    this.listBox2.Items.Add(k.ID + "   " + k.Licno_Ime + "   " + k.Prezime);

                }
                s.Flush();
                s.Close();
                listBox1.Update();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
            
        }


        private void Obrisibutton_Click(object sender, EventArgs e)//obrisi da selektovani kreator prikazuje na reviji
        {

            int broj_selektovanih1 = this.listBox1.SelectedItems.Count;
            if (broj_selektovanih1 == 0)
            {
                MessageBox.Show("Niste selektovali koga kreatora ne zelite vise da prikazuje na reviji");
                return;
            }
            string z1 = this.listBox1.SelectedItem.ToString();
            char[] param1 = { ' ' };
            string[] rez1 = z1.Split(param1);
            int p1 = Convert.ToInt32(rez1[0]);
            try
            {
                ISession s = DataLayer.GetSession();
                //IQuery q = s.CreateQuery("select m.Prikazuje_NaKreator from Modna_Revija as m where m.Redni_Broj  = ? and m.Prikazuje_NaKreator.PrikazujeKreator.ID = ?");
                List<Prikazuje_Na> p = (from prikaz in s.Query<Prikazuje_Na>() join revija in s.Query<Modna_Revija>() on prikaz.PrikazujeModna_Revija equals revija join kreator in s.Query<Kreator>() on prikaz.PrikazujeKreator equals kreator where (revija.Redni_Broj == ID_Modne_Revije && kreator.ID == p1) select prikaz).ToList<Prikazuje_Na>();
                Kreator kr = s.Load<Kreator>(p1);
                Modna_Revija mrevija = s.Load<Modna_Revija>(ID_Modne_Revije);
                kr.Prikazuje_NaMRevija.Remove(p[0]);
                mrevija.Prikazuje_NaKreator.Remove(p[0]);
                s.Delete(p[0]);
                s.Flush();
                s.Close();
                MessageBox.Show("Uspesno brisanje prikaza");
                this.prikazi();
          
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void Dodajbutton_Click(object sender, EventArgs e)
        {
            int broj_selektovanih = this.listBox2.SelectedItems.Count;
            if (broj_selektovanih == 0)
            {
                MessageBox.Show("Niste selektovali kreatora!");
                return;
            }
            string z = this.listBox2.SelectedItem.ToString();
            char[] param = { ' ' };
            string[] rez = z.Split(param);
            int p = Convert.ToInt32(rez[0]);
            try
            {
                ISession s = DataLayer.GetSession();
                Modna_Revija mrevija = s.Load<Modna_Revija>(this.ID_Modne_Revije);
                //provera da li je sa 1 kreatorom-moze prikazivati samo 1 kreator
                IList<Modna_Revija_Sa_Jednim_Kreatorom> ucesnici = (from m in s.Query<Modna_Revija_Sa_Jednim_Kreatorom>() where (m.Redni_Broj == this.ID_Modne_Revije) select m).ToList<Modna_Revija_Sa_Jednim_Kreatorom>();
                if (ucesnici.Count()==1)
                {
                    if ((ucesnici[0].Prikazuje_NaKreator.Count() == 1))
                    {
                        MessageBox.Show("U pitanju je modna revija sa jednim kreatorom i vec 1 prikazuje svoje kreacije na njoj!");
                        return;
                    }
                }
                Kreator kreator = s.Load<Kreator>(p);//selektovani kreator iz listBox2
                IList<Prikazuje_Na> svi_prikazi_revije = mrevija.Prikazuje_NaKreator;
                foreach (Prikazuje_Na pri in svi_prikazi_revije)
                {
                    if (pri.PrikazujeKreator == kreator)
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
                MessageBox.Show("Dodat je prikaz");
                this.prikazi();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }

        }

        

    }
}
