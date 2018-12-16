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
    public partial class Form_DetaljiManekeniAgencijecs : Form
    {
        int ID_Agencije;
        public Form_DetaljiManekeniAgencijecs()
        {
            InitializeComponent();
        }
        public Form_DetaljiManekeniAgencijecs(int ID)
        {
            InitializeComponent();
            this.ID_Agencije = ID;
            try
            {
                ISession s = DataLayer.GetSession();
                Agencija m = s.Load<Agencija>(ID_Agencije);
                this.label1.Text = "Agencija: " + m.Naziv + " " + m.Sediste + " " + m.Tip;
                IQuery q = s.CreateQuery("select m.AManekeni from Agencija as m where m.ID  = ? ");
                q.SetInt32(0, ID);
                IList<Agencijski_Maneken> akc = q.List<Agencijski_Maneken>();

                foreach (Agencijski_Maneken a in akc)
                {
                    this.listBox1.Items.Add(a.ID + " " +a.Licno_Ime+ " " + a.Prezime + " " + a.Visina + " " + a.Tezina);
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
