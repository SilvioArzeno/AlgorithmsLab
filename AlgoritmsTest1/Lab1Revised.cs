/*
 * Puntos ejercicio: 3 (+1 extra)
 * 
 * Este ejercicio consiste en implementar el algoritmo mencionado mas abajo
 * para resolver este problema relacionado al precio diario de Bitcoin: Dado un
 * arreglo con los precios diarios de Bitcoin y un numero entero positivo K,
 * quiero determinar, por cada dia, el precio mas bajo en los ultimos K dias.
     *
     * El algoritmo es el siguiente: por cada dia, itera los ultimos K dias para
     * determinar el precio mas bajo en esos ultimos K dias.  Como para los primeros
     * K-1 dias, no hay K dias anteriores, itera todos los dias disponibles.
     *
 * En las complejidades, la variable N se refiere a la cantidad de dias y K
 * es el parametro descrito en el problema.
 * 
 * Ubica todas las secciones con el tag TODO.  Cada tag les indicara que deben
 * completar.  Para TODOs que requieren respuestas, escribe las respuestas en
 * un comment.
 *
 */

using System;

class Lab1c
{
    public static int[] Solve(int[] precio, int K)
    {
        // TODO: Implementa el algoritmo explicado arriba. Ver ejemplo en Main.
        // Complejidad: Ver siguiente TODO
        // Valor: 2.5 puntos

        // TODO: en clase indique la complejidad era Theta(N*K), pero resulta
        //       que no es correcta!  Determina cual es la complejidad de este
        //       algoritmo.
        // Valor: 0.5 puntos
        
        int[] SolvedPrecios = new int[precio.Length];
        for(int i = 0; i < precio.Length; i++)
        {
            int cheaper = precio[i];
            int dias = K;
            while (i < dias - 1)
            {
                dias--;
            }
          for(int x = 0; x < dias; x++)
            {
               
                if (cheaper > precio[i - x])
                {
                    cheaper = precio[i - x];
                }
            }
         SolvedPrecios[i] = cheaper;

        }

        return SolvedPrecios;
    }

    public static void Main()
    {
        int[] resultado = Solve(new int[] {4, 5, 1, 4, 7, 6, 8, 8, 9, 5}, 3);
        for (int day = 0; day < resultado.Length; day++)
            Console.WriteLine("Day {0}: {1}", day+1, resultado[day]);
        // Debe imprimir:
        // Day 1: 4
        // Day 2: 4
        // Day 3: 1
        // Day 4: 1
        // Day 5: 1
        // Day 6: 4
        // Day 7: 6
        // Day 8: 6
        // Day 9: 8
        // Day 10: 5

        // TODO: Disenia un experimento que muestre que la complejidad del
        //       algoritmo NO es Theta(N*K).  Justifica bien tu conclusion.
        // Valor: 1 punto extra
        Console.ReadKey();
    }
}
