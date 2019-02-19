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
            CurrentSize = 0;
        }
        private object[] ArrayList;
        public int CurrentSize { get; private set; }

        const int GROWTH_FACTOR = 2 ;

        void Resize(int newcapacity)
        {
            object[] temp = new object[newcapacity];
            ArrayList.CopyTo(temp, 0);
            ArrayList = temp;

        }
        bool CheckSpace()
        {
            if (CurrentSize == ArrayList.Length)
            {
                Resize(ArrayList.Length*GROWTH_FACTOR);

            }
            if(CurrentSize <= ArrayList.Length / Math.Pow(GROWTH_FACTOR, 2))
            {
                Resize(ArrayList.Length / GROWTH_FACTOR);
            }
            return true;
        }

        public void AddFirst(object T)
        {
            CheckSpace();
            Insert(0, T);
        }

        public void AddLast(object T)
        {
            CheckSpace();
                Insert(CurrentSize, T);
            
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
            CheckSpace();
        }
        

        public void Insert(int pos, object T)
        {
            for (int i = CurrentSize; i > pos; i--)
            {
                ArrayList[i + 1] = ArrayList[i];
            }
            ArrayList[pos] = T;
            CurrentSize++;
        }
    }
}
