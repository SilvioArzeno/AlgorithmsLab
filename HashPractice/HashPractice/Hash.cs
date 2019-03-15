using System;
using System.Collections.Generic;
using System.Text;

namespace HashPractice
{
    class Dictionary<V>
    {

        class KVP
        {
            public string key { get; set; }
            public V value { get; set; }
            public bool Removed { get; set; }

        }

        public int Size { get; set; }
        const int INITIAL_CAPACITY = 4;

        KVP[] arr = new KVP[INITIAL_CAPACITY];

        private KVP Get(string key)
        {
            int pos = Math.Abs((int)Hash(key) % arr.Length);
            foreach(KVP node in arr)
            {
                if(arr[pos] == null)
                {
                    return null;
                }
                else if(arr[pos].key == key)
                {
                    return arr[pos];
                }
                pos++;
                if(pos >= arr.Length)
                {
                    pos = 0;
                }
            }
            throw new KeyNotFoundException();
        }

        private long Hash(string key)
        {
            return 31L * Convert.ToInt32(key) + 8092435135;
        }

        public V Find(string key)
        {
            KVP p = Get(key);
            if(p == null || p.Removed)
            {
                throw new KeyNotFoundException();
            }

            return p.value;
        }

        public V Remove(string key)
        {
            KVP p = Get(key);
            if(p == null || p.Removed)
            {
                throw new KeyNotFoundException();
            }

            p.Removed = true;
            Size--;
            return p.value;
        }

        public
    }
}
