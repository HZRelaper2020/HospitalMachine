using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalMachine.DB
{
    public class UserInt
    {
        public static void AddUser(UserEntry entry)
        {
            var db = new DB();
            db.Open();
            db.Execute("insert into users(username) values('xiao')");
            db.Close();
        }
        public static List<UserEntry> GetUsers()
        {
            var db = new DB();
            db.Open();
            var list = new List<UserEntry>();
            var reader = db.Query("select id from users");
            while (reader.Read())
            {
                var role = new UserEntry();
                role.id = reader.GetInt32(0);
                list.Add(role);
            }
            reader.Close();
            db.Close();
            return list;
        }



        public  class UserEntry
        {
            public int id { get; set; }
            public string emial { get; set; }

            public string username { get; set; }
            public string name { get; set; }

            public string password { get; set; }

            public int permissions { get; set; }

        }
    }
}
