namespace Fashion_Show.Forme
{
    partial class Form_Casopisi
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
            this.Prikazbutton = new System.Windows.Forms.Button();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.listBox1);
            this.groupBox4.Location = new System.Drawing.Point(12, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(354, 223);
            this.groupBox4.TabIndex = 19;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Lista Svih Casopisa:";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(11, 19);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(330, 186);
            this.listBox1.TabIndex = 0;
            // 
            // Prikazbutton
            // 
            this.Prikazbutton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Prikazbutton.Location = new System.Drawing.Point(12, 241);
            this.Prikazbutton.Name = "Prikazbutton";
            this.Prikazbutton.Size = new System.Drawing.Size(126, 30);
            this.Prikazbutton.TabIndex = 22;
            this.Prikazbutton.Text = "Prikaz ";
            this.Prikazbutton.UseVisualStyleBackColor = true;
            this.Prikazbutton.Click += new System.EventHandler(this.Prikazbutton_Click);
            // 
            // Form_Casopisi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 279);
            this.Controls.Add(this.Prikazbutton);
            this.Controls.Add(this.groupBox4);
            this.Name = "Form_Casopisi";
            this.Text = "Form_Casopisi";
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox4;
        public System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button Prikazbutton;
    }
}