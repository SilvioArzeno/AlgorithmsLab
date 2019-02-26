/*
 *
 * Puntos ejercicio: 18
 *
 * En este ejercicio, usaremos un Linked List para representar un "deck" de
 * naipes.
 *
 * Cada naipe es representado como un string de dos letras, donde la primera
 * letra representa el 'rank' de la carta: A, 2, 3, ..., T, J, Q, K, y la
 * segunda letra representa el 'suit': S=Spade, H=Heart, C=Club y D=Diamond.
 *
 * Las operaciones a implementar estan marcadas con el tag TODO.
 *
 * En todas las operaciones a implementar, debes respetar las siguientes
 * restricciones:
 *   1) No se permite crear arreglos
 *   2) No se permite crear nodos nuevos (ni llamar ningun metodo que crea
 *      nuevos nodos)
 *   3) No se permite modificar el valor del campo 'card' grabado en el nodo
 *
 * Instrucciones adicionales: 
 *   a) No borren los comments que existen en este codigo
 *   b) No se permite usar las estructuras de datos en C#
 *   c) Puedes crear metodos adicionales a los metodos que debes implementar
 *   d) Se permite agregar campos adicionales en la declaracion de las clases
 *
 */


using System;
using System.Text;


class ParametroInvalido : Exception { }


/**
 * Nodo del Doubly Linked List, el cual contiene uno de los naipes
 */
class DLinkNode
{
    public String card;   // el naipe representando como un string de dos letras
    public DLinkNode next, prev;
    public DLinkNode(String _card)
    {
        card = _card;
    }
}


/**
 * Linked List que representa una "mano" de cartas
 */
class CardHand
{
    public DLinkNode head = null;
    public DLinkNode tail = null;

//  Para este ejercicio, no necesitamos el atributo size, pero lo puedes agregar
//  si asi lo prefieres
//  public int size { get; private set; }


    /**
     * Convertir la "mano de cartas" a un string para ser impreso en la consola
     */
    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        DLinkNode cur = head;
        while (cur != null)
        {
            if (cur != head)
                sb.Append(' ');
            sb.Append(cur.card);
            cur = cur.next;
        }
        return sb.ToString();
    }
}


/**
 * Linked List que representa una baraja de cartas
 */
class CardDeck
{
    public const string CardValues = "A23456789TJQK";
    public const string CardSuits = "SHCD";   // Spade, Heart, Club, Diamonds

    private DLinkNode head = null;   // nodo del primer naipe en el Deck
    private DLinkNode tail = null;   // nodo del ultimo naipe en el Deck
    public int size { get; private set; } = 0;  // cantidad de naipes en el Deck


    /**
     * Constructor
     */
    public CardDeck(bool standardDeck = true)
    {
        if (standardDeck)
        {
            // Llena el "deck" con los 52 naipes de una baraja comun
            // NOTA: tu implementacion NO debe asumir que siempre tendremos un
            //       deck de 52 cartas
            foreach (char suit in CardDeck.CardSuits)
            {
               foreach (char val in CardDeck.CardValues)
               {
                   string card = val + "" + suit;
                   AddBack(card);
               }
            }
        }
    }


    /**
     * Agregar la carta x al final de la lista
     */
    public void AddBack(string x)
    {
        DLinkNode newNode = new DLinkNode(x);
        if (size == 0) {
            head = newNode;
            tail = newNode;
            size = 1;
            return;
        }
        tail.next = newNode;
        newNode.prev = tail;
        tail = newNode;
        size++;
    }


    /**
     * Reparte cartas a 'numPlayers' jugadores de tal manera que cada jugador
     * tenga 'numCardsPerPlayer' naipes.  La reparticion debe hacerse carta por
     * carta, rotando el turno de cada jugador.  Es decir, el primer jugador
     * recibe la carta en el tope, el segundo jugador recibe la segunda carta
     * desde el tope, etc.
     *
     * Devuelve un arreglo de "manos" con tamanio numPlayers, donde la celda en
     * la posicion i corresponde a la mano de naipes que el jugador i recibe.
     * Cada mano contiene las cartas en orden inverso del orden repartido: la
     * primera carta en la mano corresponde a la ultima carta que ese jugador
     * recibio, la segunda carta es la penultima recibida, etc.
     *
     * Las cartas repartidas dejan de estar presentes en el "deck".
     */
    public CardHand[] Deal(int numPlayers, int numCardsPerPlayer)
    {
        // TODO: implementar
        // Complejidad esperada: O(P + C) worst-case, donde P es la cantidad de
        //                       jugadores y C la cantidad total de cartas a
        //                       repartir
        // Restricciones: ver encabezado de este archivo
        // Valor: 5 puntos

        

        if (numPlayers <= 0 || numCardsPerPlayer <= 0)
           throw new ParametroInvalido();

        return null;
    }


    /**
     * "Cortar el deck" consiste en los siguientes pasos:
     *  1) Cuenta M cartas desde el tope
     *  2) Corta la baraja en ese punto, separandolo en dos mitades: mitad
     *     superior y mitad inferior
     *  3) Toma la mitad inferior y colocalo encima de la mitad superior
     */
    public void Cut(int M)
    {
        // TODO: implementar
        // Complejidad esperada: O(M) worst-case para ubicar la posicion M
        //                       O(1) worst-case para ejecutar el corte
        // Restricciones: ver encabezado de este archivo
        // Valor: 3 puntos

        if (M < 0 || M > size)
           throw new ParametroInvalido();

    }


    /**
     * Ejecuta un "Riffle Shuffle" de manera que las cartas queden intercaladas:
     *   1) Divide la lista en dos "mitades": la primera "mitad" tiene las
     *      primeras M cartas y la segunda "mitad" contiene el resto. Ambas
     *      partes deben tener las cartas en el mismo orden original.
     *   2) "Mezcla" las cartas de las dos mitades, tomando la primera carta de
     *      la primera mitad, luego la primera carta de la segunda mitad, la
     *      segunda carta de la primera mitad y asi alternando hasta que se
     *      acabe una de las dos mitades
     *   3) Finalmente, agregamos el resto de las cartas de la mitad que queda
     *      al final del Deck
     * Ejemplo: Si L = ("2D", "AC", "JS", "JD", "QH", "9D", "6D", "AD", "KS"),
     * L.RiffleShuffle(6) hace esto:
     * 1) Dividimos L en dos "mitades"
     *    ("2D", "AC", "JS", "JD", "QH", "9D") y ("6D", "AD", "KS")
     * 2) Mezclamos las dos mitades, resultando en
     *    L = ("2D", "6D", "AC", "AD", "JS", "KS", "JD", "QH", "9D")
     * NOTA: Tecnicamente, el Riffle Shuffle se hace en orden inverso: desde la
     *       ultima carta hasta la primera.  Pero para simplificar, usaremos
     *       el orden descrito.
     */
    public void RiffleShuffle(int M)
    {
        // TODO: implementar
        // Complejidad esperada: O(N) worst-case
        // Restricciones: ver encabezado de este archivo
        // Valor: 10 puntos

        if (M < 0 || M > size)
           throw new ParametroInvalido();

    }


    /**
     * Convertir el Deck a un string para ser impreso en la consola
     */
    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        DLinkNode cur = head;
        while (cur != null)
        {
            if (cur != head)
                sb.Append(' ');
            sb.Append(cur.card);
            cur = cur.next;
        }
        return sb.ToString();
    }
}


class Lab2s
{

    public static void printHands(CardHand[] hands)
    {
        for (int i = 0; i < hands.Length; i++)
            Console.WriteLine("Hand #{0}: {1}", i+1, hands[i]);
    }


    public static void Main()
    {
        Console.WriteLine("==================================================");
        Console.WriteLine("Sin shuffle ni corte");
        CardDeck deck1 = new CardDeck();
        CardHand[] hands1 = deck1.Deal(4, 5);
        printHands( hands1 );
        Console.WriteLine();

        Console.WriteLine("==================================================");
        Console.WriteLine("Sin shuffle, pero con corte");
        CardDeck deck2 = new CardDeck();
        deck2.Cut(24);
        CardHand[] hands2 = deck2.Deal(4, 5);
        printHands( hands2 );
        Console.WriteLine();

        Console.WriteLine("==================================================");
        Console.WriteLine("Con shuffle, pero sin corte");
        CardDeck deck3 = new CardDeck();
        deck3.RiffleShuffle(24);
        CardHand[] hands3 = deck3.Deal(4, 5);
        printHands( hands3 );
        Console.WriteLine();

        Console.WriteLine("==================================================");
        Console.WriteLine("Con shuffle y corte");
        CardDeck deck4 = new CardDeck();
        deck4.RiffleShuffle(24);
        deck4.Cut(24);
        CardHand[] hands4 = deck4.Deal(4, 5);
        printHands( hands4 );
        Console.WriteLine();

        Console.ReadLine();

/*
Salida esperada:

==================================================
Sin shuffle ni corte
Hand #1: 4H KS 9S 5S AS
Hand #2: 5H AH TS 6S 2S
Hand #3: 6H 2H JS 7S 3S
Hand #4: 7H 3H QS 8S 4S

==================================================
Sin shuffle, pero con corte
Hand #1: 2D JC 7C 3C QH
Hand #2: 3D QC 8C 4C KH
Hand #3: 4D KC 9C 5C AC
Hand #4: 5D AD TC 6C 2C

==================================================
Con shuffle, pero sin corte
Hand #1: 9S 7S 5S 3S AS
Hand #2: 7C 5C 3C AC QH
Hand #3: TS 8S 6S 4S 2S
Hand #4: 8C 6C 4C 2C KH

==================================================
Con shuffle y corte
Hand #1: 8H 6H 4H 2H KS
Hand #2: 6D 4D 2D KC JC
Hand #3: 9H 7H 5H 3H AH
Hand #4: 7D 5D 3D AD QC

*/
    }

}


