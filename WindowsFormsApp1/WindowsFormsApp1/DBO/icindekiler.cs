using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.DBO
{
    class icindekiler
    {

        public static DataTable malzemeid_listele_yemekidile(int yemek_id)
        {
            DataTable table = new DataTable();

            try
            {
                connection.open();
                OleDbCommand selectCommand = new OleDbCommand($"SELECT * FROM icindekiler WHERE yemek_id = {yemek_id}", connection.baglanti);
                OleDbDataAdapter adapter = new OleDbDataAdapter();
                adapter.SelectCommand = selectCommand;
                adapter.Fill(table);
                connection.close();
            }
            catch (Exception hata)
            {
                System.Windows.Forms.MessageBox.Show(hata.Message,"Hata!", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            return table;
        }

        public static bool yemek_malzeme_iliskilendir(INF.icindekiler icindekiler)
        {

            try
            {
                connection.open();

                OleDbCommand insertCommand = new OleDbCommand($"INSERT INTO icindekiler ([yemek_id],[malzeme_id],[miktar]) " +
                     $"VALUES ({icindekiler.yemek_id},{icindekiler.malzeme_id},{icindekiler.miktar})", connection.baglanti);
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
        public static bool yemek_iliskili_malzemeleri_sil(int ID)
        {
            try
            {
                OleDbCommand insertCommand = new OleDbCommand(
                $"DELETE * FROM icindekiler " +
                $"WHERE yemek_id=@yemek_id", connection.baglanti);
                insertCommand.Parameters.Add("@yemek_id", OleDbType.Integer).Value = ID;
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
        public static List<INF.icindekiler_listeleme> yemek_icindekiler_getir(int yemek_id)
        {
            List<INF.icindekiler_listeleme> icindekiler_listeleme = new List<INF.icindekiler_listeleme>();

            OleDbCommand insertCommand = new OleDbCommand(
                $"SELECT icindekiler.miktar, birim, marka_ad, malzeme_ad, malzeme_id " +
                $"FROM (icindekiler INNER JOIN malzeme ON icindekiler.malzeme_id = malzeme.ID) " +
                $"WHERE icindekiler.yemek_id = @yemek_id", connection.baglanti);
            insertCommand.Parameters.Add("@yemek_id", OleDbType.Integer).Value = yemek_id;
            connection.open();
            OleDbDataReader dr = insertCommand.ExecuteReader();
            while (dr.Read())
            {
                INF.icindekiler_listeleme temp = new INF.icindekiler_listeleme();
                temp.malzeme_id = Convert.ToInt32(dr["malzeme_id"].ToString());
                temp.malzeme_ad = dr["malzeme_ad"].ToString();
                temp.marka_ad = dr["marka_ad"].ToString();
                temp.birim = dr["birim"].ToString();
                temp.miktar = dr["miktar"].ToString() ;
                icindekiler_listeleme.Add(temp);
            }
            connection.close();

            return icindekiler_listeleme;
        }

        public static DataTable miktar(int yemek_id,int malzeme_id)
        {
            using (OleDbCommand selectCommand = new OleDbCommand($"SELECT miktar FROM icindekiler WHERE yemek_id = {yemek_id} and malzeme_id = {malzeme_id} ", connection.baglanti))
            {
                connection.open();
                DataTable table = new DataTable();
                OleDbDataAdapter adapter = new OleDbDataAdapter();
                adapter.SelectCommand = selectCommand;
                adapter.Fill(table);
                connection.close();
                return table;
            }
        }

    }
}
