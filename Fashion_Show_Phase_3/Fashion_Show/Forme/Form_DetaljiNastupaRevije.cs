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
    public partial class Form_DetaljiNastupaRevije : Form
    {
        int ID_Modne_Revije;
        public Form_DetaljiNastupaRevije()
        {
            InitializeComponent();
        }
        public Form_DetaljiNastupaRevije(int ID)
        {
            InitializeComponent();
            this.ID_Modne_Revije = ID;
            try
            {
                ISession s = DataLayer.GetSession();
                Modna_Revija m = s.Load<Modna_Revija>(ID_Modne_Revije);
                this.label1.Text = "Modna revija: " + m.Naziv + " " + m.Mesto_Odrzavanja;
                IQuery q = s.CreateQuery("select m.NastupaManekeni from Modna_Revija as m where m.Redni_Broj  = ? ");
                q.SetInt32(0, ID);
                IList<Nastupa> akc = q.List<Nastupa>();

                foreach (Nastupa n in akc)
                {
                    this.listBox1.Items.Add(n.NastupaManeken.ID + "   " + n.NastupaManeken.Licno_Ime + "   " + n.NastupaManeken.Prezime);
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

        
    }
}
