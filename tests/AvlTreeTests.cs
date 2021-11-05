#nullable enable
using System;
using System.Linq;
using System.Threading;
using NUnit.Framework;
using src;

namespace tests
{
    public class Tests
    {
        private AvlTree Tree = new();

        private Random _random = new Random();
        
        [SetUp]
        public void Setup()
        {
            Tree = new AvlTree();

            var n = _random.Next(10, 100);
            
            var b = new byte[n];

            for (byte i = 0; i < n; i++)
            {
                b[i] = i;
            }

            foreach (var el in b.OrderBy(x => _random.Next()))
            {
                Tree.Insert(el);
            }
        }

        private static void CheckAvl(AvlTreeElement? el) {
            if (el is null) return;

            var leftHeight = el.Left?.Height ?? -1;
            var rightHeight = el.Right?.Height ?? -1;

            CheckHeight(el, leftHeight, rightHeight);
            CheckBalanceFactor(leftHeight, rightHeight);

            CheckAvl(el.Left);
            CheckAvl(el.Right);
        }

        private static void CheckHeight(AvlTreeElement el, int leftHeight, int rightHeight) {
            var expectedHeight = 1 + Math.Max(leftHeight, rightHeight);

            Assert.AreEqual(expectedHeight, el.Height);
        }
        
        private static void CheckBalanceFactor(int leftHeight, int rightHeight) {
            var bf = rightHeight - leftHeight;
            Assert.AreEqual(0, bf, 1, "Balance factor must be in range [-1; 1]");
        }

        [Test]
        [Repeat(100)]
        public void Avl()
        {
            CheckAvl(Tree.Root);
        }
    }
}