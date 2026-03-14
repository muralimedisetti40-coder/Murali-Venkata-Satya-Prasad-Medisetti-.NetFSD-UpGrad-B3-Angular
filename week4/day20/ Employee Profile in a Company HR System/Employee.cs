namespace ConsoleApp8
{
    internal class Employee
    {
        private String fullname;
        private decimal salary;
        private int age;
        private String employeeid;
        public String Fullname
        {
            get
            {
                return fullname;
            }
            set
            {
             if (String.IsNullOrEmpty(value))
            {
             throw new ArgumentException("name cannot be empty");
            }
                fullname= value.Trim();
            }
        }
        public decimal Salary
        {
            get
            {
                return salary;
            }
             private set
            {
                if (value < 1000)
                {
                    throw new ArgumentException("slaary must be grater than 1000");
                }
                salary=value;
            }
        }
        public int Age
        {
            get
            {
                return age;
            }
            set
            {
                if (value < 18 || value > 80)
                {
                    throw new ArgumentException("enter valid age");
                }
                age=value;
            }
        }
        public String Employeeid
        {
            get { return employeeid;}
        }
        public Employee(String fullname,decimal salary,int age,String employeeid=null)
        {
            if (String.IsNullOrEmpty(fullname))
            {
             throw new ArgumentException("name cannot be empty");
            }
            if (age < 18 || age > 80)
                {
                    throw new ArgumentException("enter valid age");
                }
            if (salary < 1000)
                {
                    throw new ArgumentException("slaary must be grater than 1000");
                }
            if (string.IsNullOrWhiteSpace(employeeid))
            {
                this.employeeid = "E" + Guid.NewGuid().ToString("N").Substring(0, 5);
            }
            else
            {
                this.employeeid = employeeid;
            }
            Fullname=fullname;
            Age=age;
            Salary=salary;
        }
     public void GiveRaise(decimal persent)
        {
            if (persent <= 0 || persent > 30)
            {
                Console.WriteLine("Raise persentage must be between 0 and 30");
            }
            Salary=Salary+(Salary*persent/100);
            Console.WriteLine($"salary increased by{persent} persentage after raise salary{salary.ToString("F2")}");
        }
     public bool DeductPenality(decimal amount)
        {
            if (amount < 0)
            {
                Console.WriteLine("penality amount must be grater than 0");
                return false;
            }
            if (Salary - amount < 1000)
            {
               Console.WriteLine("after deductpenality the salary was below 1000");
                return false;
            }
            Salary-=amount;
            return true;
        }
    }
}