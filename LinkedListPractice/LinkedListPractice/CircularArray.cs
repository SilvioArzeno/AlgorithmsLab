using System;
using System.Collections.Generic;
using System.Text;

namespace ListPractice
{
    class CircularArray<T>
    {
        public CircularArray(int space)
        {
            MainArray = new T[space];
            head = 0;
            tail = 0;
        }
        public T[] MainArray { get; set; }
        int head;
        int tail;
        int size;
        const int GROWTH_FACTOR = 2;
        public void Enqueue(T element)
        {

            CheckQueue();
            MainArray[tail] = element;
            tail++;
            size++;

        }

        public void Dequeue()
        {
            head++;
            size--;
            CheckQueue();
        }
        public void PeekFirst()
        {
            if (head != tail)
                Console.WriteLine(MainArray[head]);

            else
                Console.WriteLine("Queue is empty");
        }

        public void PeekLast()
        {
            if (head != tail)
            {
                if(tail != 0)
                Console.WriteLine(MainArray[tail - 1]);

                else
                    Console.WriteLine((MainArray[MainArray.Length - 1]));
            }
            else
                Console.WriteLine("Queue is empty");
        }

        void CheckQueue()
        {
            if (tail == MainArray.Length)
            {
                tail = 0;
            }
            if(head == MainArray.Length)
            {
                head = 0;
            }
            if (size > 1)
            {
                if (head == tail)
                {
                    ResizeQueue(MainArray.Length * GROWTH_FACTOR);
                }
            }
        }

        private void ResizeQueue(int newcapacity)
        {
            T[] temp = new T[newcapacity];
            bool GoBack = false;
            for(int i = head; i <= size; i++)
            {
                if(i == MainArray.Length)
                {
                    GoBack = true;
                    break;
                }

                temp[i - head] = MainArray[i];
            }

            if (GoBack)
            {
                for(int i = 0; i < tail; i++)
                {
                    temp[MainArray.Length - head + i] = MainArray[i];
                }

                tail = MainArray.Length - head + tail;
            }
            head = 0;
            MainArray = temp;
        }

        public void PrintQueue()
        {
            if(size == 0)
            {
                Console.WriteLine("The queue is empty");
                return;
            }
            bool GoBack = false;
            for (int i = head; i != tail; i++)
            {
                if (i == MainArray.Length)
                {
                    GoBack = true;
                    break;
                }

                Console.WriteLine(MainArray[i]);
            }

            if (GoBack)
            {
                for (int i = 0; i < tail; i++)
                {
                    Console.WriteLine(MainArray[i]);
                }
            }
        }
    }   
    
}
