using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    class Program
    {
        static void Main(string[] args)
        {
            Tree tree = new Tree();

            tree.Insert(55);
            tree.Insert(34);
            tree.Insert(21);
            tree.Insert(13);
            tree.Insert(8);
            tree.Insert(5);
            tree.Insert(3);
            tree.Insert(2);
            tree.Insert(1);

            tree.Print();
            Console.WriteLine("\n----------------------------------\n");

            tree.TreePrint();
            tree.Balance();
            tree.TreePrint();

            Console.WriteLine($"Глубина дерева: {tree.Depth()}");

            tree.Erase(5);
            Console.WriteLine("\nПосле удаления 5:");
            tree.Print();

            tree.Clear();
            Console.WriteLine("\nПосле очистки:");
            tree.Print();

            TestStack();
            TestQueue();
        }

        static void TestStack()
        {
            Console.WriteLine("\nTesting Stack:");
            Stack<int> stack = new Stack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            Console.WriteLine($"Peek: {stack.Peek()}");
            Console.WriteLine($"Pop: {stack.Pop()}");
            Console.WriteLine($"Count: {stack.Count}");
        }

        static void TestQueue()
        {
            Console.WriteLine("\nTesting Queue:");
            Queue<string> queue = new Queue<string>();
            queue.Enqueue("First");
            queue.Enqueue("Second");

            Console.WriteLine($"Peek: {queue.Peek()}");
            Console.WriteLine($"Dequeue: {queue.Dequeue()}");
            Console.WriteLine($"Count: {queue.Count}");
        }
    }
}