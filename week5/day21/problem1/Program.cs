using System.Net;

namespace ConsoleApp8
{

    class Employee
    {
        static void Main(string[] args)
        {
        BankAccount account = new BankAccount("002",0);
        account.deposit(5000);
        account.withdraw(2000);

        Console.WriteLine("Current Balance = " + account.Balance);
        }
    }
}
