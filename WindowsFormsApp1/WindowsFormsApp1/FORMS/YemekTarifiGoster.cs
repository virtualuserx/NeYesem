using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.FORMS
{
    public partial class YemekTarifiGoster : Form
    {
        public int yemek_id { get; set; }
        public INF.yemek yemek;
        string system_klasoru = DBO.connection.system_klasoru;
        List<string> yapilis_tarifi = new List<string>();
        int yapilis_tarifi_index;
        public YemekTarifiGoster()
        {
            InitializeComponent();
        }
        public List<string> yapilis_tarifi_adimlar(string yapilis_tarifi)
        {
            List<string> _yapilis_tarifi = new List<string>();
            string desen = "(\\w|\\s|,|;|:|\\(|\\))*(\\.)+\\*";
            yapilis_tarifi = string.IsNullOrEmpty(yapilis_tarifi) ? "" : yapilis_tarifi;
            MatchCollection mc = Regex.Matches(yapilis_tarifi,desen);
            foreach (Match m in mc)
            {
                _yapilis_tarifi.Add(m.ToString().Substring(0, m.Length-1));
            }
            return _yapilis_tarifi;
        }
        public string ToCapitalize(string str)//verilen string'in ilk harfini büyük olarak döndürür
        {
            return (!string.IsNullOrEmpty(str)) ? char.ToUpper(str[0]) + str.Substring(1) : "";
        }

        public void icindekiler_olustur(List<INF.icindekiler_listeleme> icindekiler_listeleme)
        {
            lbl_icindekiler.Text = "";
            foreach (INF.icindekiler_listeleme malzeme in icindekiler_listeleme)
            {
                lbl_icindekiler.Text += $"• {malzeme.miktar} {malzeme.birim.ToLower()} {ToCapitalize(malzeme.marka_ad)} {ToCapitalize(malzeme.malzeme_ad.Split('[')[0])}\n";
            }
        }
        public string tarif(List<string> yapilis_tarifi)
        {
            string temp = "";
            for (int i = 0; i < yapilis_tarifi.Count; i++)
            {
                temp += $"• {yapilis_tarifi.ElementAt(i)} \n";
            }
            return temp;
        }
        private void YemekTarifiGoster_Load(object sender, EventArgs e)
        {
            yemek = DBO.yemekler.yemek_tarifi_getir(yemek_id);
            if(string.IsNullOrEmpty(yemek.yemek_ad))
            {
                MessageBox.Show("Yemek tarifi bulunamadı.", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            List<INF.icindekiler_listeleme> icindekiler_listeleme = DBO.icindekiler.yemek_icindekiler_getir(yemek_id);
            icindekiler_olustur(icindekiler_listeleme);
            yapilis_tarifi = yapilis_tarifi_adimlar(yemek.yapilis_tarifi);//global yapilis tarifine atama
            lbl_adim_no.Text = $"1.Adım";
            lbl_adim_yazi.Text = yapilis_tarifi.Count > 0 ? yapilis_tarifi.ElementAt(0) : "";
            lbl_yemek_ad.Text = string.IsNullOrEmpty(yemek.yemek_ad) ? "Tarif bulunamadı." : yemek.yemek_ad;
            lbl_yapilis_tarifi.Text = string.IsNullOrEmpty(yemek.yapilis_tarifi) ? "" : tarif(yapilis_tarifi);
            pb_resim_adresi.ImageLocation = system_klasoru + yemek.resim_adresi;
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
        //SON

        //SAĞ OK BUTONU
        private void pb_ok_sag_Click(object sender, EventArgs e)
        {
            try
            {
                int max = yapilis_tarifi.Count;
                yapilis_tarifi_index = (yapilis_tarifi_index < max - 1) ? ++yapilis_tarifi_index : 0;
                lbl_adim_no.Text = $"{yapilis_tarifi_index + 1}.Adım";
                lbl_adim_yazi.Text = yapilis_tarifi.ElementAt(yapilis_tarifi_index);
            }
            catch{}
        }

        private void pb_ok_sag_MouseHover(object sender, EventArgs e)
        {
            pb_ok_sag.ImageLocation = system_klasoru + "System\\righthover.png";
        }

        private void pb_ok_sag_MouseLeave(object sender, EventArgs e)
        {
            pb_ok_sag.ImageLocation = system_klasoru + "System\\right.png";
        }
        //SON

        //SOL OK BUTONU
        private void pb_ok_sol_Click(object sender, EventArgs e)
        {
            try
            {
                yapilis_tarifi_index = (yapilis_tarifi_index < 1) ? yapilis_tarifi.Count - 1 : --yapilis_tarifi_index;
                lbl_adim_no.Text = $"{yapilis_tarifi_index + 1}.Adım";
                lbl_adim_yazi.Text = yapilis_tarifi.ElementAt(yapilis_tarifi_index);
            }
            catch{}
        }
        private void pb_ok_sol_MouseHover(object sender, EventArgs e)
        {
            pb_ok_sol.ImageLocation = system_klasoru + "System\\lefthover.png";
        }

        private void pb_ok_sol_MouseLeave(object sender, EventArgs e)
        {
            pb_ok_sol.ImageLocation = system_klasoru + "System\\left.png";
        }

        private void pb_resim_adresi_Click(object sender, EventArgs e)
        {

        }

        private void lbl_adim_no_Click(object sender, EventArgs e)
        {

        }

       

        private void lbl_yemek_ad_Click(object sender, EventArgs e)
        {

        }
        //SON
    }
}
