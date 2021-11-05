#nullable enable
using System;
using System.Collections.Generic;

namespace src
{
    public static class AvlTreePrinter
    {
        public static void PrintPretty(AvlTreeElement? node, string indent = "", bool last = true)
        {
            if (node is null) return;

            Console.Write(indent);
            if (last)
            {
                Console.Write("\\-");
                indent += "  ";
            }
            else
            {
                Console.Write("|-");
                indent += "| ";
            }
            Console.WriteLine(node.Key);

            PrintPretty(node.Left, indent, false);
            PrintPretty(node.Right, indent, true);
        }
    }
}