namespace ConsoleApp9
{  
    internal class Program
    { 
        static void Main(string[] args)
        {
            Console.WriteLine("enter student name");
            String name=Console.ReadLine();
            Console.WriteLine("enter student marks");
            int marks=int.Parse(Console.ReadLine());
            if (marks < 0 || marks > 100)
            {
                Console.WriteLine("enter valid marks");
            }
            else{
               Console.WriteLine("student name:"+name);
            if (marks > 85)
            {
                Console.WriteLine("grade :A");
                
            }
            else if (marks > 70)
            {
                
                Console.WriteLine("grade :B");
            }
            else if(marks>55)
            {
                Console.WriteLine("grade :C");
            }
            else if (marks > 45)
            {
                Console.WriteLine("grade :D");
            }
            else
            {
                Console.WriteLine("grade :Fail");
            }
            }
        }
    }
}
