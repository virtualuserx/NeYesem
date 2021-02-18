using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;

namespace WindowsFormsApp1.DBO
{
    public static class connection
    {
        public static string baglanti_adresim = (Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\DOS\\Database2.accdb");
        public static string system_klasoru = (Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + $"\\NeYesem\\NeYesem\\IMAGES\\");
        public static OleDbConnection baglanti = new OleDbConnection($"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={baglanti_adresim}");
       //
        public static void open()
        {
            if (baglanti.State == System.Data.ConnectionState.Closed)
            {
                baglanti.Open();
            }
        }

        public static void close()
        {
            if (baglanti.State == System.Data.ConnectionState.Open)
            {
                baglanti.Close();
            }
        }

        public static DataTable listele(string tablo_name)
        {
            using (OleDbCommand selectCommand = new OleDbCommand($"SELECT * FROM {tablo_name}", baglanti))
            {
                open();
                DataTable table = new DataTable();
                OleDbDataAdapter adapter = new OleDbDataAdapter();
                adapter.SelectCommand = selectCommand;
                adapter.Fill(table);
                close();
                return table;
            }
        }

        public static DataTable listele(string tablo_name,int ID)
        {
            using (OleDbCommand selectCommand = new OleDbCommand($"SELECT * FROM {tablo_name} WHERE ID = {ID} ", baglanti))
            {
                open();
                DataTable table = new DataTable();
                OleDbDataAdapter adapter = new OleDbDataAdapter();
                adapter.SelectCommand = selectCommand;
                adapter.Fill(table);
                close();
                return table;
            }
        }
        public static bool komut_calistir(OleDbCommand insertCommand)
        {
            try
            {
                connection.open();
                insertCommand.ExecuteNonQuery();
                connection.close();
                return true;
            }
            catch (Exception hata)
            {
                System.Windows.Forms.MessageBox.Show(hata.Message, "Hata!", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }
        public static bool id_ve_komuta_gore_sil(int ID, string komut)
        {
            try
            {
                OleDbCommand insertCommand = new OleDbCommand(komut, connection.baglanti);
                insertCommand.Parameters.Add("@ID", OleDbType.Integer).Value = ID;
                connection.open();
                insertCommand.ExecuteNonQuery();
                connection.close();
                return true;
            }
            catch (Exception hata)
            {
                System.Windows.Forms.MessageBox.Show(hata.Message, "Hata!", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }
        public static string id_ve_komuta_gore_getir(int ID, string komut,string sutun_ad)
        {
            string result = "-1";
            OleDbCommand insertCommand = new OleDbCommand(komut, connection.baglanti);
            insertCommand.Parameters.Add("@ID", OleDbType.Integer).Value = ID;
            connection.open();
            OleDbDataReader dr = insertCommand.ExecuteReader();
            while (dr.Read())
            {
                result=dr[sutun_ad].ToString();
            }
            connection.close();
            return result;
        }
    }
}
