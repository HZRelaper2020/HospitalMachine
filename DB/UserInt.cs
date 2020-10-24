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
            //var db = new DB();
            //db.Open();
            //var sql = String.Format("insert into users (username) values('{0}')",entry.username);
            //db.Execute(sql);
            //db.Close();        
        }

        public static UserEntry GetUser(string username)
        {
            var db = new DB();
            db.Open();
            var reader = db.Query(String.Format("SELECT t1.id,t1.`username`,t1.role_id,t2.`name` AS role_name,t2.`permissions` FROM users t1 LEFT JOIN roles t2 ON t1.`role_id`=t2.`id` where username='{0}'", username));
            var find = false;
            var role = new UserEntry();
            if (reader.Read())
            {
                find = true;
                role.id = reader.GetInt32(0);
                role.username = reader.GetString(1);
                role.roleId = reader.GetInt32(2);
                role.roleName = reader.GetString(3);
                role.permissions = reader.GetInt32(4);
            }

            reader.Close();
            db.Close();
            if (find)
                return role;
            return null;
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

            public int roleId { get; set; }
            public string roleName { get; set; }

            public int permissions { get; set; }

        }
    }
}
