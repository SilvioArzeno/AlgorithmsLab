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
            public object data;

            public Node(Object T)
            {
                this.data = T;
                next = null;
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

        public void AddNode(object T)
        {
            Node node = new Node(T);
            Node current = head;
            while(current != null)
            {
                current = current.next;
            }

            current.next= node;
            tail = node;
            ListSize++;
        }
    }
}
