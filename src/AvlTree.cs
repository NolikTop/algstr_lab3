#nullable enable
using System;
using System.Collections.Generic;

namespace src
{
    public class AvlTree
    {
        public AvlTreeElement? Root
        {
            get;
            private set;
        } = null;

        public int Count => GetFullCount(Root);
        
        private static int GetFullCount(AvlTreeElement? element)
        {
            if(element is null)
            {
                return 0;
            }
            
            Console.Write(element.Key + " ");

            return 1 + GetFullCount(element.Left) + GetFullCount(element.Right);
        }

        public void Insert(int value)
        {
            if (Root == null)
            {
                Root = new AvlTreeElement(value);
                return;
            }

            Insert(Root, value);
        }

        public bool Exists(int value)
        {
            return Root?.Exists(value) ?? false;
        }

        public void Remove(int value)
        {
            Remove(Root, value);
        }

        private static AvlTreeElement Insert(AvlTreeElement? element, int key)
        {
            if (element is null)
            {
                return new AvlTreeElement(key);
            }

            if (key < element.Key)
            {
                element.Left = Insert(element.Left, key);
            }
            else
            {
                element.Right = Insert(element.Right, key);
            }

            return element.Balance();
        }

        private AvlTreeElement? Remove(AvlTreeElement? element, int key)
        {
            if (element is null) return null;

            if (key < element.Key)
            {
                element.Left = Remove(element.Left, key);
            }
            else if(key > element.Key)
            {
                element.Right = Remove(element.Right, key);
            }
            else
            {
                var left = element.Left;
                var right = element.Right;

                if (right is null) return left;

                var min = right.FindElementWithMinKey();
                min.Right = right.RemoveElementWithMinKey();
                min.Left = left;

                return min.Balance();
            }

            return element.Balance();
        }

    }
}