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
    public partial class Form_Modna_Revija : Form
    {
        public Form_Modna_Revija()
        {
            InitializeComponent();
        }

        private void Kreiraj_Modnu_Revijubutton_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                if (Jedan_Kreator.Checked == true)
                {
                    Modna_Revija_Sa_Jednim_Kreatorom mkreator = new Modna_Revija_Sa_Jednim_Kreatorom();
                    mkreator.Naziv = this.textBox2.Text;
                    mkreator.Mesto_Odrzavanja = this.textBox3.Text;
                    mkreator.Datum_Vreme_Odrzavanja = Convert.ToDateTime(this.textBox4.Text);
                    s.Save(mkreator);
                    s.Flush();
                    s.Close();
                    MessageBox.Show("Stavka uspesno dodata");
                    this.Prikazbutton.PerformClick();
                   
                }
                else if (Vise_Kreatora.Checked == true)
                {
                    if (this.DaradioButton.Checked == false && this.NeradioButton.Checked == false)
                    {
                        MessageBox.Show("Niste izabrali da li su ranije kreatori nastupali");
                        return;
                    }
                    Modna_Revija_Sa_Vise_Kreatora mkreator = new Modna_Revija_Sa_Vise_Kreatora();
                    mkreator.Naziv = this.textBox2.Text;
                    mkreator.Mesto_Odrzavanja = this.textBox3.Text;
                    mkreator.Datum_Vreme_Odrzavanja = Convert.ToDateTime(this.textBox4.Text);
                    if (this.DaradioButton.Checked)
                    {
                        mkreator.Ranije_Nastupali_Zajedno ="da";
                    }
                    else if (this.NeradioButton.Checked)
                        mkreator.Ranije_Nastupali_Zajedno ="ne";

                    s.Save(mkreator);
                    s.Flush();
                    s.Close();
                    MessageBox.Show("Stavka uspesno dodata");
                    this.Prikazbutton.PerformClick();
                }
                else
                {
                    MessageBox.Show("Niste pravilno izabrali tip modne revije!");
                    return;
                }

            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }


        }

        private void Jedan_Kreator_CheckedChanged(object sender, EventArgs e)
        {
            if (Jedan_Kreator.Checked == true)
            {
                groupBox3.Visible = false;
              
            }

        }

        private void Vise_Kreatora_CheckedChanged(object sender, EventArgs e)
        {
            if(Vise_Kreatora.Checked==true)
            {
                  groupBox3.Visible = true;
                 
            }
            else
                groupBox3.Visible = false;
                
        }

        private void Obrisi_Modnu_Revijubutton_Click(object sender, EventArgs e) //brise i Prikazuje_Na i Nastupa
        {
            int broj_selektovanih = this.listBox1.SelectedItems.Count;
            if (broj_selektovanih == 0)
            {
                MessageBox.Show("Niste selektovali reviju za brisanje");
                return;
            }
            string z = this.listBox1.SelectedItem.ToString();// vadi redni broj revije
            char[] param = { ' ' };
            string[] rez = z.Split(param);
            int p = Convert.ToInt32(rez[0]);
            try
            {
                ISession s = DataLayer.GetSession();
                Fashion_Show.Entiteti.Modna_Revija ucesnik = s.Load<Fashion_Show.Entiteti.Modna_Revija>(p);
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

        public void Prikazbutton_Click(object sender, EventArgs e)//Lista Modnih Revija
        {
            try
            {
                ISession s = DataLayer.GetSession();

                IList<Modna_Revija> ucesnici = (from m in s.Query<Modna_Revija>() orderby m.Redni_Broj select m).ToList<Modna_Revija>();
                listBox1.Items.Clear();
                foreach (Modna_Revija u in ucesnici)
                {
                        if (u.GetType() == typeof(Modna_Revija_Sa_Jednim_Kreatorom))
                        {
                            Modna_Revija_Sa_Jednim_Kreatorom ujedan = (Modna_Revija_Sa_Jednim_Kreatorom)u;
                            this.listBox1.Items.Add(ujedan.Redni_Broj + " " + ujedan.Naziv + " " + ujedan.Mesto_Odrzavanja+ " " + ujedan.Datum_Vreme_Odrzavanja);
                        }
                        else if (u.GetType() == typeof(Modna_Revija_Sa_Vise_Kreatora))
                        {
                            Modna_Revija_Sa_Vise_Kreatora uvise = (Modna_Revija_Sa_Vise_Kreatora)u;
                            this.listBox1.Items.Add(uvise.Redni_Broj + " " + uvise.Naziv + " " + uvise.Mesto_Odrzavanja + " " + uvise.Datum_Vreme_Odrzavanja + " nastupali ranije: " + uvise.Ranije_Nastupali_Zajedno);
                            
                        }
                }


                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }

        }

        private void button1_Click(object sender, EventArgs e) //Azuriranje selektovane stavke
        {
            int broj_selektovanih = this.listBox1.SelectedItems.Count;
            if (broj_selektovanih == 0)
            {
                MessageBox.Show("Niste selektovali reviju za azuriranje");
                return;
            }
            string z = this.listBox1.SelectedItem.ToString();
            char[] param = { ' ' };
            string[] rez = z.Split(param);
            int p = Convert.ToInt32(rez[0]);
            try
            {
                ISession s = DataLayer.GetSession();
                IQuery q = s.CreateQuery("select m from Modna_Revija m where m.Redni_Broj = ? ");
                q.SetInt32(0,p);
                Modna_Revija mrevija = q.UniqueResult<Modna_Revija>();
                bool jedan=true;
               // if (ucesnik.Tip == "jedan")//ali tip nije mapiran
                if (mrevija.GetType() == typeof(Modna_Revija_Sa_Jednim_Kreatorom))
                    jedan = true;
                else if (mrevija.GetType() == typeof(Modna_Revija_Sa_Vise_Kreatora))
                    jedan = false;
                Form_Azuriraj_Modnu_Reviju am = new Form_Azuriraj_Modnu_Reviju(p,jedan);
                am.ShowDialog();
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
                MessageBox.Show("Niste selektovali reviju!");
                return;
            }
            string z = this.listBox1.SelectedItem.ToString();
            char[] param = { ' ' };
            string[] rez = z.Split(param);
            int p = Convert.ToInt32(rez[0]);

            Form_DetaljiNastupaRevije child = new Form_DetaljiNastupaRevije(p);
            child.ShowDialog();
        }

        private void DetaljiPrikaza_Click(object sender, EventArgs e)
        {
            int broj_selektovanih = this.listBox1.SelectedItems.Count;
            if (broj_selektovanih == 0)
            {
                MessageBox.Show("Niste selektovali reviju!");
                return;
            }
            string z = this.listBox1.SelectedItem.ToString();
            char[] param = { ' ' };
            string[] rez = z.Split(param);
            int p = Convert.ToInt32(rez[0]);

            Form_DetaljiPrikazaZaReviju child = new Form_DetaljiPrikazaZaReviju(p);
            child.ShowDialog();

        }

      
       
       
    }
}
