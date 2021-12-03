using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_System
{
    class UserManager
    {
        public List<User> users = new List<User>();

        public UserManager()
        {
            for (int i = 0; i < 1; i++)
            {
                User user = new();
                Account account = new();

                user.Name = "Tunahan";
                user.Surname = "KARAKOK";
                user.TcNo = 1;

                Random newNumber = new Random();
                int accountNumber = newNumber.Next(1000, 10000);
                account.AccountNumber = accountNumber;
                user.Account = account;
                users.Add(user);
            }
        }

        

        public void AddUser()
        {
            User user = new();
            Account account = new();
            Console.WriteLine(" ENTER USER INFO ");
            Console.Write(" Please enter new user name      :");
            user.Name = Console.ReadLine();
            Console.Write(" Please enter new user surname   :");
            user.Surname = Console.ReadLine();
            Console.Write(" Please enter TC No              :");
            user.TcNo = long.Parse(Console.ReadLine());

            Random newNumber = new Random();
            int accountNumber = newNumber.Next(1000, 10000);
            account.AccountNumber = accountNumber;
            user.Account = account;
            users.Add(user);
        }

        public void GetUserInfo()
        {
            foreach (var item in users)
            {
                Console.WriteLine(item.Name);
                Console.WriteLine(item.Surname);
                Console.WriteLine(item.TcNo);
                Console.WriteLine(item.Account.AccountNumber);
                Console.WriteLine(item.Account.Amount);
            }
        }

       
    }
}
