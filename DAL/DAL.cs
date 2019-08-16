﻿using System;
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
                //cls.classes = rd.GetString(5);
                //product.Id = rd.GetInt32(0);
                //product.Name = rd.GetString(1);
                //product.Price = rd.GetInt32(2);
                results.Add(cls);
            }
            cnn.Close();
            return results;
        }

        public Class GetStudentToInserrtfromDB(string ID)
        {
            //var results = new List<Class>();
            OleDbConnection cnn = new OleDbConnection();
            cnn.ConnectionString = @"Provider=SQLOLEDB;Server=DESKTOP-124IO3D;Database=University;Trusted_connection=yes;";
            cnn.Open();
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = cnn;
            cmd.CommandText = $"select * from Class where Class.ID='{ID}'";
            var rd = cmd.ExecuteReader();

            rd.Read();
            var cls = new Class();
            cls.STT = Convert.ToString(rd.GetInt32(0));
            cls.ID = rd.GetString(1);
            cls.Name = rd.GetString(2);
            cls.Sex = rd.GetString(3);
            cls.SSN = rd.GetString(4);
            cls.classes = rd.GetString(5);
            //cls.classes = rd.GetString(5);
            //product.Id = rd.GetInt32(0);
            //product.Name = rd.GetString(1);
            //product.Price = rd.GetInt32(2);
            //results.Add(cls);

            cnn.Close();
            return cls;
        }
        public void InsertSchedule(Class cls, string Code)
        {

            OleDbConnection cnn = new OleDbConnection();
            cnn.ConnectionString = @"Provider=SQLOLEDB;Server=DESKTOP-124IO3D;Database=University;Trusted_connection=yes;";
            cnn.Open();
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = cnn;

            //cmd.CommandText = $"insert into Schedule values ('{loglist.Code}', '{loglist.Name}','{loglist.classroom}','{loglist.classess}');";
            cmd.CommandText = $"insert into Schedule_Class values ('{cls.ID}', '{cls.Name}','{cls.Sex}','{cls.SSN}','{cls.classes}','{Code}');";
            cmd.ExecuteNonQuery();
            //var a = this.AddScheToDB(loglist);


            cnn.Close();
        }

        public void DeleteSchedule(string Code, string ID)
        {

            OleDbConnection cnn = new OleDbConnection();
            cnn.ConnectionString = @"Provider=SQLOLEDB;Server=DESKTOP-124IO3D;Database=University;Trusted_connection=yes;";
            cnn.Open();
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = cnn;

            //cmd.CommandText = $"insert into Schedule values ('{loglist.Code}', '{loglist.Name}','{loglist.classroom}','{loglist.classess}');";
            //cmd.CommandText = $"insert into Schedule_Class values ('{cls.ID}', '{cls.Name}','{cls.Sex}','{cls.SSN}','{cls.classes}','{Code}');";
            cmd.CommandText = $"delete from Schedule_Class where Schedule_Class.CodeSchedule='{Code}' and Schedule_Class.ID='{ID}' ;";
            cmd.ExecuteNonQuery();
            //var a = this.AddScheToDB(loglist);


            cnn.Close();
        }

        public Transcript GetFindUpdate(string code, string ID)
        {

            //var results = new List<Class>();
            OleDbConnection cnn = new OleDbConnection();
            cnn.ConnectionString = @"Provider=SQLOLEDB;Server=DESKTOP-124IO3D;Database=University;Trusted_connection=yes;";
            cnn.Open();
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = cnn;
            cmd.CommandText = $"select * from Transcript where Transcript.ID='{ID}' and Transcript.code='{code}'";
            var rd = cmd.ExecuteReader();

            rd.Read();
            var cls = new Transcript();
            cls.STT = Convert.ToString(rd.GetInt32(0));
            cls.ID = rd.GetString(1);
            cls.Code = rd.GetString(2);
            cls.Name = rd.GetString(3);
            
            cls.MidTerm = Convert.ToString(rd.GetDouble(4));
            cls.FinalTerm = Convert.ToString(rd.GetDouble(5));
            cls.Bonus = Convert.ToString(rd.GetDouble(6));
            cls.Total = Convert.ToString(rd.GetDouble(7));
            cls.Classes = rd.GetString(8);
            //cls.classes = rd.GetString(5);
            //product.Id = rd.GetInt32(0);
            //product.Name = rd.GetString(1);
            //product.Price = rd.GetInt32(2);
            //results.Add(cls);

            cnn.Close();
            return cls;
        }

        public void UpdateScore(string Code,string ID, string mid,string final,string bonus,string total)
        {
            OleDbConnection cnn = new OleDbConnection();
            cnn.ConnectionString = @"Provider=SQLOLEDB;Server=DESKTOP-124IO3D;Database=University;Trusted_connection=yes;";
            cnn.Open();
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = cnn;

            //cmd.CommandText = $"insert into Schedule values ('{loglist.Code}', '{loglist.Name}','{loglist.classroom}','{loglist.classess}');";
            //cmd.CommandText = $"insert into Schedule_Class values ('{cls.ID}', '{cls.Name}','{cls.Sex}','{cls.SSN}','{cls.classes}','{Code}');";
            cmd.CommandText = $"update Transcript set Transcript.Midterm={mid} ,Transcript.Finalterm={final},Transcript.Bonus={bonus},Transcript.total={total} where Transcript.code='{Code}' and Transcript.ID='{ID}' ;";
            cmd.ExecuteNonQuery();
            cnn.Close();
        }



        public List<Class> GetCodeShedulefromDB(string cl)
        {
            var results = new List<Class>();
            OleDbConnection cnn = new OleDbConnection();
            cnn.ConnectionString = @"Provider=SQLOLEDB;Server=DESKTOP-124IO3D;Database=University;Trusted_connection=yes;";
            cnn.Open();
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = cnn;
            cmd.CommandText = $"select * from Schedule_Class where Schedule_Class.CodeSchedule='{cl}'";
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
                //cls.classes = rd.GetString(5);
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
            cmd.CommandText = "select distinct Schedule.Code from Schedule";
            var rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                s.Add(rd.GetString(0));
            }
            return s;
        }

        public List<string> GetScoreFromDBToCombobox()
        {
            List<string> s = new List<string>();
            OleDbConnection cnn = new OleDbConnection();
            cnn.ConnectionString = @"Provider=SQLOLEDB;Server=DESKTOP-124IO3D;Database=University;Trusted_connection=yes;";
            cnn.Open();
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = cnn;
            cmd.CommandText = "select distinct Transcript.Code from Transcript";
            var rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                s.Add(rd.GetString(0));
            }
            return s;
        }

        //type =0 loi,type=1 thanh cong
        public List<Schedule> GetSchedule(string path, bool type, List<string> cls)
        {

            var result = new List<Schedule>();
            type = true;
            StreamReader reader = new StreamReader(path);

            string r = reader.ReadLine();
            string[] l = r.Split(',');

            //cls = l[0];

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
                cls.Add(M[1]);
                result.Add(sche);

            }
            reader.Close();
            return result;
        }

        public List<Transcript> GetScorefromDB(string code)
        {
            var results = new List<Transcript>();
            OleDbConnection cnn = new OleDbConnection();
            cnn.ConnectionString = @"Provider=SQLOLEDB;Server=DESKTOP-124IO3D;Database=University;Trusted_connection=yes;";
            cnn.Open();
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = cnn;
            cmd.CommandText = $"select * from Transcript where Transcript.code='{code}'";
            var rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                var cls = new Transcript();
                cls.STT = Convert.ToString(rd.GetInt32(0));
                cls.ID = rd.GetString(1);
                cls.Code = rd.GetString(2);
                cls.Name = rd.GetString(3);

                cls.MidTerm = Convert.ToString(rd.GetDouble(4));
                cls.FinalTerm = Convert.ToString(rd.GetDouble(5));
                cls.Bonus = Convert.ToString(rd.GetDouble(6));
                cls.Total = Convert.ToString(rd.GetDouble(7));
                cls.Classes = rd.GetString(8);
                //cls.classes = rd.GetString(5);
                //product.Id = rd.GetInt32(0);
                //product.Name = rd.GetString(1);
                //product.Price = rd.GetInt32(2);
                results.Add(cls);
            }
            cnn.Close();
            return results;
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

        public void AddListStudentSchedule(string classes, string code)
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

        public bool AddSchedule(string path, List<string> cls)
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
                    this.AddListStudentSchedule(loglist.classess, loglist.Code);
                }
                cnn.Close();
                return true;
            }
        }

        //type =0 loi,type=1 thanh cong
        public List<Transcript> GetScore(string path, bool type, string cls)
        {

            var result = new List<Transcript>();
            type = true;
            StreamReader reader = new StreamReader(path);

            string r = reader.ReadLine();
            string[] l = r.Split('-');

            cls = l[0];
            string Code = l[1];
            string[] p = Code.Split(',');
            string CoureseCode = p[0];


            string empty = reader.ReadLine();

            for (int i = 0; i < 1000; i++)
            {
                string s = reader.ReadLine();
                if (s == null)
                    break;
                string[] M = s.Split(',');

                var score = new Transcript();
                //kiem tra rang buoc
                if (M[0] == "" || M[1] == "" || M[2] == "" || M[3] == ""||M[4] == "" || M[5] == "" || M[6] == "")
                {
                    type = false;
                    break;

                }
                score.STT = M[0];
                score.ID = M[1];
                score.Name = M[2];
                score.MidTerm = M[3];
                score.FinalTerm = M[4];
                score.Bonus = M[5];
                score.Total = M[6];
                score.Classes = cls;
                score.Code = CoureseCode;
                
                result.Add(score);

            }
            reader.Close();
            return result;
        }

        public bool AddScore(string path, string cls)
        {
            bool type = true;
            List<DTO.Transcript> log = new List<DTO.Transcript>();
            //DAL.DAL d = new DAL.DAL();
            var list = this.GetScore(path, type, cls);
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
                    
                    
                    cmd.CommandText = $"insert into Transcript values ('{loglist.ID}', '{loglist.Code}','{loglist.Name}','{loglist.MidTerm}','{loglist.FinalTerm}','{loglist.Bonus}','{loglist.Total}','{loglist.Classes}');";

                    cmd.ExecuteNonQuery();
                }
                cnn.Close();
                return true;
            }
        }

    }
}

