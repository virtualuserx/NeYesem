namespace WindowsFormsApp1.FORMS
{
    partial class YemekTarifiGoster
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(YemekTarifiGoster));
            this.pb_resim_adresi = new System.Windows.Forms.PictureBox();
            this.lbl_yemek_ad = new System.Windows.Forms.Label();
            this.lbl_icindekiler = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pb_kapat = new System.Windows.Forms.PictureBox();
            this.pb_kucult = new System.Windows.Forms.PictureBox();
            this.pnl_icindekiler = new System.Windows.Forms.Panel();
            this.pnl_tarif = new System.Windows.Forms.Panel();
            this.lbl_yapilis_tarifi = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl_adim_no = new System.Windows.Forms.Label();
            this.lbl_adim_yazi = new System.Windows.Forms.Label();
            this.pb_ok_sol = new System.Windows.Forms.PictureBox();
            this.pb_ok_sag = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pb_resim_adresi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_kapat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_kucult)).BeginInit();
            this.pnl_icindekiler.SuspendLayout();
            this.pnl_tarif.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_ok_sol)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_ok_sag)).BeginInit();
            this.SuspendLayout();
            // 
            // pb_resim_adresi
            // 
            resources.ApplyResources(this.pb_resim_adresi, "pb_resim_adresi");
            this.pb_resim_adresi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pb_resim_adresi.Name = "pb_resim_adresi";
            this.pb_resim_adresi.TabStop = false;
            // 
            // lbl_yemek_ad
            // 
            resources.ApplyResources(this.lbl_yemek_ad, "lbl_yemek_ad");
            this.lbl_yemek_ad.ForeColor = System.Drawing.Color.Peru;
            this.lbl_yemek_ad.Name = "lbl_yemek_ad";
            this.lbl_yemek_ad.Click += new System.EventHandler(this.lbl_yemek_ad_Click);
            // 
            // lbl_icindekiler
            // 
            resources.ApplyResources(this.lbl_icindekiler, "lbl_icindekiler");
            this.lbl_icindekiler.ForeColor = System.Drawing.Color.Bisque;
            this.lbl_icindekiler.Name = "lbl_icindekiler";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.ForeColor = System.Drawing.Color.Peru;
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.ForeColor = System.Drawing.Color.Peru;
            this.label2.Name = "label2";
            // 
            // pb_kapat
            // 
            resources.ApplyResources(this.pb_kapat, "pb_kapat");
            this.pb_kapat.Name = "pb_kapat";
            this.pb_kapat.TabStop = false;
            this.pb_kapat.Click += new System.EventHandler(this.pb_kapat_Click);
            this.pb_kapat.MouseLeave += new System.EventHandler(this.pb_kapat_MouseLeave);
            this.pb_kapat.MouseHover += new System.EventHandler(this.pb_kapat_MouseHover);
            // 
            // pb_kucult
            // 
            resources.ApplyResources(this.pb_kucult, "pb_kucult");
            this.pb_kucult.Name = "pb_kucult";
            this.pb_kucult.TabStop = false;
            this.pb_kucult.Click += new System.EventHandler(this.pb_kucult_Click);
            this.pb_kucult.MouseLeave += new System.EventHandler(this.pb_kucult_MouseLeave);
            this.pb_kucult.MouseHover += new System.EventHandler(this.pb_kucult_MouseHover);
            // 
            // pnl_icindekiler
            // 
            resources.ApplyResources(this.pnl_icindekiler, "pnl_icindekiler");
            this.pnl_icindekiler.Controls.Add(this.lbl_icindekiler);
            this.pnl_icindekiler.Name = "pnl_icindekiler";
            // 
            // pnl_tarif
            // 
            resources.ApplyResources(this.pnl_tarif, "pnl_tarif");
            this.pnl_tarif.Controls.Add(this.lbl_yapilis_tarifi);
            this.pnl_tarif.Name = "pnl_tarif";
            // 
            // lbl_yapilis_tarifi
            // 
            resources.ApplyResources(this.lbl_yapilis_tarifi, "lbl_yapilis_tarifi");
            this.lbl_yapilis_tarifi.ForeColor = System.Drawing.Color.Bisque;
            this.lbl_yapilis_tarifi.Name = "lbl_yapilis_tarifi";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbl_adim_no);
            this.panel1.Controls.Add(this.lbl_adim_yazi);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // lbl_adim_no
            // 
            resources.ApplyResources(this.lbl_adim_no, "lbl_adim_no");
            this.lbl_adim_no.ForeColor = System.Drawing.Color.Peru;
            this.lbl_adim_no.Name = "lbl_adim_no";
            this.lbl_adim_no.Click += new System.EventHandler(this.lbl_adim_no_Click);
            // 
            // lbl_adim_yazi
            // 
            resources.ApplyResources(this.lbl_adim_yazi, "lbl_adim_yazi");
            this.lbl_adim_yazi.ForeColor = System.Drawing.Color.Bisque;
            this.lbl_adim_yazi.Name = "lbl_adim_yazi";
            // 
            // pb_ok_sol
            // 
            resources.ApplyResources(this.pb_ok_sol, "pb_ok_sol");
            this.pb_ok_sol.Name = "pb_ok_sol";
            this.pb_ok_sol.TabStop = false;
            this.pb_ok_sol.Click += new System.EventHandler(this.pb_ok_sol_Click);
            this.pb_ok_sol.MouseLeave += new System.EventHandler(this.pb_ok_sol_MouseLeave);
            this.pb_ok_sol.MouseHover += new System.EventHandler(this.pb_ok_sol_MouseHover);
            // 
            // pb_ok_sag
            // 
            resources.ApplyResources(this.pb_ok_sag, "pb_ok_sag");
            this.pb_ok_sag.Name = "pb_ok_sag";
            this.pb_ok_sag.TabStop = false;
            this.pb_ok_sag.Click += new System.EventHandler(this.pb_ok_sag_Click);
            this.pb_ok_sag.MouseLeave += new System.EventHandler(this.pb_ok_sag_MouseLeave);
            this.pb_ok_sag.MouseHover += new System.EventHandler(this.pb_ok_sag_MouseHover);
            // 
            // YemekTarifiGoster
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(0)))), ((int)(((byte)(13)))));
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pb_ok_sag);
            this.Controls.Add(this.pb_ok_sol);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnl_tarif);
            this.Controls.Add(this.pnl_icindekiler);
            this.Controls.Add(this.pb_kucult);
            this.Controls.Add(this.pb_kapat);
            this.Controls.Add(this.lbl_yemek_ad);
            this.Controls.Add(this.pb_resim_adresi);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "YemekTarifiGoster";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.YemekTarifiGoster_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pb_resim_adresi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_kapat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_kucult)).EndInit();
            this.pnl_icindekiler.ResumeLayout(false);
            this.pnl_icindekiler.PerformLayout();
            this.pnl_tarif.ResumeLayout(false);
            this.pnl_tarif.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pb_ok_sol)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_ok_sag)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pb_resim_adresi;
        private System.Windows.Forms.Label lbl_yemek_ad;
        private System.Windows.Forms.Label lbl_icindekiler;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pb_kapat;
        private System.Windows.Forms.PictureBox pb_kucult;
        private System.Windows.Forms.Panel pnl_icindekiler;
        private System.Windows.Forms.Panel pnl_tarif;
        private System.Windows.Forms.Label lbl_yapilis_tarifi;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbl_adim_no;
        private System.Windows.Forms.Label lbl_adim_yazi;
        private System.Windows.Forms.PictureBox pb_ok_sol;
        private System.Windows.Forms.PictureBox pb_ok_sag;
    }
}