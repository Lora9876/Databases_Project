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
    public partial class Form_Osoba : Form
    {
        public Form_Osoba()
        {
            InitializeComponent();
        }

        private void Prikazbutton_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                IList<Osoba> ucesnici = (from o in s.Query<Osoba>() orderby o.ID select o).ToList<Osoba>();

                listBox1.Items.Clear();
                foreach (Osoba osoba in ucesnici)
                {
                        this.listBox1.Items.Add(osoba.ID + " " + osoba.Licno_Ime + " " + osoba.Prezime + " " + osoba.Pol);
                    
                }

                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }

        }

    }
}
