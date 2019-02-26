/*
 * Puntos ejercicio: 8 puntos (+3 extra)
 * 
 * En este ejercicio, usaremos un Linked List para representar un polinomio
 * P(x), el cual no es mas que una lista de terminos.  Cada termino tiene un
 * coeficiente y un exponente.  Para simplificar, asumiremos que el polinomio:
 *  1) siempre utiliza la variable x
 *  2) los coeficientes son numeros enteros
 *  3) los exponentes son numeros enteros no negativos
 *
 * Para convertir un string en una secuencia de terminos, he proveido una clase
 * llamada Parser, el cual contiene un constructor que recibe un string.  No
 * tienes que entender la implementacion de Parser, solo debes saber usarlo:
 * Luego construir el Parser, puedes "iterar" el parser con un bucle foreach,
 * tal como se muestra en los ejemplos comentados que se encuentran en el metodo
 * Main de la clase Lab2p.
 *
 * Ubica todas las secciones con el tag TODO.  Cada tag les indicara que deben
 * completar.
 * 
 * Instrucciones adicionales: 
 *   a) No se permite usar las estructuras de datos incluidas en C#
 *   b) No se permite usar arreglos
 *   c) Agrega los metodos, atributos, excepciones adicionales que necesites
 *
 */

using System;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;



namespace Polinomio
{

/**
 * Define un termino de un polinomio
 */
public class Termino {
    public int coeficiente;
    public uint exponente;
    public Termino(int coeficiente, uint exponente) {
        this.coeficiente = coeficiente;
        this.exponente   = exponente;
    }
}


/**
 * Define un parser de un string en una secuencia (enumerador) de terminos
 * de un polinomio
 */
public class Parser : IEnumerable<Termino> {

    const string pattern = @"([+-]?[0-9]*)(x(?:\^([0-9]+))?)?";
    static Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);

    private string expr;
    public Parser(string expr) {
        this.expr = expr == null ? "" : expr.Replace(" ", "");
    }

    public IEnumerator<Termino> GetEnumerator() {
        Match match = regex.Match(this.expr);
        while (match.Success) {
        //  Console.Error.WriteLine("Matched value = " + match.Value);
            if (string.IsNullOrEmpty(match.Value))
                break;
            string scoeff = match.Groups[1].Value;
            if (string.IsNullOrEmpty(scoeff))
                scoeff = "1";
            else if (scoeff.Equals("+") || scoeff.Equals("-"))
                scoeff += "1";
            string sexp = match.Groups[3].Value;
            if (string.IsNullOrEmpty(sexp))
                sexp = string.IsNullOrEmpty(match.Groups[2].Value) ? "0" : "1";
        //  Console.Error.WriteLine( scoeff + " " + sexp );
            yield return new Termino(int.Parse(scoeff), uint.Parse(sexp));
            match = match.NextMatch();
        }
    }

    IEnumerator IEnumerable.GetEnumerator() {
        // Invoke IEnumerator<Termino> GetEnumerator() above.
        return GetEnumerator();
    }

}


public class Polinomio
{

    // Define un nodo del linked list
    // Puedes agregar el atributo prev para convertirlo la lista en Doubly
    // Linked List
    class LinkNode
    {
        public Termino value { get; private set; }
        // Restriccion: una vez el Termino es construido, no puedes modificar
        //              el atribudo value (por eso lo puse private)
        public LinkNode next , prev;  
        public LinkNode(Termino t)
        {
            value = t;
            next = null;
            prev = null;
        }
    }

    private LinkNode head = null, tail = null;


    public Polinomio(string expresion)
    {
            // TODO: Usando la clase Polinomio.Parser, construye el linked list con
            //       los terminos del polinomio.
            // NOTA1: Puedes asumir que el string 'expresion':
            //       A) contiene los terminos del polinomio en orden descendente del
            //          exponente.  O sea, el termino con mayor exponente va primero;
            //          le sigue el segundo mayor exponente, etc.
            //       B) no contiene mas de un termino con el mismo exponente.
            //       C) no contiene terminos con coeficiente == 0.
            // Complejidad: O(N) worst-case, donde N es la cantidad de terminos
            //              del polinomio
            // Valor: 1 punto


            // TODO: Implementalo sin asumir nada de lo indicado en NOTA1
            // Complejidad: O(N^2) worst-case, donde N es la cantidad de terminos
            //              del polinomio
            // Extra: 3 puntos

            Parser expr = new Parser(expresion);
            foreach(Termino term in expr)
            {
                LinkNode newNode = new LinkNode(term);
                if(head == null)
                {
                    head = newNode;
                    tail = newNode;
                }

                else
                {

                    LinkNode current = head;
                    while (current != null)
                    {
                        if (term.exponente > current.value.exponente && current == head)
                        {
                            newNode.next = current;
                            current.prev = newNode;
                            head = newNode;
                            break;
                        }
                        else if(term.exponente > current.value.exponente && current != head)
                        {
                            current.prev.next = newNode;
                            newNode.prev = current.prev;
                            current.prev = newNode;
                            newNode.next = current;
                            break;
                        }

                        else if(current.next == null)
                        {
                            current.next = newNode;
                            newNode.prev = current;
                            tail = newNode;
                            break;
                        }

                        else
                        {
                            current = current.next;
                        }
                    }
                  
                }
               
            }

    }

    /**
     * Agrega el polinompio 'P' al polinomio 'this'.
     *
     * Luego de esta operacion, el polinomio 'this' debe contener la suma
     * de los dos polinomios.
     */
    public void Add(Polinomio P)
    {
            // TODO: Implementar
            // Complejidad esperada: O(N1 + N2) worst-case, donde N1 y N2 son las
            //                       cantidades de terminos en el polinomio 'this'
            //                       y P respectivamente
            // Restricciones:
            //  1) No se permite crear mas de N2 nuevos nodos
            //  2) En el polinomio resultante, debes mantener los terminos ordenados
            //     de mayor exponente a menor exponente
            //  3) El polinomio resultante no puede contener mas de un termino con
            //     el mismo exponente
            //  4) Si la suma arroja un coeficiente con valor 0, debes omitir dicho
            //     termino del resultado (a menos que el polinomio consiste solo
            //     del termino que es constante)
            // OJO: el polinomio P no debe modificarse
            // Valor: 5 puntos


            {
                LinkNode currentP = P.head;
                LinkNode current = head;

              while(current != null && currentP != null)
                {
                    if(current.value.exponente < currentP.value.exponente)
                    {
                        LinkNode temp = currentP;
                        if(current == head)
                        {

                            currentP = currentP.next;
                            current.prev = temp;
                            temp.next = current;
                            head = temp;
                        }
                        else
                        {
                            currentP = currentP.next;
                            current.prev.next = temp;
                            temp.prev = current.prev;
                            current.prev = temp;
                            temp.next = current;
                        }
                    }
                    else if (current.value.exponente > currentP.value.exponente)
                    {
                        LinkNode temp = current;
                        if (currentP == P.head)
                        {

                            current = current.next;
                            currentP.prev = temp;
                            temp.next = currentP;
                            head = temp;
                        }
                        else
                        {
                            current = current.next;
                            currentP.prev.next = temp;
                            temp.prev = currentP.prev;
                            currentP.prev = temp;
                            temp.next = currentP;
                        }
                    }

                    else if(current.value.exponente == currentP.value.exponente)
                    {
                        int newvalue = current.value.coeficiente += currentP.value.coeficiente;
                        if(newvalue == 0)
                        { if (current == head)
                            {
                                current.next.prev = null;
                                head = current.next;
                                current = current.next;
                                currentP = currentP.next;
                            }
                            else
                            {
                                current.prev.next = current.next;
                                current.next.prev = current.prev;
                                current = current.next;
                                currentP = currentP.next;
                            }
                        }
                        

                        else
                        {
                            current.value.coeficiente = newvalue;
                            current = current.next;
                            currentP = currentP.next;
                        }
                    }
                }




            
            }

            
            

    }

    public override string ToString()
    {
            // TODO: Implementar
            // OJO: Si el coeficiente es 1 o -1 (y no es el termino constante),
            //      debes omitirlo en el string.  Ejemplo: "- x^4" en vez de "-1x^4"
            //      Si el exponente es 1, tambien debes omitirlo.  Ejemplo: "3x"
            //      en vez de "3x^1"
            // Complejidad: O(N) worst-case, donde N es la cantidad de terminos
            //              del polinomio
            // Valor: 2 puntos
            
            LinkNode current = head;
            string sb = "";
            while(current != null)
            {
                if (current.value.coeficiente == 0)
                {
                   
                }
                if(current.value.coeficiente == 1 )
                {
                    sb = sb + "x^" + current.value.exponente;
                }
                if (current.value.coeficiente == -1)
                {
                    sb = sb +" -x^" + current.value.exponente +" ";
                }
                if (current.value.exponente == 0)
                {
                    sb = sb + current.value.coeficiente;
                }
                if (current.value.exponente == 1)
                {
                    sb = sb + current.value.coeficiente + "x ";
                }
                if(current.value.coeficiente > 1  && current.value.exponente > 1)
                {
                    sb = sb + current.value.coeficiente + " x^" + current.value.exponente;
                }

                current = current.next;
            }

        return sb;
    }
}


}


class Lab2p {
    public static void Main(string[] args) {
        string expr1 = "3x^5 - x^2 - 5x + 13";
        /*
        Console.WriteLine("Parsing expression: " + expr1);
        var parser = new Polinomio.Parser(expr1);
        foreach (Polinomio.Termino term in parser) {
            Console.WriteLine("coeficiente={0}  exponente={1}",
                              term.coeficiente, term.exponente);
        }
        Console.WriteLine();
        */

        string expr2 = "x^8 - 4x^5 + 10x^3 + x^2 + x";
        /*
        Console.WriteLine("Parsing expression: " + expr2);
        parser = new Polinomio.Parser(expr2);
        foreach (Polinomio.Termino term in parser) {
            Console.WriteLine("coeficiente={0}  exponente={1}",
                              term.coeficiente, term.exponente);
        }
        Console.WriteLine();
        */

        var P1 = new Polinomio.Polinomio(expr1);
        var P2 = new Polinomio.Polinomio(expr2);
        P1.Add(P2);
        Console.WriteLine("Resultado: " + P1);
        Console.ReadKey();

    }
}

