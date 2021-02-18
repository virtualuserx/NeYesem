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
using WindowsFormsApp1.INF;


namespace WindowsFormsApp1.FORMS
{
    public partial class YemekListeleme : Form
    {
        public YemekListeleme()
        {
            InitializeComponent();
        }
        bool kahvalti = false, oglen = false, aksam = false;
        public static string baglanti_adresim = DBO.connection.baglanti_adresim;
        OleDbConnection baglanti = new OleDbConnection($"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={baglanti_adresim}");
        string system_klasoru = DBO.connection.system_klasoru;
      
        private void YemekListeleme_Load(object sender, EventArgs e)
        {
            filtrele.pratik_ = 9;
            filtrele.saglik_ = 9;
            filtrele.fiyat_ = 100;
            filtrele.vakit_ = 150;
            filtrele.bulunabilirlik_ = 9;
            //Filtrelenmislisteleme_Load();
           
        }
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
                lb.Font = new System.Drawing.Font("Corbel", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
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
            string resim_adresi = system_klasoru + yemek.resim_adresi;
            PictureBox picture = new benim_picturebox().create(ID, resim_adresi);
            picture.Click += yemek_click;
            pnl_yemek_new.Controls.Add(picture);
            pnl_yemek_new.Controls.Add(pnl_yemek_ozellikler_new);


            flowLayout_pnl_yemekler.Controls.Add(pnl_yemek_new);
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
            //MessageBox.Show(ID.Split('_')[0]);
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




        /*while (rd.Read())             SİLMEYİNİZ!!!
        {
            for (int i = 0; i < ozellikListem.Count; i++)
            {
                for (int j = 1; j < ozellikListem.Count - 1; j++)
                {
                    if(Math.Abs(ozellikListem[i] - seciliOzellikler) <= Math.Abs(ozellikListem[j] - seciliOzellikler))
                    {
                        if (Convert.ToInt32(rd["ogun"]) == 1)
                            listem.Add(Convert.ToInt32(rd["yemek_id"]));
                    }
                }

            }

        }*/
        class NodeListem
        {
            Node head = null;
            List<int> listem_sortedid = new List<int>();

            public void node_ekle(Node n)
            {

                if (head == null)
                {
                    head = n;
                }
                else
                {
                    ekle(head, n);
                }
            }

            public void ekle(Node parent, Node n)
            {
                if (n.puan <= parent.puan)
                {
                    if (parent.left == null)
                    {
                        parent.left = n;
                    }
                    else
                    {
                        ekle(parent.left, n);
                    }
                }
                else
                {
                    if (parent.right == null)
                    {
                        parent.right = n;
                    }
                    else
                    {
                        ekle(parent.right, n);
                    }
                }
            }

            public List<int> sirala()
            {
                sirala_into_array(head);
                return listem_sortedid;
            }

            void sirala_into_array(Node n)
            {
                if (n != null)
                {
                    sirala_into_array(n.left);
                    listem_sortedid.Add(n.ID);
                    sirala_into_array(n.right);
                }

            }

        }
        class Node
        {
            public int ID;
            public double puan;
            public Node left = null;
            public Node right = null;

            public Node(int id, double p)
            {
                ID = id;
                puan = p;
            }
        }
        private void Filtrelenmislisteleme_Load()
        {
            baglanti.Open();
            //INF.ozellikler ozellikler = new INF.ozellikler();
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = baglanti;
            cmd.CommandText = ("Select * From ozellikler where fiyat<= "+INF.filtrele.fiyat_+" and vakit <="+INF.filtrele.vakit_);
            OleDbDataReader rd = cmd.ExecuteReader();
            NodeListem listem = new NodeListem();
            if (kahvalti && oglen == false && aksam == false)
            {
                while(rd.Read())
                {
                    if (Convert.ToInt32(rd["ogun"]) == 1) { 
                        int id = Convert.ToInt32(rd["yemek_id"]);
                        double islem = Math.Pow(INF.filtrele.pratik_ - Convert.ToInt32(rd["pratik"]), 2) +
                            Math.Pow(INF.filtrele.bulunabilirlik_ - Convert.ToInt32(rd["bulunabilirlik"]), 2) +
                            Math.Pow(INF.filtrele.saglik_ - Convert.ToInt32(rd["saglik"]), 2);
                        int puan = (int)Math.Sqrt(islem);
                        listem.node_ekle(new Node(id, puan));
                    }

                }
            }
            else if (oglen && aksam == false && kahvalti == false)
            {
                while (rd.Read())
                {
                    if (Convert.ToInt32(rd["ogun"]) == 2)
                    {
                        int id = Convert.ToInt32(rd["yemek_id"]);
                        double islem = Math.Pow(INF.filtrele.pratik_ - Convert.ToInt32(rd["pratik"]), 2) +
                            Math.Pow(INF.filtrele.bulunabilirlik_ - Convert.ToInt32(rd["bulunabilirlik"]), 2) +
                            Math.Pow(INF.filtrele.saglik_ - Convert.ToInt32(rd["saglik"]), 2);
                        double puan = Math.Sqrt(islem);
                        listem.node_ekle(new Node(id, puan));
                    }
                }
            }
            else if(aksam && kahvalti == false && oglen == false)
            {
                while (rd.Read())
                {
                    if (Convert.ToInt32(rd["ogun"]) == 3)
                    {
                        int id = Convert.ToInt32(rd["yemek_id"]);
                        double islem = Math.Pow(INF.filtrele.pratik_ - Convert.ToInt32(rd["pratik"]), 2) +
                            Math.Pow(INF.filtrele.bulunabilirlik_ - Convert.ToInt32(rd["bulunabilirlik"]), 2) +
                            Math.Pow(INF.filtrele.saglik_ - Convert.ToInt32(rd["saglik"]), 2);
                        int puan = (int)Math.Sqrt(islem);
                        listem.node_ekle(new Node(id, puan));
                    }
                }
            }
            else if(kahvalti && oglen && aksam == false)
            {
                while (rd.Read())
                {
                    if (Convert.ToInt32(rd["ogun"]) == 1 || Convert.ToInt32(rd["ogun"]) == 2)
                    {
                        int id = Convert.ToInt32(rd["yemek_id"]);
                        double islem = Math.Pow(INF.filtrele.pratik_ - Convert.ToInt32(rd["pratik"]), 2) +
                            Math.Pow(INF.filtrele.bulunabilirlik_ - Convert.ToInt32(rd["bulunabilirlik"]), 2) +
                            Math.Pow(INF.filtrele.saglik_ - Convert.ToInt32(rd["saglik"]), 2);
                        int puan = (int)Math.Sqrt(islem);
                        listem.node_ekle(new Node(id, puan));
                    }
                }
            }
            else if(kahvalti && aksam && oglen == false)
            {
                while (rd.Read())
                {
                    if (Convert.ToInt32(rd["ogun"]) == 1 || Convert.ToInt32(rd["ogun"]) == 3)
                    {
                        int id = Convert.ToInt32(rd["yemek_id"]);
                        double islem = Math.Pow(INF.filtrele.pratik_ - Convert.ToInt32(rd["pratik"]), 2) +
                            Math.Pow(INF.filtrele.bulunabilirlik_ - Convert.ToInt32(rd["bulunabilirlik"]), 2) +
                            Math.Pow(INF.filtrele.saglik_ - Convert.ToInt32(rd["saglik"]), 2);
                        int puan = (int)Math.Sqrt(islem);
                        listem.node_ekle(new Node(id, puan));
                    }
                }
            }
            else if(oglen && aksam && kahvalti == false)
            {
                while (rd.Read())
                {
                    if (Convert.ToInt32(rd["ogun"]) == 2 || Convert.ToInt32(rd["ogun"]) == 3)
                    {
                        int id = Convert.ToInt32(rd["yemek_id"]);
                        double islem = Math.Pow(INF.filtrele.pratik_ - Convert.ToInt32(rd["pratik"]), 2) +
                            Math.Pow(INF.filtrele.bulunabilirlik_ - Convert.ToInt32(rd["bulunabilirlik"]), 2) +
                            Math.Pow(INF.filtrele.saglik_ - Convert.ToInt32(rd["saglik"]), 2);
                        int puan = (int)Math.Sqrt(islem);
                        listem.node_ekle(new Node(id, puan));
                    }
                }
            }
            else if (kahvalti && oglen && aksam)
            {
                while (rd.Read())
                {
                    if (Convert.ToInt32(rd["ogun"]) == 2 || Convert.ToInt32(rd["ogun"]) == 3 || Convert.ToInt32(rd["ogun"]) == 1)
                    {

                        int id = Convert.ToInt32(rd["yemek_id"]);
                        double islem = Math.Pow(INF.filtrele.pratik_ - Convert.ToInt32(rd["pratik"]), 2) +
                            Math.Pow(INF.filtrele.bulunabilirlik_ - Convert.ToInt32(rd["bulunabilirlik"]), 2) +
                            Math.Pow(INF.filtrele.saglik_ - Convert.ToInt32(rd["saglik"]), 2);
                        int puan = (int)Math.Sqrt(islem);
                        listem.node_ekle(new Node(id, puan));
                    }
                }
            }

            baglanti.Close();
            listeleme_bilgileri.id_list = listem.sirala();
            listeleme_bilgileri.goruntulenecek_veri_sayisi = 4;
            listele_fonksiyon();
        }

        INF.ozellikler ozellik_bilgileri(int yemek_id)
        {
            INF.ozellikler ozellikler = DBO.ozellikler.ozellik_getir(yemek_id);
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
                flowLayout_pnl_yemekler.Controls.Add(b);
            }
        }

        private void daha_fazla_listele(object sender, EventArgs e)
        {
            flowLayout_pnl_yemekler.Controls.Remove(sender as Button);
            listele_fonksiyon();
            move_panel_smotthly();
        }

        void move_panel_smotthly()
        {
            //int y = flowLayout_pnl_yemekler.VerticalScroll.Value + flowLayout_pnl_yemekler.VerticalScroll.SmallChange * 30;
            for (int i = 0; i < 10; i++)
            {
                flowLayout_pnl_yemekler.AutoScrollPosition = new Point(0, flowLayout_pnl_yemekler.VerticalScroll.Value + 27);
                System.Threading.Thread.Sleep(50);
                this.Update();
            }
        }

        private void Pratik_trackbar_Scroll(object sender, EventArgs e)
        {
            filtrele.pratik_ = (Pratik_trackbar.Value * 2 + 1);
        }

        private void Fiyat_trackbar_Scroll(object sender, EventArgs e)
        {
            filtrele.fiyat_ = ((Fiyat_trackbar.Value == 4) ? 10000 :
                (Fiyat_trackbar.Value == 3) ? 5000 :
                (Fiyat_trackbar.Value == 2) ? 2500 :
                (Fiyat_trackbar.Value == 1) ? 1200 : 600);
        }

        private void Bulunabilirlik_trackbar_Scroll(object sender, EventArgs e)
        {
            filtrele.bulunabilirlik_ = (Bulunabilirlik_trackbar.Value * 2 + 1);
        }

        private void Vakit_trackbar_Scroll(object sender, EventArgs e)
        {
            filtrele.vakit_ = (Vakit_trackbar.Value * 30 + 10);
        }

        private void Saglik_trackbar_Scroll(object sender, EventArgs e)
        {
            filtrele.saglik_ = (Saglik_trackbar.Value * 2 + 1);
        }

        private void Listele_button_Click(object sender, EventArgs e)
        {
            flowLayout_pnl_yemekler.Controls.Clear();
            if (Kahvalti_checkbox.Checked && Oglen_checkbox.Checked == false && Aksam_checkbox.Checked == false)
            {
                kahvalti = true;
                aksam = false;
                oglen = false;
            }
            else if(Oglen_checkbox.Checked && Kahvalti_checkbox.Checked == false && Aksam_checkbox.Checked == false)
            {
                oglen = true;
                kahvalti = false;
                aksam = false;
            }
            else if(Aksam_checkbox.Checked && Oglen_checkbox.Checked == false && Kahvalti_checkbox.Checked == false)
            {
                aksam = true;
                oglen = false;
                kahvalti = false;

            }
            else if(Kahvalti_checkbox.Checked && Oglen_checkbox.Checked && Aksam_checkbox.Checked == false)
            {
                kahvalti = true;
              
                oglen = true;

                aksam = false;
                
            }
            else if(Kahvalti_checkbox.Checked && Aksam_checkbox.Checked && Oglen_checkbox.Checked == false)
            {
                kahvalti = true;
                
                aksam = true;

                oglen = false;

                
            }
            else if(Oglen_checkbox.Checked && Aksam_checkbox.Checked && Kahvalti_checkbox.Checked == false)
            {
                oglen = true;
                aksam = true;
                kahvalti = false;
            } 
            else if(Oglen_checkbox.Checked && Aksam_checkbox.Checked && Kahvalti_checkbox.Checked)
            {
                oglen = true;
                aksam = true;
                kahvalti = true;
            }
            else if (Hepsi_checkbox.Checked)
            {
                oglen = true;
                aksam = true;
                kahvalti = true;
            }
            else if(Kahvalti_checkbox.Checked == false)
            {
                kahvalti = false;
            }
            else if(Oglen_checkbox.Checked == false)
            {
                oglen = false;
            }
            else if(Aksam_checkbox.Checked == false)
            {
                aksam = false;
            }

            Filtrelenmislisteleme_Load();
           
        }

        private void Temizle_button_Click(object sender, EventArgs e)
        {
          
            Kahvalti_checkbox.Checked = false;
            Oglen_checkbox.Checked = false;
            Aksam_checkbox.Checked = false;
            Hepsi_checkbox.Checked  = false;
            kahvalti = false;
            oglen = false;
            aksam = false;
            flowLayout_pnl_yemekler.Controls.Clear();

        }

        private void Ogun_panel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Kahvalti_checkbox_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void Oglen_checkbox_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void pb_kucult_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pb_kapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void flowLayout_pnl_yemekler_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pb_kapat_MouseHover(object sender, EventArgs e)
        {
            pb_kapat.ImageLocation = system_klasoru + "System\\closehover.png";
        }

        private void pb_kapat_MouseLeave(object sender, EventArgs e)
        {
            pb_kapat.ImageLocation = system_klasoru + "System\\close.png";
        }

        private void pb_kucult_MouseHover(object sender, EventArgs e)
        {
            pb_kucult.ImageLocation = system_klasoru + "System\\minhover.png";
        }

        private void pb_kucult_MouseLeave(object sender, EventArgs e)
        {
            pb_kucult.ImageLocation = system_klasoru + "System\\min.png";
        }

        private void Aksam_checkbox_CheckedChanged(object sender, EventArgs e)
        {
       
        }

        private void Hepsi_checkbox_CheckedChanged(object sender, EventArgs e)
        {
           
        }
    }
}
