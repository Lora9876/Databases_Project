namespace Fashion_Show.Forme
{
    partial class Form_CasopisiManekena
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
            this.label1 = new System.Windows.Forms.Label();
            this.CasopisText = new System.Windows.Forms.TextBox();
            this.Obrisibutton = new System.Windows.Forms.Button();
            this.Dodajbutton = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.CasopisText);
            this.groupBox1.Controls.Add(this.Obrisibutton);
            this.groupBox1.Controls.Add(this.Dodajbutton);
            this.groupBox1.Controls.Add(this.listBox1);
            this.groupBox1.Location = new System.Drawing.Point(24, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(157, 338);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Casopisi Manekena:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 191);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Unesite naziv casopisa:";
            // 
            // CasopisText
            // 
            this.CasopisText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CasopisText.Location = new System.Drawing.Point(9, 207);
            this.CasopisText.Name = "CasopisText";
            this.CasopisText.Size = new System.Drawing.Size(124, 26);
            this.CasopisText.TabIndex = 3;
            // 
            // Obrisibutton
            // 
            this.Obrisibutton.Location = new System.Drawing.Point(70, 249);
            this.Obrisibutton.Name = "Obrisibutton";
            this.Obrisibutton.Size = new System.Drawing.Size(60, 38);
            this.Obrisibutton.TabIndex = 3;
            this.Obrisibutton.Text = "Obrisi";
            this.Obrisibutton.UseVisualStyleBackColor = true;
            this.Obrisibutton.Click += new System.EventHandler(this.Obrisibutton_Click);
            // 
            // Dodajbutton
            // 
            this.Dodajbutton.Location = new System.Drawing.Point(6, 249);
            this.Dodajbutton.Name = "Dodajbutton";
            this.Dodajbutton.Size = new System.Drawing.Size(57, 38);
            this.Dodajbutton.TabIndex = 1;
            this.Dodajbutton.Text = "Dodaj";
            this.Dodajbutton.UseVisualStyleBackColor = true;
            this.Dodajbutton.Click += new System.EventHandler(this.Dodajbutton_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(9, 19);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(124, 160);
            this.listBox1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(9, 293);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(116, 38);
            this.button1.TabIndex = 4;
            this.button1.Text = "Azuriraj naziv casopisa";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form_CasopisiManekena
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(204, 362);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form_CasopisiManekena";
            this.Text = "Form_CasopisiManekena";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox CasopisText;
        private System.Windows.Forms.Button Obrisibutton;
        private System.Windows.Forms.Button Dodajbutton;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button button1;
    }
}