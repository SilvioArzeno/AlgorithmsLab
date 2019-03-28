/*
 *
 * Puntos ejercicio: 15
 *
 *
 * Este ejercicio consiste en convertir un Binary Search Tree (arbitrario) a un
 * arbol AVL.
 *
 * Todas las secciones a modificar estan marcardas con el tag TODO.
 *
 * Para simplificar este ejercicio:
 *   1) Grabaremos keys de int (sin value asociado al key)
 *   2) Se permite usar las estructuras de datos en System.Collections.Generic
 *
 * A menos que se indique de lo contrario, no se permite:
 *   1) Alterar los atributos existentes de las clases
 *   2) Alterar el funcionamiento de los otros metodos
 *
 * Instrucciones adicionales: 
 *   a) Se permite agregar mas atributos a las clases
 *   b) Se permite crear metodos adicionales auxiliares a los metodos que debes
 *      implementar
 *   c) No borren los comments que existen en este codigo
 *
 *
 */

using System;
using System.Collections.Generic;
using System.Text;


class DuplicateKeyException : Exception { }
class InvalidRotation : Exception { }

class NotAVLTree
{
    class TreeNode
    {
        public int key;
        public TreeNode left, right, parent;
    //  public int height, depth;  // NOTA: puedes agregar estos atributos si lo deseas
        public TreeNode(int key)
        {
            this.key   = key;
        }

        // Convertir el subtree cuya raiz es este nodo a un string (para
        // verificar que su codigo de conversion funciona)
        // Nota: les sugiero que ignoren este codigo
        override public string ToString() {
            StringBuilder sb = new StringBuilder();
            sb.Append('(');
            sb.Append(key);
            if (left != null || right != null) {
                sb.Append('-');
                sb.Append(left == null ? "()" : left.ToString());
                sb.Append('-');
                sb.Append(right == null ? "()" : right.ToString());
            }
            sb.Append(')');
            return sb.ToString();
        }
    }


    private TreeNode root;
    public int size { get; private set; }  // Cantidad de keys grabados en el arbol


    /** 
     *  Agrega key al arbol
     **/
    public void Add(int key)
    {
        if (size == 0)
        {
            root = new TreeNode(key);
            size = 1;
            return;
        }

        TreeNode cur = root, prev = null;
        while (cur != null)
        {
            if (key == cur.key)
                throw new DuplicateKeyException();
            prev = cur;
            if (key < cur.key)
                cur = cur.left;
            else
                cur = cur.right;
        }
        TreeNode newNode = new TreeNode(key);
        newNode.parent = prev;
        if (key < prev.key)
            prev.left = newNode;
        else
            prev.right = newNode;
        ++size;
    }


    /** 
     *  Busca y devuelve el nodo que contiene key; devuelve null si no se 
     *  encuentra
     **/
    private TreeNode FindNode(int key)
    {
        TreeNode cur = root;
        while (cur != null)
        {
            if (key == cur.key)
                return cur;
            else if (key < cur.key)
                cur = cur.left;
            else
                cur = cur.right;
        }
        return null;
    }
    private int Balance_Factor(TreeNode x)
    {
        if (x == null)
        {
            return -1;
        }
        return Height(x.right) - Height(x.left);
    }


    /** 
     *  Devuelve true si key existe en el arbol
     **/
    public bool Exists(int key)
    {
        TreeNode x = FindNode(key);
        return x != null;
    }
    private TreeNode MinNode(TreeNode cur)
    {
        if (cur == null)
        {
            return null;
        }
        while (cur.left != null)
        {
            cur = cur.left;
        }
        return cur;
    }

    private TreeNode MaxNode(TreeNode cur)
    {
        if (cur == null)
        {
            return null;
        }

        while (cur.right != null)
        {
            cur = cur.right;
        }
        return cur;
    }

    /** 
     *  Borra key del arbol; devuelve false si el key NO se encuentra en el
     *  arbol
     **/
    public bool Remove(int key)
    {
        // TODO: implementar el siguiente algoritmo
        //       1) Buscar el nodo X que contiene key
        //       2) Si X es un leaf o tiene un solo hijo, borralo como fue
        //          descrito para Hibbard's Delete
        //       3) Si X tiene 2 hijos
        //            3a) Ubica el sucesor de X, llamemoslo Y
        //            3b) Rota el nodo Y hasta que se convierta en padre de X
        //            3c) En este punto X no tendra hijo derecho y lo puedes
        //                borrar como en el caso de que tiene un solo hijo
        // Valor: 5 puntos
        // Complejidad esperada: Theta(H)

        TreeNode x = FindNode(key);
        if (x == null)
        {
            throw new KeyNotFoundException();
        }
        V ret = RemoveNode(x);
        size--;
        return ret;

    }


    private int RemoveNode(TreeNode x)
    {
        int ret = x.key;

        TreeNode p = x.parent;
        if (x.left == null && x.right == null)
        {//No tiene hijos
            if (p == null)
            {// Es el root
                root = null;
                return ret;
            }
            if (x.key.CompareTo(p.key) > 0)
            {// Hijo derecho
                p.right = null;
            }
            else if (x.key.CompareTo(p.key) < 0)
            {//Hijo Izquierdo
                p.left = null;
            }
        }
        else if (x.left != null && x.right == null)
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
        }
        TreeNode cur = p;
        
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
                        RotateLeft(cur.left);
                    }


                    RotateRight(cur);
                }
                else
                {
                    if (Balance_Factor(cur.right) < 0)
                    {
                        RotateRight(cur.right);
                    }
                    RotateLeft(cur);
                }
            }
        }
        return ret;
    }

    /** 
     *  rotateLeft(P) rota el nodo P hacia la izquierda.
     **/
    private void RotateLeft(TreeNode P)
    {
        // NOTA: Puedes alterar este metodo
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
        if (par != null) {
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
    private void RotateRight(TreeNode Q)
    { 
        // NOTA: Puedes alterar este metodo
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
        if (par != null) {
            if (Q == par.left)
                par.left = P;
            else
                par.right = P;
        }
        else
            root = P;
    }


    /**
     * Transformar el Binary Search Tree a AVL Tree
     **/
    private bool FixAVLPropertyOfNode(TreeNode x)
    {
        // TODO: Implementa el algoritmo descrito en clase para corregir la
        //       violacion (si existiese) de la propiedad AVL en el nodo x.
        //       NOTA: el algoritmo descrito en clase NO funciona si el
        //       height balance factor del nodo x es < -2 o > +2, en cuyo caso
        //       este metodo simplemente devuelve false; de lo contrario,
        //       corrigelo y devuelve true
        // Complejidad esperada: O(1)
        // Valor: 4 puntos

            int HBF = Balance_Factor(x);
            if (Math.Abs(HBF) > 1)
            {
                if (HBF < 0)
                {
                    if (Balance_Factor(x.left) > 0)
                    {
                        RotateLeft(x.left);
                    }


                    RotateRight(x);
                }
                else
                {
                    if (Balance_Factor(x.right) < 0)
                    {
                        RotateRight(x.right);
                    }
                    RotateLeft(xs);
                }
            return true;
            }

        return false;
    }


    /**
     * Transformar el Binary Search Tree a AVL Tree
     **/

    public List<TreeNode> InOrder()
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

        List<TreeNode> Keys = new List<TreeNode>();
        Recursive(Keys, root);
        return Keys;
    }

    private void Recursive(List<TreeNode> keys, TreeNode cur)
    {
        if (cur == null)
        {
            return;
        }
        Recursive(keys, cur.left);
        keys.Add(cur);
        Recursive(keys, cur.right);
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

    public int GetDepth(int key)
    {
        return Depth(FindNode(key));
    }
    public bool TransformToAVLTree()
    {
        // TODO: Implementa el siguiente algoritmo:
        //       1) Computa el depth de cada nodo en el arbol
        //       2) Ordena los nodos por su depth
        //          Puedes consultar en Internet sobre como ordenar datos en C#
        //       3) Itera los nodos de mayor a menor depth
        //         3a) Calcula el height y balance factor de cada nodo
        //         3b) Si un nodo requiere correccion, llama al metodo
        //             FixAVLPropertyOfNode
        //       Si en alguno punto no fue posible corregirse, devuelve false
        // Complejidad esperada: mejor que cuadratico
        // Valor: 5 puntos

        // TODO: determina la complejidad de cada paso en el algoritmo indicado
        // Valor: 1 punto

        // TODO: Implementa otro algoritmo con complejidad lineal
        // Complejidad esperada: Theta(N)
        // Valor: 3 puntos extras
        List<TreeNode> nodes = InOrder();
        foreach(TreeNode x in nodes)
        {
            
        }
        
        
        return false;
    }


    /**
     * Convertir el arbol a un string (para debugging)
     **/
    override public string ToString() {
        if (root == null) return "";
        return root.ToString();
    }
}


class Lab3v
{
    static void Main(string[] args)
    {
        NotAVLTree T = new NotAVLTree();
        T.Add(90);
        T.Add(100);
        T.Add(20);
        T.Add(10);
        T.Add(70);
        T.Add(30);
        T.Add(40);
        T.Add(50);
        T.Add(80);

        Console.WriteLine(T);
        // (90-(20-(10)-(70-(30-()-(40-()-(50)))-(80)))-(100))

        T.TransformToAVLTree();

        Console.WriteLine(T);
        // (40-(20-(10)-(30))-(90-(70-(50)-(80))-(100)))
        // NOTA: No estoy seguro si este output esta correcto :-P

        T.Remove(40);
        Console.WriteLine(T.Exists(40));  // False

        Console.WriteLine(T);
        // (50-(20-(10)-(30))-(90-(70-()-(80))-(100)))
        // NOTA: Tampoco estoy seguro si este output esta correcto :-P

        Console.ReadKey();
    }
}

