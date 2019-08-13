using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class LogIn
    {
        private string _User;
        public string User
        {
            get { return _User; }
            set { _User = value; }
        }
        private string _Password;
        public string Password
        {
            get { return _Password; }
            set { _Password = value; }
        }
        /*
        public LogIn(string user,string pass)
        {
            this._User = user;
            this._Password = pass;
        }
        */
    }
}
