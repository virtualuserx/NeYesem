using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.DBO
{
    class kategoriler
    {

        public static bool kategori_ekle(INF.kategoriler kategoriler)
        {

            try
            {
                connection.open();

                OleDbCommand insertCommand = new OleDbCommand($"INSERT INTO kategoriler ([kategori_ad],[resim_adresi]) " +
                     $"VALUES ('{kategoriler.kategori_ad}','{kategoriler.resim_adresi}')", connection.baglanti);
                insertCommand.ExecuteNonQuery();

                connection.close();

                return true;


            }
            catch (Exception hata)
            {
                return false;
            }
        }
        public static bool kategori_guncelle(INF.kategoriler kategoriler)
        {
            try
            {
                OleDbCommand insertCommand = new OleDbCommand(
                $"UPDATE kategoriler " +
                $"SET kategori_ad=@kategori_ad, resim_adresi=@resim_adresi " +
                $"WHERE ID=@ID"
                , connection.baglanti);
                insertCommand.Parameters.Add("@kategori_ad", OleDbType.VarChar).Value = kategoriler.kategori_ad;
                insertCommand.Parameters.Add("@resim_adresi", OleDbType.VarChar).Value = kategoriler.resim_adresi;
                insertCommand.Parameters.Add("@ID", OleDbType.Integer).Value = kategoriler.ID;
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
        public static INF.kategoriler kategori_getir(int ID)
        {
            INF.kategoriler kategoriler = new INF.kategoriler();
            OleDbCommand insertCommand = new OleDbCommand(
                $"SELECT * " +
                $"FROM kategoriler WHERE ID = @ID", connection.baglanti);

            insertCommand.Parameters.Add("@ID", OleDbType.Integer).Value = ID;
            connection.open();
            OleDbDataReader dr = insertCommand.ExecuteReader();
            while (dr.Read())
            {
                kategoriler.kategori_ad = dr["kategori_ad"].ToString();
                kategoriler.resim_adresi = dr["resim_adresi"].ToString();
            }
            connection.close();
            return kategoriler;
        }
    }
}
