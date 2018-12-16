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
    public partial class Form_AzurirajSpecijalnogGosta : Form
    {
        int ID_SGosta;
        public Form_AzurirajSpecijalnogGosta()
        {
            InitializeComponent();
        }
        public Form_AzurirajSpecijalnogGosta(int ID)
        {
            InitializeComponent();
            this.ID_SGosta = ID;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Fashion_Show.Entiteti.Specijalan_Gost sgost = s.Load<Fashion_Show.Entiteti.Specijalan_Gost>(ID_SGosta);
                //IQuery q = s.CreateQuery("select a.PripadaAgeciji  from Agencijski_Maneken as a where a.ID  = ? ");
                // q.SetInt32(0, ID_AManekena);
                // Agencija stara_agencija = q.UniqueResult<Agencija>();

                sgost.Maticni_Broj = Convert.ToInt64(this.textBox2.Text);
                sgost.Licno_Ime = this.textBox3.Text;
                sgost.Prezime = this.textBox4.Text;
                sgost.Datum_Rodjenja = Convert.ToDateTime(this.textBox5.Text);
                sgost.Pol = this.textBox1.Text;
                sgost.Boja_Kose = this.textBox6.Text;
                sgost.Boja_Ociju = this.textBox7.Text;
                sgost.Visina = Convert.ToInt32(this.textBox8.Text);
                sgost.Tezina = Convert.ToInt32(this.textBox9.Text);
                sgost.Konfekcijski_Broj = Convert.ToInt32(this.textBox10.Text);
                sgost.Zanimanje = this.textBox11.Text;
                s.SaveOrUpdate(sgost);
                s.Flush();
                s.Close();
                MessageBox.Show("Azurirali ste stavku idite na prikaz specijalnih gostiju za refresh!");
                Close();

            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

    }
}
