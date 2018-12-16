namespace Fashion_Show
{
    partial class Form1
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
            this.cmdOneToMany = new System.Windows.Forms.Button();
            this.cmdManytoOne = new System.Windows.Forms.Button();
            this.cmdRead = new System.Windows.Forms.Button();
            this.cmdManytoOne2 = new System.Windows.Forms.Button();
            this.cmdOneToMany2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.cmdNastupa = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.cmdTPC = new System.Windows.Forms.Button();
            this.cmdCreateSGost = new System.Windows.Forms.Button();
            this.cmdCreateAManeken = new System.Windows.Forms.Button();
            this.cmdCreateNastupa = new System.Windows.Forms.Button();
            this.cmdCreateSubclassModnaRevija = new System.Windows.Forms.Button();
            this.cmdCreateSubclassAgencija = new System.Windows.Forms.Button();
            this.cmdCreateZemlja = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmdOneToMany
            // 
            this.cmdOneToMany.Location = new System.Drawing.Point(0, 153);
            this.cmdOneToMany.Name = "cmdOneToMany";
            this.cmdOneToMany.Size = new System.Drawing.Size(271, 23);
            this.cmdOneToMany.TabIndex = 4;
            this.cmdOneToMany.Text = "Veza One-to-Many - 1.primer";
            this.cmdOneToMany.UseVisualStyleBackColor = true;
            this.cmdOneToMany.Click += new System.EventHandler(this.cmdOneToMany_Click);
            // 
            // cmdManytoOne
            // 
            this.cmdManytoOne.Location = new System.Drawing.Point(0, 125);
            this.cmdManytoOne.Name = "cmdManytoOne";
            this.cmdManytoOne.Size = new System.Drawing.Size(271, 23);
            this.cmdManytoOne.TabIndex = 5;
            this.cmdManytoOne.Text = "Veza Many-to-One - 1.primer";
            this.cmdManytoOne.UseVisualStyleBackColor = true;
            this.cmdManytoOne.Click += new System.EventHandler(this.cmdManytoOne_Click);
            // 
            // cmdRead
            // 
            this.cmdRead.Location = new System.Drawing.Point(0, 12);
            this.cmdRead.Name = "cmdRead";
            this.cmdRead.Size = new System.Drawing.Size(271, 23);
            this.cmdRead.TabIndex = 6;
            this.cmdRead.Text = "Ucitavanje podataka o agenciji";
            this.cmdRead.UseVisualStyleBackColor = true;
            this.cmdRead.Click += new System.EventHandler(this.cmdRead_Click);
            // 
            // cmdManytoOne2
            // 
            this.cmdManytoOne2.Location = new System.Drawing.Point(0, 236);
            this.cmdManytoOne2.Name = "cmdManytoOne2";
            this.cmdManytoOne2.Size = new System.Drawing.Size(271, 23);
            this.cmdManytoOne2.TabIndex = 8;
            this.cmdManytoOne2.Text = "Veza Many-to-One - 2.primer";
            this.cmdManytoOne2.UseVisualStyleBackColor = true;
            this.cmdManytoOne2.Click += new System.EventHandler(this.cmdManytoOne2_Click);
            // 
            // cmdOneToMany2
            // 
            this.cmdOneToMany2.Location = new System.Drawing.Point(0, 265);
            this.cmdOneToMany2.Name = "cmdOneToMany2";
            this.cmdOneToMany2.Size = new System.Drawing.Size(271, 23);
            this.cmdOneToMany2.TabIndex = 9;
            this.cmdOneToMany2.Text = "Veza One-to-Many - 2.primer";
            this.cmdOneToMany2.UseVisualStyleBackColor = true;
            this.cmdOneToMany2.Click += new System.EventHandler(this.cmdOneToMany2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(0, 36);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(271, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "Ucitavanje podataka o modnoj reviji";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cmdNastupa
            // 
            this.cmdNastupa.Location = new System.Drawing.Point(319, 12);
            this.cmdNastupa.Name = "cmdNastupa";
            this.cmdNastupa.Size = new System.Drawing.Size(271, 23);
            this.cmdNastupa.TabIndex = 11;
            this.cmdNastupa.Text = "Gde Nastupa";
            this.cmdNastupa.UseVisualStyleBackColor = true;
            this.cmdNastupa.Click += new System.EventHandler(this.cmdNastupa_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(0, 65);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(271, 23);
            this.button2.TabIndex = 12;
            this.button2.Text = "Ucitavanje podataka o agencijskom manekenu";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(319, 236);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(271, 23);
            this.button3.TabIndex = 13;
            this.button3.Text = "Table-per-Class-Hierarchy inheritance";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // cmdTPC
            // 
            this.cmdTPC.Location = new System.Drawing.Point(319, 124);
            this.cmdTPC.Name = "cmdTPC";
            this.cmdTPC.Size = new System.Drawing.Size(271, 23);
            this.cmdTPC.TabIndex = 14;
            this.cmdTPC.Text = "Table-per-Class inheritance";
            this.cmdTPC.UseVisualStyleBackColor = true;
            this.cmdTPC.Click += new System.EventHandler(this.cmdTPC_Click);
            // 
            // cmdCreateSGost
            // 
            this.cmdCreateSGost.Location = new System.Drawing.Point(319, 153);
            this.cmdCreateSGost.Name = "cmdCreateSGost";
            this.cmdCreateSGost.Size = new System.Drawing.Size(271, 23);
            this.cmdCreateSGost.TabIndex = 15;
            this.cmdCreateSGost.Text = "Kreiranje specijalnog gosta";
            this.cmdCreateSGost.UseVisualStyleBackColor = true;
            this.cmdCreateSGost.Click += new System.EventHandler(this.cmdCreateSGost_Click);
            // 
            // cmdCreateAManeken
            // 
            this.cmdCreateAManeken.Location = new System.Drawing.Point(0, 182);
            this.cmdCreateAManeken.Name = "cmdCreateAManeken";
            this.cmdCreateAManeken.Size = new System.Drawing.Size(271, 23);
            this.cmdCreateAManeken.TabIndex = 17;
            this.cmdCreateAManeken.Text = "Kreiranje agen. manekena";
            this.cmdCreateAManeken.UseVisualStyleBackColor = true;
            this.cmdCreateAManeken.Click += new System.EventHandler(this.cmdCreateAManeken_Click);
            // 
            // cmdCreateNastupa
            // 
            this.cmdCreateNastupa.Location = new System.Drawing.Point(319, 41);
            this.cmdCreateNastupa.Name = "cmdCreateNastupa";
            this.cmdCreateNastupa.Size = new System.Drawing.Size(271, 23);
            this.cmdCreateNastupa.TabIndex = 18;
            this.cmdCreateNastupa.Text = "Kreiranje Nastupa";
            this.cmdCreateNastupa.UseVisualStyleBackColor = true;
            this.cmdCreateNastupa.Click += new System.EventHandler(this.cmdCreateNastupa_Click);
            // 
            // cmdCreateSubclassModnaRevija
            // 
            this.cmdCreateSubclassModnaRevija.Location = new System.Drawing.Point(319, 265);
            this.cmdCreateSubclassModnaRevija.Name = "cmdCreateSubclassModnaRevija";
            this.cmdCreateSubclassModnaRevija.Size = new System.Drawing.Size(271, 23);
            this.cmdCreateSubclassModnaRevija.TabIndex = 19;
            this.cmdCreateSubclassModnaRevija.Text = "Kreiranje podklase Modna Revija";
            this.cmdCreateSubclassModnaRevija.UseVisualStyleBackColor = true;
            this.cmdCreateSubclassModnaRevija.Click += new System.EventHandler(this.cmdCreateSubclassModnaRevija_Click);
            // 
            // cmdCreateSubclassAgencija
            // 
            this.cmdCreateSubclassAgencija.Location = new System.Drawing.Point(319, 294);
            this.cmdCreateSubclassAgencija.Name = "cmdCreateSubclassAgencija";
            this.cmdCreateSubclassAgencija.Size = new System.Drawing.Size(271, 23);
            this.cmdCreateSubclassAgencija.TabIndex = 20;
            this.cmdCreateSubclassAgencija.Text = "Kreiranje podklase Agencija";
            this.cmdCreateSubclassAgencija.UseVisualStyleBackColor = true;
            this.cmdCreateSubclassAgencija.Click += new System.EventHandler(this.cmdCreateSubclassAgencija_Click);
            // 
            // cmdCreateZemlja
            // 
            this.cmdCreateZemlja.Location = new System.Drawing.Point(0, 294);
            this.cmdCreateZemlja.Name = "cmdCreateZemlja";
            this.cmdCreateZemlja.Size = new System.Drawing.Size(271, 23);
            this.cmdCreateZemlja.TabIndex = 21;
            this.cmdCreateZemlja.Text = "Kreiranje zemalja";
            this.cmdCreateZemlja.UseVisualStyleBackColor = true;
            this.cmdCreateZemlja.Click += new System.EventHandler(this.cmdCreateZemlja_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(614, 421);
            this.Controls.Add(this.cmdCreateZemlja);
            this.Controls.Add(this.cmdCreateSubclassAgencija);
            this.Controls.Add(this.cmdCreateSubclassModnaRevija);
            this.Controls.Add(this.cmdCreateNastupa);
            this.Controls.Add(this.cmdCreateAManeken);
            this.Controls.Add(this.cmdCreateSGost);
            this.Controls.Add(this.cmdTPC);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.cmdNastupa);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cmdOneToMany2);
            this.Controls.Add(this.cmdManytoOne2);
            this.Controls.Add(this.cmdRead);
            this.Controls.Add(this.cmdManytoOne);
            this.Controls.Add(this.cmdOneToMany);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmdOneToMany;
        private System.Windows.Forms.Button cmdManytoOne;
        private System.Windows.Forms.Button cmdRead;
        private System.Windows.Forms.Button cmdManytoOne2;
        private System.Windows.Forms.Button cmdOneToMany2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button cmdNastupa;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button cmdTPC;
        private System.Windows.Forms.Button cmdCreateSGost;
        private System.Windows.Forms.Button cmdCreateAManeken;
        private System.Windows.Forms.Button cmdCreateNastupa;
        private System.Windows.Forms.Button cmdCreateSubclassModnaRevija;
        private System.Windows.Forms.Button cmdCreateSubclassAgencija;
        private System.Windows.Forms.Button cmdCreateZemlja;
    }
}

