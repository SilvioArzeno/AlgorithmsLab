﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BSTCool
{
    class DuplicateKeyException : Exception { }
    class InvalidRotation : Exception { }
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

        
        private int Height(TreeNode x)
        {
            if (x == null)
            {
                return -1;
            }
            if (x.left == null && x.right == null)
            {
                return 0;
            }
            
            return Math.Max(Height(x.left), Height(x.right)) + 1;

        }

        private int Balance_Factor(TreeNode x)
        {
            if(x == null)
            {
                return -1;
            }
            return Height(x.right) - Height(x.left);
        }

        public int GetHeight(K key)
        {
           
          return  Height(FindNode(key));
        }

        private int Depth(TreeNode x)
        {
            TreeNode p = x.parent;
            if (p == null)
                return 0;
            int count = 1;
            while(p.parent != null)
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

            cur = prev;
            while(cur != null)
            {
                int HBF = Balance_Factor(cur);
                if(Math.Abs(HBF) > 1)
                {
                    if(HBF < 0)
                    {
                        if(Balance_Factor(cur.left) > 0)
                        {
                            rotateLeft(cur.left);
                        }

                        rotateRight(cur);
                    }
                    else
                    {
                        if( Balance_Factor(cur.right) < 0)
                        {
                            rotateRight(cur.right);
                        }
                        rotateLeft(cur);
                    }
                }
                cur.SubTreeSize = subtreesize(cur.left) + subtreesize(cur.right) + 1;
                cur = cur.parent;
            }

        }
        /** 
            *  rotateLeft(P) rota el nodo P hacia la izquierda.
            **/
        private void rotateLeft(TreeNode P)
        {
            if (P == null || P.right == null)
                throw new InvalidRotation();

            TreeNode par = P.parent;
            TreeNode Q = P.right;
            TreeNode B = Q.left;
            if (B != null)
                B.parent = P;
            P.right = B;
            P.parent = Q;
            Q.left = P;
            Q.parent = par;
            if (par != null)
            {
                if (P == par.left)
                    par.left = Q;
                else
                    par.right = Q;
            }
            else
                root = Q;
        }

        /** 
         *  rotateRight(Q) rota el nodo Q hacia la derecha.
         **/
        private void rotateRight(TreeNode Q)
        {
            if (Q == null || Q.left == null)
                throw new InvalidRotation();

            TreeNode par = Q.parent;
            TreeNode P = Q.left;
            TreeNode B = P.right;
            if (B != null)
                B.parent = Q;
            Q.left = B;
            Q.parent = P;
            P.right = Q;
            P.parent = par;
            if (par != null)
            {
                if (Q == par.left)
                    par.left = P;
                else
                    par.right = P;
            }
            else
                root = P;
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
                else if(x.key.CompareTo(p.key) < 0)
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
                RemoveNode(s);
                x.key = s.key;
                x.value = s.value;
            }
            TreeNode cur = p;
            while (cur != null)
            {
                //  cur.subtreeSize--;
                cur.SubTreeSize = subtreesize(cur.left) +
                                  subtreesize(cur.right) + 1;
                cur = cur.parent;
            }
            cur = p;
            while (cur != null)
            {
                int HBF = Balance_Factor(cur);
                if (Math.Abs(HBF) > 1)
                {
                    if (HBF < 0)
                    {
                        if (Balance_Factor(cur.left) > 0)
                        {
                            rotateLeft(cur.left);
                        }

                        rotateRight(cur);
                    }
                    else
                    {
                        if (Balance_Factor(cur.right) < 0)
                        {
                            rotateRight(cur.right);
                        }
                        rotateLeft(cur);
                    }
                }
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

        public List<K> InOrder()
        {
            /* Iteration using stack

            K[] ret = new K[size];
            Stack<TreeNode> temp = new Stack<TreeNode>();
            TreeNode cur = root;
            for (int i = 0; i < size; i++)
            {
                while (cur != null)
                {
                    temp.Push(cur);
                    cur = cur.left;
                }
                cur = temp.Pop();
                ret[i] = cur.key;
                cur = cur.right;
            }
            return ret;
            */

            List<K> Keys = new List<K>();
            Recursive(Keys, root);
            return Keys;
        }

        private void Recursive(List<K> keys, TreeNode cur)
        {
            if(cur == null)
            {
                return;
            }
            Recursive(keys, cur.left);
            keys.Add(cur.key);
            Recursive(keys, cur.right);
        }
    }
}
