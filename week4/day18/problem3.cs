namespace ConsoleApp8
{  
    internal class Program
    { 
        static void Main(string[] args)
        {
           Console.WriteLine("enter employee name");
           String employeename=Console.ReadLine();
           Console.WriteLine("enter employee salary");
           double employeesalary=double.Parse(Console.ReadLine());
           Console.WriteLine("enter employee experience");
           int employeeexperience=int.Parse(Console.ReadLine());
           double bounouspersent;
            if (employeeexperience <=2)
            {
                bounouspersent=0.05;
            }
            else
            {
                bounouspersent=employeeexperience>2&&employeeexperience<=5?0.10:0.15;
            }
            double bonous=employeesalary*bounouspersent;
            double finalsalary=employeesalary+bonous;
            Console.WriteLine("Employee:"+employeename);
            Console.WriteLine("Bonous"+bonous);
            Console.WriteLine("Final Salary:"+finalsalary);

        }
    }
}
