using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace PKK
{
    class DB
    {
        public static MySqlConnection koneksi = new MySqlConnection
            ("server=127.0.0.1; username=root; password= ; database=pkk_mufti");
        public static DataSet ds = new DataSet();
        public static MySqlDataAdapter da;
        public static MySqlCommand perintah;

        public static void crud(string query)
        {
            Console.WriteLine(query);
            ds.Tables.Clear();
            perintah = new MySqlCommand(query, koneksi);
            da = new MySqlDataAdapter(perintah);
            da.Fill(ds);
        }
        public static DataTable chart(string query)
        {
            Console.WriteLine(query);
            ds.Tables.Clear();
            perintah = new MySqlCommand(query, koneksi);
            da = new MySqlDataAdapter(perintah);
            da.Fill(ds);
            return ds.Tables[0];
        }
        public DataTable GetVisiMisi(int idPaslon)
        {
            string query = "SELECT visi, misi, proker FROM calon_pasangan WHERE id_pasangan = @id";
            MySqlCommand cmd = new MySqlCommand(query, koneksi);
            cmd.Parameters.AddWithValue("@id", idPaslon);

            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }
    }
}
