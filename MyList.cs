using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Collections;



namespace WinFormsApp1
{
    public class Node<T>
    {
        public Node(T data)
        {
            Data = data;
        }
        public T Data { get; set; }
        public Node<T> Prev { get; set; }
        public Node<T> Next { get; set; }
    }
    public class MyList<T> : IEnumerable<T>

    {
        Node<T> front;
        Node<T> back;
        int count;

        public void Add(T data)
        {
            Node<T> node = new Node<T>(data);
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
        public void PushFront(T data)
        {
            Node<T> node = new Node<T>(data);
            Node<T> temp = front;
            node.Next = temp;
            front = node;
            if (count == 0)
                back = front;
            else
                temp.Prev = node;
            count++;
        }
        public bool Remove(T data)
        {
            Node<T> current = front;
            //поиск удаляемого узла
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
                //если узел не последний
                if (current.Next != null)
                {
                    current.Next.Prev = current.Prev;
                }
                else
                {
                    //если последний, переустанавливаем back
                    back = current.Prev;
                }

                //если узел не первый
                if (current.Prev != null)
                {
                    current.Prev.Next = current.Next;
                }
                else
                {
                    //если первый, переустанавливаем front
                    front = current.Next;
                }
                count--;
                return true;
            }
            return false;
        }
        public int Count { get { return count; } }
        public bool IsEmpty { get { return count == 0; } }

        public void Clear()
        {
            front = null;
            back = null;
            count = 0;
        }

        public bool Contains(T data)
        {
            Node<T> current = front;
            while (current != null)
            {
                if (current.Data.Equals(data))
                    return true;
                current = current.Next;
            }
            return false;
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            Node<T> current = front;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        public IEnumerable<T> BackEnumerator()
        {
            Node<T> current = back;
            while (current != null)
            {
                yield return current.Data;
                current = current.Prev;
            }
        }
    }
}
