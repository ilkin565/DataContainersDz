using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    public class Queue<T>
    {
        private QueueItem<T> front;
        private QueueItem<T> rear;
        public int Count { get; private set; }

        public Queue() { front = rear = null; Count = 0; }

        public void Enqueue(T data)
        {
            QueueItem<T> newNode = new QueueItem<T>(data, rear);
            if (rear == null) front = rear = newNode;
            else { rear.pNext = newNode; rear = newNode; }
            Count++;
        }

        public T Dequeue()
        {
            if (front == null) throw new InvalidOperationException("Queue is empty");
            T result = front.Data;
            front = front.pNext;
            if (front == null) rear = null;
            else front.pPrev = null;
            Count--;
            return result;
        }

        public T Peek()
        {
            if (front == null) throw new InvalidOperationException("Queue is empty");
            return front.Data;
        }

        public void Clear()
        {
            front = rear = null;
            Count = 0;
        }

        public bool IsEmpty() => front == null;
    }
}