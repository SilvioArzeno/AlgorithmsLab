/*
 *
 * Puntos ejercicio: 10 puntos
 *
 * En la clase de teoria del jueves, hice una broma de que hoy sabado me sentire
 * como Thanos porque probablemente eliminare a la mitad del curso con su famoso
 * "finger snap".  Este ejercicio esta inspirado en esa broma.
 * 
 * Dado un listado de datos grabados en un Doubly Linked List,  implementa un
 * metodo RemoveSelected para borrar elementos en posiciones especificas del
 * Linked List.  Ver descripcion en los comentarios anexos a ese metodo.
 *
 * Ubica todas las secciones con el tag TODO.  Cada tag les indicara que deben
 * completar.  Para TODOs que requieren respuestas, escribe las respuestas en
 * un comment.
 *
 * Instrucciones adicionales: 
 *   a) No borren los comments que existen en este codigo
 *   b) No se permite usar las estructuras de datos en C#
 *   c) No alteren la firma de los metodos existentes; o sea, no pueden cambiar
 *      el return type, ni agregar mas parametros, ni modificar sus tipos de
 *      datos
 *
 */


using System;
using System.Text;


public class DLinkedList<T>
{
    class DLinkNode
    {
        public T value;
        public DLinkNode next, prev;
        public DLinkNode(T value)
        {
            this.value = value;
        }
    }

    private DLinkNode head = null;   // nodo del primer elemento en la lista
    private DLinkNode tail = null;   // nodo del ultimo elemento en la lista
    public int Size { get; private set; }   // cantidad de datos en la lista


    /*
     * Constructor de un Doubly Linked List vacio
     */
    public DLinkedList()
    {
    }


    /*
     * Constructor de un Doubly Linked List a partir de un arreglo
     * Agrega los elementos en el orden del arreglo A, donde head debe contener
     * el dato en la posicion A[0] y tail debe tener el dato en A[A.Length-1]
     */
    public DLinkedList(T[] A)
    {
        // TODO: implementar
        // Valor: 1 punto

        foreach(T value in A)
        {
            DLinkNode newNode = new DLinkNode(value);
            if(head == null)
            {
                head = newNode;
                tail = newNode;
                Size++;
            }
            else
            {
                DLinkNode current = head;
                while (current.next != null)
                {
                    current = current.next;
                }
                current.next = newNode;
                newNode.prev = current;
                tail = newNode;
                Size++;

            }
        }

    }

    
    /*
     * Elimina los elementos elegidos por el arreglo de flags 'toRemove', donde:
     *   toRemove[i] es true si el elemento en la posicion i debe ser eliminado
     *   toRemove[i] es false si el elemento en la posicion i no se elimina
     * Las posiciones son 0-based, donde head corresponde a la posicion 0 y tail
     * corresponde a la ultima posicion.
     * Devuelve un Linked List con los elementos eliminados de la lista
     */
    public DLinkedList<T> RemoveSelected(bool[] toRemove)
    {
        // TODO: implementar
        // Valor: 9 puntos
        // Complejidad esperada: O(N)
        // Restricciones:
        // 1) No se permite crear nodos nuevos: o sea, tu implementacion no debe
        //    invocar "new DLinkedNode"
        // 2) No se permite crear arreglos
        // 3) No se permite modificar el valor del atributo 'value' grabado en
        //    el nodo

        DLinkedList<T> Removed = new DLinkedList<T>();
        DLinkNode current = head;
        DLinkNode CurrentRemoved = Removed.head;
        for(int i = 0; i < toRemove.Length && current != null; i++)
        {
            if (toRemove[i])
            {
                if (CurrentRemoved == null && current == head)
                {
                    Removed.head = current;
                    Removed.tail = current;
                    head = current.next;
                    current = head;
                    CurrentRemoved = Removed.head;
                    CurrentRemoved.next = null;
                    Removed.Size++;
                    Size--;
                }
                else if (Removed.head == null && current != head)
                {
                    Removed.head = current;
                    Removed.tail = current;
                    current.prev.next = current.next;
                    current = current.next;
                    CurrentRemoved = Removed.head;
                    current.prev = CurrentRemoved.prev;
                    CurrentRemoved.prev = null;
                    CurrentRemoved.next = null;
                    Removed.Size++;
                    Size--;
                }
                else if(Removed.head != null && current.next != null)
                {
                    CurrentRemoved.next = current;
                    current.prev.next = current.next;
                    current.prev = CurrentRemoved;
                    current = current.next;
                    CurrentRemoved = CurrentRemoved.next;
                    CurrentRemoved.next = null;
                    Removed.tail = CurrentRemoved;
                    Removed.Size++;
                    Size--;
                }
                else
                {
                    CurrentRemoved.next = current;
                    current.prev.next = null;
                    tail = current.prev;
                    CurrentRemoved = CurrentRemoved.next;
                    CurrentRemoved.next = null;
                    Removed.tail = CurrentRemoved;
                    Removed.Size++;
                    Size--;
                }
            }
            else 
                current = current.next;
        }
        return Removed;
    }


    /*
     * Convertir el Linked List a un string para ser impreso en la consola
     */
    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        DLinkNode curNode = head;
        while (curNode != null)
        {
            if (curNode != head)
                sb.Append('\n');
            sb.Append(curNode.value);
            curNode = curNode.next;
        }
        return sb.ToString();
    }

}


public class ThanosFingerSnap
{
    public static void Main()
    {
        // Listado de heroes cuyo destino conocemos con cierta certeza
        string[] heroes = {
            "Iron Man",
            "Captain America",
            "The Black Panther",
            "Star-Lord",
            "Thor",
            "Black Widow",
            "The Hulk",
            "Spider-Man",
            "Rocket Raccoon",
            "Groot",
            "Drax",
            "Ant-Man",
            "Doctor Stranger",
            "The Winter Soldier",
            "Scarlet Witch",
            "Nebula",
            "Falcon",
            "War Machine",
            "General Okoye",
            "M'Baku",
            "Mantis",
            "Nick Fury",
            "Maria Hill",
            "Captain Marvel",
            "The Wasp",
            "Hank Pym",
            "Janet van Dyne"
        };


        // Thanos' Finger Snap: Aleatoriamente decide cuales heroes eliminar
        Random rnd = new Random(1234567);
        bool[] toRemove = new bool[ heroes.Length ];
        for (int i = 0; i < toRemove.Length; i++)
        {
            if (rnd.Next(2) == 0)
                toRemove[i] = true;
            else
                toRemove[i] = false;
            if (toRemove[i])
            {
                //Console.Error.WriteLine( heroes[i] );
            }
        }

        DLinkedList<string> L = new DLinkedList<string>(heroes);
        DLinkedList<string> deceased = L.RemoveSelected(toRemove);
        Console.WriteLine("Casualties of Thanos' Finger Snap:");
        Console.WriteLine(deceased);
        Console.WriteLine();
        Console.WriteLine("Survivors of Thanos' Finger Snap:");
        Console.WriteLine(L);
        Console.WriteLine();
        Console.ReadLine();
    }

/*
 * Para evitar spoilers, he omitido el resultado esperado :-)
 */
}


