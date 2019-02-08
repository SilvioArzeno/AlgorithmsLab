using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedListPractice
{
    class LinkedListSilvio
    {
        public class Node
        {
            public Node next;
            public Node prev;
            public object data;

            public Node(Object T)
            {
                this.data = T;
                next = null;
                prev = null;
            }
        }

        private Node head;
        private Node tail;
        private int ListSize;

        public LinkedListSilvio()
        {
            head = null;
            tail = null;
            ListSize = 0;
        }
        public void AllNodes()
        {
            Node current = head;
            while (current != null)
            {
                Console.WriteLine(current.data);
                current = current.next;
            }
        }

        public void AddFirst(Object T)
        {
            Node node = new Node(T);
            if (head == null)
            {
                head = node;
                tail = node;
                ListSize++;
                return;
            }
            node.next = head;
            head.prev = node;
            head = node;
            ListSize++;

        }

        public void AddLast(object T)
        {
            Node node = new Node(T);
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
            ListSize++;
        }

        public void RemoveFirst()
        {
            if(head == null)
            {
                Console.WriteLine("The list is empty you can't delete anything");
                return;
            }

            object temp = head.data;
            head.next.prev = null;
            head = head.next;
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

            object temp = tail.data;
            tail.prev.next = null;
            tail = tail.prev;
            ListSize--;
            Console.WriteLine("Eliminated "+ temp +" from the ending of the list");

        }

    }
}
