using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.DBO;
namespace WindowsFormsApp1.FORMS
{
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }
        string system_klasoru = acilis.system_klasoru;
        private void Admin_Load(object sender, EventArgs e)
        {
            gorunurluk_gizle();
        }
        private void tab_admin_SelectedIndexChanged(object sender, EventArgs e)
        {
            temizle();
            gorunurluk_gizle();
            if (tab_admin.SelectedTab.Text == "Özellik")
            {
                cmbx_doldur_once_id(cb_ozellik, "yemekler", "yemek_ad");
                string[] menu1 = { "Tüm yemekleri hesapla" };
                //FARKLI YÖNTEMLER İLE ÖZELLİK OTOMATİK OLUŞTURULACAK
                    //"Kategori ID'ye göre hesapla",
                   // "Öğüne göre yeniden hesapla" };
                lw_yukle(lw_ozellik, menu1);
                lw_ozellik.Items[0].Selected = true;
            }
            else
            if (tab_admin.SelectedTab.Text == "Sil")
            {
                string[] menu1 = { "Kategori", "Yemek", "Malzeme" };
                lw_yukle(lw_sil_menu1, menu1);
                lw_sil_menu1.Items[0].Selected = true;
            }
        }
        void temizle()
        {
            //yemek_ekle & düzenle
            cb_yemek_duzenle.Text = "";
            cb_yemek_kategoriler.Text = "";
            cb_malzemeler.Text = "";
            txt_miktar.Text = "";
            txt_yemek_ad.Text = "";
            txt_yemek_yapilisi.Text = "";
            txt_yemek_adres.Text = "";
            lw_icindekiler.Items.Clear();
            //malzeme_ekle
            txt_malzeme_saglik_deger.Text = "";
            txt_malzeme_marka_ad.Text = "";
            txt_malzeme_fiyat.Text = "";
            txt_malzeme_bulunabilirlik_deger.Text = "";
            txt_malzeme_birim.Text = "";
            txt_malzeme_ad.Text = "";
            //kategori
            txt_kategori_ad.Text = "";
            txt_kategori_resim_adres.Text = "";
            //sil
            lw_sil_menu1.Items.Clear();
            lw_sil_menu2.Items.Clear();
            txt_sil.Text = "";
            //özellik
            lw_ozellik.Items.Clear();
            cb_ozellik.Text="";
            txt_ozellik_ogun.Text = "";
            txt_ozellik_pratiklik.Text = "";
            txt_ozellik_saglik.Text = "";
            txt_ozellik_vakit.Text = "";
            txt_ozellik_fiyat.Text = "";
            txt_ozellik_bulunabilirlik.Text = "";
            txt_ozellik_deger.Text = "";

        }
        void gorunurluk_gizle()
        {
            pnl_kategori.Visible = false;
            pnl_yemek.Visible = false;
            pnl_malzeme.Visible = false;
        }
        void lw_icerik_sil(ListView lw, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Back || (Keys)e.KeyChar == Keys.Delete)
            {
                if (lw.SelectedItems.Count > 0)
                {
                    foreach (ListViewItem lvi in lw.SelectedItems)
                    {
                        lw.Items.RemoveAt(lvi.Index);
                    }
                }
            }
        }
        void lw_ozellikler_ayarla(ListView lw)
        {
            lw.View = View.Details;
            lw.Clear();
            lw.Columns.Add("ID", 50);
            lw.Columns.Add("Malzeme Adı", 125);
            lw.Columns.Add("Miktar", 100);
        }

        //istenen tablodaki yemek, malzeme veya kategori adlarını id'si ile birlikte combobox'a ekle
        void cmbx_doldur_once_id(ComboBox cmbx, string tablo_ad, string sutun_ad)
        {
            cmbx.Items.Clear();
            DataTable table = DBO.connection.listele(tablo_ad);
            DataRowCollection collection = table.Rows;
            foreach (DataRow row in collection)
            {
                cmbx.Items.Add(row["ID"].ToString() + "_" + row[sutun_ad].ToString());
            }
        }
        void cmbx_doldur_once_ad(ComboBox cmbx, string tablo_ad, string sutun_ad)
        {
            cmbx.Items.Clear();
            DataTable table = DBO.connection.listele(tablo_ad);
            DataRowCollection collection = table.Rows;
            foreach (DataRow row in collection)
            {
                cmbx.Items.Add(row[sutun_ad].ToString() + "_" + row["ID"].ToString());
            }
        }

        //KATEGORİ EKLE
        private void kategoriEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            temizle();
            gorunurluk_gizle();
            cb_kategori_duzenle.Visible = false;
            btn_kategori_duzenle.Visible = false;
            pnl_kategori.Visible = true;
            lbl_kategori.Text = "Kategori Ekle";
        }

        private void btn_kategori_ekle_onay_Click(object sender, EventArgs e)
        {
            INF.kategoriler kategoriler = new INF.kategoriler();
            kategoriler.kategori_ad = txt_kategori_ad.Text;
            kategoriler.resim_adresi = txt_kategori_resim_adres.Text;
            if (lbl_kategori.Text == "Kategori Ekle")
            {
                if (DBO.kategoriler.kategori_ekle(kategoriler) == true)
                {
                    MessageBox.Show($"Kategori başarıyla kaydedildi!", "Bilgi!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    temizle();
                }
                else
                {
                    MessageBox.Show($"Kategori kaydedilemedi!", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else if (lbl_kategori.Text == "Kategori Düzenle")
            {
                int id = Convert.ToInt32(cb_kategori_duzenle.Text.Split('_')[1]);
                kategoriler.ID = id;
                if (DBO.kategoriler.kategori_ekle(kategoriler) == true)
                {
                    MessageBox.Show($"Kategori başarıyla kaydedildi!", "Bilgi!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    temizle();
                    cmbx_doldur_once_ad(cb_kategori_duzenle, "kategoriler", "kategori_ad");
                }
                else
                {
                    MessageBox.Show($"Kategori kaydedilemedi!", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btn_kategori_ekle_esc_Click(object sender, EventArgs e)
        {
            gorunurluk_gizle();
            temizle();
        }
        //SON

        //YEMEK EKLE
        private void btn_icindekiler_ekle_onayla_Click(object sender, EventArgs e)
        {
            try
            {
                string[] strmalzeme = cb_malzemeler.SelectedItem.ToString().Split('_');
                string malzeme_id = strmalzeme[0];
                string malzeme_adi = strmalzeme[1];
                string miktar = txt_miktar.Text;
                string[] item = { malzeme_id, malzeme_adi, miktar };
                ListViewItem lvi = new ListViewItem(item);
                lw_icindekiler.Items.Add(lvi);
                txt_miktar.Text = "";
            }
            catch(NullReferenceException nre){ }
            catch(FormatException fe) { }
        }

        private void yemekEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            temizle();
            gorunurluk_gizle();
            pnl_yemek.Visible = true;
            lbl_yemek.Text = "Yemek Ekle";
            cb_yemek_duzenle.Visible = false;
            btn_duzenle_getir.Visible = false;
            cmbx_doldur_once_id(cb_yemek_kategoriler, "kategoriler", "kategori_ad");
            cmbx_doldur_once_id(cb_malzemeler, "malzeme", "malzeme_ad");
            lw_ozellikler_ayarla(lw_icindekiler);
        }

        private void lw_icindekiler_KeyPress(object sender, KeyPressEventArgs e)
        {
            lw_icerik_sil(lw_icindekiler, e);
        }
        
        private void lw_icindekiler_DoubleClick(object sender, EventArgs e)
        {
            if (lw_icindekiler.SelectedItems.Count > 0)
            {
                txt_miktar.Text = lw_icindekiler.SelectedItems[0].SubItems[2].Text;
                cb_malzemeler.Text = lw_icindekiler.SelectedItems[0].SubItems[0].Text+"_"+lw_icindekiler.SelectedItems[0].SubItems[1].Text;
            }
        }

        private void btn_yemek_ekle_onay_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txt_yemek_ad.Text) || string.IsNullOrEmpty(cb_yemek_kategoriler.Text))
            {
                MessageBox.Show($"*Doldurulması zorunlu alanlar boş bırakılamaz.", "Bilgi!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                INF.yemek yemek = new INF.yemek();
                yemek.kategori_id = Convert.ToInt32(cb_yemek_kategoriler.Text.Split('_')[0]);
                yemek.yemek_ad = txt_yemek_ad.Text;
                yemek.yapilis_tarifi = txt_yemek_yapilisi.Text;
                yemek.resim_adresi = txt_yemek_adres.Text;
                bool tamamlandi = true;
                if (lbl_yemek.Text == "Yemek Ekle")
                {
                    if (DialogResult.Yes == MessageBox.Show($"{txt_yemek_ad.Text} kaydedilecek. Onaylıyor musunuz?", "Onay!", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                    {
                        bool eklendi = DBO.yemekler.yemek_ekle(yemek);
                        if (eklendi)
                        {
                            int ID = DBO.yemekler.yemek_tarifi_id_getir(yemek);
                            foreach (ListViewItem lvi in lw_icindekiler.Items)
                            {
                                INF.icindekiler icindekiler = new INF.icindekiler();
                                icindekiler.yemek_id = Convert.ToInt32(ID);
                                icindekiler.malzeme_id = Convert.ToInt32(lvi.SubItems[0].Text);
                                icindekiler.miktar = lvi.SubItems[2].Text;
                                if (!DBO.icindekiler.yemek_malzeme_iliskilendir(icindekiler))
                                    tamamlandi = false;
                            }
                            if (tamamlandi)
                            {
                                MessageBox.Show($"Yemek başarıyla kaydedildi!", "Bilgi!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                                MessageBox.Show($"Yemek kaydedildi, ancak bazı kısımlarda sorun oluştu.", "Bilgi!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                            MessageBox.Show($"Yemek kaydedilemedi!", "Bilgi!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else if (lbl_yemek.Text == "Yemek Düzenle")
                {
                    int ID = Convert.ToInt32(cb_yemek_duzenle.Text.Split('_')[0]);
                    yemek.ID = ID;
                    bool guncellendi = DBO.yemekler.yemek_guncelle(yemek);
                    DBO.icindekiler.yemek_iliskili_malzemeleri_sil(ID);//tüm ilişkili malzemeler silinir
                    foreach (ListViewItem lvi in lw_icindekiler.Items)
                    {
                        INF.icindekiler icindekiler = new INF.icindekiler();
                        icindekiler.yemek_id = Convert.ToInt32(ID);
                        icindekiler.malzeme_id = Convert.ToInt32(lvi.SubItems[0].Text);
                        icindekiler.miktar = lvi.SubItems[2].Text;
                        if (!DBO.icindekiler.yemek_malzeme_iliskilendir(icindekiler))
                            tamamlandi = false;
                    }
                    if (guncellendi && tamamlandi) 
                    {
                         MessageBox.Show($"Yemek başarıyla güncellendi!", "Bilgi!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else 
                    { 
                        MessageBox.Show($"Yemek güncellendi, ancak bazı kısımlarda sorun oluştu.", "Bilgi!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                cmbx_doldur_once_id(cb_yemek_duzenle, "yemekler", "yemek_ad");
                cmbx_doldur_once_id(cb_yemek_kategoriler, "kategoriler", "kategori_ad");
                cmbx_doldur_once_id(cb_malzemeler, "malzeme", "malzeme_ad");
            }
            temizle();
        }

        private void btn_yemek_ekle_temizle_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void btn_yemek_ekle_esc_Click(object sender, EventArgs e)
        {
            gorunurluk_gizle();
            temizle();
        }
        //SON

        //MALZEME EKLE
        private void malzemeEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            temizle();
            gorunurluk_gizle();
            pnl_malzeme.Visible = true;
            btn_malzeme_duzenle_getir.Visible = false;
            cb_malzeme_duzenle_getir.Visible = false;
            lbl_malzeme.Text = "Malzeme Ekle";
        }


        private void btn_malzeme_ekle_onay_Click(object sender, EventArgs e)
        {
            INF.malzeme yeni_malzeme = new INF.malzeme();
            yeni_malzeme.malzeme_ad = txt_malzeme_ad.Text;
            yeni_malzeme.marka_ad = txt_malzeme_marka_ad.Text;
            yeni_malzeme.birim = txt_malzeme_birim.Text;
            yeni_malzeme.fiyat = Convert.ToDouble(txt_malzeme_fiyat.Text).ToString("c2");
            yeni_malzeme.saglik = Convert.ToInt32(txt_malzeme_saglik_deger.Text);
            yeni_malzeme.bulunabilirlik = Convert.ToInt32(txt_malzeme_bulunabilirlik_deger.Text);
            if (lbl_malzeme.Text == "Malzeme Ekle")
            {
                if (DBO.malzeme.malzeme_ekle(yeni_malzeme))
                {
                    MessageBox.Show($"Malzeme başarıyla kaydedildi!", "Bilgi!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    temizle();
                }
                else
                {
                    MessageBox.Show($"Malzeme kaydedilemedi!", "Bilgi!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else if(lbl_malzeme.Text=="Malzeme Düzenle")
            {
                yeni_malzeme.ID = Convert.ToInt32(cb_malzeme_duzenle_getir.Text.Split('_')[1]);
                if (DBO.malzeme.malzeme_guncelle(yeni_malzeme))
                {
                    MessageBox.Show($"Malzeme başarıyla güncellendi!", "Bilgi!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    temizle();
                }
                else
                {
                    MessageBox.Show($"Malzeme güncellenemedi!", "Bilgi!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            cmbx_doldur_once_ad(cb_malzeme_duzenle_getir, "malzeme", "malzeme_ad");
        }

        private void btn_mazleme_ekle_esc_Click(object sender, EventArgs e)
        {
            gorunurluk_gizle();
            temizle();
        }
        //SON

        //YEMEK DÜZENLE
        private void yemekDuzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            temizle();
            gorunurluk_gizle();
            pnl_yemek.Visible = true;
            lbl_yemek.Text = "Yemek Düzenle";
            cb_yemek_duzenle.Visible = true;
            btn_duzenle_getir.Visible = true;
            cmbx_doldur_once_id(cb_yemek_duzenle, "yemekler", "yemek_ad");
            cmbx_doldur_once_id(cb_yemek_kategoriler, "kategoriler", "kategori_ad");
            cmbx_doldur_once_id(cb_malzemeler, "malzeme", "malzeme_ad");
            lw_ozellikler_ayarla(lw_icindekiler);
        }

        private void btn_duzenle_getir_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(cb_yemek_duzenle.Text.Split('_')[0]);
                INF.yemek yemek = DBO.yemekler.yemek_tarifi_getir(id);
                INF.kategoriler kategoriler = DBO.kategoriler.kategori_getir(yemek.kategori_id);
                cb_yemek_kategoriler.Text = $"{kategoriler.ID}_{kategoriler.kategori_ad}";
                txt_yemek_ad.Text = yemek.yemek_ad;
                txt_yemek_yapilisi.Text = yemek.yapilis_tarifi;
                txt_yemek_adres.Text = yemek.resim_adresi;
                lw_icindekiler.Items.Clear();
                List<INF.icindekiler_listeleme> icl = DBO.icindekiler.yemek_icindekiler_getir(id);
                foreach (INF.icindekiler_listeleme i in icl)
                {
                    string[] item = { i.malzeme_id.ToString(), i.malzeme_ad, i.miktar };
                    ListViewItem lvi = new ListViewItem(item);
                    lw_icindekiler.Items.Add(lvi);
                }
            }
            catch (FormatException fe)
            {}
        }
        //SON

        //MALZEME DÜZENLE
        private void malzemeDuzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            temizle();
            gorunurluk_gizle();
            pnl_malzeme.Visible = true;
            lbl_malzeme.Text = "Malzeme Düzenle";
            btn_malzeme_duzenle_getir.Visible = true;
            cb_malzeme_duzenle_getir.Visible = true;
            cmbx_doldur_once_ad(cb_malzeme_duzenle_getir, "malzeme", "malzeme_ad");
        }

        private void btn_malzeme_duzenle_getir_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(cb_malzeme_duzenle_getir.Text.Split('_')[1]);
            INF.malzeme malzeme = DBO.malzeme.malzeme_getir(id);
            txt_malzeme_ad.Text = malzeme.malzeme_ad;
            txt_malzeme_marka_ad.Text = malzeme.marka_ad;
            txt_malzeme_birim.Text = malzeme.birim;
            txt_malzeme_fiyat.Text = malzeme.fiyat.ToString();
            txt_malzeme_saglik_deger.Text = malzeme.saglik.ToString();
            txt_malzeme_bulunabilirlik_deger.Text = malzeme.bulunabilirlik.ToString();
        }

        private void txt_malzeme_fiyat_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) == false && e.KeyChar != (char)08 && e.KeyChar != (char)44)
            // text'e sadece sayıların girmesi,geri silme tuşu(ascii kodu:08),virgül(ascii kodu:44) karakterinin girilmesini sağlar.
            //del tuşununda aktif olmasını isterseniz del ascıı kodu:127
            //
            {
                e.Handled = true;
            }
            else if(e.KeyChar == (char)46)
            {
                MessageBox.Show("Lütfen kuruş bilgisi için virgül kullanınız.", "Bilgi!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        //SON

        //KATEGORİ DÜZENLE
        private void kategoriDuzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            temizle();
            gorunurluk_gizle();
            cb_kategori_duzenle.Visible = true;
            btn_kategori_duzenle.Visible = true;
            pnl_kategori.Visible = true;
            lbl_kategori.Text = "Kategori Düzenle";
            cmbx_doldur_once_ad(cb_kategori_duzenle, "kategoriler", "kategori_ad");
        }

        private void btn_kategori_duzenle_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(cb_kategori_duzenle.Text.Split('_')[1]);
            INF.kategoriler kategoriler = DBO.kategoriler.kategori_getir(id);
            txt_kategori_ad.Text = kategoriler.kategori_ad;
            txt_kategori_resim_adres.Text = kategoriler.resim_adresi;
        }
        //SON

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
        //SON
        void lw_yukle(ListView lw, string[] menu)
        {
            foreach (string e in menu)
            {
                ListViewItem lvi = new ListViewItem(e);
                lw.Items.Add(lvi);
            }
        }

        private void lw_sil_menu1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lw_sil_menu1.SelectedItems.Count>0)
            {
                lw_sil_menu2.Items.Clear();
                string secim = lw_sil_menu1.SelectedItems[0].Text;
                string[] menu2 = { $"Tüm {secim} kayıtlarını sil", 
                    $"{secim} türünde ID'ye sahip olan kaydı sil", };
                lw_yukle(lw_sil_menu2,menu2);
            }
        }

        private void btn_sil_Click(object sender, EventArgs e)
        {
            if (lw_sil_menu2.SelectedItems.Count > 0)
            {

                int id = string.IsNullOrEmpty(txt_sil.Text) ? -1 : Convert.ToInt32(txt_sil.Text);//textbox boşsa -1 ata
                string secim = lw_sil_menu1.SelectedItems[0].Text,
                    ad = "",
                    tablo_ad = secim.ToLower(), sil_komutu = "",
                    ad_getir_komutu = "";//string değerler
                if (lw_sil_menu1.SelectedItems[0].Index!=2)//kategoriler,yemekler şeklinde yazmak için
                {
                    tablo_ad += "ler";
                }
                if (lw_sil_menu2.Items[0].Selected == true)//ilgili db komutunu oluşturmak için
                {
                    sil_komutu = $"DELETE * FROM {tablo_ad}";
                    ad = "TÜM";
                }
                else if (lw_sil_menu2.Items[1].Selected == true)
                {
                    sil_komutu = $"DELETE * FROM {tablo_ad} WHERE ID=@ID";
                    ad_getir_komutu = $"SELECT * FROM {tablo_ad} WHERE ID=@ID";
                    string sutun_ad = secim.ToLower() + "_ad";
                    ad = DBO.connection.id_ve_komuta_gore_getir(id, ad_getir_komutu, sutun_ad);
                }
                if (ad == "-1" || id == -1)  
                {
                    MessageBox.Show($"Bu id değerine sahip kayıt yok.", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    string txt = ad == "TÜM" ? $"Tüm '{secim}' verilerini silmek üzeresiniz. Bu işlem geri döndürülemez. Devam edilsin mi?" : $"'{ad}' silinecek. Bu işlem geri döndürülemez. Onaylıyor musunuz?";
                    if (DialogResult.Yes == MessageBox.Show(txt, "Uyarı!", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                    {
                        bool tamamlandi = DBO.connection.id_ve_komuta_gore_sil(id, sil_komutu);
                        if (tamamlandi)
                        {
                            MessageBox.Show($"Silme işlemi uygulandı!", "Bilgi!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txt_sil.Text = "";
                        }
                    }
                }

            }
        }
        //SON

        //ÖZELLİK
        private void btn_ozellik_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(cb_ozellik.Text.Split('_')[0]);
            INF.ozellikler ozellikler = DBO.ozellikler.ozellik_getir(id);
            txt_ozellik_ogun.Text = ozellikler.ogun.ToString();
            txt_ozellik_pratiklik.Text = ozellikler.pratik.ToString();
            txt_ozellik_fiyat.Text = ozellikler.fiyat.ToString();
            txt_ozellik_saglik.Text = ozellikler.saglik.ToString();
            txt_ozellik_vakit.Text = ozellikler.vakit.ToString();
            txt_ozellik_bulunabilirlik.Text = ozellikler.bulunabilirlik.ToString();
        }

        private void btn_ozellik_onay_Click(object sender, EventArgs e)
        {
            INF.ozellikler ozellikler = new INF.ozellikler();
            int yemek_id = -1;
            try
            {
                ozellikler.yemek_id = yemek_id;
                ozellikler.ogun = Convert.ToInt32(txt_ozellik_ogun.Text);
                ozellikler.pratik = Convert.ToInt32(txt_ozellik_pratiklik.Text);
                ozellikler.fiyat = Convert.ToInt32(txt_ozellik_fiyat.Text);
                ozellikler.saglik = Convert.ToInt32(txt_ozellik_saglik.Text);
                ozellikler.vakit = Convert.ToInt32(txt_ozellik_vakit.Text);
                ozellikler.bulunabilirlik = Convert.ToInt32(txt_ozellik_bulunabilirlik.Text);
                yemek_id = (int)sender;
            }
            catch (InvalidCastException ice)
            {
                yemek_id = string.IsNullOrEmpty(cb_ozellik.Text) ? -1 : Convert.ToInt32(cb_ozellik.Text.Split('_')[0]);
                ozellikler.yemek_id = yemek_id;
            }
            catch (FormatException fe)
            {
                ozellikler.ogun = 0;
                ozellikler.pratik = 0;
                ozellikler.fiyat = 0;
                ozellikler.saglik = 0;
                ozellikler.vakit = 0;
                ozellikler.bulunabilirlik = 0;
            }
            string komut = "SELECT ID FROM ozellikler WHERE yemek_id=@yemek_id";
            OleDbCommand insertCommand;
            int id = DBO.ozellikler.ozellik_getir(yemek_id,komut).ID;
            MessageBox.Show($"YEMEK ID:{yemek_id}, ID: {id}");
            string islem = "";
            if (id > -1)
            {
                komut = "UPDATE ozellikler SET ogun=@ogun, pratik=@pratik, fiyat=@fiyat, saglik=@saglik, " +
                    "vakit=@vakit, bulunabilirlik=@bulunabilirlik WHERE yemek_id=@yemek_id";
                islem = "güncel";
            }
            else
            {
                komut = "INSERT INTO ozellikler (ogun, pratik, fiyat, saglik, vakit, bulunabilirlik, yemek_id)" +
                        "VALUES(@ogun, @pratik, @fiyat, @saglik, @vakit, @bulunabilirlik, @yemek_id)";
                islem = "ek";
            }

            insertCommand = new OleDbCommand(komut, DBO.connection.baglanti);
            insertCommand.Parameters.Add("@ogun", OleDbType.Integer).Value = ozellikler.ogun;
            insertCommand.Parameters.Add("@pratik", OleDbType.Integer).Value = ozellikler.pratik;
            insertCommand.Parameters.Add("@fiyat", OleDbType.Integer).Value = ozellikler.fiyat;
            insertCommand.Parameters.Add("@saglik", OleDbType.Integer).Value = ozellikler.saglik;
            insertCommand.Parameters.Add("@vakit", OleDbType.Integer).Value = ozellikler.vakit;
            insertCommand.Parameters.Add("@bulunabilirlik", OleDbType.Integer).Value = ozellikler.bulunabilirlik;
            insertCommand.Parameters.Add("@yemek_id", OleDbType.Integer).Value = ozellikler.yemek_id;
            if(DBO.connection.komut_calistir(insertCommand))
            {
                MessageBox.Show($"Özellik {islem}lendi!", "Bilgi!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show($"Özellik {islem}lenemedi!", "Bilgi!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void btn_ozellik_oto_onay_Click(object sender, EventArgs e)
        {
            /*
                string[] menu1 = { "Tüm yemekleri hesapla",
                    "Kategori ID'ye göre hesapla",
                    "Öğüne göre yeniden hesapla" };
            */
            string deger = string.IsNullOrEmpty(txt_ozellik_deger.Text) ? "-1" : txt_ozellik_deger.Text;

            if (lw_ozellik.Items[0].Selected == true)
            {
                //List<int> yemek_id_list = new List<int>();
                DataTable table = connection.listele("yemekler");
                DataRowCollection rc = table.Rows;
                foreach (DataRow r in rc)
                {
                    int miktar = 0;
                    int bulunabilirlik = 0;
                    int saglik = 0;
                    double fiyat = 0;

                    int yemek_id = Convert.ToInt32(r["ID"]);

                    DataTable table_i = DBO.icindekiler.malzemeid_listele_yemekidile(yemek_id);
                    DataRowCollection ri = table_i.Rows;
                    foreach (DataRow r_ii in ri)
                    {
                        DataTable table_m = connection.listele("malzeme", Convert.ToInt32(r_ii["malzeme_id"]));
                        DataRowCollection rm = table_m.Rows;
                        foreach (DataRow r_m in rm)
                        {
                            miktar++;
                            bulunabilirlik += Convert.ToInt32(r_m["bulunabilirlik"]);
                            saglik += Convert.ToInt32(r_m["saglik"]);
                            fiyat += (Convert.ToInt32(r_m["fiyat"]) * Convert.ToDouble(r_ii["miktar"]));
                        }

                    }

                    bulunabilirlik /= miktar;
                    saglik /= miktar;
                    if (bulunabilirlik > 8) bulunabilirlik = 9;
                    else if (bulunabilirlik > 6) bulunabilirlik = 7;
                    else if (bulunabilirlik > 4) bulunabilirlik = 5;
                    else if (bulunabilirlik > 2) bulunabilirlik = 3;
                    else bulunabilirlik = 1;

                    if (saglik > 8) saglik = 9;
                    else if (saglik > 6) saglik = 7;
                    else if (saglik > 4) saglik = 5;
                    else if (saglik > 2) saglik = 3;
                    else saglik = 1;
                    int fiyatt = (int)fiyat;
                    DBO.ozellikler.update_ozellikler(yemek_id, fiyatt, bulunabilirlik, saglik);
                    MessageBox.Show($"İşlem tamamlandı!", "Bilgi!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                if (deger == "-1")
                {
                    MessageBox.Show("Değer kısmı boş bırakılamaz.", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (lw_ozellik.Items[1].Selected == true)
                    {
                        MessageBox.Show("2 seçildi");

                    }
                    else if (lw_ozellik.Items[2].Selected == true)
                    {
                        MessageBox.Show("3 seçildi");

                    }
                }
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void pnl_kategori_Paint(object sender, PaintEventArgs e)
        {

        }


        //SON
    }
}
