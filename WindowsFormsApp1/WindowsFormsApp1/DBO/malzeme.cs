using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.DBO
{
    class malzeme
    {
       public static bool malzeme_ekle(INF.malzeme malzeme)
        {

            try
            {
               OleDbCommand insertCommand = new OleDbCommand(
                   $"INSERT INTO malzeme ([malzeme_ad],[marka_ad],[birim],[fiyat],[bulunabilirlik],[saglik]) " +
                   $"VALUES (@malzeme_ad, @marka_ad, @birim, @fiyat, @bulunabilirlik, @saglik)", connection.baglanti);
                insertCommand.Parameters.Add("@malzeme_ad", OleDbType.VarChar).Value = malzeme.malzeme_ad;
                insertCommand.Parameters.Add("@marka_ad", OleDbType.VarChar).Value = malzeme.marka_ad;
                insertCommand.Parameters.Add("@birim", OleDbType.VarChar).Value = malzeme.birim;
                insertCommand.Parameters.Add("@fiyat", OleDbType.Currency).Value = malzeme.fiyat;
                insertCommand.Parameters.Add("@bulunabilirlik", OleDbType.Integer).Value = malzeme.bulunabilirlik;
                insertCommand.Parameters.Add("@saglik", OleDbType.Integer).Value = malzeme.saglik;
                connection.open();
                insertCommand.ExecuteNonQuery();
                connection.close();
                    return true;
            }
            catch(Exception hata)
            {
                System.Windows.Forms.MessageBox.Show(hata.ToString()+hata.Message, "Hata!", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }

        }
        public static bool malzeme_guncelle(INF.malzeme malzeme)
        {
            try
            {
                OleDbCommand insertCommand = new OleDbCommand(
                $"UPDATE malzeme " +
                $"SET malzeme_ad=@malzeme_ad, marka_ad=@marka_ad, birim=@birim, " +
                $"fiyat=@fiyat, bulunabilirlik=@bulunabilirlik, saglik=@saglik " +
                $"WHERE ID=@ID"
                , connection.baglanti);
                insertCommand.Parameters.Add("@malzeme_ad", OleDbType.VarChar).Value = malzeme.malzeme_ad;
                insertCommand.Parameters.Add("@marka_ad", OleDbType.VarChar).Value = malzeme.marka_ad;
                insertCommand.Parameters.Add("@birim", OleDbType.VarChar).Value = malzeme.birim;
                insertCommand.Parameters.Add("@fiyat", OleDbType.Currency).Value = malzeme.fiyat;
                insertCommand.Parameters.Add("@bulunabilirlik", OleDbType.Integer).Value = malzeme.bulunabilirlik;
                insertCommand.Parameters.Add("@saglik", OleDbType.Integer).Value = malzeme.saglik;
                insertCommand.Parameters.Add("@ID", OleDbType.Integer).Value = malzeme.ID;
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
        public static INF.malzeme malzeme_getir(int ID)
        {
            INF.malzeme malzeme = new INF.malzeme();
            OleDbCommand insertCommand = new OleDbCommand(
                $"SELECT * " +
                $"FROM malzeme WHERE ID = @ID", connection.baglanti);
            insertCommand.Parameters.Add("@ID", OleDbType.Integer).Value = ID;
            connection.open();
            OleDbDataReader dr = insertCommand.ExecuteReader();
            while (dr.Read())
            {
                malzeme.malzeme_ad = dr["malzeme_ad"].ToString();
                malzeme.marka_ad = dr["marka_ad"].ToString();
                malzeme.birim = dr["birim"].ToString();
                malzeme.fiyat = dr["fiyat"].ToString() ;
                malzeme.bulunabilirlik = Convert.ToInt32(dr["bulunabilirlik"]);
                malzeme.saglik = Convert.ToInt32(dr["saglik"]);
            }
            connection.close();
            return malzeme;
        }
    }
}
