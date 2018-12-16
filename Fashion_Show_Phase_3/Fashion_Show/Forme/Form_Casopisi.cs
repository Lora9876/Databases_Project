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
using NHibernate.Linq;

namespace Fashion_Show.Forme
{
    public partial class Form_Casopisi : Form
    {
        public Form_Casopisi()
        {
            InitializeComponent();
        }

        private void Prikazbutton_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                IList<Casopic> ucesnici = (from o in s.Query<Casopic>() orderby o.ID_Casopis select o).ToList<Casopic>();

                listBox1.Items.Clear();
                foreach (Casopic c in ucesnici)
                {
                    this.listBox1.Items.Add(c.ID_Casopis + " " + c.Naziv_Casopisa + " maneken ciji je casopis: " + c.PripadaManekenu.Licno_Ime + " " + c.PripadaManekenu.Prezime);

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
