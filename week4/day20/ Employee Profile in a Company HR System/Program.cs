using ConsoleApp8;

namespace ConsoleApp39
{ 
    internal class Program
    {
        static void Main(string[] args)
        {
            // ALLOWED & CONTROLLED:
         var emp = new Employee("Marko Horvat", 4500m, 35,"Emp120");
         Console.WriteLine(emp.Salary);        // 4500
         emp.GiveRaise(15);                    // OK → 5175
         emp.GiveRaise(40);                    // throws exception (too high)
         emp.Fullname = "Marko Horvat Jr.";    // OK
         Console.WriteLine(emp.Fullname);      // "Marko Horvat Jr."
          Console.WriteLine(emp.Age);           // 35
        }
    }
}