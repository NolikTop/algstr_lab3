namespace src
{
    public class AvlTreePrinterElementInfo
    {
        public AvlTreeElement Node;
        public string Text;
        public int StartPos;
        public int Size => Text.Length;
        public int EndPos { 
            get => StartPos + Size;
            set => StartPos = value - Size;
        }
        
        public AvlTreePrinterElementInfo Parent, Left, Right;
    }
}