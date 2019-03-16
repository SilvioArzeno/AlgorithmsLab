/*
 * Puntos ejercicio: 9 (+ 1 extra)
 *
 * Como les encanto el "infame" ejercicio Lab4a del Trimestre 2014Q4, vamos
 * repetirlo: implementa operaciones para convertir un Binary Search Tree en un
 * Complete BST.  Al igual que aquel ejercicio, en cada nodo solo grabaremos key
 * (sin valor asociado) y no borraremos datos del arbol.  El codigo en este
 * ejercicio es una traduccion fiel de la version Java a C#.
 *
 *
 * Se permiten usar las estructuras definidas en System.Collections.Generic.
 *
 */

using System;
using System.Collections.Generic;
using System.Text;


class InvalidRotation : System.Exception {}

class BinarySearchTree {
    class TreeNode
    {
        public int key;
        public TreeNode left, right;
        public TreeNode parent;       // padre de este nodo
        public TreeNode(int _key, TreeNode _parent = null)
        {
            key    = _key;
            parent = _parent;  // para reducir la cantidad de lineas de codigo,
                               // asignamos el parent en este constructor
        }

        // Convertir el subtree cuya raiz es este nodo a un string (para
        // verificar que su codigo de conversion funciona)
        // Nota: les sugiero que ignoren este codigo
        override public string ToString() {
            StringBuilder sb = new StringBuilder();
            sb.Append('(');
            sb.Append(key);
            sb.Append('-');
            sb.Append(left == null ? "*" : left.ToString());
            sb.Append('-');
            sb.Append(right == null ? "*" : right.ToString());
            sb.Append(')');
            return sb.ToString();
        }
    }

    TreeNode root;                  // raiz del arbol
    public int size { get; private set; }  // cantidad de datos en el arbol


    /**
     * add(key) agregar 'key' al arbol
     **/
    public void add(int key)
    {
        if (size == 0)
        {
            root = new TreeNode(key);
            size++;
            return;
        }

        TreeNode cur = root;
        while (cur != null)
        {
            if (key == cur.key)
                return;
            if (key < cur.key)
            {
                if (cur.left == null)
                {
                    cur.left = new TreeNode(key, cur);
                    break;
                }
                cur = cur.left;
            }
            else
            {
                if (cur.right == null)
                {
                    cur.right = new TreeNode(key, cur);
                    break;
                }
                cur = cur.right;
            }
        }
        size++;
    }


    /** 
     * toCompleteBST() convierte este arbol a un Complete BST
     **/
    public void toCompleteBST()
    {
        stretch();   // estirar el arbol
        fold();      // plegar
    }


    /** 
     *  stretch() "estira" el arbol para que sea "lineal". El arbol que resulta
     *  de esta operacion debe tener como root el key mas pequenio del arbol
     **/
    public void stretch()
    {
        // TODO: Implementar el siguiente algoritmo:
        //       1) Comienzo con el nodo de la raiz
        //       2) Mientras el nodo tiene hijo izquierdo:
        //            2.1) roto el nodo hacia la derecha
        //            2.2) me "devuelvo" a la nueva raiz del subarbol donde
        //                 ejecute la rotation; o sea, al padre del nodo rotado
        //       3) En este punto, el subarbol ya no tiene hijo izquierdo,
        //          por lo tanto, ya esta "estirado".  Entonces, simplemente
        //          avanzamos al subarbol derecho y repetimos desde el paso 2
        // Complejidad esperada: O(N)
        // Valor: 3 puntos

    }
    

    /** 
     *  fold(x) pliega un arbol "estirado" para convertirlo a un Complete
     *  Binary Tree
     **/
    public void fold()
    {
        // TODO: Implementar el siguiente algoritmo:
        //       1) Calcular la cantidad de hojas en el ultimo nivel de un
        //          Complete Binary Tree que tiene 'size' nodos.  Por ejemplo,
        //          si size = 9, la cantidad de leaves en el ultimo nivel es 2.
        //          HINT: de size, "restale" la cantidad de nodos de cada nivel
        //
        //       2) Si ese ultimo nivel NO esta lleno completo (o sea, el arbol
        //          no es un Perfect Binary Tree), comenzamos en la raiz y
        //          repetimos las siguientes operaciones X veces, donde
		  //          X = cantidad de leaves en el ultimo nivel
        //          2.1) Rotar el nodo hacia la izquierda
        //          2.2) Avanzar hacia la derecha de la (nueva) raiz del
        //               subarbol rotado; o sea, al nodo hermano del nodo rotado
        //
        //       3) Calculamos la cantidad remanente de nodos aun 'estirados'
        //          rem = size - cantidad de rotaciones ejecutadas en el paso 2.1
        //
        //       4) Mientras la cantidad remanente de nodos es mas de 1
        //          4.1) Comenzando desde root
        //          4.2) Repetimos los mismos pasos de 2.1 y 2.2 por rem/2 veces
        //               (division entera)
        //          4.3) Reducimos rem a la mitad (division entera)
        //
        // Valor: 6 puntos


        // TODO: Determina la complejidad de cada paso descrito arriba
        // Valor: 1 punto (extra)
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
     * Convertir el arbol a un string (para verificar que tu implementacion
     * de stretch() y fold() funcionan
     **/
    override public string ToString() {
        if (root == null) return "";
        return root.ToString();
    }

}



class Lab4a
{
    public static void Main()
    {
        BinarySearchTree tree = new BinarySearchTree();
        tree.add(5);
        tree.add(2);
        tree.add(3);
        tree.add(6);
        tree.add(7);
        tree.add(4);
        tree.add(1);
        tree.add(9);
        tree.add(8);

        Console.WriteLine("Despues de los adds:");
        Console.WriteLine(tree);
     // (5-(2-(1-*-*)-(3-*-(4-*-*)))-(6-*-(7-*-(9-(8-*-*)-*))))

        tree.stretch();
        Console.WriteLine("Despues de stretch:");
        Console.WriteLine(tree);
     // (1-*-(2-*-(3-*-(4-*-(5-*-(6-*-(7-*-(8-*-(9-*-*)))))))))

        tree.fold();
        Console.WriteLine("Despues de fold:");
        Console.WriteLine(tree);
     // (6-(4-(2-(1-*-*)-(3-*-*))-(5-*-*))-(8-(7-*-*)-(9-*-*)))

    }
}


