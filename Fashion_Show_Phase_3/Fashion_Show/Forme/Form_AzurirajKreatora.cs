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

namespace Fashion_Show.Forme
{
    public partial class Form_AzurirajKreatora : Form
    {
        int ID_Kreatora;
        public Form_AzurirajKreatora()
        {
            InitializeComponent();
        }
        public Form_AzurirajKreatora(int ID)
        {
            InitializeComponent();
            this.ID_Kreatora = ID;
        }


        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Fashion_Show.Entiteti.Kreator k = s.Load<Fashion_Show.Entiteti.Kreator>(ID_Kreatora);
                k.Maticni_Broj = Convert.ToInt64(this.textBox2.Text);
                k.Licno_Ime = this.textBox3.Text;
                k.Prezime = this.textBox4.Text;
                k.Datum_Rodjenja = Convert.ToDateTime(this.textBox5.Text);
                k.Pol = this.textBox1.Text;
                k.Zemlja_Porekla = this.textBox6.Text;
                k.Naziv_Modne_Kuce = this.textBox7.Text; 
                s.SaveOrUpdate(k);
                s.Flush();
                s.Close();
                MessageBox.Show("Azurirali ste stavku idite na prikaz kreatora za refresh!");
                Close();

            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }


        }
    }
}
