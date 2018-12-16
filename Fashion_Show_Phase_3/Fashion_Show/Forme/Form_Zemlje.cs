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
    public partial class Form_Zemlje : Form
    {
        public Form_Zemlje()
        {
            InitializeComponent();
        }

        private void Prikazbutton_Click(object sender, EventArgs e)
        {

            try
            {
                ISession s = DataLayer.GetSession();
                IList<Zemlja> ucesnici = (from o in s.Query<Zemlja>() orderby o.ID_Zemlja select o).ToList<Zemlja>();

                listBox1.Items.Clear();
                foreach (Zemlja z in ucesnici)
                {
                    this.listBox1.Items.Add(z.ID_Zemlja + " " + z.Naziv_Zemlje + "  int. agencija: " + z.PripadaAgenciji.Naziv + " " + z.PripadaAgenciji.Sediste);

                }

                IList<Agencija> ucesnici2 = (from a in s.Query<Agencija>() orderby a.ID select a).ToList<Agencija>();


            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }

        }
    }

}
