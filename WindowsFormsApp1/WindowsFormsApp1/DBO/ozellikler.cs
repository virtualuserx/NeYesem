using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.DBO
{
    class ozellikler
    {

        public static void update_ozellikler(int yemek_id,int fiyat, int bulunabilirlik, int saglik)
        {
            OleDbCommand cmd = new OleDbCommand();
            connection.open();
            cmd.Connection = connection.baglanti;
            cmd.CommandText = "update ozellikler set fiyat='" + fiyat + "',bulunabilirlik='" + bulunabilirlik + "',saglik='" + saglik + "' where yemek_id=" + yemek_id + "";
            cmd.ExecuteNonQuery();
            connection.close();
        }



        public static bool ozellik_ekle(INF.ozellikler ozellikler,string komut)
        {

            try
            {
                OleDbCommand insertCommand = new OleDbCommand(komut, connection.baglanti);
                insertCommand.Parameters.Add("@vakit", OleDbType.Integer).Value = ozellikler.vakit;
                insertCommand.Parameters.Add("@saglik", OleDbType.Integer).Value = ozellikler.saglik;
                insertCommand.Parameters.Add("@pratik", OleDbType.Integer).Value = ozellikler.pratik;
                insertCommand.Parameters.Add("@ogun", OleDbType.Integer).Value = ozellikler.ogun;
                insertCommand.Parameters.Add("@fiyat", OleDbType.Integer).Value = ozellikler.fiyat;
                insertCommand.Parameters.Add("@bulunabilirlik", OleDbType.Integer).Value = ozellikler.bulunabilirlik;
                insertCommand.Parameters.Add("@yemek_id", OleDbType.Integer).Value = ozellikler.yemek_id;
                insertCommand.Parameters.Add("@ID", OleDbType.Integer).Value = ozellikler.ID;
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
        public static INF.ozellikler ozellik_getir(int yemek_id)
        {
            INF.ozellikler ozellikler = new INF.ozellikler();
            OleDbCommand insertCommand = new OleDbCommand(
                $"SELECT * " +
                $"FROM ozellikler WHERE yemek_id=@yemek_id", connection.baglanti);

            insertCommand.Parameters.Add("@yemek_id", OleDbType.Integer).Value = yemek_id;
            connection.open();
            OleDbDataReader dr = insertCommand.ExecuteReader();
            while (dr.Read())
            {
                ozellikler.ID = Convert.ToInt32(dr["ID"]);
                ozellikler.yemek_id = Convert.ToInt32(dr["yemek_id"]);
                ozellikler.ogun = Convert.ToInt32(dr["ogun"]);
                ozellikler.pratik = Convert.ToInt32(dr["pratik"]);
                ozellikler.fiyat = Convert.ToInt32(dr["fiyat"]);
                ozellikler.saglik = Convert.ToInt32(dr["saglik"]);
                ozellikler.vakit = Convert.ToInt32(dr["vakit"]);
                ozellikler.bulunabilirlik = Convert.ToInt32(dr["bulunabilirlik"]);
            }
            connection.close();
            return ozellikler;
        }
        public static INF.ozellikler ozellik_getir(int yemek_id, string komut)
        {
            INF.ozellikler ozellikler = new INF.ozellikler();
            OleDbCommand insertCommand = new OleDbCommand(komut, connection.baglanti);

            insertCommand.Parameters.Add("@yemek_id", OleDbType.Integer).Value = yemek_id;
            ozellikler.ID = -1;
            connection.open();
            OleDbDataReader dr = insertCommand.ExecuteReader();
            while (dr.Read())
            {
                ozellikler.ID = Convert.ToInt32(dr["ID"]);
                ozellikler.yemek_id = Convert.ToInt32(dr["yemek_id"]);
                ozellikler.ogun = Convert.ToInt32(dr["ogun"]);
                ozellikler.pratik = Convert.ToInt32(dr["pratik"]);
                ozellikler.fiyat = Convert.ToInt32(dr["fiyat"]);
                ozellikler.saglik = Convert.ToInt32(dr["saglik"]);
                ozellikler.vakit = Convert.ToInt32(dr["vakit"]);
                ozellikler.bulunabilirlik = Convert.ToInt32(dr["bulunabilirlik"]);
            }
            connection.close();
            return ozellikler;
        }
        /*
        public string List<int> toplu_ozellik_guncelle(string komut)
        {

            try
            {
                OleDbCommand insertCommand = new OleDbCommand(komut, connection.baglanti);
                insertCommand.Parameters.Add("@vakit", OleDbType.Integer).Value = ozellikler.vakit;
                insertCommand.Parameters.Add("@saglik", OleDbType.Integer).Value = ozellikler.saglik;
                insertCommand.Parameters.Add("@pratik", OleDbType.Integer).Value = ozellikler.pratik;
                insertCommand.Parameters.Add("@ogun", OleDbType.Integer).Value = ozellikler.ogun;
                insertCommand.Parameters.Add("@fiyat", OleDbType.Integer).Value = ozellikler.fiyat;
                insertCommand.Parameters.Add("@bulunabilirlik", OleDbType.Integer).Value = ozellikler.bulunabilirlik;
                insertCommand.Parameters.Add("@yemek_id", OleDbType.Integer).Value = ozellikler.yemek_id;
                insertCommand.Parameters.Add("@ID", OleDbType.Integer).Value = ozellikler.ID;
                connection.open();
                insertCommand.ExecuteNonQuery();
                connection.close();
            }
            catch (Exception hata)
            {
                System.Windows.Forms.MessageBox.Show(hata.Message, "Hata!", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }*/

    }
}
