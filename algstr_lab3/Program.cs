using System;
using src;

namespace algstr_lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            var tree = new AvlTree();

            tree.Insert(1);
            tree.Insert(2);
            tree.Insert(3);
            tree.Insert(4);
            tree.Insert(5);
            tree.Insert(6);
            
            Console.WriteLine("\nelements (" + tree.Count  + ")");
            AvlTreePrinter.Print(tree.Root);
            Console.WriteLine("\nnigga");
        }
    }
}