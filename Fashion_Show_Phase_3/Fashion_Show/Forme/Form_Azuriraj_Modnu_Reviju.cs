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
    public partial class Form_Azuriraj_Modnu_Reviju : Form
    {
        int ID_Modne_Revije;
        bool jedan_je;
     
        public Form_Azuriraj_Modnu_Reviju()
        {
            InitializeComponent();
        }
        public Form_Azuriraj_Modnu_Reviju(int ID, bool jedan)
        {
            InitializeComponent();
            ID_Modne_Revije = ID;
            this.jedan_je = jedan;
            if (jedan == true)
                this.groupBox3.Visible = false;
            else 
                this.groupBox3.Visible = true;
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                if (this.jedan_je == true)
                {
                    Fashion_Show.Entiteti.Modna_Revija_Sa_Jednim_Kreatorom revija = s.Load<Fashion_Show.Entiteti.Modna_Revija_Sa_Jednim_Kreatorom>(ID_Modne_Revije);
                    revija.Naziv = this.textBox2.Text;
                    revija.Mesto_Odrzavanja = this.textBox3.Text;
                    revija.Datum_Vreme_Odrzavanja = Convert.ToDateTime(this.textBox4.Text);
                    s.SaveOrUpdate(revija);
                    s.Flush();
                    s.Close();
                    MessageBox.Show("Azurirali ste stavku idite na listu modnih revija za refresh");
                    Close();
                }
                else if (this.jedan_je == false)//vise kreator
                {
                     if (this.DaradioButton.Checked == false && this.NeradioButton.Checked == false)
                    {
                        MessageBox.Show("Niste izabrali da li su ranije kreatori nastupali");
                        return;
                    }
                    Fashion_Show.Entiteti.Modna_Revija_Sa_Vise_Kreatora revija = s.Load<Fashion_Show.Entiteti.Modna_Revija_Sa_Vise_Kreatora>(ID_Modne_Revije);
                    revija.Naziv = this.textBox2.Text;
                    revija.Mesto_Odrzavanja = this.textBox3.Text;
                    revija.Datum_Vreme_Odrzavanja = Convert.ToDateTime(this.textBox4.Text);
                    if(this.DaradioButton.Checked)
                        revija.Ranije_Nastupali_Zajedno="da";
                    else if(this.NeradioButton.Checked)
                        revija.Ranije_Nastupali_Zajedno="ne";
                    s.SaveOrUpdate(revija);
                    s.Flush();
                    s.Close();
                    MessageBox.Show("Azurirali ste stavku idite na listu modnih revija za refresh");
                    Close();


                }
                

            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }
    }
}
