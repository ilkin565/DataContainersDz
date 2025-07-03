using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    class Tree
    {
        static readonly int BASE_INTERVAL = 3;
        public Element Root { get; protected set; }

        public Tree()
        {
            Root = null;
            Console.WriteLine($"TConstructor:{GetHashCode()}");
        }

        ~Tree()
        {
            Console.WriteLine($"TDestructor:{GetHashCode()}");
        }

        public void Insert(int Data)
        {
            if (Root == null)
            {
                Root = new Element(Data);
                return;
            }
            Insert(Data, Root);
        }

        private void Insert(int Data, Element current)
        {
            if (Data < current.Data)
            {
                if (current.pLeft == null)
                    current.pLeft = new Element(Data);
                else
                    Insert(Data, current.pLeft);
            }
            else
            {
                if (current.pRight == null)
                    current.pRight = new Element(Data);
                else
                    Insert(Data, current.pRight);
            }
        }

        public void Clear()
        {
            Root = null;
        }

        public void Erase(int Data)
        {
            Root = Erase(Data, Root);
        }

        private Element Erase(int Data, Element current)
        {
            if (current == null) return null;

            if (Data < current.Data)
            {
                current.pLeft = Erase(Data, current.pLeft);
            }
            else if (Data > current.Data)
            {
                current.pRight = Erase(Data, current.pRight);
            }
            else
            {
                if (current.pLeft == null)
                    return current.pRight;
                else if (current.pRight == null)
                    return current.pLeft;

                current.Data = MinValue(current.pRight);
                current.pRight = Erase(current.Data, current.pRight);
            }
            return current;
        }

        public void Balance()
        {
            Root = Balance(Root);
        }

        private Element Balance(Element current)
        {
            if (current == null) return null;

            current.pLeft = Balance(current.pLeft);
            current.pRight = Balance(current.pRight);

            int balanceFactor = GetBalanceFactor(current);

            if (balanceFactor > 1)
            {
                if (GetBalanceFactor(current.pLeft) >= 0)
                {
                    return RotateRight(current);
                }
                else
                {
                    current.pLeft = RotateLeft(current.pLeft);
                    return RotateRight(current);
                }
            }
            else if (balanceFactor < -1)
            {
                if (GetBalanceFactor(current.pRight) <= 0)
                {
                    return RotateLeft(current);
                }
                else
                {
                    current.pRight = RotateRight(current.pRight);
                    return RotateLeft(current);
                }
            }

            return current;
        }

        private int GetBalanceFactor(Element node)
        {
            if (node == null) return 0;
            return Depth(node.pLeft) - Depth(node.pRight);
        }

        private Element RotateRight(Element y)
        {
            Element x = y.pLeft;
            Element T2 = x.pRight;

            x.pRight = y;
            y.pLeft = T2;

            return x;
        }

        private Element RotateLeft(Element x)
        {
            Element y = x.pRight;
            Element T2 = y.pLeft;

            y.pLeft = x;
            x.pRight = T2;

            return y;
        }

        public int MinValue()
        {
            if (Root == null) throw new InvalidOperationException("Дерево пустое");
            return MinValue(Root);
        }

        private int MinValue(Element node)
        {
            return node.pLeft == null ? node.Data : MinValue(node.pLeft);
        }

        public int MaxValue()
        {
            if (Root == null) throw new InvalidOperationException("Дерево пустое");
            return MaxValue(Root);
        }

        private int MaxValue(Element node)
        {
            return node.pRight == null ? node.Data : MaxValue(node.pRight);
        }

        public int Count()
        {
            return Count(Root);
        }

        private int Count(Element node)
        {
            return node == null ? 0 : Count(node.pLeft) + Count(node.pRight) + 1;
        }

        public int Sum()
        {
            return Sum(Root);
        }

        private int Sum(Element node)
        {
            return node == null ? 0 : Sum(node.pLeft) + Sum(node.pRight) + node.Data;
        }

        public double Avg()
        {
            if (Root == null) return 0;
            return (double)Sum() / Count();
        }

        public int Depth()
        {
            return Depth(Root);
        }

        private int Depth(Element node)
        {
            if (node == null) return 0;
            int lDepth = Depth(node.pLeft);
            int rDepth = Depth(node.pRight);
            return (lDepth > rDepth ? lDepth : rDepth) + 1;
        }

        public void DepthPrint(int depth)
        {
            DepthPrint(Root, depth);
            Console.WriteLine();
        }

        private void DepthPrint(Element node, int depth)
        {
            int interval = BASE_INTERVAL * (Depth() - depth);
            if (node == null)
            {
                Console.Write("".PadLeft(interval));
                return;
            }
            if (depth == 0)
            {
                Console.Write(node.Data.ToString().PadLeft(interval));
            }
            else
            {
                DepthPrint(node.pLeft, depth - 1);
                DepthPrint(node.pRight, depth - 1);
            }
        }

        public void TreePrint(int depth = 0)
        {
            if (Root == null) return;
            if (Depth() - depth == 0) return;
            int interval = BASE_INTERVAL * (Depth() - depth);
            Console.Write("".PadLeft(interval));
            PrintInterval(Depth() - depth);
            DepthPrint(depth);
            TreePrint(depth + 1);
        }

        private void PrintInterval(int count)
        {
            for (int i = 0; i < count; i++) Console.Write("    ");
        }

        public void Print()
        {
            Print(Root);
            Console.WriteLine();
        }

        private void Print(Element node)
        {
            if (node == null) return;
            Print(node.pLeft);
            Console.Write(node.Data + "\t");
            Print(node.pRight);
        }
    }
}