using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    public class Stack<T>
    {
        private StackItem<T> top;
        public int Count { get; private set; }

        public Stack() { top = null; Count = 0; }

        public void Push(T data)
        {
            top = new StackItem<T>(data, top);
            Count++;
        }

        public T Pop()
        {
            if (top == null) throw new InvalidOperationException("Stack is empty");
            T result = top.Data;
            top = top.pNext;
            Count--;
            return result;
        }

        public T Peek()
        {
            if (top == null) throw new InvalidOperationException("Stack is empty");
            return top.Data;
        }

        public void Clear()
        {
            top = null;
            Count = 0;
        }

        public bool IsEmpty() => top == null;
    }
}