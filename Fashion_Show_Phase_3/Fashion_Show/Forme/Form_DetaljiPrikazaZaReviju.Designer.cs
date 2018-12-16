namespace Fashion_Show.Forme
{
    partial class Form_DetaljiPrikazaZaReviju
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.Obrisibutton = new System.Windows.Forms.Button();
            this.Dodajbutton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.listBox1);
            this.groupBox1.Location = new System.Drawing.Point(12, 33);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(350, 169);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Kreatori koji prikazuju na toj reviji:";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(7, 19);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(322, 134);
            this.listBox1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(55, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 25);
            this.label1.TabIndex = 4;
            this.label1.Text = "label1";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.listBox2);
            this.groupBox2.Location = new System.Drawing.Point(404, 23);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(287, 240);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Svi kreatori ";
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Location = new System.Drawing.Point(6, 20);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(264, 199);
            this.listBox2.TabIndex = 1;
            // 
            // Obrisibutton
            // 
            this.Obrisibutton.BackColor = System.Drawing.Color.Transparent;
            this.Obrisibutton.Location = new System.Drawing.Point(12, 208);
            this.Obrisibutton.Name = "Obrisibutton";
            this.Obrisibutton.Size = new System.Drawing.Size(350, 32);
            this.Obrisibutton.TabIndex = 23;
            this.Obrisibutton.Text = "Obrisi da selektovani  kreator prikazuje na ovoj reviji";
            this.Obrisibutton.UseVisualStyleBackColor = false;
            this.Obrisibutton.Click += new System.EventHandler(this.Obrisibutton_Click);
            // 
            // Dodajbutton
            // 
            this.Dodajbutton.BackColor = System.Drawing.Color.Coral;
            this.Dodajbutton.Location = new System.Drawing.Point(368, 100);
            this.Dodajbutton.Name = "Dodajbutton";
            this.Dodajbutton.Size = new System.Drawing.Size(30, 28);
            this.Dodajbutton.TabIndex = 24;
            this.Dodajbutton.Text = "<---";
            this.Dodajbutton.UseVisualStyleBackColor = false;
            this.Dodajbutton.Click += new System.EventHandler(this.Dodajbutton_Click);
            // 
            // Form_DetaljiPrikazaZaReviju
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(698, 306);
            this.Controls.Add(this.Dodajbutton);
            this.Controls.Add(this.Obrisibutton);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form_DetaljiPrikazaZaReviju";
            this.Text = "Form_DetaljiPrikaza";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        public System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.Button Obrisibutton;
        private System.Windows.Forms.Button Dodajbutton;
    }
}