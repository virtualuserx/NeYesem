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
using WindowsFormsApp1.FORMS;


namespace WindowsFormsApp1
{
    public partial class Kategoriler : Form
    {
        public Kategoriler()
        {
            InitializeComponent();
        }
        int i = 0;
        string[] paths = new string[19];
        
        
        public static string baglanti_adresim = (Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\BM315G19\\mp_proje_x\\WindowsFormsApp1\\WindowsFormsApp1\\DOS\\Database2.accdb");
        public static OleDbConnection baglanti = new OleDbConnection($"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={baglanti_adresim}");
        string system_klasoru = (Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + $"\\BM315G19\\mp_proje_x\\WindowsFormsApp1\\WindowsFormsApp1\\IMAGES\\");
        private void Kategoriler_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = baglanti;
            cmd.CommandText = ("Select * From kategoriler");
            OleDbDataReader rd = cmd.ExecuteReader();
            int a = 0; // It provides to the index of imagelist.
            populate();
            while (rd.Read())
            {
                ListViewItem add = new ListViewItem(" " , a);
                a++;
               add.SubItems.Add(rd["kategori_ad"].ToString());
                listViewKategoriler.Items.Add(add);
            }

            baglanti.Close();
        }
        private void populate()
        {
            try
            {
                ImageList imgs = new ImageList();
                imgs.ImageSize = new Size(100, 100);
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = baglanti;
                cmd.CommandText = ("Select * From kategoriler");
                OleDbDataReader rd = cmd.ExecuteReader();

                while (rd.Read())
                {
                    paths[i] = system_klasoru + rd["resim_adresi"].ToString();
                    imgs.Images.Add(Image.FromFile(paths[i]));
                    listViewKategoriler.SmallImageList = imgs;
                    i++;
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }



        }
    }
}
