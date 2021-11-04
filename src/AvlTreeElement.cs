#nullable enable
namespace src
{
    public class AvlTreeElement
    {
        public int Key;
        public byte Height = 1;

        public int BalanceFactor => SafeHeight(Right) - SafeHeight(Left);

        public AvlTreeElement? Left = null;
        public AvlTreeElement? Right = null;

        public AvlTreeElement(int key)
        {
            Key = key;
        }

        public bool Exists(int key)
        {
            var el = this;

            while (el is not null)
            {
                if (key < Key)
                {
                    el = el.Left;
                }
                else if(key > Key)
                {
                    el = el.Right;
                }
                else
                {
                    return true;
                }
            }

            return false;
        }

        private AvlTreeElement RotateRight()
        {
            var t = Left!;
            Left = t.Right;
            t.Right = this;
            
            FixHeight();
            t.FixHeight();
            
            return t;
        }
        
        private AvlTreeElement RotateLeft()
        {
            var t = Right!;
            Right = t.Left;
            t.Left = this;

            FixHeight();
            t.FixHeight();
            
            return t;
        }

        public AvlTreeElement Balance()
        {
            FixHeight();

            var bFactor = BalanceFactor;
            switch (bFactor)
            {
                case 2:
                    if (Right!.BalanceFactor < 0)
                    {
                        Right = Right!.RotateRight();
                    }

                    return RotateLeft();
                case -2:
                    if (Left!.BalanceFactor > 0)
                    {
                        Left = Left!.RotateLeft();
                    }

                    return RotateRight();
                default:
                    return this;
            }
        }
        
        public AvlTreeElement FindElementWithMinKey()
        {
            var el = this;
            while (el.Left is not null)
            {
                el = el.Left;
            }
            
            return el;
        }

        public AvlTreeElement? RemoveElementWithMinKey()
        {
            while (Left is not null)
            {
                Left = Left.RemoveElementWithMinKey();

                Balance();
            }

            return Right;
        }

        private void FixHeight()
        {
            var leftHeight = SafeHeight(Left);
            var rightHeight = SafeHeight(Right);

            Height = leftHeight > rightHeight ? leftHeight : rightHeight;
            Height++;
        }
        
        private static byte SafeHeight(AvlTreeElement? element)
        {
            return element?.Height ?? 0;
        }
    }
}