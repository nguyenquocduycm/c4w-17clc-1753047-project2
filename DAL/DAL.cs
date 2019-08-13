using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            StreamReader reader = new StreamReader("E:\\duy\\Lập trình Windows\\Đồ án 2\\Project2\\Login.csv");
            //string l = reader.ReadToEnd();

            // int N = int.Parse(reader.ReadToEnd());
            //int N = Convert.ToInt32(l);
            
            for(int i=0;i<1000;i++)
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
            return result;
        }
    }
    
   
}
