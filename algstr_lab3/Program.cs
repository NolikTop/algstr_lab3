using System;
using src;

namespace algstr_lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            var tree = new AvlTree();

            var n = 10;
            for (var i = 1; i <= n; ++i)
            {
                tree.Insert(i);
            }
            
            //tree.Delete(4);
            //tree.Delete(2);

            Console.WriteLine("elements (" + tree.Count  + ")");
            AvlTreePrinter.PrintPretty(tree.Root);

            Console.Write("клп: ");
            foreach (var el in AvlTreeTraversal.IterativePreOrder(tree.Root!))
            {
                Console.Write(el + " ");
            }
            Console.WriteLine();

            Console.Write("лкп: ");
            foreach (var el in AvlTreeTraversal.IterativeInOrder(tree.Root!))
            {
                Console.Write(el + " ");
            }
            Console.WriteLine();

            Console.Write("лпк: ");
            foreach (var el in AvlTreeTraversal.IterativePostOrder(tree.Root!))
            {
                Console.Write(el + " ");
            }
            Console.WriteLine();

            Console.Write("в глубину: ");
            foreach (var el in AvlTreeTraversal.BreadthFirst(tree.Root!))
            {
                Console.Write(el + " ");
            }
            Console.WriteLine();
            
            
        }
    }
}