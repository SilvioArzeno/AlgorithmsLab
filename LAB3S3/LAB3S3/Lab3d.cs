/*
 *
 * Puntos ejercicio: 10
 *
 * En este ejercicio implementaremos la siguiente variante de Open Addressing:
 * En la insercion de un nuevo key, la resolucion de colisiones es similar a
 * Linear Probing (con step size 1), excepto que solo iteraremos un maximo de
 * MAX_PROBES pasos.  Si despues de iterar MAX_PROBES veces, no se encontro un
 * bucket disponible, el nuevo key se agrega al final de una secuencia llamada
 * stash (este puede ser un Dynamic Array o Linked List).
 *
 * Para simplificar, asumiremos que los keys son numeros enteros y que no hay
 * Remove.
 *
 * Ubica todas las secciones con el tag TODO.  Cada tag les indicara que deben
 * completar.  Para TODOs que requieren respuestas, escribe las respuestas en
 * un comment.
 *
 * Instrucciones adicionales: 
 *   a) No borren los comments que existen en este codigo
 *   b) No alteren la firma de los metodos existentes; o sea, no pueden cambiar
 *      el return type, ni agregar mas parametros, ni modificar sus tipos de
 *      datos
 *
 */

using System;
using System.Collections.Generic;

public class KeyNotFoundException : System.Exception {}
public class DuplicateKeyException : System.Exception {}

public class MyDictionary<V>
{
    // Pareja de Key y Value a grabar en cada bucket del Hash Table (y en el
    // stash)
    class KeyValuePair
    {
        public int key;
        public V value;
        public KeyValuePair(int key, V value)
        {
            this.key   = key;
            this.value = value;
        }
    }

    const int INITIAL_SIZE = 3;  // capacidad inicial del arreglo arr

    // Hash Table normal
    private KeyValuePair[] arr = new KeyValuePair[INITIAL_SIZE];

    // Lista donde se graban los keys que no "caben" en el Hash Table
    private List<KeyValuePair> stash = new List<KeyValuePair>();
    // NOTA: Si te es mas comodo, puedes reemplazarlo por tu propio Dynamic
    //       Array o Linked List


    // Cantidad de datos grabados en la estructura de datos (incluyendo los
    // que estan en el stash)
    public int Size { get; private set; }
    

    // funcion hash a usar
    private int hash(int key) {
        return key * 31 + 987654321;
    }

    const int MAX_PROBES = 10; // Maxima cantidad de probes antes de ir al stash
    const double MAX_LOAD_FACTOR = 0.65;  // Maximo Load Factor a permitir
    const int GROWTH_FACTOR = 2;  // Factor de crecimiento para Resize

    // Agregar 'key' al diccionario asociandolo al valor 'value'
    public void Add(int key, V value)
    {
        // TODO: Implementar la estrategia descrita en el enunciado.  En adicion
        //       debes hacer ResizeAndReindex si el load factor excede el maximo
        //       load factor permitido
        // Valor: 3 puntos
        try
        {
            Find(key);
           throw new DuplicateKeyException();
        }
        
        catch (KeyNotFoundException) {
            KeyValuePair x = new KeyValuePair(key, value);
            int pos = Math.Abs(hash(key)) % arr.Length;
            bool Added = false;

            if ((double)Size / arr.Length > MAX_LOAD_FACTOR)
            {
                ResizeAndReindex(arr.Length * GROWTH_FACTOR);
            }
            if (arr[pos] == null)
            {
                arr[pos] = x;
                Added = true;
            }
            else
            {
                for (int i = 0; i < MAX_PROBES; i++)
                {
                    if (arr[pos] == null)
                    {
                        arr[pos] = x;
                        Added = true;

                        break;
                    }
                    pos++;

                    if (pos >= arr.Length)
                    {
                        pos = 0;
                    }
                }

            }
            Size++;
        }
    }

    
    // Buscar 'key' en el diccionario devolviendo el valor asociado
    public V Find(int key)
    {
        // TODO: Implementar tomando en cuenta la estrategia descrita para Add
        // Valor: 2 puntos
        int pos = Math.Abs(hash(key)) % arr.Length;
        for(int i = 0; i < MAX_PROBES; i++)
        {
            if (arr[pos] == null)
            {
                throw new KeyNotFoundException();
            }
            else if (arr[pos].key == key)
            {
                return arr[pos].value;
            }
        }

        throw new KeyNotFoundException();

    }
    

    // Resize y reindexar
    private void ResizeAndReindex(int newCapacity)
    {
        // TODO: Implementar tomando en cuenta la estrategia descrita para Add
        // Valor: 3 puntos
        KeyValuePair[] temp = new KeyValuePair[newCapacity];
        foreach(KeyValuePair p in arr)
        {
            if(p == null)
            {
                continue;
            }
            else
            {
                int pos = Math.Abs(hash(p.key)) % newCapacity;
                for (int i = 0; i < MAX_PROBES; i++)
                {
                    if (temp[pos] == null)
                    {
                        break;
                    }
                    pos++;
                    if (pos >= newCapacity)
                    {
                        pos = 0;
                    }
                    if (i == MAX_PROBES)
                    {
                        stash.Add(p);
                        continue;
                    }
                }
                temp[pos] = p;
            }
        }
        foreach(KeyValuePair p in stash)
        {
            int pos = Math.Abs(hash(p.key)) % newCapacity;
            while (true)
            {
                if (temp[pos] == null)
                {
                    break;
                }
                pos++;
                if (pos >= newCapacity)
                {
                    pos = 0;
                }
            }
            temp[pos] = p;
        }
        arr = temp;


    }
}



public class Lab3d
{
    public static void Main(string[] args)
    {




        System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
        stopwatch.Start();
        var D = new MyDictionary<int>();
        for(int i = 0; i < 10000; i++)
        {
            D.Add(i, i);
        }
        stopwatch.Stop();
        Console.WriteLine(stopwatch.Elapsed);
        Console.WriteLine("Termino");
        /*
        D.Add(1, "uno");
        D.Add(10, "diez");
        D.Add(11, "once");
        D.Add(3, "tres");
        D.Add(5, "cinco");
        D.Add(6, "seis");
        D.Add(0, "cero");
        D.Add(-3, "negativo tres");
        try {
            D.Add(3, "tres duplicado!");
            Console.WriteLine("NOK: Esto no debe imprimirse");
        }
        catch (DuplicateKeyException) {
           Console.WriteLine("OK: 3 esta duplicado");
        }
        
        try {
            string res = D.Find(3);
            Console.WriteLine( "OK: valor asociado al key 3: {0}", res );
        }
        catch (KeyNotFoundException) {
            Console.WriteLine("NOK: Esto no debe imprimirse");
        }
        try {
            D.Find(-10);
            Console.WriteLine("NOK: Esto no debe imprimirse");
        }
        catch (KeyNotFoundException) {
            Console.WriteLine("OK: key -10 no existe");
        }*/
        Console.ReadKey();
        // TODO: Diseña e implementa un experimento para determinar cual es
        //       la complejidad de la operacion Add en el average case.
        //       Presenta y justifica tu conclusion del experimento en un
        //       comment o en otro documento aparte        
        // Valor: 2 puntos
        
    }
}
