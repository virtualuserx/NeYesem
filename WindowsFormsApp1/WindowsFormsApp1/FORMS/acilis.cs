using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;
using System.Diagnostics;
using WindowsFormsApp1.FORMS;
using WindowsFormsApp1.DBO;
using WindowsFormsApp1.INF;

namespace WindowsFormsApp1
{
    public partial class acilis : Form
    {
        public acilis()
        {
            InitializeComponent();
        }
        Stopwatch stp = new Stopwatch();
        int imageBoxClickCounter = 0;
        string[] paths = new string[19];
        public static string baglanti_adresim = connection.baglanti_adresim;
        public static OleDbConnection baglanti = new OleDbConnection($"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={baglanti_adresim}");
        public static string system_klasoru = connection.system_klasoru;
        private void kategori_verigörüntüle(int id_num, ToolStripMenuItem Menu)
        {
            
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand();
            komut.Connection = baglanti;
            komut.CommandText = ("Select * From kategoriler  where ID=" + id_num);
            //komut.CommandText = ("Select ID, kategori_ad, resim_adresi from yemekler where id = 1",baglanti);
            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                Menu.Text = oku["kategori_ad"].ToString();
                Menu.Name = oku["kategori_ad"].ToString() + "_" + oku["ID"].ToString();
                Menu.Image = Image.FromFile( system_klasoru+oku["resim_adresi"].ToString());
                //Menu.Image.Size = new Point(100, 100);
                //btn.Image = Image.FromFile(system_klasoru + oku["resim_adresi"].ToString());
            }
            baglanti.Close();
            //Menu.ImageScalingSize=new System.Drawing.Size(20, 20);
        }
     

        private void acilis_Load(object sender, EventArgs e)
        {
            //kategori4ToolStripMenuItem= ImageLayout.Stretch;
            yemekyazdır_Load();

            kategori_verigörüntüle(3, kategori1ToolStripMenuItem);
            kategori_verigörüntüle(13, kategori2ToolStripMenuItem);
            kategori_verigörüntüle(9,kategori3ToolStripMenuItem);
            kategori_verigörüntüle(5, kategori4ToolStripMenuItem);
            //kategori1ToolStripMenuItem.Size=new Size(330,330);
            
            baglanti.Open();
            List<string> strList = new List<string>();
            OleDbCommand komut = new OleDbCommand();
            komut.Connection = baglanti;
            komut.CommandText = ("Select * From kategoriler");
            //komut.CommandText = ("Select ID, kategori_ad, resim_adresi from yemekler where id = 1",baglanti);
            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                strList.Add(oku["kategori_ad"].ToString() + "_" + oku["ID"].ToString()+"-"+ oku["resim_adresi"].ToString());
                

                //btn.Image = Image.FromFile(system_klasoru + oku["resim_adresi"].ToString());
            }
            baglanti.Close();
            foreach (string rw in strList)
            {
                string[] parca = rw.Split('-');
                ToolStripMenuItem SSMenu = new ToolStripMenuItem(parca[0].Split('_')[0], Image.FromFile(system_klasoru + parca[1]));
                SSMenu.Name = parca[0];
                tumkategorilerToolStripMenuItem.DropDownItems.Add(SSMenu);
                SSMenu.Click += new EventHandler(SSMenu_Click);
            }
            tumkategorilerToolStripMenuItem.Text = "Tüm kategoriler";
            
            pictureBox_acılıs.ImageLocation = system_klasoru + "neyesemlogo1.png";
        
        }
        
        private void SSMenu_Click(object sender, EventArgs e)
        {
            acilisflowLayoutPanel1.Controls.Clear();
            string namee = (sender as ToolStripMenuItem).Name;
            yemekyazdır(namee.Split('_')[1]);
        }        

        private void tumkategorilerToolStripMenuItem_Click(object sender, EventArgs e)
        {
          //  MessageBox.Show(tumkategorilerToolStripMenuItem.DropDownItems.);
        }
        ////////////
        public static class listeleme_bilgileri
        {
            public static int goruntulenecek_veri_sayisi;
            public static int panel_icerik_miktari;
            public static List<int> id_list = new List<int>();
        }

        public class benim_yemek_panel
        {
            public Panel create(int id)
            {
                Panel pnl = new Panel();
                pnl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(0)))), ((int)(((byte)(13)))));
                pnl.Name = id.ToString() + "_pnl";
                pnl.Size = new System.Drawing.Size(240, 267);
                return pnl;
            }
        }

        public class benim_picturebox
        {
            public PictureBox create(int id, string resim_adresi)
            {
                PictureBox pb = new PictureBox();
                pb.Location = new System.Drawing.Point(5, 30);
                pb.Size = new System.Drawing.Size(230, 150);
                pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                pb.Image = Image.FromFile(resim_adresi);
                pb.Cursor = Cursors.Hand;
                pb.Name = id.ToString() + "_pb";
                return pb;
            }
        }

        public class benim_label_baslik
        {
            public Label create(int id, string text)
            {
                Label lb = new Label();
                lb.Dock = System.Windows.Forms.DockStyle.Top;
                lb.Font = new System.Drawing.Font("Corbel", 15F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
                lb.ForeColor = System.Drawing.Color.Peru;
                lb.ImeMode = System.Windows.Forms.ImeMode.NoControl;
                lb.Location = new System.Drawing.Point(0, 0);
                lb.Size = new System.Drawing.Size(260, 32);
                lb.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                lb.Text = text.ToUpper();
                lb.Cursor = Cursors.Hand;
                lb.Name = id.ToString() + "_lb";
                return lb;
            }
        }
        public class benim_label_icerik
        {
            public Label create(string text)
            {
                Label lb = new Label();
                lb.Font = new System.Drawing.Font("Corbel", 14.25F, System.Drawing.FontStyle.Italic);
                lb.ForeColor = System.Drawing.Color.Bisque;
                lb.ImeMode = System.Windows.Forms.ImeMode.NoControl;
                lb.Text = text.ToUpper();
                lb.AutoSize = true;
                return lb;
            }
        }

        public class benim_label_icerik_derece
        {
            public Label create(int derece)
            {
                Label lb = new Label();
                lb.Font = new System.Drawing.Font("Corbel", 14.25F, System.Drawing.FontStyle.Italic);
                lb.ImeMode = System.Windows.Forms.ImeMode.NoControl;
                lb.AutoSize = true;

                if (derece == 1)
                {
                    lb.Text = "X";
                    lb.ForeColor = System.Drawing.Color.Red;
                }
                else if (derece == 3)
                {
                    lb.Text = "X";
                    lb.ForeColor = System.Drawing.Color.Orange;
                }
                else if (derece == 5)
                {
                    lb.Text = "✔";
                    lb.ForeColor = System.Drawing.Color.Gray;
                }
                else if (derece == 7)
                {
                    lb.Text = "✔";
                    lb.ForeColor = System.Drawing.Color.Orange;
                }
                else if (derece == 9)
                {
                    lb.Text = "✔";
                    lb.ForeColor = System.Drawing.Color.Green;
                }
                return lb;
            }
        }

        public class benim_label_kriter
        {
            public Label create(string text)
            {
                Label lb = new Label();
                lb.Font = new System.Drawing.Font("Corbel", 12F, System.Drawing.FontStyle.Bold);
                lb.ForeColor = System.Drawing.Color.Peru;
                lb.ImeMode = System.Windows.Forms.ImeMode.NoControl;
                lb.Text = text + ": ";
                lb.AutoSize = true;
                return lb;
            }
        }

        public class benim_button
        {
            public Button create()
            {
                Button b = new Button();
                b.Font = new System.Drawing.Font("Corbel", 12F, System.Drawing.FontStyle.Bold);
                b.ForeColor = System.Drawing.Color.Peru;
                b.ImeMode = System.Windows.Forms.ImeMode.NoControl;
                b.Text = "DAHA FAZLA YUKLE";
                b.Size = new System.Drawing.Size(980, 50);
                return b;
            }
        }


        void yemek_goster(int ID)
        {
            INF.yemek yemek = yemek_bilgileri(ID);//FiltelenmisYemekListele();
            INF.ozellikler ozellikler = ozellik_bilgileri(ID);//FiltrelenmisOzellikler();

            
            Panel pnl_yemek_new = new benim_yemek_panel().create(ID);
            pnl_yemek_new.Click += yemek_click;

            Panel pnl_yemek_ozellikler_new = new Panel();
            pnl_yemek_ozellikler_new.Location = new System.Drawing.Point(3, 190);
            pnl_yemek_ozellikler_new.Size = new System.Drawing.Size(240, 75);

            string ogun;
            if (ozellikler.ogun == 1)
            {

                ogun = "Kahvaltı";
            }
            else if (ozellikler.ogun == 2)
            {
                ogun = "Öğlen";
            }
            else if (ozellikler.ogun == 3)
            {
                ogun = "Akşam";
            }
            else
            {
                ogun = "Hepsi";
            }


            Label lbl_yemek_ogun_new = new benim_label_icerik().create(ogun);
            lbl_yemek_ogun_new.Location = new System.Drawing.Point(10, 0);


            Label lbl_yemek_vakit_new = new benim_label_icerik().create("⏱️ " + ozellikler.vakit.ToString() + " Dk");
            lbl_yemek_vakit_new.Location = new System.Drawing.Point(140, 0);

            Label lbl_pratik_new = new benim_label_kriter().create("Pratik");
            lbl_pratik_new.Location = new System.Drawing.Point(3, 30);
            Label lbl_yemek_pratik_new = new benim_label_icerik_derece().create(ozellikler.pratik);
            lbl_yemek_pratik_new.Location = new System.Drawing.Point(60, 25);

            Label lbl_saglik_new = new benim_label_kriter().create("Sağlık");
            lbl_saglik_new.Location = new System.Drawing.Point(135, 30);
            Label lbl_yemek_saglik_new = new benim_label_icerik_derece().create(ozellikler.saglik);
            lbl_yemek_saglik_new.Location = new System.Drawing.Point(190, 25);

            Label lbl_bulunabilirlik_new = new benim_label_kriter().create("Bulunabilirlik");
            lbl_bulunabilirlik_new.Location = new System.Drawing.Point(3, 50);
            Label lbl_yemek_bulunabilirlik_new = new benim_label_icerik_derece().create(ozellikler.bulunabilirlik);
            lbl_yemek_bulunabilirlik_new.Location = new System.Drawing.Point(110, 45);

            Label lbl_fiyat_new = new benim_label_kriter().create("Fiyat");
            lbl_fiyat_new.Location = new System.Drawing.Point(135, 50);
            Label lbl_yemek_fiyat_new = new benim_label_icerik().create(((int)ozellikler.fiyat / 100).ToString() + " TL");
            lbl_yemek_fiyat_new.Location = new System.Drawing.Point(190, 45);

            pnl_yemek_ozellikler_new.Controls.Add(lbl_pratik_new);
            pnl_yemek_ozellikler_new.Controls.Add(lbl_saglik_new);
            pnl_yemek_ozellikler_new.Controls.Add(lbl_bulunabilirlik_new);
            pnl_yemek_ozellikler_new.Controls.Add(lbl_fiyat_new);
            pnl_yemek_ozellikler_new.Controls.Add(lbl_yemek_ogun_new);
            pnl_yemek_ozellikler_new.Controls.Add(lbl_yemek_vakit_new);
            pnl_yemek_ozellikler_new.Controls.Add(lbl_yemek_pratik_new);
            pnl_yemek_ozellikler_new.Controls.Add(lbl_yemek_saglik_new);
            pnl_yemek_ozellikler_new.Controls.Add(lbl_yemek_bulunabilirlik_new);
            pnl_yemek_ozellikler_new.Controls.Add(lbl_yemek_fiyat_new);


            Label baslik = new benim_label_baslik().create(ID, yemek.yemek_ad);
            baslik.Click += yemek_click;
            pnl_yemek_new.Controls.Add(baslik);
            string resim_adresi = system_klasoru+ yemek.resim_adresi;
            PictureBox picture = new benim_picturebox().create(ID, resim_adresi);
            picture.Click += yemek_click;
            pnl_yemek_new.Controls.Add(picture);
            pnl_yemek_new.Controls.Add(pnl_yemek_ozellikler_new);


            acilisflowLayoutPanel1.Controls.Add(pnl_yemek_new);
        }

        private void yemek_click(object sender, EventArgs e)
        {
            string ID = "";
            if (sender.GetType().Name == "PictureBox")
            {
                ID = (sender as PictureBox).Name;
            }
            else if (sender.GetType().Name == "Label")
            {
                ID = ((sender as Label).Name);
            }
            else
            {
                ID = ((sender as Panel).Name);
            }

            FORMS.YemekTarifiGoster yemekTarifiGoster = new FORMS.YemekTarifiGoster();
            yemekTarifiGoster.yemek_id = Convert.ToInt32(ID.Split('_')[0]);
            yemekTarifiGoster.Show();
        }

        INF.yemek yemek_bilgileri(int yemek_id)
        {
            INF.yemek yemek = new INF.yemek();
            DataTable table = DBO.connection.listele("yemekler", yemek_id);
            DataRowCollection collection = table.Rows;
            foreach (DataRow row in collection)
            {

                yemek.yemek_ad = row["yemek_ad"].ToString();
                yemek.resim_adresi = row["resim_adresi"].ToString();

            }
            return yemek;
        }

        private void yemekyazdır_Load()
        {
            baglanti.Open();
            //INF.ozellikler ozellikler = new INF.ozellikler();
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = baglanti;
            cmd.CommandText = ("Select * From yemekler ORDER BY RND(-(100000*ID)*Time())");
            OleDbDataReader rd = cmd.ExecuteReader();
            List<int> listem = new List<int>() { };
            while (rd.Read())
            {
                listem.Add(Convert.ToInt32(rd["ID"]));
            }
            baglanti.Close();
            //List<int> listem = new List<int>() { 2, 3, 4, 5, 6, 7, 10, 11, 12, 13, 14, 15, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31 };
            listeleme_bilgileri.id_list = listem;
            //flow panelin boyutuna gore kac tane veri gerekiyorsa 
            // 4 bir satir, 8 iki satir, 12 uc satir olarak
            listeleme_bilgileri.goruntulenecek_veri_sayisi = 4;
            listele_fonksiyon();
        }
        public void yemekyazdır(string kategori_id)
        {
            baglanti.Open();
            //INF.ozellikler ozellikler = new INF.ozellikler();
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = baglanti;
            cmd.CommandText = ("Select * From yemekler where kategori_id=" + kategori_id);
            OleDbDataReader rd = cmd.ExecuteReader();
            List<int> listem = new List<int>() { };
            while (rd.Read())
            {
                listem.Add(Convert.ToInt32(rd["ID"]));
            }
            baglanti.Close();
            //List<int> listem = new List<int>() { 2, 3, 4, 5, 6, 7, 10, 11, 12, 13, 14, 15, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31 };
            listeleme_bilgileri.id_list = listem;
            //flow panelin boyutuna gore kac tane veri gerekiyorsa 
            // 4 bir satir, 8 iki satir, 12 uc satir olarak
            listeleme_bilgileri.goruntulenecek_veri_sayisi = 4;
            listele_fonksiyon();
        }

        INF.ozellikler ozellik_bilgileri(int yemek_id)
        {
            INF.ozellikler ozellikler = new INF.ozellikler();
            ozellikler = DBO.ozellikler.ozellik_getir(yemek_id);
            return ozellikler;
        }
        public void listele_fonksiyon()
        {
            int sayac = listeleme_bilgileri.goruntulenecek_veri_sayisi;
            for (int i = 0; i < listeleme_bilgileri.goruntulenecek_veri_sayisi; i++)
            {
                if (listeleme_bilgileri.id_list.Count > 0)
                {
                    yemek_goster(listeleme_bilgileri.id_list[0]);
                    listeleme_bilgileri.id_list.Remove(listeleme_bilgileri.id_list[0]);
                    this.Update();
                }
            }
            if (listeleme_bilgileri.id_list.Count > 0)
            {
                Button b = new Button();
                b = new benim_button().create();
                b.Click += daha_fazla_listele;
                acilisflowLayoutPanel1.Controls.Add(b);
            }
        }

        private void daha_fazla_listele(object sender, EventArgs e)
        {
            acilisflowLayoutPanel1.Controls.Remove(sender as Button);
            listele_fonksiyon();
            move_panel_smotthly();
        }

        void move_panel_smotthly()
        {
            //int y = acilisflowLayoutPanel1.VerticalScroll.Value + acilisflowLayoutPanel1.VerticalScroll.SmallChange * 30;
            for (int i = 0; i < 10; i++)
            {
                acilisflowLayoutPanel1.AutoScrollPosition = new Point(0, acilisflowLayoutPanel1.VerticalScroll.Value + 27);
                System.Threading.Thread.Sleep(50);
                this.Update();
            }
        }

        private void kategori1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            acilisflowLayoutPanel1.Controls.Clear();
            string namee = (sender as ToolStripMenuItem).Name;
            yemekyazdır(namee.Split('_')[1]);
        }

        private void kategori2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            acilisflowLayoutPanel1.Controls.Clear();
            string namee = (sender as ToolStripMenuItem).Name;
            yemekyazdır(namee.Split('_')[1]);
        }

        private void kategori3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            acilisflowLayoutPanel1.Controls.Clear();
            string namee = (sender as ToolStripMenuItem).Name;
            yemekyazdır(namee.Split('_')[1]);
        }

        private void kategori4ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            acilisflowLayoutPanel1.Controls.Clear();
            string namee = (sender as ToolStripMenuItem).Name;
            yemekyazdır(namee.Split('_')[1]);
        }

      

        

        private void filtrelemeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            YemekListeleme yemekListeleme = new YemekListeleme();
            yemekListeleme.Show();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        

        //KAPAT BUTONU
        private void pb_kapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void pb_kapat_MouseHover(object sender, EventArgs e)
        {
            pb_kapat.ImageLocation = system_klasoru + "System\\closehover.png";
        }

        private void pb_kapat_MouseLeave(object sender, EventArgs e)
        {
            pb_kapat.ImageLocation = system_klasoru + "System\\close.png";
        }
        //SON

        //KÜÇÜLT BUTONU
        private void pb_kucult_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void pb_kucult_MouseHover(object sender, EventArgs e)
        {
            pb_kucult.ImageLocation = system_klasoru + "System\\minhover.png";
        }

        private void pb_kucult_MouseLeave(object sender, EventArgs e)
        {
            pb_kucult.ImageLocation = system_klasoru + "System\\min.png";
        }

        private void pictureBox_acılıs_Click(object sender, EventArgs e)
        {
            stp.Start();
            imageBoxClickCounter++;
            if(stp.ElapsedMilliseconds < 5000)
            {
                if (imageBoxClickCounter == 3)
                {
                    adminGiris_pnl.Visible = true;
                    imageBoxClickCounter = 0;
                    adminGiris_btn.Enabled = true;
                    stp.Reset();
                }


            }
            else
            {
                stp.Stop();
                stp.Reset();
                imageBoxClickCounter = 0;
            }
        }

        

        private void adminGiris_btn_Click(object sender, EventArgs e)
        {
            if(adminSifre_tb.Text.Trim() == "neyesem")
            {
                Admin admin = new Admin();
                admin.Show();
                adminGiris_pnl.Visible = false;
                adminGiris_btn.Enabled = false;
                adminSifre_tb.ResetText();
            }
            else
            {
                MessageBox.Show("Hatalı Şifre", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            adminGiris_pnl.Visible = false;
        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            pictureBox1.ImageLocation = system_klasoru + "System\\closehover.png";
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.ImageLocation = system_klasoru + "System\\close.png";
        }

       

        private void adminSifreGoster_cb_CheckedChanged(object sender, EventArgs e)
        {
            if(adminSifreGoster_cb.Checked)
            {
                string a = adminSifre_tb.Text;
                adminSifre_tb.PasswordChar = '\0';
                adminSifre_tb.Text = a;
            }
            else
            {
                adminSifre_tb.PasswordChar = '*';
            }
        }
        //SON

    }
}
