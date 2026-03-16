using System.Xml.XPath;

namespace ConsoleApp8
{
    class Vehicle
    {
        private int rentalrateperday;
        public String Brand
        {
            get;
            set;
        }
        public int Rentalrateperday
        {
            get
            {
                return rentalrateperday;
            }
            set
            {
                if (value > 0)
                {
                    rentalrateperday=value;
                }else
                {
                    Console.WriteLine("rent must be grater than 0");
                }
            }
        }
        public virtual double  CalculateRental(int days)
        {
            return Rentalrateperday*days;
        }
    }
    class Car : Vehicle
    {
        public override double CalculateRental(int days)
        {
            if (days <= 0)
            {
                Console.WriteLine("Invalid rental days");
                return 0;
            }
            double total=Rentalrateperday*days;
           return total+500;
        }
    }
    class Bike : Vehicle
    {
        public override double CalculateRental(int days)
        {
            if (days <= 0)
            {
                Console.WriteLine("Invalid rental days");
                return 0;
            }
            double total=Rentalrateperday*days;
            return total-(total*0.05);
        }
    }
}