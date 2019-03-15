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

            public KVP(string _key, V _value)
            {
                key = _key;
                value = _value;
            }

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
            return null;
        }
        private long Hash(string key)
        {
            return 31L * key.GetHashCode() + 8092435135;
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

        public V Replace(string key, V value)
        {
            KVP p = Get(key);

            if (p == null || p.Removed)
            {
                throw new KeyNotFoundException();
            }
            V old = p.value;
            p.value = value;

            return old;
        }
         public void add(string key, V value)
        {
            KVP p = Get(key);
            if(p != null && !p.Removed)
            {
                throw new Exception("Duplicate key");
            }
            double LOAD_FACTOR = Size / arr.Length;

            if(LOAD_FACTOR > 0.7)
            {
                Resize(2 * arr.Length);
            }

            int pos = Math.Abs((int)Hash(key) % arr.Length);
           while(true)
            {
                if (arr[pos] == null || arr[pos].Removed)
                {
                    break;
                }
                pos++;
                if(pos >= arr.Length)
                {
                    pos = 0;
                }
            }
            arr[pos] = new KVP(key, value);
            Size++;

        }

        private void Resize(int newcapacity)
        {
            KVP[] temp = new KVP[newcapacity];
            foreach(KVP p in arr)
            {
                if(p == null || p.Removed)
                {
                    continue;
                }
                int pos = Math.Abs((int)Hash(p.key) % newcapacity);
                while (true)
                {
                    if (temp[pos] == null)
                    {
                        break;
                    }
                    pos++;
                    if (pos >= newcapacity)
                    {
                        pos = 0;
                    }
                }
                temp[pos] = p;
            }

            arr = temp;
        }
    }
}
