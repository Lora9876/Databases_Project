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
    public partial class Form_DetaljiAgencije : Form
    {
        public Form_DetaljiAgencije(int ID)
        {
            InitializeComponent();
            try
            {
                ISession s = DataLayer.GetSession();
                Agencijski_Maneken man = s.Load<Agencijski_Maneken>(ID);

                this.label1.Text = "Agencija: " + man.PripadaAgeciji.ID + " " +man.PripadaAgeciji.PIB + " " + man.PripadaAgeciji.Naziv + " " + man.PripadaAgeciji.Sediste;
                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
            

        }
    }
}
