#nullable enable
namespace src
{
    public class AvlTreeElement
    {
        public int Key;
        public int Height = 1;

        public AvlTreeElement? Left = null;
        public AvlTreeElement? Right = null;

        public AvlTreeElement(int key)
        {
            Key = key;
        }
    }
}