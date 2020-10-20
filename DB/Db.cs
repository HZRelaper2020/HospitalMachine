using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalMachine.DB
{
    public class DB
    {
        public static string connection = "server=192.168.5.13;port=3306;database=hospital_machine;user=root;password=123456";

        MySqlConnection con;
        public void Open()
        {
            con = new MySqlConnection(connection);
            con.Open();
        }

        public int Execute(string sql)
        {
            MySqlCommand mycmd = new MySqlCommand(sql,con);
            int ret = mycmd.ExecuteNonQuery();
            //mycmd.Dispose();
            return ret;
        }

        public MySqlDataReader Query(string sql)
        {
            MySqlCommand cmd = new MySqlCommand(sql, con);
            MySqlDataReader reader = cmd.ExecuteReader();       
            return reader;
        }

        public void Close()
        {
            con.Close();
        }
    }
}
