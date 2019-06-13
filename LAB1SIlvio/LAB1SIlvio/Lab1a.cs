/*
 * Puntos ejercicio: 5
 *
 * "Avengers Assemble!" es el grito de guerra del Captain America para que el
 * equipo de vengadores ataquen juntos contra el ejercito de Thanos.
 *
 * Desafortunadamente, en vez de una sola fila, los Avengers se alinearon en dos
 * filas.  Por suerte, cada fila de superheroes esta ordenada por el nombre del
 * del superheroe (en orden alfabetico).  Pero, para colmo, las filas son Linked
 * Lists!
 *
 * Tu mision es hacer un "merge" de las dos filas en una sola.
 *
 * Ubica todas las secciones con el tag TODO.  Cada tag les indicara que deben
 * completar.  Para TODOs que requieren respuestas, escribe las respuestas en
 * un comment.
 *
 * Para mas informacion sobre LinkedList de C#, consulta la documentacion en:
 * https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.linkedlist-1?view=netframework-4.5.2
 *
 */


using System;
using System.Text;
using System.Collections.Generic;
 
class Lab1a
{
    static LinkedList<string>
        Assemble(LinkedList<string> fila1, LinkedList<string> fila2)
    {
        // TODO: implementar
        // Restriccion: tu solucion NO debe crear nodos nuevos.
        // HINT: C# provee metodos especificos que trabajan con parametros de
        //       tipo LinkedListNode
        // Complejidad esperada: O(N1 + N2)
        // Valor: 6 puntos

        LinkedListNode<string> cur1 = fila1.First;

        LinkedListNode<string> cur2 = fila2.First;

        LinkedList<string> Avengers = new LinkedList<string>();

        LinkedListNode<string> temp;
              
            while (cur1 != null && cur2 != null)
            {
                if (cur1.Value.CompareTo(cur2.Value) <= 0)
                {
                    temp = cur1.Next;
                    fila1.Remove(cur1);
                    Avengers.AddLast(cur1);
                    cur1 = temp;
                }
                else
                {
                    temp = cur2.Next;
                    fila2.Remove(cur2);
                    Avengers.AddLast(cur2.Value);
                    cur2 = temp;
                }
            }

            while (cur1 != null)
            {
                temp = cur1.Next;
                fila1.Remove(cur1);
                Avengers.AddLast(cur1);
                cur1 = temp;
            }

            while (cur2 != null)
            {
                temp = cur2.Next;
                fila2.Remove(cur2);
                Avengers.AddLast(cur2.Value);
                cur2 = temp;
            }



        return Avengers;
    }
    
    public static void Main()
    {
        LinkedList<string> fila1 = new LinkedList<string>(
            new string[] {
                "Ant-Man",
                "Black Panther",
                "Captain America",
                "Captain Marvel",
                "Falcon",
                "Hulk",
                "M'Baku",
                "Okoye",
                "Shuri",
                "Thor",
                "Valkyrie",
                "Wasp",
                "Winter Soldier"
            }
        );

        LinkedList<string> fila2 = new LinkedList<string>(
            new string[] {
                "Doctor Strange",
                "Drax",
                "Groot",
                "Hawkeye",
                "Iron Man",
                "Mantis",
                "Nebula",
                "Pepper Potts",
                "Rocket", 
                "Star-Lord",
                "Scarlet Witch",
                "Spider-Man",
                "War Machine",
                "Wong"
            }
        );
        
        LinkedList<string> fila = Assemble(fila1, fila2);
        foreach (string name in fila)
        {
            Console.WriteLine(name);
        }
    }
}
