using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RitAutomationTestTask3
{
    public class SingleLinkedNode<TValue>
    {
        public readonly TValue Value;
        public readonly SingleLinkedNode<TValue> Next;

        public SingleLinkedNode(TValue value, SingleLinkedNode<TValue> nextNode)
        {
            Value = value;
            Next = nextNode;
        }
    }

    public class SingleLinkedList<TValue>
    {
        private SingleLinkedNode<TValue> _head;
        private int _count;

        public SingleLinkedNode<TValue> Head
        {
            get { return _head; }
        }

        public int Count
        {
            get { return _count; }
        }

        private SingleLinkedList(SingleLinkedNode<TValue> head, int count)
        {
            _head = head;
            _count = count;
        }

        public SingleLinkedList() { }

        public bool IsEmpty
        {
            get { return _head == null; }
        }

        public TValue this[int index]
        {
            get
            {
                if (index > _count - 1) throw new IndexOutOfRangeException();
                if (_head == null) throw new InvalidOperationException("Sequence contains no elements.");

                var curNode = _head;

                for (int i = 0; i < index; i++)
                {
                    curNode = curNode.Next;
                }

                return curNode.Value;
            }
        }

        public void Add(TValue value)
        {
            if (_head == null)
            {
                _head = new SingleLinkedNode<TValue>(value, null);
                _count = 1;
                return;
            }

            var temp = new SingleLinkedNode<TValue>[_count];

            var curNode = _head;

            for (int i = 0; curNode != null; i++)
            {
                temp[i] = curNode;
                curNode = curNode.Next;
            }

            for (int i = _count - 1; i >= 0; i--)
            {
                if (i == _count - 1)
                {
                    temp[i] = new SingleLinkedNode<TValue>(temp[i].Value, new SingleLinkedNode<TValue>(value, null));
                    continue;
                }

                temp[i] = new SingleLinkedNode<TValue>(temp[i].Value, temp[i + 1]);
            }

            _head = temp[0];
            _count++;
        }

        public void Replace(int index, TValue value)
        {
            if (index > _count - 1) throw new IndexOutOfRangeException();

            var temp = new SingleLinkedNode<TValue>[_count];

            var curNode = _head;

            for (int i = 0; curNode != null; i++)
            {
                if (i == index)
                {
                    var next = i == _count - 1 ? null : curNode.Next;
                    temp[i] = new SingleLinkedNode<TValue>(value, next);
                }
                else
                {
                    temp[i] = curNode;
                }

                curNode = curNode.Next;
            }

            for (int i = _count - 2; i >= 0; i--)
            {
                temp[i] = new SingleLinkedNode<TValue>(temp[i].Value, temp[i + 1]);
            }

            _head = temp[0];
        }

        public SingleLinkedList<TValue> Merge(SingleLinkedList<TValue> another)
        {
            var newCount = _count + another.Count;

            if (newCount == 0)
            {
                return new SingleLinkedList<TValue>();
            }

            var temp = new SingleLinkedNode<TValue>[newCount];
            var curNode = _head;

            for (int i = 0; curNode != null; i++)
            {
                temp[i] = curNode;
                curNode = curNode.Next;
            }

            curNode = another.Head;

            for (int i = 0; curNode != null; i++)
            {
                temp[i + _count] = curNode;
                curNode = curNode.Next;
            }

            for (int i = newCount - 2; i >= 0; i--)
            {
                temp[i] = new SingleLinkedNode<TValue>(temp[i].Value, temp[i + 1]);
            }

            return new SingleLinkedList<TValue>(temp[0], newCount);
        }
    }
}
