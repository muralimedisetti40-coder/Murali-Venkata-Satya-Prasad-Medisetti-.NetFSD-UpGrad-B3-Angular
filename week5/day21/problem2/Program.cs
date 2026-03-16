using System.Net;

namespace ConsoleApp8
{

    class Employee
    {
        static void Main(string[] args)
        {
         Employeesalary manager=new Manager();
         manager.Name="murali";
         manager.BaseSalary=50000;
         Console.WriteLine("manager salary ="+manager.CalculateSalary());
         Employeesalary developer=new Developer();
         developer.Name="mani";
         developer.BaseSalary=50000;
         Console.WriteLine("developer salary ="+developer.CalculateSalary());
        }
    }
}
