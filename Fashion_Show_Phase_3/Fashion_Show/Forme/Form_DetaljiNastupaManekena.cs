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

namespace Fashion_Show.Forme
{
    public partial class Form_DetaljiNastupaManekena : Form
    {
        int ID_Manekena;
        public Form_DetaljiNastupaManekena()
        {
            InitializeComponent();
        }
        public Form_DetaljiNastupaManekena(int ID)
        {
            InitializeComponent();
            this.ID_Manekena = ID;
            try
            {
                ISession s = DataLayer.GetSession();
                Maneken m = s.Load<Maneken>(ID_Manekena);
                this.label1.Text = "Maneken: " + m.Licno_Ime + " " + m.Prezime;
                IQuery q = s.CreateQuery("select m.NastupaModna_Revija from Maneken as m where m.ID  = ? ");
                q.SetInt32(0, ID_Manekena);//svi nastupi ovog manekena
                IList<Nastupa> akc = q.List<Nastupa>();

                foreach (Nastupa n in akc)
                {
                    this.listBox1.Items.Add(n.NastupaModna_Revija.Redni_Broj + "   " + n.NastupaModna_Revija.Naziv + "   " + n.NastupaModna_Revija.Mesto_Odrzavanja);
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
