using System.Collections;

namespace LinkedList
{
    public class LinkedList<T> : IEnumerable<T>
    {
        Node<T>? head;
        Node<T>? tail;
        public int Count { get; private set; }

        public void AddFirst(T item)
        {
            Node<T> newNode = new Node<T>(item);
            if (head == null)
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                newNode.Next = head;
                head = newNode;
            }
            Count++;
        }

        public void AddLast(T item)
        {
            Node<T> newNode = new Node<T>(item);
            if (tail == null)
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                tail.Next = newNode;
                tail = newNode;
            }
            Count++;
        }

        public void Clear()
        {
            head = null;
            tail = null;
            Count = 0;
        }

        public bool Contains(T item)
        {
            Node<T>? current = head;
            while (current != null)
            {
                if (Equals(current.Data, item))
                {
                    return true;
                }
                current = current.Next;
            }
            return false;
        }

        public Node<T>? Find(T item)
        {
            Node<T>? current = head;
            while (current != null)
            {
                if (Equals(current.Data, item))
                {
                    return current;
                }
                current = current.Next;
            }
            return null;
        }

        public Node<T>? FindLast(T item)
        {
            Node<T>? current = head;
            Node<T>? found = null;
            while (current != null)
            {
                if (Equals(current.Data, item))
                {
                    found = current;
                }
                current = current.Next;
            }
            return found;
        }

        public bool Remove(T item)
        {
            Node<T>? previous = null;
            Node<T>? current = head;

            while (current != null)
            {
                if (Equals(current.Data, item))
                {
                    if (previous != null)
                    {
                        previous.Next = current.Next;
                        if (current == tail)
                        {
                            tail = previous;
                        }
                    }
                    else
                    {
                        head = current.Next;
                        if (head == null)
                        {
                            tail = null;
                        }
                    }
                    Count--;
                    return true;
                }

                previous = current;
                current = current.Next;
            }
            return false;
        }

        public bool RemoveFirst()
        {
            if (head != null)
            {
                head = head.Next;
                Count--;
                if (head == null)
                {
                    tail = null;
                }
                return true;
            }
            return false;
        }

        public bool RemoveLast()
        {
            if (head == null)
            {
                return false;
            }
            if (head == tail)
            {
                head = null;
                tail = null;
                Count--;
                return true;
            }

            Node<T>? current = head;
            while (current != null)
            {
                if (current.Next == tail)
                {
                    tail = current;
                    tail.Next = null;
                    Count--;
                    return true;
                }
                current = current.Next;
            }
            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node<T>? current = head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() 
        {
            return GetEnumerator();
        }
    }
}
