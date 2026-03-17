using System.ComponentModel;

namespace ConsoleApp8
{  
    public class InsufficientBalanceException : Exception
    {
        public InsufficientBalanceException(string message) : base(message)
        {
        }
    }

    public class BankAccount
    {
        private double balance;

        public BankAccount(double balance)
        {
            this.balance = balance;
        }

        public void Withdraw(double amount)
        {
            if (amount > balance)
            {
                throw new InsufficientBalanceException("Withdrawal amount exceeds available balance");
            }

            balance -= amount;
            Console.WriteLine($"Withdrawal successful! Remaining Balance: {balance}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Enter Balance: ");
                double balance = double.Parse(Console.ReadLine());

                Console.Write("Enter Withdraw Amount: ");
                double amount = double.Parse(Console.ReadLine());

                BankAccount account = new BankAccount(balance);

                account.Withdraw(amount);
            }
            catch (InsufficientBalanceException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                Console.WriteLine("Transaction process completed.");
            }
        }
    }
}


