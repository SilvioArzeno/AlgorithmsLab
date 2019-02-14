
using System;

namespace ListPractice
{
    class Program
    {
        static void Main(string[] args)
        {/* Linked List from C# Library

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

            /* Linked List implementing IList interface created 

            LinkedListSilvio practice = new LinkedListSilvio();

            practice.AddFirst("Hello world!");
            practice.AddLast("Always remember");
            practice.AddLast("Sub 2 PewDiePie ");
            practice.AddFirst("T series is gay");
            practice.AddFirst(85000000);
            practice.AddLast("Sub 2 T-series");
            practice.RemoveFirst();
            practice.RemoveLast();

            practice.PrintAll();
            Console.ReadKey();
            */

            StaticArrayList list = new StaticArrayList(10);

            list.AddFirst("Hola");
            list.AddLast(85000000);
            list.AddFirst("Subscribe to PewDiePie");
            list.AddLast("Destroy T-Series");
            for (int i = 0; i < 10; i++)
            {
                list.AddFirst("T-series suck");
            }
            list.PrintAll();
            Console.ReadKey();
        }
    }
}
