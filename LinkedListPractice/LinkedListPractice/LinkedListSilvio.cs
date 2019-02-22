using System;
using System.Collections.Generic;
using System.Text;

namespace ListPractice
{
    class LinkedListSilvio<T> : IListSilvio<T>
    {
        public class Node
        {
            public Node next;
            public Node prev;
            public T data;

            public Node(T element)
            {
                this.data = element;
                next = null;
                prev = null;
            }
        }

        private Node head;
        private Node tail;
        public int ListSize { get; private set; }

        public LinkedListSilvio()
        {
            head = null;
            tail = null;
            ListSize = 0;
        }
        public void PrintAll()
        {
            Node current = head;
            while (current != null)
            {
                Console.WriteLine(current.data);
                current = current.next;
            }
        }

        public void AddFirst(T element)
        {
            Node node = new Node(element);
            if (head == null)
            {
                head = node;
                tail = node;
                ListSize++;
                return;
            }
            node.next = head;
            head.prev = node;
            node.prev = tail;
            head = node;
            ListSize++;

        }

        public void AddLast(T element)
        {
            Node node = new Node(element);
            if (tail == null)
            {
                head = node;
                tail = node;
                ListSize++;
                return;
            }
            tail.next = node;
            node.prev = tail;
            tail = node;
            node.next = head;
            ListSize++;
        }

        public void RemoveFirst()
        {
            if(head == null)
            {
                Console.WriteLine("The list is empty you can't delete anything");
                return;
            }

            T temp = head.data;
            head.next.prev = tail;
            head = head.next;
            tail.next = head;
            ListSize--;
            Console.WriteLine("Eliminated "+ temp +" from the beginning of the list");
        }

        public void RemoveLast()
        {
            if (head == null)
            {
                Console.WriteLine("The list is empty you can't delete anything");
                return;
            }

            T temp = tail.data;
            tail.prev.next = head;
            tail = tail.prev;
            ListSize--;
            Console.WriteLine("Eliminated "+ temp +" from the ending of the list");

        }

        public void Insert(int pos, T element)
        {
            Node temp = new Node(element);
            Node Current = head;
            for(int i = 0; i < pos; i++)
            {
                Current = Current.next;
            }
            temp.next = Current;
            temp.prev = Current.prev;
            Current.prev.next = temp;
            Current.prev = temp;
            ListSize++;
        }

        public void Erase(int pos)
        {
            if (pos == 0)
                RemoveFirst();
            else if (pos == ListSize)
                RemoveLast();
            else
            {
                Node Current = head;
                for (int i = 0; i < pos; i++)
                {
                    Current = Current.next;
                }
                Current.prev.next = Current.next;
                Current.next.prev = Current.prev;
                Current = null;
                ListSize--;
            }
        }

        public void Erase(T element)
        {
            Node current = head;
            bool found = false;
            do
            {
                if (current.data.Equals(element))
                {
                    current.next.prev = current.prev;
                    current.prev.next = current.next;
                    current = null;
                    found = true;
                    ListSize--;
                    break;
                }
                current = current.next;
            }
            while (current != head);
            if (!found)
            {
                Console.WriteLine("Element not found in the list");
            }
        }
    }
}
