using System.Net;

namespace ConsoleApp8
{

    class Employee
    {
        static void Main(string[] args)
        {
         Product electronics=new Electronics();
         electronics.Name="laptop";
         electronics.Price=20000;
         Console.WriteLine("Final Price after 5% discount = "+electronics.CalculateDiscount());
         Product clothing=new Clothing();
         clothing.Name="shirt";
         clothing.Price=1000;
         Console.WriteLine("Final Price after 15% discount = "+clothing.CalculateDiscount());
        }
    }
}
