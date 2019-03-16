/*
 * Puntos del ejercicio: 12 puntos (+2 extra)
 *
 * En la clase del miercoles, Axel propuso una nueva manera de manejar el
 * problema de los Remove en Linear Probing y habiamos quedado en que la
 * complejidad de cada operacion era Theta(N / M) en el average case, donde
 * N es la cantidad de datos y M = arr.Length.  Fijense que si variamos M
 * de acuerdo a la cantidad de datos en el Dictionary, Theta(N / M) = O(1),
 * tal como demostramos para Separate Chaining.
 *
 * En este ejercicio, debes implementar la estrategia descrita por Axel y
 * comprobar o refutar la hipotesis de que la complejidad es O(1) en average.
 *
 * La estrategia de Axel es mantener una tabla de frecuencia C, donde C[r] =
 * cantidad de datos cuyo key tiene r como remantente si se divide por M.
 *
 * Para Find:
 *   - T = la cantidad de datos cuyo key tiene el mismo remanente que el key que
 *     estas buscando
 *   - Calcula la posicion inicial
 *   - Itera desde esa posicion inicial avanzando con step size 1
 *      - Si encuentras el key, devuelve el valor asociado a ese key
 *      - Deten el bucle cuando ya inspeccionaste exactamente T keys cuyo
 *        remanente (de dividir por M) coincide con el remanente del key que
 *        estas buscando.
 *
 * Para Remove:
 *   - Encuentra el dato a borrar
 *   - Elimina el dato dejando vacio el bucket donde se encuentra el dato
 *   - Reduce el contador del remantente que corresponde al key que acabas de
 *     eliminar
 *
 * Para Add:
 *   - Busca el siguiente bucket vacio y coloca el dato en esa casilla
 *   - Aumenta el contador del remantente que corresponde al key que acabas de
 *     de grabar
 *
 * Puedes asumir que los keys son numeros enteros sin negativos.
 *
 * Ubica todas las secciones con el tag TODO.  Cada tag les indicara que deben
 * completar.
 * 
 * Instrucciones adicionales: 
 *   a) No se permite usar las estructuras de datos incluidas en C#
 *   b) Agrega todas las clases adicionales que requieras
 *   c) Agrega todos los atributos y metodos que requieras
 *
 */


using System;


public class AxelDictionary<V>
{
    private int size = 0;
    public int Size()
    {
        return size;
    }
    class KVP
    {
        public int key { get; set; }
        public V value { get; set; }
        public bool Removed { get; set; }

        public KVP(int _key, V _value)
        {
            key = _key;
            value = _value;
        }

    }

    private KVP[] arr = new KVP[6];
    public int[] C = new int[6] ;
   
    public void Add(int key, V value)
    {
        // TODO: implementar
        // Complejidad esperada: O(1) average?
        // Valor: 1.5 puntos

        // TODO: Para la estrategia de Axel, en clase mencione incorrectamente
        //       que haremos Resize cuando la tabla se llena 100%.  Esto no
        //       funciona!  Provee un contraejemplo en Main que haga que cause
        //       mal performance
        // Valor: 1 punto extra

        {
            KVP p = Get(key);
            if (p != null && !p.Removed)
            {
                throw new Exception("Duplicate key");
            }
            double LOAD_FACTOR = (double)size / arr.Length;

            if (LOAD_FACTOR > 0.7)
            {
                ResizeAndReindex(2 * arr.Length);
            }

            int pos = Math.Abs((int)Hash(key) % arr.Length);
            while (true)
            {
                if (arr[pos] == null || arr[pos].Removed)
                {
                    break;
                }
                pos++;
                if (pos >= arr.Length)
                {
                    pos = 0;
                }
            }
            arr[pos] = new KVP(key, value);
            C[pos]++;
            size++;

        }





    }
    private KVP Get(int key)
    {
        int pos = Math.Abs((int)Hash(key) % arr.Length);
        foreach (KVP node in arr)
        {
            if (arr[pos] == null)
            {
                return null;
            }
            else if (arr[pos].key == key)
            {
                return arr[pos];
            }
            pos++;
            if (pos >= arr.Length)
            {
                pos = 0;
            }
        }
        return null;
    }

    private long Hash( int x )
    {
        return 31L * x + 809243513564;

    }

    public V Remove(int key)
    {
        // TODO: implementar
        // Complejidad esperada: O(1) average?
        // NOTA: No tienes que hacer resize
        // Valor: 1.5 puntos

        // TODO: Determina (e implementa) la condicion correcta hacer resize
        // Valor: 1 punto extra

        return default(V);
    }

    public V Find(int key)
    {
        // TODO: implementar
        // Complejidad esperada: O(1) average?
        // Valor: 3 puntos

        return default(V);
    }

    private void ResizeAndReindex(int newCapacity)
    {
        // TODO: implementar
        // Complejidad esperada: O(newCapacity + N)
        // Valor: 3 puntos

    }
}


public class Lab2h
{
    public static void Main()
    {

        AxelDictionary<string> d = new AxelDictionary<string>();
        d.Add(3, "Tu maldita");
        d.Add(8, "Madre");
        d.Add(7, "Tu maldita");
        d.Add(19, "Madre");
        d.Add(53, "Tu maldita");
        d.Add(4, "Madre");
        d.Add(5, "Tu maldita");
        d.Add(9, "Madre");
        Console.ReadKey();
        /*
        var D = new AxelDictionary<string>();
        D.Add(3, "tres");
        D.Add(1, "uno");
        D.Add(4, "cuatro");

        Random rnd = new Random(123);
        int k = rnd.Next(0, 100);  // Genera un numero aleatorio de 0 a 100
        D.Add(k, "" + k);
        k = rnd.Next(0, 100);      // Genera otro numero aleatorio de 0 a 100
        D.Add(k, "" + k);


        // TODO: Comprueba via un experimento de que la complejidad de los
        //       metodos Add, Remove y Find son O(1) en average.
        //       Debes proveer el codigo que usaste para conducir tus
        //       experimentos
        // Valor: 3 puntos
        */
    }
}


