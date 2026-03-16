using System.Reflection.Metadata.Ecma335;

namespace ConsoleApp8
{
    class BankAccount
    {
        private String accountnumber;
        private decimal balance;
        public String Accountnumber
        {
            get
            {
                return accountnumber;
            }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Account Number is Not Null");
                }
              accountnumber=value;
            }
        }
        public  decimal Balance
        {
            get
            {
                return balance;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("balance must be grater than 0");
                }
                balance=value;
            }
        }
        public BankAccount(String accountnumber,Decimal balance)
        {
             if (String.IsNullOrWhiteSpace(accountnumber))
                {
                    Console.WriteLine("Account Number is Not Null");
                }
            if (balance <0)
                {
                  Console.WriteLine("balance must be positive");
                }
        }
        public void deposit(decimal amount)
        {
            if (amount > 0)
            {
                balance+=amount;
                Console.WriteLine("amount deposit sucess");

            }
            else
            {
                Console.WriteLine("deposit amount must be grater than 0");
            }
        }
        public void withdraw(decimal amount)
        {
          if (amount <= 0)
           {
            Console.WriteLine("Invalid withdrawal amount");
           }else if (balance > amount)
            {
                balance-=amount;
                Console.WriteLine("amount withdraw sucessed");
            }
            else
            {
                Console.WriteLine("Insufficient Balance");
            }
        }
    }
}