using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BUS
{
    public class BUS
    {
        public bool AddListStudent(string path)
        {
            
            bool type = true; ;
            List<DTO.Class> log = new List<DTO.Class>();
            DAL.DAL d = new DAL.DAL();
            var list = d.GetClass(path, type);
            if (type == false)
            {
                return false;
            }
            else
            {
                foreach (var loglist in list)
                {
                    var a=d.AddStudent(loglist);
                }
                return true;
            }
        }

        public void AddSchedule(string Code, string ID)
        {
            DAL.DAL d = new DAL.DAL();
            var newStudent=d.GetStudentToInserrtfromDB(ID);
            d.InsertSchedule(newStudent, Code);
        }

        public void DeleteSchedule(string Code,string ID)
        {
            DAL.DAL d = new DAL.DAL();
            //var newStudent = d.GetStudentToInserrtfromDB(ID);
            d.DeleteSchedule(Code, ID);
        }


        
        public string GetCLassfromPath(string s)
        {
            //string m;
            char[] a = s.ToCharArray();
            for(int i=a.Length-1;i>0;i--)
            {
                if(a[i].ToString()==@"\")
                {
                    return s.Substring(i + 1, a.Length - i-5);
                }
            }
            return null; 
        }
        
        
    }
}
