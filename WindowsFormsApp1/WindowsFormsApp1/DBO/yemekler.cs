using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.DBO
{
    class yemekler
    {
        public static bool yemek_ekle(INF.yemek yemek)
        {

            try
            {
                connection.open();

                OleDbCommand insertCommand = new OleDbCommand($"INSERT INTO yemekler ([yemek_ad],[kategori_id],[yapilis_tarifi],[resim_adresi]) " +
                     $"VALUES ('{yemek.yemek_ad}','{yemek.kategori_id}','{yemek.yapilis_tarifi}','{yemek.resim_adresi}')", connection.baglanti);
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
        public static bool yemek_guncelle(INF.yemek yemek)
        {
            try
            {
                OleDbCommand insertCommand = new OleDbCommand(
                $"UPDATE yemekler " +
                $"SET yemek_ad=@yemek_ad, kategori_id=@kategori_id, yapilis_tarifi=@yapilis_tarifi, resim_adresi=@resim_adresi " +
                $"WHERE ID = @ID"
                , connection.baglanti);
                insertCommand.Parameters.Add("@yemek_ad", OleDbType.VarChar).Value = yemek.yemek_ad;
                insertCommand.Parameters.Add("@kategori_id", OleDbType.Integer).Value = yemek.kategori_id;
                insertCommand.Parameters.Add("@yapilis_tarifi", OleDbType.VarChar).Value = yemek.yapilis_tarifi;
                insertCommand.Parameters.Add("@resim_adresi", OleDbType.VarChar).Value = yemek.resim_adresi;
                insertCommand.Parameters.Add("@ID", OleDbType.Integer).Value = yemek.ID;
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
        public static int yemek_tarifi_id_getir(INF.yemek yemek)
        {
            int result = -1;
            OleDbCommand insertCommand = new OleDbCommand(
                $"SELECT ID FROM yemekler " +
                $"WHERE yemek_ad = @yemek_ad and kategori_id = @kategori_id and" +
                $" yapilis_tarifi = @yapilis_tarifi and resim_adresi = @resim_adresi"
                , connection.baglanti);
            insertCommand.Parameters.Add("@yemek_ad", OleDbType.VarChar).Value = yemek.yemek_ad;
            insertCommand.Parameters.Add("@kategori_id", OleDbType.Integer).Value = yemek.kategori_id;
            insertCommand.Parameters.Add("@yapilis_tarifi", OleDbType.VarChar).Value = yemek.yapilis_tarifi;
            insertCommand.Parameters.Add("@resim_adresi", OleDbType.VarChar).Value = yemek.resim_adresi;
            connection.open();
            OleDbDataReader dr = insertCommand.ExecuteReader();
            while (dr.Read())
            {
                result = Convert.ToInt32(dr["ID"]);
            }
            connection.close();
            return result;
        }
        public static INF.yemek yemek_tarifi_getir(int ID)
        {
            INF.yemek yemek = new INF.yemek();
            OleDbCommand insertCommand = new OleDbCommand(
                $"SELECT yemek_ad, kategori_id, yapilis_tarifi, resim_adresi " +
                $"FROM yemekler WHERE ID = @ID", connection.baglanti);

            insertCommand.Parameters.Add("@ID", OleDbType.Integer).Value = ID; 
            connection.open();
            OleDbDataReader dr = insertCommand.ExecuteReader();
            while (dr.Read())
            {
                yemek.yemek_ad = dr["yemek_ad"].ToString();
                yemek.kategori_id = Convert.ToInt32(dr["kategori_id"]);
                yemek.yapilis_tarifi = dr["yapilis_tarifi"].ToString();
                yemek.resim_adresi = dr["resim_adresi"].ToString();
            }
            connection.close();
            return yemek;
        }
    }
}
