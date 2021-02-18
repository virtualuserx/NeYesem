namespace WindowsFormsApp1
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
            this.btnAdminPaneli = new System.Windows.Forms.Button();
            this.btnYemekTarifi = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnAdminPaneli
            // 
            this.btnAdminPaneli.Location = new System.Drawing.Point(12, 91);
            this.btnAdminPaneli.Name = "btnAdminPaneli";
            this.btnAdminPaneli.Size = new System.Drawing.Size(114, 23);
            this.btnAdminPaneli.TabIndex = 71;
            this.btnAdminPaneli.Text = "ADMİN PANELİ";
            this.btnAdminPaneli.UseVisualStyleBackColor = true;
            this.btnAdminPaneli.Click += new System.EventHandler(this.btnAdminPaneli_Click);
            // 
            // btnYemekTarifi
            // 
            this.btnYemekTarifi.Location = new System.Drawing.Point(12, 62);
            this.btnYemekTarifi.Name = "btnYemekTarifi";
            this.btnYemekTarifi.Size = new System.Drawing.Size(114, 23);
            this.btnYemekTarifi.TabIndex = 72;
            this.btnYemekTarifi.Text = "YEMEK TARIFI";
            this.btnYemekTarifi.UseVisualStyleBackColor = true;
            this.btnYemekTarifi.Click += new System.EventHandler(this.btnYemekTarifi_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(132, 64);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 73;
            // 
            // Form1
            // 
            this.AcceptButton = this.btnYemekTarifi;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 461);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnYemekTarifi);
            this.Controls.Add(this.btnAdminPaneli);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "v";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnAdminPaneli;
        private System.Windows.Forms.Button btnYemekTarifi;
        private System.Windows.Forms.TextBox textBox1;
    }
}

