using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalMachine.DB
{
    public class QuestionInt
    {
        public static void add(QuestionEntry entry)
        {
            var db = new DB();
            db.Open();
            var sql = "insert into question (question_name,question_desc,author_id,question_time) values(@question_name,@question_desc,@author_id,@question_time)";
            var table = new Hashtable();
            table["@question_name"] = entry.name;
            table["@question_desc"] = entry.description;
            table["@author_id"] = entry.authorId;
            table["@question_time"] = entry.questionTime;
            db.Execute(sql,table);
            db.Close();
        }

        internal static List<QuestionEntry> GetList(int start, int len, string searchText, int status,int requestUserId)
        {
            var sql = "select id,question_name,question_status,replys,question_time from question where 1=1";
            if (!String.IsNullOrEmpty(searchText))
                sql += String.Format(" and question_name like '%{0}%'", searchText);

            if (requestUserId > 0)
                sql += String.Format(" and author_id={0}", requestUserId);

            if (status > -1)
                sql += String.Format(" and question_status = {0}", status);

            sql += String.Format(" order by question_time desc limit {0} offset {1}", len, start);

            var db = new DB();
            db.Open();
            var rd = db.Query(sql);
            var list = new List<QuestionEntry>();
            while (rd.Read())
            {
                var entry = new QuestionEntry();
                entry.id = rd.GetInt32(0);
                entry.name = rd.GetString(1);
                entry.status = rd.GetInt32(2);
                entry.replys = rd.GetInt32(3);
                entry.questionTime = rd.GetDateTime(4);
                list.Add(entry);
            }
            rd.Close();
            db.Close();
            return list;
        }
    }

    public class QuestionEntry
    {
        public int id { get; set; }
        public String name { get; set; }
        public string description { get; set; }
        public int authorId { get; set; }

        public int replys { get; set; }
        public int status { get; set; }
        public DateTime questionTime { get; set; }

    }
}