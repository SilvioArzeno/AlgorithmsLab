using System;
using System.Collections.Generic;
using System.Text;

namespace BSTCool
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
            public TreeNode(K _key, V _value )
            {
                key = _key;
                value = _value;
            }
        }

        private TreeNode root;
        public int size { get; set; }

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
            return subtreesize(root);
        }

        public void Add( K key, V value)
        { //Add a new node to the tree

             if(size == 0)
            {// Empty tree
                root = new TreeNode(key, value);
                size = 1;
                return;
            }
            TreeNode cur = root, prev = null;
            while(cur != null)
            {
                if(key.CompareTo(cur.key) == 0)
                {
                    throw new DuplicateKeyException();
                }
                prev = cur;
                if(key.CompareTo(cur.key) < 0)
                {
                    cur = cur.left;
                }
                else if(key.CompareTo(cur.key) > 0)
                {
                    cur = cur.right;
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
            size++;
            cur = prev;
            while(cur != null)
            {
                cur.SubTreeSize = subtreesize(cur.left) + subtreesize(cur.right) + 1;
                cur = cur.parent;
            }
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

            TreeNode p = x.parent;
            if(x.left == null && x.right == null)
            {//No tiene hijos
                if(p == null)
                {// Es el root
                    root = null;
                    return ret;
                }
                if(x.key.CompareTo(p.key) > 0)
                {// Hijo derecho
                    p.right = null;
                }
                else if(x.key.CompareTo(p.key) > 0)
                {//Hijo Izquierdo
                    p.left = null;
                }
            }
            else if(x.left != null && x.right == null)
            {// Tiene un hijo izquierdo 
                TreeNode y = x.left;
                if (p == null)
                {
                    // x == root
                    root = y;
                }
                else if (x == p.left)
                {
                    p.left = y;
                }
                else
                {
                    p.right = y;
                }
                y.parent = p;
            }
            else if (x.right != null && x.left == null)
            {// Tiene un hijo derecho 
                TreeNode y = x.right;
                if (p == null)
                {
                    // x == root
                    root = y;
                }
                else if (x == p.left)
                {
                    p.left = y;
                }
                else
                {
                    p.right = y;
                }
                y.parent = p;
            }

            else if (x.right != null && x.left != null)
            {// Tiene dos hijos
                TreeNode s = MinNode(x.right);  // Succesor
                x.key = s.key;
                x.value = s.value;
                RemoveNode(s);
            }
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
    }
}
