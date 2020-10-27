using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalMachine.DB
{
    public class SuggestionInt
    {
        public static void add(SuggestionEntry entry)
        {
            DB db = new DB();
            db.Open();
            var sql = String.Format("insert into suggestion(name) values('{0}')",entry.name);
            db.Execute(sql);
            db.Close();
        }
    }

    public class SuggestionEntry
    {
        public int id { get; set; }
        public String name { get; set; }

        public String description { get; set; }
    }
}
