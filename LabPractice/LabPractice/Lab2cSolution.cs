using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class EmptyListException : Exception { }

class CLinkedList
{
    // Nodo del Circular Linked List, identico al nodo de un Doubly Linked List
    class CLinkNode
    {
        public int value;
        public CLinkNode prev, next;
        public CLinkNode(int val)
        {
            value = val;
        }
    }

    private CLinkNode cur;    // nodo actual en el Linked List
    public int size { get; private set; }         // cantidad de elementos en el Linked List


    /**
     * Devuelve el valor grabado en el nodo actual
     * @return        el valor en el nodo actual
     **/
    public int get()
    {
        if (size == 0)
            throw new EmptyListException();
        return cur.value;
    }


    /**
     *  Agrega el valor val a la lista
     *  Side effects: El nodo actual se mueve al nuevo nodo creado
     *  @param  val  valor a agregar a la lista
     */
    public void add(int val)
    {
        // TODO: implementar
        // NOTA: puedes insertar el valor en cualquier posicion de la lista,
        //       teniendo en cuenta la complejidad deseada y el codigo que
        //       tendras que escribir en la clase Lab2c
        // Complejidad esperada: O(1) en worst-case
        // Valor: 3 puntos

        CLinkNode newNode = new CLinkNode(val);
        if (size == 0)
        {
            newNode.next = newNode;
            newNode.prev = newNode;
            cur = newNode;
            size = 1;
            return;
        }

        CLinkNode nxt = cur.next;
        newNode.prev = cur;
        newNode.next = nxt;
        cur.next = newNode;
        nxt.prev = newNode;
        cur = newNode;
        size++;
    }

    
    /**
     * Localiza el valor en la lista, reposicionando el nodo actual al nodo
     * que contiene dicho valor.  Si la lista contiene multiples valores
     * duplicados, puedes elegir cualquiera.
     * @param  val  valor a buscar en la lista
     * @return      true si lo encuentra; de lo contrario, devuelve false
     */
    public bool locate(int val)
    {
        // TODO: implementar
        // Complejidad esperada: O(N) en worst-case
        // Valor: 1 punto

        CLinkNode x = cur;
        for (int i = 0; i < size; i++)
        {
            if (x.value == val)
            {
                cur = x;
                return true;
            }
            x = x.next;
        }

        return false;
    }


    /**
     * Mueve el nodo actual 'cur' steps pasos.
     *    Si steps es positivo, se mueve hacia adelante
     *    Si steps es negativo, mueve hacia atras
     *    Si steps == 0, se queda donde esta
     * @param   la cantidad de pasos a moverse
     */
    public void moveTo(int steps)
    {
        // TODO: implementar
        // Complejidad esperada: O(min(|steps|, N)) en worst-case, donde steps
        //                       es el parametro de este metodo
        // OJO: Es posible que |steps| > N
        // Valor: 2 puntos

        if (steps == 0)
            return;

        if (steps > 0)
        {
            for (int i = 0; i < steps; i++)
            {
                cur = cur.next;
            }
        }
        else
        {
            steps = -steps;
            for (int i = 0; i < steps; i++)
            {
                cur = cur.prev;
            }
        }
    }


   /**
     *  Elimina el nodo acual y devuelve el valor grabado en dicho nodo
     *  Side effects: el nodo actual debe moverse a uno de los nodos adyacentes
     *                (si existe) del nodo borrado
     *  @return       el valor grabado en la posicion actual
     */
    public int remove()
    {
        if (size == 0)
            throw new EmptyListException();

        // TODO: implementar
        // Complejidad esperada: O(1) en worst-case
        // Valor: 3 puntos

        int ret = cur.value;

        if (size == 1)
        {
            cur = null;
            size = 0;
            return ret;
        }

        CLinkNode prv = cur.prev;
        CLinkNode nxt = cur.next;

        prv.next = nxt;
        nxt.prev = prv;
        size--;

        cur = nxt;

        return ret;
    }

}


class Result
{
    public int[] execution_order;
    public int[] survivors;
}

class Program
{

    public static Result josephus(int N, int K, int S)
    {
        // TODO: usando los metodos definidos en el Circurlar Linked List,
        // implementa una solucion al problema de Flavio Josefo
        //
        // Debes simular el juego con los parametros N, K y S:
        // * Tenemos N personas paradas alrededor de un circulo, donde N es la
        //   cantidad de personas al inicio del juego.  Para identificacion,
        //   cada persona es numerada desde 1 a N, en orden de la manecilla
        //   del reloj.
        // * En el inicio, la persona #1 es ejecutada.
        // * A partir de ahi, ejecutan a cada K persona (es decir, brincamos K-1
        //   personas).
        // * La simulacion se repite hasta que queden S sobrevivivientes,
        //   quienes decidir no seguir jugando este macabro juego.
        //
        // Devuelve un objeto de la clase Result, donde:
        //  a) el atributo execution_order contiene el orden de ejecucion de las
        //     personas aniquilidas en el proceso
        //  b) el atributo survisors contiene una lista de los sobrevivientes
        //     (en cualquier orden)
        //
        // Ejemplo: Para N=41, K=3 y S=2:
        // execution_orden = {
        //    1, 4, 7, 10, 13, 16, 19, 22, 25, 28, 31, 34, 37, 40, 3, 8, 12,
        //    17, 21, 26, 30, 35, 39, 5, 11, 18, 24, 32, 38, 6, 15, 27, 36,
        //    9, 23, 41, 20, 2, 33
        // }
        // survivors = { 14, 29 }
        //
        // Asume que los parametors N, K, S tienen valores validos
        //

        //
        // Complejidad esperada: O(N*K) en worst-case
        // Valor: 5 puntos

        int cantidadVictimas = N - S;

        Result res = new Result();
        res.execution_order = new int[cantidadVictimas];
        res.survivors = new int[S];

        if (N == S)
        {
            for (int n = 0; n < N; n++)
                res.survivors[n] = n + 1;
            return res;
        }

        CLinkedList circuloDeLaMuerte = new CLinkedList();
        for (int n = 1; n <= N; n++)
            circuloDeLaMuerte.add(n);

        res.execution_order[0] = 1;
        circuloDeLaMuerte.locate(1);
        circuloDeLaMuerte.remove();

        for (int m = 1; m < cantidadVictimas; m++)
        {
            circuloDeLaMuerte.moveTo(K - 1);
            res.execution_order[m] = circuloDeLaMuerte.get();
            circuloDeLaMuerte.remove();
        }

        for (int s = 0; s < S; s++)
        {
            res.survivors[s] = circuloDeLaMuerte.get();
            circuloDeLaMuerte.moveTo( -1 );
        }

        return res;
    }

    static void Main(string[] args)
    {
        Result res1 = josephus(41, 3, 2);
        Console.WriteLine("Execution order: " +
                           ToString(res1.execution_order));
        Console.WriteLine("Survivors: " +
                           ToString(res1.survivors));
        Console.WriteLine();

        Console.ReadLine();
    }

    static string ToString(int[] arr)
    {
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < arr.Length; i++)
        {
            if (i > 0)
                sb.Append(' ');
            sb.Append(arr[i]);
        }
        return sb.ToString();
    }
}
