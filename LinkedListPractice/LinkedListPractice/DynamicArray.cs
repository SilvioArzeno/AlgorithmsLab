using System;
using System.Collections.Generic;
using System.Text;

namespace ListPractice
{
    class DynamicArray<T> : IListSilvio<T>
    {

        public DynamicArray(int space)
        {
            ArrayList = new T[space];
            CurrentSize = 0;
        }
        private T[] ArrayList;
        public int CurrentSize { get; private set; }

        const int GROWTH_FACTOR = 2 ;

        void Resize(int newcapacity)
        {
            T[] temp = new T[newcapacity];
            for(int i = CurrentSize; i > 0; i--)
            {
                temp[i - 1] = ArrayList[i - 1];
            }
            ArrayList = temp;

        }
        bool CheckSpace()
        {
            if (CurrentSize == ArrayList.Length)
            {
                Resize(ArrayList.Length*GROWTH_FACTOR);

            }
            if(CurrentSize + 1 <= ArrayList.Length / Math.Pow(GROWTH_FACTOR, 2))
            {
                Resize(ArrayList.Length / GROWTH_FACTOR);
            }
            return true;
        }

        public void AddFirst(T element)
        {
            CheckSpace();
            Insert(0, element);
        }

        public void AddLast(T element)
        {
            CheckSpace();
                Insert(CurrentSize, element);
            
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
            CheckSpace();
            Erase(0);
        }


        public void RemoveLast()
        {
            CheckSpace();
            Erase(CurrentSize);
        }
        

        public void Insert(int pos, T element)
        {
            CheckSpace();
            for (int i = CurrentSize; i > pos; i--)
            {
                ArrayList[i] = ArrayList[i-1];
            }
            ArrayList[pos] = element;
            CurrentSize++;
        }

        public void Erase(int pos)
        {
            CheckSpace();
            if (CurrentSize == 0 || pos < 0 || pos > CurrentSize)
            {
                Console.WriteLine("This position is already empty");
                return;
            }
            for (int i = pos ; i < CurrentSize ; i++)
            {
                ArrayList[i] = ArrayList[i + 1];
            }
            CurrentSize--;

        }
        public void Erase(T element)
        {
            CheckSpace();
            for(int i = 0; i < CurrentSize; i++)
            {
                if (ArrayList[i].Equals(element))
                {
                    Erase(i);
                }
            }
            
        }
    }
}
