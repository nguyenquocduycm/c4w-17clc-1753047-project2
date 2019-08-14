using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Class
    {
        private string _classes;
        public string classes
        {
            get { return _classes; }
            set { _classes = value; }
        }

        private string _STT;
        public string STT
        {
            get { return _STT; }
            set { _STT = value; }
        }

        private string _ID;
        public string ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        private string _Name;
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        private string _Sex;
        public string Sex
        {
            get { return _Sex; }
            set { _Sex = value; }
        }

        private string _SSN;
        public string SSN
        {
            get { return _SSN; }
            set { _SSN = value; }
        }
    }
}
