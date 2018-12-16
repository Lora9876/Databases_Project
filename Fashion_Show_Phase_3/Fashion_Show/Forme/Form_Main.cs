using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NHibernate;
using NHibernate.Cfg;
using Iesi.Collections.Generic;
using System.Xml.Serialization;
using System.IO;
using System.Xml;
using Fashion_Show.Entiteti;
using Fashion_Show.Mapiranja;
using Fashion_Show.Forme;

namespace Fashion_Show.Forme
{
    public partial class Form_Main : Form
    {
        public Form_Main()
        {
            InitializeComponent();
        }

        private void Modna_Revijabutton_Click(object sender, EventArgs e)
        {
            Form_Modna_Revija fm = new Form_Modna_Revija();
            fm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Form_Agencija fa= new Form_Agencija();
            fa.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form_Nastupa fn = new Form_Nastupa();
            fn.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form_AgencijskiManeken fm = new Form_AgencijskiManeken();
            fm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form_Osoba fo = new Form_Osoba();
            fo.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form_Kreator fk = new Form_Kreator();
            fk.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form_Specijalan_Gost fs = new Form_Specijalan_Gost();
            fs.Show();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form_Prikazuje_Na fp = new Form_Prikazuje_Na();
            fp.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form_Maneken fm = new Form_Maneken();
            fm.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Form_Zemlje fz = new Form_Zemlje();
            fz.Show();

        }

        private void button10_Click(object sender, EventArgs e)
        {
            Form_Casopisi fc = new Form_Casopisi();
            fc.Show();
        }

    }
}
