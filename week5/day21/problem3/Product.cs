namespace ConsoleApp8{
class Product
    {
        private  double price;
        public String Name
        {
            get;
            set;
        }
        public double Price
        {
            get
            {
                return price;
            }
            set
            {
                if (value > 0)
                {
                 price=value;   
                }else
                {
                    Console.WriteLine("price cannot be nagative");
                }
             
            }
        }
        public virtual double CalculateDiscount()
        {
           return price;
        }
    }
    class Electronics:Product
    {
        public override double CalculateDiscount()
        {
            return Price-(Price*0.05);
        }
    }
    class Clothing : Product
    {
        public override double CalculateDiscount()
        {
            return Price-(Price*0.15);
        }
    }
}