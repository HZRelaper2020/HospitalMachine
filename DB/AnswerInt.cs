using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalMachine.DB
{
    public class AnswerInt
    {
        public static List<AnswerEntry> getByQuestionId(int questionId)
        {
            var list = new List<AnswerEntry>();
            var db = new DB();
            db.Open();
            var sql = "select T1.id,T1.answer_body,T1.answer_time,T1.answer_status,T2.username from answer T1 left join users T2 on T1.user_id = T2.id";
            sql += " where question_id = " + questionId;
            sql += " order by answer_status DESC, answer_time";

            var rd = db.Query(sql);
            while (rd.Read())
            {
                var entry =new  AnswerEntry();
                entry.id = rd.GetInt32(0);
                entry.answerBody = rd.GetString(1);
                entry.answerTime = rd.GetDateTime(2);
                entry.answerStatus = rd.GetInt32(3);
                entry.username = rd.GetString(4);
                list.Add(entry);
            }
            rd.Close();
            db.Close();
            return list;
        }

        public static void addAnswer(AnswerEntry entry)
        {
            var db = new DB();
            db.Open();
            var sql = "insert into answer(user_id,question_id,answer_body,answer_time)values(@user_id,@question_id,@answer_body,@answer_time)";
            var table = new Hashtable();
            table["@user_id"] = entry.userId;
            table["@question_id"] = entry.questionId;
            table["@answer_body"] = entry.answerBody;
            table["@answer_time"] = DateTime.Now;
            db.Execute(sql, table);
            db.Close();
        }

        internal static void setAnswerStatus(int answerId, int v)
        {
            DB db = new DB();
            db.Open();
            var sql = "update answer set answer_status="+v+" where id = " + answerId;
            db.Execute(sql);
            db.Close();
        }
    }

    public class AnswerEntry
    {
        public int id { get; set; }
        public int userId { get; set; }
        public int questionId { get; set; }
        public String answerBody{get;set;}

        public int answerStatus { get; set; }
        public DateTime answerTime { get; set; }

        public String username { get; set; }
    }
}
