namespace ConsoleApp8
{  
    internal class Program
    { 
        static void Main(string[] args)
        {
           Console.WriteLine("enter number:");
           int n=int.Parse(Console.ReadLine());
           int odd=0;
           int even=0;
           int sum=0;
           for(int i = 1; i <=n; i++)
            {
                if (i % 2 == 0)
                {
                    even++;
                }
                else
                {
                    odd++;
                }
                sum+=i;
            }
            Console.WriteLine("even count :"+even);
            Console.WriteLine("odd count :"+odd);
            Console.WriteLine("sum :"+sum);


        }
    }
}
