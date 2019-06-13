/*
 *
 * Puntos ejercicio: 6
 *
 * Este ejercicio consiste en implementar el partition de QuickSort demostrado
 * en el siguiente video https://youtu.be/ywWBy6J5gz8
 *
 * Todas las partes que necesitan trabajar estan marcadas con el tag TODO
 *
 * Instrucciones adicionales: 
 *   a) No borren los comments que existen en este codigo
 *   b) Pueden utilizar los slides de Sedgewick
 *      http://algs4.cs.princeton.edu/lectures/
 *
 */

using System;

public class QuickSort {

    // Particiona el intervalo desde L a R del arreglo A, usando la estrategia
    // mostrada en el video
    // Devuelve la posicion final del pivot
    public static int Partition(int[] A, int L, int R)
    {
        // TODO: implementar el partition mostrado en el video
        // Restriccion: este algoritmo debe ser in-place
        // Complejidad esperada: O(R-L)
        // Valor: 6 puntos

        int PivotIndex = L;
        int pivot = A[PivotIndex];
        int i = PivotIndex, j = R;

        while (true)
        {
            while (PivotIndex < j)
            {
                if (A[j] <= pivot)
                {
                    int temp = A[j];
                    A[j] = pivot;
                    A[PivotIndex] = temp;
                    PivotIndex = j;
                    j = i;
                    i = PivotIndex;
                    j++;
                }
                else
                {
                    j--;
                }
                
            }

            while (PivotIndex > j)
            {
                if (A[j] > pivot)
                {
                    int temp = A[j];
                    A[j] = pivot;
                    A[PivotIndex] = temp;
                    PivotIndex = j;
                    j = i;
                    i = PivotIndex;
                    j--;
                }
                else
                    j++;
            }

            if (j == i)
            {
                return PivotIndex;
            }
        }


    }


    // Funcion recursiva de QuickSort
    static void Sort(int[] A, int L, int R)
    {
        if (L >= R) return;
        int k = Partition(A, L, R);
        Sort(A, L, k-1);
        Sort(A, k+1, R);
    }

    // wrapper function/method que llama al sort "real"
    public static void Sort(int[] A)
    {
        Sort(A, 0, A.Length-1);
    }
}


public class Lab1v
{
    public static void Main()
    {
        int[] A = { 3, 0, 1, 8, 7, 2, 5, 4, 9, 6 };
        Console.Write("Arreglo original             :");
        foreach (int x in A)
            Console.Write(" {0}", x);
        Console.WriteLine();
        Console.WriteLine();

        int k = QuickSort.Partition(A, 0, A.Length-1);
        Console.Write("Arreglo despues de Partition :");
        foreach (int x in A)
            Console.Write(" {0}", x);
        Console.WriteLine();
        Console.WriteLine();

        Console.WriteLine("Pivot at position {0}", k);
        Console.WriteLine();


        A = new int[] { 3, 0, 1, 8, 7, 2, 5, 4, 9, 6 };
        QuickSort.Sort(A);
        Console.Write("Arreglo despues de QuickSort :");
        foreach (int x in A)
            Console.Write(" {0}", x);
        Console.WriteLine();
        Console.WriteLine();

/*
Salida esperada:
Arreglo original             : 3 0 1 8 7 2 5 4 9 6

Arreglo despues de Partition : 2 0 1 3 7 8 5 4 9 6

Pivot at position 3

Arreglo despues de QuickSort : 0 1 2 3 4 5 6 7 8 9

*/

    }
}
