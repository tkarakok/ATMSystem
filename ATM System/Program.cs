using System;

namespace ATM_System
{
    class Program
    {
        static void Main(string[] args)
        {
            UserManager userManager = new();
            StartScreen(userManager);

        }

        public static void StartScreen(UserManager userManager)
        {
            Console.WriteLine(" WELCOME TO MY BANK ");
            Console.WriteLine(" -------------------");
            Console.WriteLine(" Please select the action to be taken \n 1 - Login \n 2 - Register ");
            int input = int.Parse(Console.ReadLine());
            FirstProcess(input, userManager);
        }

        public static void FirstProcess(int input, UserManager userManager)
        {
            Console.Clear();
            switch (input)
            {
                case 1:
                    Login(userManager);
                    break;
                case 2:
                    Register(userManager);
                    break;
                default:
                    break;
            }
        }

        public static void Login(UserManager userManager)
        {
        again:
            Console.Clear();
            Console.WriteLine(" *** LOGİN SYSTEM *** \n PLEASE ENTER TC NO");
            long tcNo = long.Parse(Console.ReadLine());
            foreach (var item in userManager.users)
            {
                if (item.TcNo == tcNo)
                {
                    Console.Clear();
                    Console.WriteLine("LOGIN SUCCESSFUL \n ");
                    User user = item;
                    MainMenu(userManager, user);
                }
            }
            again2:
            Console.Clear();
            Console.WriteLine(" USER NOT FOUND OUR SYSTEM PLEASE ENTER CORRECT TC NO OR CHOOSE NEW REGİSTER \n 1 - Try Again \n 2 - Register");
            int input = int.Parse(Console.ReadLine());
            if (input == 1)
            {
                goto again;
            }
            else if (input == 2)
            {
                FirstProcess(2, userManager);
            }
            else
            {
                Console.WriteLine(" INVALID INPUT PLEASE ENTER '1' OR '2");
                goto again2;
            }

        }

        public static void Register(UserManager userManager)
        {
            Console.Clear();
            userManager.AddUser();
            Console.WriteLine(" LOGİN SYSTEM ");
            Console.WriteLine();
            StartScreen(userManager);
        }

        public static void MainMenu(UserManager userManager, User user)
        {
            Console.WriteLine(" ***** WELCOME TO {0} ***** " , user.Name);
            Console.WriteLine(" ------------------------------ ");
            Console.WriteLine(" AMOUNT : {0}", user.Account.Amount);
            Console.WriteLine(" \n Please select the action to be taken \n 1 - Withdraw \n 2 - Deposit Money \n 3 - EFT ");
            int input = int.Parse(Console.ReadLine());
            switch (input)
            {
                case 1:
                    Withdraw(userManager, user);
                    break;
                case 2:
                    DepositMoney(userManager, user);
                    break;
                case 3:
                    EFT(userManager,user);
                    break;
                default:
                    break;
            }
        }

        public static void Withdraw(UserManager userManager, User user)
        {

            Console.Clear();
            again:
            Console.WriteLine(" **** WİTHDRAW SCREEN ****");
            Console.WriteLine(" AMOUNT : {0}", user.Account.Amount);
            Console.WriteLine(" \n PLEASE ENTER THE AMOUNT YOU WANT TO WITHDRAW ");
            int amount = int.Parse(Console.ReadLine());

            again2:
            Console.Clear();
            if (amount > user.Account.Amount)
            {
                again3:
                Console.WriteLine(" insufficient balance ");
                Console.WriteLine(" please select process \n 1 - Main Menu \n 2 - New Input Amount");
                int process = Convert.ToInt32(Console.ReadLine());
                if (process == 1)
                {
                    MainMenu(userManager,user);
                }
                else if (process == 2)
                {
                    goto again;
                }
                else
                {
                    goto again3;
                }
                
            }
            else
            {
                Console.WriteLine(amount + " Confirm to withdraw money worth y/n ");
                string answer = Console.ReadLine();
                if (answer == "y")
                {
                    user.Account.Amount -= amount;
                    MainMenu(userManager, user);
                }
                else if (answer == "n")
                {
                    goto again;
                }
                else
                {
                    Console.WriteLine(" please correct input value 'y or 'n");
                    goto again2;
                }
            }

        }

        public static void DepositMoney(UserManager userManager, User user)
        {
            Console.Clear();
            Console.WriteLine(" **** DEPOSİT MONEY SCREEN ****");
            Console.WriteLine(" AMOUNT : {0}", user.Account.Amount);
            Console.WriteLine(" \n PLEASE ENTER THE AMOUNT YOU WANT TO DEPOSİT ");
            int amount = int.Parse(Console.ReadLine());

            user.Account.Amount += amount;
            Console.WriteLine(" deposit money succesfull");
            MainMenu(userManager,user);

        }

        public static void EFT(UserManager userManager, User user)
        {
            User userToSend = new();
            again:
            Console.Clear();
            Console.WriteLine(" **** DEPOSİT MONEY SCREEN ****");
            Console.WriteLine(" AMOUNT : {0}", user.Account.Amount);
            Console.WriteLine(" \n ENTER THE TC NO YOU WISH TO SEND MONEY");
            long tcNo = long.Parse(Console.ReadLine());

            foreach (var item in userManager.users)
            {
                if (item.TcNo == tcNo)
                {
                    userToSend = item;
                    goto again3;
                }
            }
            again2:
            Console.WriteLine(tcNo + " user not found please select process \n 1- Try Again 2 - Back To Menu");
            int select = Convert.ToInt32(Console.ReadLine());
            if (select == 1)
            {
                goto again;
            }
            else if (select == 2)
            {
                MainMenu(userManager, user);
            }
            else
            {
                goto again2;
            }

            again3:
            Console.WriteLine(userToSend.TcNo + " how much money do you want to send");
            int amount = Convert.ToInt32(Console.ReadLine());

            if (user.Account.Amount < amount)
            {
                Console.WriteLine(" insufficient balance ");
            }
            else
            {
                user.Account.Amount -= amount;
                userToSend.Account.Amount += amount;
                Console.Clear();
                Console.WriteLine(" YOU SEND {0} TRY TO {1} !!", amount, userToSend.TcNo);
                Console.WriteLine();
                MainMenu(userManager, user);
            }
        }

        


    }
}
