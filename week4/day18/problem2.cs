namespace ConsoleApp8
{  
    internal class Program
    { 
        static void Main(string[] args)
        {
           Console.WriteLine("enter first number");
           int n=int.Parse(Console.ReadLine());
           Console.WriteLine("enter second number");
           int k=int.Parse(Console.ReadLine());
           Console.WriteLine("enter  operator");
           char op=char.Parse(Console.ReadLine());
           int z=0;
            switch (op)
            {
            case '+':
                z=n+k;
                break;
            case '-':
                z=n-k;
                break;
            case '*':
                z=n*k;
                break;
            case '/':
                z=n/k;
                break;
            default:
                Console.WriteLine("enter valid operator");
                return;
            }
            Console.WriteLine("result:"+z);
        }
    }
}
