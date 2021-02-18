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

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
        }

        private void btnYemekTarifi_Click(object sender, EventArgs e)
        {
            //FORM ÖZELLİKLERİ AYARLANACAK
            int YEMEK_ID = Convert.ToInt32(textBox1.Text);//BURAYA BU BUTONU ÇAĞIRIRKEN GETİRMEK İSTENİLEN YEMEĞİN ID'Sİ
            FORMS.YemekTarifiGoster yemekTarifiGoster = new FORMS.YemekTarifiGoster();
            yemekTarifiGoster.yemek_id = YEMEK_ID;
            yemekTarifiGoster.Show();
        }

        private void btnAdminPaneli_Click(object sender, EventArgs e)
        {
            FORMS.AdminPanel adminPanel = new FORMS.AdminPanel();
            adminPanel.Show();
        }
    }
}


