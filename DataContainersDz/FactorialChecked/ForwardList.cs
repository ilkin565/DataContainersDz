using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactorialChecked
{
    public class ForwardList : IEnumerable<int>
    {
        private class ListNode
        {
            public int Value { get; set; }
            public ListNode Next { get; set; }
            public ListNode Previous { get; set; }

            public ListNode(int value)
            {
                Value = value;
            }
        }

        private ListNode head;
        private ListNode tail;

        public void Add(int value)
        {
            var newNode = new ListNode(value);

            if (head == null)
            {
                head = tail = newNode;
            }
            else
            {
                tail.Next = newNode;
                newNode.Previous = tail;
                tail = newNode;
            }
        }

        public IEnumerator<int> GetEnumerator()
        {
            ListNode current = head;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}