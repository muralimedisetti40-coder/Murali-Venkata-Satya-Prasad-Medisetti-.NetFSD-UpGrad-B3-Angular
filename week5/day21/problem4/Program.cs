using System.Net;

namespace ConsoleApp8
{

    class Employee
    {
        static void Main(string[] args)
        {
         Vehicle car = new Car();
        car.Brand = "Toyota";
        car.Rentalrateperday = 2000;

        int days = 3;

        Console.WriteLine("Car Total Rental = " + car.CalculateRental(days));

        Vehicle bike = new Bike();
        bike.Brand = "Yamaha";
        bike.Rentalrateperday = 1000;

        Console.WriteLine("Bike Total Rental = " + bike.CalculateRental(days));
        }
    }
}
