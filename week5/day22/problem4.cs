using System;

namespace ConsoleApp8
{  
class Program
{
    class Node
    {
        public int EmpId;
        public string Name;
        public Node Next;

        public Node(int id, string name)
        {
            EmpId = id;
            Name = name;
            Next = null;
        }
    }

    static Node head = null;

    static void InsertAtBeginning(int id, string name)
    {
        Node newNode = new Node(id, name);
        newNode.Next = head;
        head = newNode;
    }

    static void InsertAtEnd(int id, string name)
    {
        Node newNode = new Node(id, name);

        if (head == null)
        {
            head = newNode;
            return;
        }

        Node temp = head;
        while (temp.Next != null)
        {
            temp = temp.Next;
        }

        temp.Next = newNode;
    }

    static void Delete(int id)
    {
        if (head == null)
        {
            Console.WriteLine("List is empty");
            return;
        }

        // If head is to be deleted
        if (head.EmpId == id)
        {
            head = head.Next;
            return;
        }

        Node temp = head;
        Node prev = null;

        while (temp != null && temp.EmpId != id)
        {
            prev = temp;
            temp = temp.Next;
        }

        if (temp == null)
        {
            Console.WriteLine("Employee not found");
            return;
        }

        prev.Next = temp.Next;
    }

    static void Display()
    {
        if (head == null)
        {
            Console.WriteLine("No employees found");
            return;
        }

        Node temp = head;
        while (temp != null)
        {
            Console.WriteLine(temp.EmpId + " - " + temp.Name);
            temp = temp.Next;
        }
    }

    static void Main()
    {
        InsertAtEnd(101, "John");
        InsertAtEnd(102, "Sara");
        InsertAtBeginning(103, "Mike");
        Delete(102);
        Console.WriteLine("Employee List After Deletion:");
        Display();
    }
}
}


