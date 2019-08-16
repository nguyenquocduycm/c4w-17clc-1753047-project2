using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Schedule
    {
        private string _STT;
        public string STT
        {
            get { return _STT; }
            set { _STT = value; }
        }

        private string _Code;
        public string Code
        {
            get { return _Code; }
            set { _Code = value; }
        }

        private string _Name;
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        private string _classroom;
        public string classroom
        {
            get { return _classroom; }
            set { _classroom = value; }
        }

        private string _classess;
        public string classess
        {
            get { return _classess; }
            set { _classess = value; }
        }
    }
}

