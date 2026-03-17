using System;

namespace ConsoleApp8
{
    public record Student(string Name, int Rollnumber, string deptname, double cgpa);

    class program1
    {
        static Student[] students = new Student[100]; 
        static int count = 0; 

        static void Main()
        {
            int choice;
            while (true)
            {
                Console.WriteLine("\nStudent Records");
                Console.WriteLine("1. Add Students");
                Console.WriteLine("2. Display Students");
                Console.WriteLine("3. Search Student");
                Console.WriteLine("4. Exit");

                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        AddStudents();
                        break;
                    case 2:
                        DisplayStudents();
                        break;
                    case 3:
                        SearchStudent();
                        break;
                    case 4:
                        return;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
            }
        }

        static void AddStudents()
        {
            Console.WriteLine("Enter number of students:");
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                if (count >= students.Length)
                {
                    Console.WriteLine("Array is full!");
                    return;
                }

                Console.WriteLine($"\nEnter student {i + 1} details");

                Console.Write("Name: ");
                string name = Console.ReadLine();

                Console.Write("Roll Number: ");
                int num = int.Parse(Console.ReadLine());

                Console.Write("Department: ");
                string dept = Console.ReadLine();

                Console.Write("CGPA: ");
                double cgpa = double.Parse(Console.ReadLine());

                students[count] = new Student(name, num, dept, cgpa);
                count++;

                Console.WriteLine("Student added successfully!");
            }
        }

        static void DisplayStudents()
        {
            if (count == 0)
            {
                Console.WriteLine("No student records available.");
                return;
            }

            Console.WriteLine("\nStudent Records:");
            for (int i = 0; i < count; i++)
            {
                var s = students[i];
                Console.WriteLine($"Name: {s.Name} | Roll: {s.Rollnumber} | Dept: {s.deptname} | CGPA: {s.cgpa}");
            }
        }

        static void SearchStudent()
        {
            Console.Write("Enter Roll Number: ");
            int num = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                if (students[i].Rollnumber == num)
                {
                    var s = students[i];
                    Console.WriteLine("\nStudent Found:");
                    Console.WriteLine($"Name: {s.Name} | Roll: {s.Rollnumber} | Dept: {s.deptname} | CGPA: {s.cgpa}");
                    return;
                }
            }

            Console.WriteLine("Student not found!");
        }
    }
}