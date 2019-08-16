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
            cmd.CommandText = $"select * from Class where Class.Class='{cl}'";
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

        public List<string> GetScheduleFromDBToCombobox()
        {
            List<string> s = new List<string>();
            OleDbConnection cnn = new OleDbConnection();
            cnn.ConnectionString = @"Provider=SQLOLEDB;Server=DESKTOP-124IO3D;Database=University;Trusted_connection=yes;";
            cnn.Open();
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = cnn;
            cmd.CommandText = "select distinct Schedule.Class from Schedule";
            var rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                s.Add(rd.GetString(0));
            }
            return s;
        }

        //type =0 loi,type=1 thanh cong
        public List<Schedule> GetSchedule(string path, bool type, string cls)
        {

            var result = new List<Schedule>();
            type = true;
            StreamReader reader = new StreamReader(path);

            string r = reader.ReadLine();
            string[] l = r.Split(',');

            cls = l[0];

            string empty = reader.ReadLine();

            for (int i = 0; i < 1000; i++)
            {
                string s = reader.ReadLine();
                if (s == null)
                    break;
                string[] M = s.Split(',');

                var sche = new Schedule();
                //kiem tra rang buoc
                if (M[0] == "" || M[1] == "" || M[2] == "" || M[3] == "")
                {
                    type = false;
                    break;
                }
                sche.STT = M[0];
                sche.Code = M[1];
                sche.Name = M[2];
                sche.classroom = M[3];
                sche.classess = l[0];

                result.Add(sche);

            }
            reader.Close();
            return result;
        }

        public List<Class> GetStudentSchedulefromDB(string Classes)
        {
            var results = new List<Class>();
            OleDbConnection cnn = new OleDbConnection();
            cnn.ConnectionString = @"Provider=SQLOLEDB;Server=DESKTOP-124IO3D;Database=University;Trusted_connection=yes;";
            cnn.Open();
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = cnn;
            cmd.CommandText = $"select * from Class where Class.Class='{Classes}';";
            var rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                var cls = new Class();
                cls.STT = Convert.ToString(rd.GetInt32(0));
                cls.ID = rd.GetString(1);
                cls.Name = rd.GetString(2);
                cls.Sex = rd.GetString(3);
                cls.SSN = rd.GetString(4);
                cls.classes = rd.GetString(5);
                //product.Id = rd.GetInt32(0);
                //product.Name = rd.GetString(1);
                //product.Price = rd.GetInt32(2);
                results.Add(cls);
            }
            cnn.Close();
            return results;
        }

        public void AddListStudentSchedule(string classes,string code)
        {
            var list = this.GetStudentSchedulefromDB(classes);
            OleDbConnection cnn = new OleDbConnection();
            cnn.ConnectionString = @"Provider=SQLOLEDB;Server=DESKTOP-124IO3D;Database=University;Trusted_connection=yes;";
            cnn.Open();
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = cnn;

            foreach (var Student in list)
            {

                //cmd.CommandText = $"insert into Schedule values ('{loglist.Code}', '{loglist.Name}','{loglist.classroom}','{loglist.classess}');";
                cmd.CommandText = $"insert into Schedule_Class values ('{Student.ID}', '{Student.Name}','{Student.Sex}','{Student.SSN}','{Student.classes}','{code}');";
                cmd.ExecuteNonQuery();
                //var a = this.AddScheToDB(loglist);

            }
            cnn.Close();
        }

        public bool AddSchedule(string path, string cls)
        {
            bool type = true;
            List<DTO.Schedule> log = new List<DTO.Schedule>();
            //DAL.DAL d = new DAL.DAL();
            var list = this.GetSchedule(path, type, cls);
            if (type == false)
            {
                return false;
            }
            else
            {
                OleDbConnection cnn = new OleDbConnection();
                cnn.ConnectionString = @"Provider=SQLOLEDB;Server=DESKTOP-124IO3D;Database=University;Trusted_connection=yes;";
                cnn.Open();
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = cnn;

                foreach (var loglist in list)
                {
                    

                    cmd.CommandText = $"insert into Schedule values ('{loglist.Code}', '{loglist.Name}','{loglist.classroom}','{loglist.classess}');";

                    cmd.ExecuteNonQuery();
                    //var a = this.AddScheToDB(loglist);
                    this.AddListStudentSchedule(loglist.classess,loglist.Code);
                }
                cnn.Close();
                return true;
            }
        }
    }
}

