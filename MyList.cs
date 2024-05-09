using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.DirectoryServices;
using System.Security.Cryptography;
using System.Drawing;
using System.Security.Policy;

namespace WinFormsApp1
{
    public class DoublyNode<T>
    {
        public DoublyNode(T data)
        {
            Data = data;
        }
        public T Data { get; set; }
        public DoublyNode<T> Prev { get; set; }
        public DoublyNode<T> Next { get; set; }
    }
    public class DoublyLinkedList<T> : IEnumerable<T>  
    {
        DoublyNode<T> front; 
        DoublyNode<T> back;
        DoublyNode<T> current;
        int count;  

        public int GetSize()
        {
            return count;
        }

        public void MoveNext()
        {
            if (current != null)
            {
                current = current.Next;
            }
        }
        public void MovePrev()
        {
            if (current != null)
            {
                current=current.Prev;
            }
        }
        public void GetFront()
        {
            current = front;
        }

        public void GetBack()
        {
            current = back;
        }
        public T GetData()
        {
            if (current != null)
            {
                return current.Data;
            }
            else
            {
                throw new Exception("empty list");
            }
        }


        public void PushBack(T data)
        {
            DoublyNode<T> node = new DoublyNode<T>(data);

            if (front == null)
                front = node;
            else
            {
                back.Next = node;
                node.Prev = back;
            }
            back = node;
            count++;
        }

        public T PopBack()
        {
            T value = back.Data;
            if (count == 0)
            {
                throw new Exception("empty list");
            }
            if (count == 1)
            {
                front = null;
                back = null;
                count--;
                return value;
            }
            back = back.Prev;
            back.Next = null;
            count--;
            return value;
        }

        public T PopFront()
        {
            T value = front.Data;
            if (count == 0)
            {
                throw new Exception("empty list");
            }
            if (count == 1)
            {
                front = null;
                back = null;
                count--;
                return value;
            }
            front = front.Next;
            front.Prev = null;
            count--;
            return value;

        }

        
        public bool Remove(T data)
        {
            DoublyNode<T> current = front;
            while (current != null)
            {
                if (current.Data.Equals(data))
                {
                    break;
                }
                current = current.Next;
            }
            if (current != null)
            {
                if (current.Next != null)
                {
                    current.Next.Prev = current.Prev;
                }
                else
                {
                    back = current.Prev;
                }
                if (current.Prev != null)
                {
                    current.Prev.Next = current.Next;
                }
                else
                {
                    front = current.Next;
                }
                count--;
                return true;
            }
            return false;
        }
        public T RemoveAt(int index)
        {
            if (index == 0)
            {
                return PopFront();
            }
            if (index == count - 1)
            {
                return PopBack();
            }
            if (index < 0 || index > count)
            {
                throw new IndexOutOfRangeException("wrong index");
            }

            DoublyNode<T> buf = front;
            for (int i = 0; i < index; i++)
            {
                buf = buf.Next;
            }
            T value = buf.Data;
            (buf.Prev).Next = buf.Next;
            (buf.Next).Prev = buf.Prev;

            count--;
            return value;
        }



        public int Count { get { return count; } }
        public bool IsEmpty { get { return count == 0; } }

        public bool EndOfList()
        {
            return current == null;
        }
        public void Clear()
        {
            front = null;
            back = null;
            current = null;
            count = 0;
        }

        public T Get(int index)
        {
            current = front;
            int c = 0;
            while (current!=null && c < index)
            {
                current = current.Next;
                c++;
            }
            if (current != null)
            {
                return current.Data;
            }
            throw new IndexOutOfRangeException();

        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            DoublyNode<T> current = front;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        public IEnumerable<T> BackEnumerator()
        {
            DoublyNode<T> current = back;
            while (current != null)
            {
                yield return current.Data;
                current = current.Prev;
            }
        }
    }
}
