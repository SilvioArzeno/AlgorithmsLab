
using System;
using System.Collections.Generic;

namespace ListPractice
{
    class Program
    {
        static void Main(string[] args)
        {/* --------Linked List from C# Library-------------------*/
         /*
         LinkedList<Object> StringList = new LinkedList<Object>();
         StringList.AddFirst("Hello");
         StringList.AddLast("World");
         LinkedListNode<Object> node = new LinkedListNode<object>("Sub 2 PewDiePie");
         StringList.AddAfter(StringList.First, node);
         foreach(Object a in StringList)
         {
             Console.WriteLine(a);
         }

         Console.ReadKey();
        */


            /*------Circular Linked List implementing IList interface created-------------------------*/
            /*
            LinkedListSilvio<string> practice = new LinkedListSilvio<string>();

            practice.AddFirst("Hello world!");
            practice.AddLast("Always remember");
            practice.AddLast("Sub 2 PewDiePie ");
            practice.AddFirst("T series is gay");
            practice.AddLast("Sub 2 T-series");
            practice.Insert(3, "We are sinking");
            practice.RemoveFirst();
            practice.RemoveLast();
            practice.Erase("We are sinking");
            practice.PrintAll();
            Console.ReadKey();
            */

            /* --------------Static and dynamic array list using IListSilvio interface-----------------*/
            /*
            DynamicArray<string> list = new DynamicArray<string>(1);

            list.AddFirst("Hola");
            list.AddFirst("Subscribe to PewDiePie");
            list.AddLast("Destroy T-Series");
            list.AddFirst("T-series suck");
            list.Insert(3, "We are going down we need your help");
            list.Insert(5, "T series will win");
            list.Erase("T series will win");
           
            list.PrintAll();
            list.RemoveFirst();
            list.RemoveLast();
            list.PrintAll();
            
            Console.ReadKey();
            */

            /*----------------- Queue circular array------------*/
            /*
            CircularArray<int> Queue = new CircularArray<int>(2);
            Queue.Enqueue(3);
            Queue.Enqueue(5);
            Queue.PeekFirst(); //3
            Queue.Dequeue();
            Queue.PeekFirst(); //5
            Queue.Enqueue(9);
            Queue.Enqueue(8);
            Queue.Enqueue(0);
            Queue.PeekLast(); //0
            Queue.Dequeue();
            Queue.Dequeue();
            Queue.PeekFirst(); //8
            Queue.Enqueue(13);
            Queue.Enqueue(19);
            Queue.Dequeue();
            Queue.Dequeue();
            Queue.PrintQueue();

            Console.ReadKey();
            */

            
        }
    }
}
