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

namespace Fashion_Show.Forme
{
    public partial class Form_DetaljiPrikazaZaKreatora : Form
    {
        int ID_Kreatora;
        public Form_DetaljiPrikazaZaKreatora()
        {
            InitializeComponent();
        }
        public Form_DetaljiPrikazaZaKreatora(int ID)
        {
            InitializeComponent();
            this.ID_Kreatora = ID;
            try
            {
                ISession s = DataLayer.GetSession();
                Fashion_Show.Entiteti.Kreator k = s.Load<Fashion_Show.Entiteti.Kreator>(ID_Kreatora);
                this.label1.Text = "Kreator: " + k.Licno_Ime + " " + k.Prezime;
                IQuery q = s.CreateQuery("select k.Prikazuje_NaMRevija from Kreator as k where k.ID  = ? ");
                q.SetInt32(0, ID_Kreatora);
                IList<Prikazuje_Na> akc = q.List<Prikazuje_Na>();

                foreach (Prikazuje_Na p in akc)
                {
                    this.listBox1.Items.Add(p.PrikazujeModna_Revija.Redni_Broj + "   " + p.PrikazujeModna_Revija.Naziv+ "   " + p.PrikazujeModna_Revija.Mesto_Odrzavanja);
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
