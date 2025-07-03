using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    public class QueueItem<T>
    {
        public T Data { get; set; }
        public QueueItem<T> pPrev { get; set; }
        public QueueItem<T> pNext { get; set; }

        public QueueItem(T data, QueueItem<T> pPrev = null, QueueItem<T> pNext = null)
        {
            Data = data;
            this.pPrev = pPrev;
            this.pNext = pNext;
        }
    }
}