using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalMachine.DB
{
    public class ConfigsInt
    {
        public static String getValue(String key)
        {
            DB db = new DB();
            db.Open();
            var ret = "";
            var sql = String.Format("select config_value from configs where config_key='{0}'",key);
            var rd = db.Query(sql);
            if (rd.Read())
            {
                ret = rd.GetString(0);
            }
            rd.Close();
            db.Close();

            return ret;
        }
    }

    public class ConfigsEntry
    {
        public String configName { get; set; }
        public String configValue { get; set; }
    }
}
