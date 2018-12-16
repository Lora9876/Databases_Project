namespace Fashion_Show.Forme
{
    partial class Form_Prikazuje_Na
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.bPrikazi = new System.Windows.Forms.Button();
            this.bObrisi = new System.Windows.Forms.Button();
            this.bDodaj = new System.Windows.Forms.Button();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.listBox1);
            this.groupBox4.Location = new System.Drawing.Point(12, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(451, 241);
            this.groupBox4.TabIndex = 18;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Lista Svih Prikaza";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(11, 19);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(434, 212);
            this.listBox1.TabIndex = 0;
            // 
            // bPrikazi
            // 
            this.bPrikazi.Location = new System.Drawing.Point(225, 259);
            this.bPrikazi.Name = "bPrikazi";
            this.bPrikazi.Size = new System.Drawing.Size(75, 23);
            this.bPrikazi.TabIndex = 21;
            this.bPrikazi.Text = "Prikazi";
            this.bPrikazi.UseVisualStyleBackColor = true;
            this.bPrikazi.Click += new System.EventHandler(this.bPrikazi_Click);
            // 
            // bObrisi
            // 
            this.bObrisi.Location = new System.Drawing.Point(387, 259);
            this.bObrisi.Name = "bObrisi";
            this.bObrisi.Size = new System.Drawing.Size(75, 23);
            this.bObrisi.TabIndex = 20;
            this.bObrisi.Text = "Obrisi";
            this.bObrisi.UseVisualStyleBackColor = true;
            this.bObrisi.Click += new System.EventHandler(this.bObrisi_Click);
            // 
            // bDodaj
            // 
            this.bDodaj.Location = new System.Drawing.Point(306, 259);
            this.bDodaj.Name = "bDodaj";
            this.bDodaj.Size = new System.Drawing.Size(75, 23);
            this.bDodaj.TabIndex = 19;
            this.bDodaj.Text = "Dodaj";
            this.bDodaj.UseVisualStyleBackColor = true;
            this.bDodaj.Click += new System.EventHandler(this.bDodaj_Click);
            // 
            // Form_Prikazuje_Na
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(490, 318);
            this.Controls.Add(this.bPrikazi);
            this.Controls.Add(this.bObrisi);
            this.Controls.Add(this.bDodaj);
            this.Controls.Add(this.groupBox4);
            this.Name = "Form_Prikazuje_Na";
            this.Text = "Form_Prikazuje_Na";
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox4;
        public System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button bPrikazi;
        private System.Windows.Forms.Button bObrisi;
        private System.Windows.Forms.Button bDodaj;

    }
}