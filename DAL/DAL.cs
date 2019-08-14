using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.IO;
using DTO;

namespace DAL
{
    public class DAL
    {
        public List<LogIn> GetLogIn()
        {
            var result = new List<LogIn>();
            //StreamReader reader = new StreamReader("Login.csv");
            StreamReader reader = new StreamReader(@"E:\duy\Lập trình Windows\Đồ án 2\Project2\Login.csv");
            //string l = reader.ReadToEnd();

            // int N = int.Parse(reader.ReadToEnd());
            //int N = Convert.ToInt32(l);

            for (int i = 0; i < 1000; i++)
            {
                string s = reader.ReadLine();
                if (s == null)
                    break;
                string[] M = s.Split(',');

                var log = new LogIn();
                log.User = M[0];
                log.Password = M[1];
                result.Add(log);

            }
            reader.Close();
            return result;
        }

        //type =0 loi,type=1 thanh cong
        public List<Class> GetClass(string path, bool type)
        {
            var result = new List<Class>();
            type = true;
            StreamReader reader = new StreamReader(@path);

            string r = reader.ReadLine();
            string[] l = r.Split(',');
            string empty = reader.ReadLine();

            for (int i = 0; i < 1000; i++)
            {
                string s = reader.ReadLine();
                if (s == null)
                    break;
                string[] M = s.Split(',');

                var cla = new Class();
                //kiem tra rang buoc
                if (M[0] == "" || M[1] == "" || M[2] == "")
                {
                    type = false;
                    break;
                }
                cla.STT = M[0];
                cla.ID = M[1];
                cla.Name = M[2];
                cla.Sex = M[3];
                cla.SSN = M[4];
                cla.classes = l[0];
                result.Add(cla);

            }
            reader.Close();
            return result;
        }

        public List<Class> GetClassfromDB(string cl)
        {
            var results = new List<Class>();
            OleDbConnection cnn = new OleDbConnection();
            cnn.ConnectionString = @"Provider=SQLOLEDB;Server=DESKTOP-124IO3D;Database=University;Trusted_connection=yes;";
            cnn.Open();
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = cnn;
            cmd.CommandText = "select * from Class where Class.Class='17HCB'";
            var rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                var cls = new Class();
                cls.STT = Convert.ToString(rd.GetInt32(0));
                cls.ID = rd.GetString(1);
                cls.Name = rd.GetString(2);
                cls.Sex = rd.GetString(3);
                cls.SSN = rd.GetString(4);
                //product.Id = rd.GetInt32(0);
                //product.Name = rd.GetString(1);
                //product.Price = rd.GetInt32(2);
                results.Add(cls);
            }
            cnn.Close();
            return results;
        }

        public Class AddStudent(Class Student)
        {


            OleDbConnection cnn = new OleDbConnection();
            cnn.ConnectionString = @"Provider=SQLOLEDB;Server=DESKTOP-124IO3D;Database=University;Trusted_connection=yes;";
            cnn.Open();
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = cnn;
            cmd.CommandText = $"insert into Class values ('{Student.ID}', '{Student.Name}','{Student.Sex}','{Student.SSN}','{Student.classes}');";
            //var id = int.Parse(cmd.ExecuteScalar().ToString());
            //Student.STT = id;
            cmd.ExecuteNonQuery();
            cnn.Close();
            return Student;
        }

        public List<string> GetClassFromDBToCombobox()
        {
            List<string> s = new List<string>();
            OleDbConnection cnn = new OleDbConnection();
            cnn.ConnectionString = @"Provider=SQLOLEDB;Server=DESKTOP-124IO3D;Database=University;Trusted_connection=yes;";
            cnn.Open();
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = cnn;
            cmd.CommandText = "select distinct Class.Class  from Class";
            var rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                s.Add(rd.GetString(0));
            }
            return s;
        }
    }
    
   
}
