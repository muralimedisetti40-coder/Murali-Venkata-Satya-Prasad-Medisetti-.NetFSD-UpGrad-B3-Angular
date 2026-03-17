using System.ComponentModel;

namespace ConsoleApp8
{  
    class StackUndo
    {
        private string[] stack;
        private int top;
        private int size;

        public StackUndo(int size)
        {
            this.size = size;
            stack = new string[size];
            top = -1;
        }

        public void Push(string action)
        {
            if (top == size - 1)
            {
                Console.WriteLine("Stack Overflow! Cannot add more actions.");
                return;
            }

            stack[++top] = action;
            Console.WriteLine($"Action Added: {action}");
            Display();
        }

        public void Pop()
        {
            if (top == -1)
            {
                Console.WriteLine("Stack Underflow! No actions to undo.");
                return;
            }

            Console.WriteLine($"Undo Action: {stack[top]}");
            top--;
            Display();
        }

        public void Display()
        {
            if (top == -1)
            {
                Console.WriteLine("Current State: Empty");
                return;
            }

            Console.Write("Current State: ");
            for (int i = 0; i <= top; i++)
            {
                Console.Write(stack[i]);
                if (i < top) Console.Write(" -> ");
            }
            Console.WriteLine();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            StackUndo editor = new StackUndo(10);

            editor.Push("Type A");
            editor.Push("Type B");
            editor.Push("Type C");

            editor.Pop(); 
            editor.Pop(); 
        }
    }
}


