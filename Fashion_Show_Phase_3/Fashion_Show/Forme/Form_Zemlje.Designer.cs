﻿namespace Fashion_Show.Forme
{
    partial class Form_Zemlje
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
            this.groupBox4.Location = new System.Drawing.Point(1, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(310, 223);
            this.groupBox4.TabIndex = 18;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Lista Svih Zemalja:";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(11, 19);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(293, 186);
            this.listBox1.TabIndex = 0;
            // 
            // Prikazbutton
            // 
            this.Prikazbutton.BackColor = System.Drawing.Color.Coral;
            this.Prikazbutton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Prikazbutton.Location = new System.Drawing.Point(12, 228);
            this.Prikazbutton.Name = "Prikazbutton";
            this.Prikazbutton.Size = new System.Drawing.Size(126, 30);
            this.Prikazbutton.TabIndex = 21;
            this.Prikazbutton.Text = "Prikaz ";
            this.Prikazbutton.UseVisualStyleBackColor = false;
            this.Prikazbutton.Click += new System.EventHandler(this.Prikazbutton_Click);
            // 
            // Form_Zemlje
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(351, 295);
            this.Controls.Add(this.Prikazbutton);
            this.Controls.Add(this.groupBox4);
            this.Name = "Form_Zemlje";
            this.Text = "Form_Zemlje";
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox4;
        public System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button Prikazbutton;
    }
}