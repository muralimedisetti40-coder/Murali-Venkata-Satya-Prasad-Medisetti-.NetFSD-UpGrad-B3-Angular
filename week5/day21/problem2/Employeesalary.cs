namespace ConsoleApp8{
class Employeesalary
    {
        public String Name
        {
            get;
            set;
        }
        public double BaseSalary
        {
            get;
            set;
        }
        public virtual double CalculateSalary()
        {
           return BaseSalary;
        }
    }
    class Manager: Employeesalary
    {
        public override double CalculateSalary()
        {
            return BaseSalary+(BaseSalary*0.20);
        }
    }
    class Developer : Employeesalary
    {
        public override double CalculateSalary()
        {
            return BaseSalary+(BaseSalary*0.10);
        }
    }
}