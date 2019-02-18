using System;
using System.Collections.Generic;
using System.Text;

namespace ListPractice
{
    class StaticArrayList : IListSilvio
    {

        public StaticArrayList(int space)
        {
            ArrayList = new object[space];
            ArraySpace = space;
            CurrentSize = 0;
        }
        private object[] ArrayList;
        public int ArraySpace { get; private set; }
        public int CurrentSize { get; private set; }
        

        void Resize(int newcapacity)
        {
            object[] temp = new object[newcapacity];
            ArrayList.CopyTo(temp, 0);
            ArrayList = temp;
            CurrentSize = temp.Length;

        }
        bool CheckSpace()
        {
            if (CurrentSize == ArraySpace)
            {
                Console.WriteLine("The list is full, please remove an element to free some space");
                return false;
            }

            else return true;

        }

        public void AddFirst(object T)
        {
            if (CheckSpace())
            {
                if (CurrentSize != 0)
                {
                    for (int i = CurrentSize - 1; i >= 0; i--)
                    {
                        ArrayList[i + 1] = ArrayList[i];
                    }
                    ArrayList[0] = T;
                }
                else ArrayList[0] = T;

                CurrentSize++;
            }
        }

        public void AddLast(object T)
        {
            if (CheckSpace())
            {
                ArrayList[CurrentSize] = T;
                CurrentSize++;
            }
        }

        public void PrintAll()
        {
            if(CurrentSize == 0)
            {
                Console.WriteLine("This list is empty");
                return;
            }

            for( int i = 0; i < CurrentSize; i++)
            {
                Console.WriteLine(ArrayList[i]);
            }
        }

        public void RemoveFirst()
        {
            if (CurrentSize == 0)
            {
                Console.WriteLine("This list is empty");
                return;
            }

            for(int i = CurrentSize - 1; i > 0; i--)
            {
                ArrayList[i] = ArrayList[i - 1];
            }

            CurrentSize--;
        }


        public void RemoveLast()
        {
            if (CurrentSize == 0)
            {
                Console.WriteLine("This list is empty");
                return;
            }

            ArrayList[CurrentSize - 1] = null;
            CurrentSize--;
        }
        

        public void Insert(int pos, object T)
        {

        }
    }
}
