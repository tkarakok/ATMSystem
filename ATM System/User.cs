using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_System
{
    class User
    {
        private string _name;
        private string _surname;
        private long _tcNo;
        private Account account;

        public string Name { get => _name; set => _name = value; }
        public string Surname { get => _surname; set => _surname = value; }
        public long TcNo { get => _tcNo; set => _tcNo = value; }
        internal Account Account { get => account; set => account = value; }
    }
}
