using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_System
{
    class Account
    {
        private long accountNumber;
        private float amount;

        public long AccountNumber { get => accountNumber; set => accountNumber = value; }
        public float Amount { get => amount; set => amount = value; }
        
    }
}
