using System;
using System.Collections;

namespace LinkedList.Collection
{
    public class LinkedList<T> : IEnumerable
    {
        private int _size = 0;
        private Node<T> _head = null;
        private Node<T> _tail = null;

        public int Count
        {
            get => _size;
        }

        public T this[int index]
        {
            get
            {
                if (IsOutOfRange(index)) 
                    throw new IndexOutOfRangeException();
                
                return GetNodeByIndex(index).Value;
            }
            set
            {
                if (IsOutOfRange(index)) 
                    throw new IndexOutOfRangeException();

                var node = GetNodeByIndex(index);
                node.Value = value;
            }
        }

        private Node<T> GetNodeByIndex(int index)
        {
            var currentNode = _tail;
            for (int i = 0; currentNode != null; i++)
            {
                if (i == index) return currentNode;
                currentNode = currentNode.Next;
            }
            return null;
        }

        private bool IsOutOfRange(int index) => index < 0 || index >= _size;

        public void AddFirst(T value)
        {
            if (_size++ == 0)
            {
                _head = _tail = new Node<T> {Value = value};
                return;
            }

            var prevTail = _tail;
            _tail = new Node<T> {Value = value, Next = prevTail};
            prevTail.Previous = _tail;
        }

        public void AddLast(T value)
        {
            if (_size++ == 0)
            {
                _head = _tail = new Node<T> {Value = value};
                return;
            }

            var prevHead = _head;
            _head = new Node<T> {Value = value, Previous = prevHead};
            prevHead.Next = _head;
        }

        public void RemoveFirst()
        {
            if (_size == 0) return;

            if (_size-- == 1)
            {
                _head = _tail = null;
                return;
            }

            _tail = _tail.Next;
            _tail.Previous = null;
        }

        public void RemoveLast()
        {
            if (_size == 0) return;

            if (_size-- == 1)
            {
                _head = _tail = null;
                return;
            }

            _head = _head.Previous;
            _head.Next = null;
        }

        public LinkedList<T> FindAll(Predicate<T> predicate)
        {
            var list = new LinkedList<T>();
            foreach (T nodeValue in this)
                if (predicate?.Invoke(nodeValue) == true)
                    list.AddLast(nodeValue);
            
            return list;
        }

        public void Sort<TKey>(Func<T, TKey> keySelector) where TKey: IComparable
        {
            void swapNodesValues(Node<T> node1, Node<T> node2)
            {
                var tmp = node1.Value;
                node1.Value = node2.Value;
                node2.Value = tmp;
            }
            
            if (keySelector == null)
                throw new ArgumentNullException(nameof(keySelector));

            if (_size < 2)
                return;
            
            for (int i = 0; i < _size - 1; i++)
            {
                var element = GetNodeByIndex(0);
                for (int j = 0; j < _size - 1 - i; j++)
                {
                    var currentValue = keySelector(element.Value);
                    var nextValue = keySelector(element.Next.Value);
                    
                    if (currentValue.CompareTo(nextValue) > 0)
                    {
                        swapNodesValues(element, element.Next);
                    }
                    element = element.Next;
                }
            }
        }

        public IEnumerator GetEnumerator()
        {
            var currentNode = _tail;
            while (currentNode != null)
            {
                yield return currentNode.Value;
                currentNode = currentNode.Next;
            }
        }
    }
}