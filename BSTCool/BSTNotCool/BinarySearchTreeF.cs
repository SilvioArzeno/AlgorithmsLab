using System;
using System.Collections.Generic;
using System.Text;

namespace BSTNotCool
{
    class DuplicateKeyException : Exception { }
    class OrderedDictionary<K,V> where K : IComparable<K>
    {   
        
        private class TreeNode
        {
            public K key;
            public V value;
            public TreeNode left, right, parent;
            public int SubTreeSize = 1;
            public bool Removed = false;
            public TreeNode(K _key, V _value )
            {
                key = _key;
                value = _value;
            }
        }
        public int size;
        private TreeNode root;
        private int subtreesize(TreeNode x)
        {
            if(x == null)
            {
                return 0;
            }
            return x.SubTreeSize;
        }
        public  int Size()
        {
            size = subtreesize(root);
            return size;
        }
        private int Height(TreeNode x)
        {
            if (x == null || (x.left == null && x.right == null))
            {
                return 0;
            }

            return Math.Max(Height(x.left), Height(x.right)) + 1;

        }

        public int GetHeight(K key)
        {
            return Height(FindNode(key));
        }

        private int Depth(TreeNode x)
        {
            TreeNode p = x.parent;
            if (p == null)
                return 0;
            int count = 1;
            while (p.parent != null)
            {
                count++;
                p = p.parent;
            }
            return count;
        }

        public int GetDepth(K key)
        {
            return Depth(FindNode(key));
        }

        public void Add( K key, V value)
        { //Add a new node to the tree

             if(root == null)
            {// Empty tree
                root = new TreeNode(key, value);
                size = 1;
                return;
            }
            TreeNode cur = root, prev = null;
            while(cur != null)
            {

                prev = cur;
                if (key.CompareTo(cur.key) == 0 && !cur.Removed)
                {
                    return;
                }
               
                if(key.CompareTo(cur.key) < 0 && !cur.Removed)
                {
                    cur = cur.left;
                }
                else if(key.CompareTo(cur.key) > 0 && !cur.Removed)
                {
                    cur = cur.right;
                }
                else if(cur.Removed)
                {
                    if(key.CompareTo(cur.key) > 0)
                    {
                        cur = cur.right;
                    }
                    else if (key.CompareTo(cur.key) < 0)
                    {
                        cur = cur.left;
                    }
                    else
                    {
                        cur.Removed = false;
                        size++;
                    }
                }
            }

            TreeNode newNode = new TreeNode(key, value);
            newNode.parent = prev;
            if(key.CompareTo(prev.key) < 0)
            {
                prev.left = newNode;
            }
            else if(key.CompareTo(prev.key) > 0)
            {
                prev.right = newNode;
            }
            cur = prev;
            while(cur != null)
            {
                cur.SubTreeSize = subtreesize(cur.left) + subtreesize(cur.right) + 1;
                cur = cur.parent;
            }

            size++;
        }

        public V Remove(K key)
        {
            TreeNode x = FindNode(key);
            if (x == null)
            {
                throw new KeyNotFoundException();
            }
            V ret = RemoveNode(x);
            size--;
            return ret;


        }

        private V RemoveNode(TreeNode x)
        {
            V ret = x.value;
            x.Removed = true;
            x.SubTreeSize--;
            TreeNode p = x.parent;
            
            TreeNode cur = p;
            while (cur != null)
            {
                //  cur.subtreeSize--;
                cur.SubTreeSize = subtreesize(cur.left) +
                                  subtreesize(cur.right) + 1;
                cur = cur.parent;
            }
            return ret;
        }

        private TreeNode MinNode(TreeNode cur)
        {
            if (cur == null)
            {
                return null;
            }
            while(cur.left != null)
            {
                cur = cur.left;
            }
            return cur;
        }

        private TreeNode MaxNode(TreeNode cur)
        {
            if(cur == null)
            {
                return null;
            }

            while(cur.right != null)
            {
                cur = cur.right;
            }
            return cur;
        }

        private TreeNode FindNode(K key)
        {
            TreeNode cur = root;
            while( cur != null)
            {
                if(cur.key.CompareTo(key) == 0)
                {
                    return cur;
                }
                if(key.CompareTo(cur.key) < 0)
                {
                    cur = cur.left;
                }
                if(key.CompareTo(cur.key) > 0)
                {
                    cur = cur.right;
                }

            }
            return null;
        }

        public V Find(K key)
        {
            TreeNode ret = FindNode(key);
            if(ret == null)
            {
                throw new KeyNotFoundException();
            }
            return ret.value;
        }

        public K Min()
        {
            TreeNode min = MinNode(root);
            if(min == null)
            {
                throw new KeyNotFoundException();
            }
            return min.key;
        }

        public K Max()
        {
            TreeNode max = MaxNode(root);
            if (max == null)
            {
                throw new KeyNotFoundException();
            }
            return max.key;
        }

        public K Successor(K key)
        {
            TreeNode cur = root, best = null;
            while (cur != null)
            {
                if (key.CompareTo(cur.key) == 0)
                {
                    cur = cur.right;
                }

                else if (key.CompareTo(cur.key) < 0)
                {
                    if (best == null || best.key.CompareTo(cur.key) > 0)
                    {
                        best = cur;
                    }
                    cur = cur.left;
                }

                else
                {
                    cur = cur.right;
                }
            }

            if(best == null) // no hay successor
            {
                throw new KeyNotFoundException();
            }
            return best.key;
        }

        public K Predecessor(K key)
        {
            TreeNode cur = root, best = null;
            while (cur != null)
            {
                if (key.CompareTo(cur.key) == 0)
                {
                    cur = cur.left;
                }

                else if (key.CompareTo(cur.key) > 0)
                {
                    if (best == null || best.key.CompareTo(cur.key) > 0)
                    {
                        best = cur;
                    }
                    cur = cur.right;
                }

                else
                {
                    cur = cur.left;
                }
            }

            if (best == null) // no hay successor
            {
                throw new KeyNotFoundException();
            }
            return best.key;
        }

        public int Rank(K key)
        {
            TreeNode cur = root;
            int count = 0;
            while (cur != null)
            {
                if(key.CompareTo(cur.key) > 0)
                {
                    count += subtreesize(cur.left) + 1;
                    cur = cur.right;
                }
                else if (key.CompareTo(cur.key) < 0)
                {
                    cur = cur.left;
                }
                else
                {
                    count += subtreesize(cur.left);
                    break;
                }
            }

            return count;
        }

        public K Select(int pos)
        {
            if(pos >= size || pos < 0)
            {
                throw new KeyNotFoundException();
            }
            int KeysMenores = pos;
            TreeNode cur = root;
            while (cur != null)
            {
                if (KeysMenores - subtreesize(cur.left) < 0)
                {
                    cur = cur.left;
                }
                else if (KeysMenores - subtreesize(cur.left) > 0)
                {
                    KeysMenores -= subtreesize(cur.left) + 1;
                    cur = cur.right;
                }   
                else
                {
                    return cur.key;
                }
            }
            throw new Exception("This is not supposed to happen");
        }
    }
}
