#nullable enable
using System;

namespace src
{
    public class AvlTree
    {
        public int Count => CountElementsInNode(Root);
        
        public AvlTreeElement? Root;
        
        public bool Contains(int key)
        {
            return FindElement(key, Root) is not null;
        }
        
        public void Insert(int key)
        {
            Root = InsertElement(key, Root);
        }
        
        public void Delete(int key)
        {
            Root = DeleteElement(key, Root);
        }

        private static int CountElementsInNode(AvlTreeElement? node)
        {
            if (node is null)
            {
                return 0;
            }

            return CountElementsInNode(node.Left) + CountElementsInNode(node.Right) + 1;
        }
        
        private static AvlTreeElement? FindElement(int key, AvlTreeElement? node)
        {
            while (true)
            {
                if (node is null)
                {
                    return null;
                }

                if (key == node.Key)
                {
                    return node;
                }

                if (key < node.Key)
                {
                    node = node.Left;
                    continue;
                }

                node = node.Right;
            }
        }

        private static AvlTreeElement InsertElement(int key, AvlTreeElement? el)
        {
            if (el is null)
            {
                el = new AvlTreeElement(key);
            }
            else if (key < el.Key)
            {
                el.Left = InsertElement(key, el.Left);
            }
            else if (key > el.Key)
            {
                el.Right = InsertElement(key, el.Right);
            }
            else
            {
                throw new ArgumentException("Tree already has " + key + " value", nameof(key));
            }

            FixHeight(el);
            return Balance(el);
        }

        private AvlTreeElement? DeleteElement(int key, AvlTreeElement? el) {
            if (el is null)
            {
                return null;
            }

            if (key < el.Key)
            {
                el.Left = DeleteElement(key, el.Left);
            }
            else if (key > el.Key)
            {
                el.Right = DeleteElement(key, el.Right);
            }
            
            else switch (el.Left)
            {
                // Элемент - лист, значит просто его удаляем
                case null when el.Right is null:
                    el = null;
                    break;
                // У элемента есть 1 потомок (правый) - заменяем его потомком
                case null:
                    el = el.Right;
                    break;
                default:
                {
                    // У элемента есть 1 потомок (левый) - заменяем его потомком
                    if (el.Right == null)
                    {
                        el = el.Left;
                    }
                    else
                    {
                        // У элемента есть оба потомка
                        DeleteElementWithChildren(el);
                    }

                    break;
                }
            }

            if (el is null) {
                return null;
            }

            FixHeight(el);
            return Balance(el);
        }

        private void DeleteElementWithChildren(AvlTreeElement avlTreeElement)
        {
            var min = FindMin(avlTreeElement.Right!);
            avlTreeElement.Key = min.Key;
            avlTreeElement.Right = DeleteElement(min.Key, avlTreeElement.Right);
        }
        
        private static AvlTreeElement FindMin(AvlTreeElement avlTreeElement)
        {
            while (avlTreeElement.Left != null)
            {
                avlTreeElement = avlTreeElement.Left;
            }

            return avlTreeElement;
        }

        private static void FixHeight(AvlTreeElement? node)
        {
            if (node is null) return;
            var leftChildHeight = Height(node.Left);
            var rightChildHeight = Height(node.Right);
            node.Height = Math.Max(leftChildHeight, rightChildHeight) + 1;
        }

        private static AvlTreeElement Balance(AvlTreeElement avlTreeElement) {
            var balance = BalanceFactor(avlTreeElement);

            switch (balance)
            {
                case < -1 when BalanceFactor(avlTreeElement.Left!) <= 0:
                    avlTreeElement = RotateRight(avlTreeElement);
                    break;
                case < -1:
                    avlTreeElement.Left = RotateLeft(avlTreeElement.Left!);
                    avlTreeElement = RotateRight(avlTreeElement);
                    break;
                case > 1 when BalanceFactor(avlTreeElement.Right!) >= 0:
                    avlTreeElement = RotateLeft(avlTreeElement);
                    break;
                case > 1:
                    avlTreeElement.Right = RotateRight(avlTreeElement.Right!);
                    avlTreeElement = RotateLeft(avlTreeElement);
                    break;
            }

            return avlTreeElement;
        }

        private static AvlTreeElement RotateRight(AvlTreeElement avlTreeElement) {
            AvlTreeElement leftChild = avlTreeElement.Left!;

            avlTreeElement.Left = leftChild.Right;
            leftChild.Right = avlTreeElement;

            FixHeight(avlTreeElement);
            FixHeight(leftChild);

            return leftChild;
        }

        private static AvlTreeElement RotateLeft(AvlTreeElement avlTreeElement) {
            AvlTreeElement rightChild = avlTreeElement.Right!;

            avlTreeElement.Right = rightChild.Left;
            rightChild.Left = avlTreeElement;

            FixHeight(avlTreeElement);
            FixHeight(rightChild);

            return rightChild;
        }

        private static int BalanceFactor(AvlTreeElement avlTreeElement) {
            return Height(avlTreeElement.Right) - Height(avlTreeElement.Left);
        }

        private static int Height(AvlTreeElement? node) {
            return node?.Height ?? -1;
        }
        
    }
}