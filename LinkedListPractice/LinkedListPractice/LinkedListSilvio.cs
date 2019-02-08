﻿using System;
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
            tail = node;
            ListSize++;
        }


    }
}
