using System;

namespace areyesram
{
    internal class Program
    {
        private static void Main()
        {
            var r = new Random();

            var tree = new Tree<int>();
            for (var i = 0; i < 10000; i++)
                tree.Insert(r.Next(30000));

            Console.WriteLine("Enter a number to find it, a non-number to display the list of numbers in the tree, or a blank line to exit.");
            while (true)
            {
                Console.Write("> ");
                var input = Console.ReadLine();
                if (string.IsNullOrEmpty(input)) break;
                int number;
                if (int.TryParse(input, out number))
                {
                    if (tree.Find(number))
                        Console.WriteLine("I found it.");
                    else
                        Console.WriteLine("Can't seem to find it.");
                }
                else
                {
                    tree.Traverse(data => Console.Write(data + " "));
                    Console.WriteLine();
                }
            }
        }
    }
}