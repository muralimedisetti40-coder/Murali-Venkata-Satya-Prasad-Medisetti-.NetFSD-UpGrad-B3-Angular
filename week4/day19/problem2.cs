namespace ConsoleApp39
{ 
    using System;
using System;

class Student
{
    public double CalculateAverage(int m1, int m2, int m3)
    {
        return (m1 + m2 + m3) / 3.0;
    }
}

class Program
{
    static void Main()
    {
        Student s = new Student();

        Console.Write("Enter marks 1: ");
        int m1 = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter marks 2: ");
        int m2 = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter marks 3: ");
        int m3 = Convert.ToInt32(Console.ReadLine());

        double avg = s.CalculateAverage(m1, m2, m3);

        string grade;

        if (avg >= 80)
            grade = "A";
        else if (avg >= 60)
            grade = "B";
        else if (avg >= 40)
            grade = "C";
        else
            grade = "Fail";

        Console.WriteLine("Average = " + avg);
        Console.WriteLine("Grade = " + grade);
    }
}
}