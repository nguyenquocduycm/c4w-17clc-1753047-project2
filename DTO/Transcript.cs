using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Transcript
    {
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

        private string _Classes;
        public string Classes
        {
            get { return _Classes; }
            set { _Classes = value; }
        }

        private string _MidTerm;
        public string MidTerm
        {
            get { return _MidTerm; }
            set { _MidTerm = value; }
        }

        private string _FinalTerm;
        public string FinalTerm
        {
            get { return _FinalTerm; }
            set { _FinalTerm = value; }
        }

        private string _Bonus;
        public string Bonus
        {
            get { return _Bonus; }
            set { _Bonus = value; }
        }

        private string _Total;
        public string Total
        {
            get { return _Total; }
            set { _Total = value; }
        }
    }
}
