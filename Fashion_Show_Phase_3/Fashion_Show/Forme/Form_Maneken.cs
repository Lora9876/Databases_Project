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
using Fashion_Show;
using Fashion_Show.Entiteti;

namespace Fashion_Show.Forme
{
    public partial class Form_Maneken : Form
    {
        public Form_Maneken()
        {
            InitializeComponent();
        }

        private void Prikazbutton_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                IList<Maneken> ucesnici = (from m in s.Query<Maneken>() orderby m.ID select m).ToList<Maneken>();

                listBox1.Items.Clear();
                foreach (Maneken m in ucesnici)
                {
                    this.listBox1.Items.Add(m.ID + " " + m.Licno_Ime + " " + m.Prezime + " " + m.Visina + " " + m.Tezina);

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
