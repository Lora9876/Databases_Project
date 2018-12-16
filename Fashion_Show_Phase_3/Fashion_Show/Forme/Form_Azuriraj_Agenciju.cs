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
    public partial class Form_Azuriraj_Agenciju : Form
    {
        int ID_Agencije;
        public Form_Azuriraj_Agenciju()
        {
            InitializeComponent();
        }
        public Form_Azuriraj_Agenciju(int ID)
        {
            InitializeComponent();
            ID_Agencije = ID;

        }
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Fashion_Show.Entiteti.Agencija agencija = s.Load<Fashion_Show.Entiteti.Agencija>(ID_Agencije);
                agencija.PIB = Convert.ToInt32(this.textBox2.Text);
                agencija.Naziv = this.textBox3.Text;
                agencija.Datum_Osnivanja = Convert.ToDateTime(this.textBox4.Text);
                agencija.Sediste = this.textBox5.Text;
                s.SaveOrUpdate(agencija);
                s.Flush();
                s.Close();
                MessageBox.Show("Azurirali ste stavku idite na listu agencija za refresh");
                Close();

            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }
    }
}
