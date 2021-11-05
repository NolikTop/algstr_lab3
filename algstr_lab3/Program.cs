using System;
using src;

namespace algstr_lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            var tree = new AvlTree();

            var n = 30;
            for (var i = 0; i < n; ++i)
            {
                tree.Insert(i);
            }
            
            //tree.Delete(4);
            //tree.Delete(2);

            Console.WriteLine("elements (" + tree.Count  + ")");
            AvlTreePrinter.PrintPretty(tree.Root);
        }
    }
}