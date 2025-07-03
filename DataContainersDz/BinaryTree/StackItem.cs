using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    public class StackItem<T>
    {
        public T Data { get; set; }
        public StackItem<T> pNext { get; set; }

        public StackItem(T data, StackItem<T> pNext = null)
        {
            Data = data;
            this.pNext = pNext;
        }
    }
}