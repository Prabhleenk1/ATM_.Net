using System;
using System.Collections.Generic;
using System.Linq;

public class cHandler
{
    private string fName;
    private string lName;
    private int pin;
    private string cardNum;
    private double balance;

    public cHandler(string fName, string lName, int pin, string cardNum, double balance)
    {
        this.fName = fName;
        this.lName = lName;
        this.pin = pin;
        this.cardNum = cardNum;
        this.balance = balance;
    }

    public string GetFName() { return fName; }

    public string GetLName() { return lName; }

    public int GetPin() { return pin; }

    public string GetCardNum() { return cardNum; }

    public double GetBalance() { return balance; }

    public void SetBalance(double balance) { this.balance = balance; }

    public static void Main(string[] args)
    {
        void PrintOpt()
        {
            Console.WriteLine("Choose from one of the following options!!");
            Console.WriteLine("1. Withdrawal");
            Console.WriteLine("2. Deposit");
            Console.WriteLine("3. Show balance");
            Console.WriteLine("4. Exit");
        }

        void Deposit(cHandler recentUser)
        {
            Console.WriteLine("How much $$ would you like to deposit?");
            double deposit = Double.Parse(Console.ReadLine());
            recentUser.SetBalance(recentUser.GetBalance() + deposit);
            Console.WriteLine("Thank you for your $$. Your current balance is: " + recentUser.GetBalance());
        }

        void Withdrawal(cHandler recentUser)
        {
            Console.WriteLine("How much would you like to withdraw: ");
            double withdrawal = Double.Parse(Console.ReadLine());

            // Checking if user has enough money
            if (recentUser.GetBalance() < withdrawal)
            {
                Console.WriteLine("Balance not sufficient :(");
            }
            else
            {
                recentUser.SetBalance(recentUser.GetBalance() - withdrawal);
                Console.WriteLine("Good to go! Thank you :)");
            }
        }

        void Balance(cHandler recentUser)
        {
            Console.WriteLine("Current balance: " + recentUser.GetBalance());
        }

        List<cHandler> cHandlers = new List<cHandler>();
        cHandlers.Add(new cHandler("Kim", "Taehyung", 0123, "7845263198541265", 500.02));
        cHandlers.Add(new cHandler("Jungkook", "Jeon", 4561, "5126435287594021", 1000));
        cHandlers.Add(new cHandler("Kim", "Namjoon", 7854, "1025634897561246", 405.13));
        cHandlers.Add(new cHandler("Jung", "Hoseok", 8523, "6542314897560235", 220.80));
        cHandlers.Add(new cHandler("Park", "Jimin", 3987, "4569872654103598", 50));

        Console.WriteLine("Welcome to the Automated Machine");
        Console.WriteLine("Please insert your debit card: ");

        string debitCnum = "";
        cHandler recentUser;

        while (true)
        {
            try
            {
                debitCnum = Console.ReadLine();
                recentUser = cHandlers.FirstOrDefault(a => a.GetCardNum() == debitCnum);

                if (recentUser != null)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Card not recognized. Please try again");
                }
            }
            catch
            {
                Console.WriteLine("Card not recognized. Please try again");
            }
        }

        Console.WriteLine("Please enter your pin: ");

        int userPin = 0;
        while (true)
        {
            try
            {
                userPin = int.Parse(Console.ReadLine());

                if (recentUser.GetPin() != userPin)
                {
                    Console.WriteLine("Incorrect pin. Please try again");
                }
                else
                {
                    break;
                }
            }
            catch
            {
                Console.WriteLine("Card not recognized. Please try again");
            }
        }

        Console.WriteLine("Welcome " + recentUser.GetFName() + " :)");
        int option = 0;
        do
        {
            PrintOpt();
            try
            {
                option = int.Parse(Console.ReadLine());
            }
            catch
            {
                option = 0;
            }

            if (option == 1)
            {
                Withdrawal(recentUser);
            }
            else if (option == 2)
            {
                Deposit(recentUser);
            }
            else if (option == 3)
            {
                Balance(recentUser);
            }
            else if (option == 4)
            {
                break;
            }
            else
            {
                option = 0;
            }
        }
        while (option != 4);

        Console.WriteLine("Thank you");
    }
}
