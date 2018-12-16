using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.Linq;
using Fashion_Show.Entiteti;
namespace Fashion_Show
{
    public partial class Form1 : Form
    {
      
        
        public Form1()
        {
            InitializeComponent();
        }

        private void cmdManytoOne_Click(object sender, EventArgs e)//Agencijski_Maneken pripada Agenciji//
        {
            try
            {
               ISession s = DataLayer.GetSession();
               Agencijski_Maneken amaneken = s.Load<Agencijski_Maneken> (7);

               MessageBox.Show(amaneken.Licno_Ime + " " + amaneken.Prezime+ " " +amaneken.Visina + " " +amaneken.Tezina);
               MessageBox.Show(amaneken.PripadaAgeciji.Naziv + " " + amaneken.PripadaAgeciji.Sediste);
                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void cmdOneToMany_Click(object sender, EventArgs e)//Agenciji pripada bar 1 Agencijski_maneken//
        {
            try
            {
                ISession s = DataLayer.GetSession();

                //Ucitavaju se podaci o agenciji sa zadatim brojem
                Fashion_Show.Entiteti.Agencija p = s.Load<Fashion_Show.Entiteti.Agencija>(203);

                foreach (Agencijski_Maneken o in p.AManekeni)
                {
                    MessageBox.Show(o.Licno_Ime + " " + o.Prezime);
                }

                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void cmdRead_Click(object sender, EventArgs e)//ucitavanje podataka o agenciji//
        {
            try
            {
                ISession s = DataLayer.GetSession();

                //Ucitavaju se podaci o agenciji za zadatim brojem
                Fashion_Show.Entiteti.Agencija a = s.Load<Fashion_Show.Entiteti.Agencija>(201);

                MessageBox.Show(a.PIB + " "+ a.Naziv + " " + a.Datum_Osnivanja + " " + a.Sediste + " " +a.Tip);

                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }

        }
        private void button1_Click(object sender, EventArgs e)//ucitavanje modne revije//
        {
            try
            {
                ISession s = DataLayer.GetSession();

                
                Fashion_Show.Entiteti.Modna_Revija m = s.Load<Fashion_Show.Entiteti.Modna_Revija>(3);

                MessageBox.Show(m.Naziv + " " + m.Mesto_Odrzavanja + " " + m.Datum_Vreme_Odrzavanja + " " + m.Tip);

                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }

        }
        private void button2_Click(object sender, EventArgs e)//ucitavanjne agencijskog manekena//
        {
            try
            {
                ISession s = DataLayer.GetSession();


                Fashion_Show.Entiteti.Agencijski_Maneken o = s.Load<Fashion_Show.Entiteti.Agencijski_Maneken>(6);

                MessageBox.Show(o.Maticni_Broj + " " + o.Licno_Ime + " " + o.Prezime + " " + o.Pol + " " + o.Visina + " " + o.Tezina);

                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }

        }
        private void cmdManytoOne2_Click(object sender, EventArgs e)// Zemlja visevrednosi atribut internacionalne agencije //
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Zemlja z = s.Load<Zemlja>(300);

                MessageBox.Show(z.Naziv_Zemlje);
                MessageBox.Show(z.PripadaAgenciji.Naziv + " " + z.PripadaAgenciji.Sediste);

                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void cmdOneToMany2_Click(object sender, EventArgs e)//Internacionalna agencija ima visevrednosni atribut Zemlja//
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Fashion_Show.Entiteti.Internacionalna_Agencija iagencija = s.Load<Fashion_Show.Entiteti.Internacionalna_Agencija>(203);

                foreach (Zemlja z in iagencija.Zemlje)
                {
                    MessageBox.Show(z.Naziv_Zemlje);
                }

                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

       
        private void button3_Click(object sender, EventArgs e)//
        {
            try
            {
                ISession s = DataLayer.GetSession();
                IList<Agencija> agencije = s.QueryOver<Agencija>()
                                                .List<Agencija>();

                foreach (Agencija a in agencije)
                {
                    if (a.GetType() == typeof(Internacionalna_Agencija))
                    {
                        Internacionalna_Agencija ia = (Internacionalna_Agencija)a;
                        MessageBox.Show("Podaci o internacionalnoj agenciji:" + " " + ia.PIB + " " + ia.Naziv + " " + ia.Sediste + " " + ia.Tip);
                    }
                    else if (a.GetType() == typeof(Domaca_Agencija))
                    {
                        Domaca_Agencija da = (Domaca_Agencija)a;
                        MessageBox.Show("Podaci o domacoj agenciji:" + " " + da.PIB + " " + da.Naziv + " " + da.Sediste + " " + da.Tip);
                    }
                }

                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void cmdTPC_Click(object sender, EventArgs e)//Osoba-Kreator//
        {
            try
            {
                ISession s = DataLayer.GetSession();

                IList<Osoba> osobe = s.QueryOver<Osoba>()
                                                .Where(p => p.ID == 1)
                                                .List<Osoba>();
                Kreator k = (Kreator)osobe[0];
                MessageBox.Show(k.Licno_Ime + " " + k.Prezime + " " +  " " + k.Zemlja_Porekla);
                s.Close();

            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

       

        private void cmdCreateAManeken_Click(object sender, EventArgs e)//PIB i Maticni_Broj su UNIQUE//
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Random rnd = new Random();
                int PIB_Agencije = rnd.Next(10000,99999);
                long Mbr1 = 5000000000000 + PIB_Agencije;

                DateTime dd = new DateTime(2010, 3, 6);
               



                //tip je domaca
                Entiteti.Domaca_Agencija da = new Entiteti.Domaca_Agencija()
                {
                    Naziv = "Aleksandrija",
                    PIB= PIB_Agencije,
                    Sediste = "Beograd ",
                    Datum_Osnivanja=dd
                };
                Agencijski_Maneken o = new Agencijski_Maneken()
                {
                   Maticni_Broj=Mbr1,
                   Licno_Ime="Marija",
                   Prezime="Marjanovic",
                   Pol = "Ž",
                   Visina=177,
                   Boja_Kose="seda",
                   Boja_Ociju="braon",
                   Tezina=50,
                   Konfekcijski_Broj=1
                
                };
                Agencijski_Maneken o1 = new Agencijski_Maneken()
                {
                    Maticni_Broj = Mbr1+1,
                    Licno_Ime = "Marko",
                    Prezime = "Marjanovic",
                    Pol = "M",
                    Visina = 192,
                    Boja_Kose = "seda",
                    Boja_Ociju = "braon",
                    Tezina = 84,
                    Konfekcijski_Broj = 8

                };
                

                s.Save(da);

                o.PripadaAgeciji = da;
                s.Save(o);

                o1.PripadaAgeciji = da;
                s.Save(o1);

                da.AManekeni.Add(o);
                da.AManekeni.Add(o1);

                s.Save(da);
                MessageBox.Show("Unos u bazu obavljen!");
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void cmdNastupa_Click(object sender, EventArgs e)//Maneken nastupa na kojim revijama // 
        {
            try
            {
                ISession s = DataLayer.GetSession();


                Maneken m1 = (Maneken)s.Load<Maneken>(6);


                foreach (Entiteti.Nastupa n1 in m1.NastupaModna_Revija)
                {
                    MessageBox.Show(n1.NastupaModna_Revija.Redni_Broj + " " + n1.NastupaModna_Revija.Naziv + " " + n1.NastupaModna_Revija.Mesto_Odrzavanja + " " + n1.NastupaModna_Revija.Tip);
                }

                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }

        }

        private void cmdCreateNastupa_Click(object sender, EventArgs e)//kreiranje NASTUPA//
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Maneken m = s.Load<Maneken>(9);
                Entiteti.Modna_Revija p = s.Load<Entiteti.Modna_Revija>(3);

                Nastupa nastupa= new Nastupa();
                nastupa.NastupaManeken= m;
                nastupa.NastupaModna_Revija = p;
                s.Save(nastupa);

                s.Flush();
                s.Close();
                MessageBox.Show("Unos u bazu obavljen!");
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void cmdCreateSGost_Click(object sender, EventArgs e)//kreiranje specijalnog gosta Maticni_Broj je unique//
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Random rnd = new Random();
                int pomocna = rnd.Next(10000, 99999);
                long Mbr1 = 6000000000000 + pomocna;

                Specijalan_Gost m = new Specijalan_Gost();
                m.Licno_Ime = "Mina";
                m.Prezime = "Petrovic";
                m.Pol = "Ž";
                m.Maticni_Broj = Mbr1;
                m.Boja_Kose = "plava";
                m.Boja_Ociju = "zelena";
                m.Visina = 165;
                m.Tezina = 55;
                m.Konfekcijski_Broj = 3;
                m.Zanimanje = "pisac";

                s.Save(m);

                s.Close();
                MessageBox.Show("Unos u bazu obavljen!");
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }

        }

        private void cmdCreateSubclassModnaRevija_Click(object sender, EventArgs e)//podklasa Modna Revija
        {
            try
            {
                ISession s = DataLayer.GetSession();


                DateTime dd = new DateTime(2016, 5, 20);
                

                //kolona TIP automatski dobija vrednost jedan i Ranije_Nastupali_Zajedno null
                Modna_Revija_Sa_Jednim_Kreatorom m1 = new Modna_Revija_Sa_Jednim_Kreatorom()
                {
                    Naziv = "Famous",
                    Mesto_Odrzavanja = "Milano",
                    Datum_Vreme_Odrzavanja=dd

                };

                s.Save(m1);

                s.Close();
                MessageBox.Show("Unos u bazu obavljen!");

            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            } 
        }

        private void cmdCreateSubclassAgencija_Click(object sender, EventArgs e)//kreiranje domace
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Random rnd = new Random();
                int PIB_Agencije = rnd.Next(10000, 99999);

                DateTime dd = new DateTime(2005, 7, 18);
              
                //kolona TIP automatski dobija vrednost domaca
                Domaca_Agencija da = new Domaca_Agencija()
                {
                    PIB= PIB_Agencije,
                    Naziv= "Milenijum",
                    Sediste= "Kragujevac",
                    Datum_Osnivanja=dd

                };
               
                s.Save(da);

                s.Close();
                MessageBox.Show("Unos u bazu obavljen!");

            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void cmdCreateZemlja_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Random rnd = new Random();
                int PIB_Agencije = rnd.Next(10000, 99999);

                //tip je internacionalna
                Entiteti.Internacionalna_Agencija ia = new Entiteti.Internacionalna_Agencija()
                {
                    Naziv = "MQI",
                    PIB = PIB_Agencije,
                    Sediste = "Moskva "
                };
                Zemlja o = new Zemlja()
                {
                    Naziv_Zemlje= "Japan"

                };
                Zemlja o1 = new Zemlja()
                {
                    Naziv_Zemlje="Argentina"

                };

                s.Save(ia);

                o.PripadaAgenciji = ia;
                s.Save(o);

                o1.PripadaAgenciji = ia;
                s.Save(o1);

                ia.Zemlje.Add(o);
                ia.Zemlje.Add(o1); 

                s.Save(ia);
                MessageBox.Show("Unos u bazu obavljen!");
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

       

      

    }
}
