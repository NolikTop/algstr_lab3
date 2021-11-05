#nullable enable
using System;
using System.Collections.Generic;
using System.Linq;
using src.dynamicArray;

namespace src
{
    public static class AvlTreeTraversal
    {
        // клп
        // PreOrder 
        public static IEnumerable<int> IterativePreOrder(AvlTreeElement root)
        {
            var stack = new stack.Stack<AvlTreeElement>();
            stack.Push(root);
 
            while (stack.Count > 0) {
                var el = stack.Pop();
                yield return el.Key;
                
                if (el.Right != null) {
                    stack.Push(el.Right);
                }
                if (el.Left != null) {
                    stack.Push(el.Left);
                }
            }
        }
        
        // лкп
        // InOrder
        public static IEnumerable<int> IterativeInOrder(AvlTreeElement root)
        {
            var stack = new stack.Stack<AvlTreeElement>();
            var el = root;
 
            while (el != null || stack.Count > 0)
            {
                while (el != null)
                {
                    stack.Push(el);
                    el = el.Left;
                }
 
                el = stack.Pop();
                yield return el.Key;
                el = el.Right;
            }
        }
        
        // лпк 
        // PostOrder 
        public static IEnumerable<int> IterativePostOrder(AvlTreeElement root)
        {
            var stack = new stack.Stack<AvlTreeElement>();
            var resStack = new stack.Stack<AvlTreeElement>();

            stack.Push(root);
 
            while (stack.Count > 0) {
                var el = stack.Pop();
                resStack.Push(el);

                if (el.Left is not null)
                {
                    stack.Push(el.Left);
                }

                if (el.Right is not null)
                {
                    stack.Push(el.Right);
                }
            }
 
            while (resStack.Count > 0) {
                var el = resStack.Pop();
                yield return el.Key;
            }
        }
        
        // в ширину
        public static IEnumerable<int> BreadthFirst(AvlTreeElement root)
        {
            var h = root.Height + 1;
            Console.WriteLine("height: " + h);
            int i;
            var result = new DynamicArray<int>();

            for (i = 1; i <= h; i++) {
                PrintCurrentLevel(root, i, result);
            }

            return result;
        }
        
        private static void PrintCurrentLevel(AvlTreeElement? el, int level, DynamicArray<int> result)
        {
            if (el is null)
            {
                return;
            }

            switch (level)
            {
                case 1:
                    result.Add(el.Key);
                    break;
                case > 1:
                    PrintCurrentLevel(el.Left, level - 1, result);
                    PrintCurrentLevel(el.Right, level - 1, result);
                    break;
            }
        }
        
        // sort
        public static IEnumerable<int> Sort(IEnumerable<int> array)
        {
            var tree = new AvlTree();
            foreach (var t in array)
            {
                tree.Insert(t);
            }

            return IterativeInOrder(tree.Root!);
        }
    }
}