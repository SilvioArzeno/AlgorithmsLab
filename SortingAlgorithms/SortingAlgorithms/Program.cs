using System;
using System.Collections.Generic;

namespace SortingAlgorithms
{
    class Program
    {
        static void Swap(int[] A, int i ,int j)
        {
            int temp = A[i];
            A[i] = A[j];
            A[j] = temp;
        }

        static void PrintArray(int[] A)
        {
            for(int i = 0; i < A.Length; i++)
            {
                Console.Write(A[i] + " ");
            }
            Console.WriteLine();
        }
        static void SelectionSort(int[] A)  //Complejidad Best Case O(N^2) , "In place" , Unstable ------------- Este es una M de sort no se ni para que lo hice
        {
            for(int i = 0; i < A.Length; i++)
            {
                int min = A[i];
                int minPos = i;
                for (int j = i; j < A.Length; j++)
                {
                    if( A[j] < min)
                    {
                        min = A[j];
                        minPos = j;
                    }
                }
                Swap(A, i, minPos);
            }
        }

        static void InsertionSort(int[] A) // Complejidad WorstCase O(N^2) , In place, Stable ------------ Bueno para pocos datos.
        {
            for(int i = 0; i < A.Length; i++)
            {
                int j = i;
                int key = A[i];
                while(j > 0 && A[j - 1] > key)
                {
                    A[j] = A[j - 1];
                    j--;
                }
                A[j] = key;
            }
        }

        static void BubbleSort(int[] A) // Complexity WorstCase y AvgCase O(N^2) y Best case O(N), InPlace , Stable
        {
            bool Swapped = true;
            while (Swapped)
            {
                Swapped = false;
                for (int i = 0; i < A.Length - 1; i++)
                {
                    int j = i + 1;

                    if (A[i] > A[j])
                    {
                        Swap(A, i, j);
                        Swapped = true;
                    }
                }
            }
        }

        static void BSTsort(int[] A)   //Esto no funciona si hay duplicados, Con un BST que acepte duplicados y auto balancing como AVL pues seria O(NlogN) worst case
        {
            SortedSet<int> BST = new SortedSet<int>();
            foreach(int a in A)
            {
                BST.Add(a);
            }
            for(int i = 0; i < BST.Count; i++) // Aqui iria un In-Order iteration
            {
                A[i] = BST.Min;
                BST.Remove(BST.Min);
            }
        }

        static void HeapSort(int[] A)   // Heap Construction es O(N) y el Sort es O(LogN) asi que es WC (NlogN), Inplace (Esta implementacion) , Unstable
        {
            for(int i = A.Length/2 - 1; i >= 0; i--)
            {
                heapify(A, A.Length, i);
            }

           for(int i = A.Length-1; i >=0; i--)
            {
                int temp = A[0];
                A[0] = A[i];
                A[i] = temp;
                heapify(A, i, 0);
            }
        }
       static void heapify(int[] arr, int n, int i)
        {
            int largest = i; // Initialize largest as root 
            int l = 2 * i + 1; // left = 2*i + 1 
            int r = 2 * i + 2; // right = 2*i + 2 

            // If left child is larger than root 
            if (l < n && arr[l] > arr[largest])
                largest = l;

            // If right child is larger than largest so far 
            if (r < n && arr[r] > arr[largest])
                largest = r;

            // If largest is not root 
            if (largest != i)
            {
                int swap = arr[i];
                arr[i] = arr[largest];
                arr[largest] = swap;

                // Recursively heapify the affected sub-tree 
                heapify(arr, n, largest);
            }
        }// Heap Construction O(N)

        static void MergeSort(int[] A)                     //Maldita sea la recursividad.... Merge es O(N) y el sort es O(LogN)  asi que Merge sort es O(NlogN)
        {
            if (A.Length <= 10)
            {
                InsertionSort(A);
                return;
            }
            MergeSort(A, 0, A.Length - 1);
        }
       static void MergeSort(int[] A, int Lo, int Hi)
        {
            if (Lo >= Hi)
                return;
           else if (A.Length <= 10)
            {
                InsertionSort(A);
                return;
            }
            int mid = (Lo + Hi) / 2;

            MergeSort(A, Lo, mid);
            MergeSort(A, mid + 1, Hi);
            Merge(A, Lo, Hi, mid);

        }
        static void Merge(int[] A, int Lo, int Hi, int mid)
        {
            int[] temp1 = new int[mid - Lo + 1];

            int[] temp2 = new int[Hi - mid];
            
            for(int i = Lo; i <= mid; i++)
            {
                temp1[i - Lo] = A[i];
            }
            for(int j = mid + 1; j <= Hi; j++)
            {
                temp2[j - (mid + 1)] = A[j];
            }

            int h = 0, l = 0, k = Lo;
            while(h < mid - Lo + 1 && l < Hi - mid)
            {
                if (temp1[h] <= temp2[l])
                {
                    A[k] = temp1[h];
                    h++;
                    k++;
                }
                else
                {
                    A[k] = temp2[l];
                    k++;
                    l++;
                }
            }

            while( h < mid - Lo + 1)
            {
                A[k] = temp1[h];
                h++;
                k++;
            }

            while (l < Hi - mid)
            {
                A[k] = temp1[l];
                l++;
                k++;
            }

        }

        static int partition(int[] arr, int left, int right)
        {
            Random rnd = new Random();
            int pivot = arr[rnd.Next(arr.Length-1)];
            while (true)
            {

                while (arr[left] < pivot)
                {
                    left++;
                }

                while (arr[right] > pivot)
                {
                    right--;
                }

                if (left < right)
                {
                    if (arr[left] == arr[right]) return right;

                    int temp = arr[left];
                    arr[left] = arr[right];
                    arr[right] = temp;


                }
                else
                {
                    return right;
                }
            }
        }
            static void QuickSort(int[] A)
        {
            QuickSort(A, 0, A.Length - 1);
        }

        /* The main function that implements QuickSort() 
        arr[] --> Array to be sorted, 
        low --> Starting index, 
        high --> Ending index */
        static void QuickSort(int[] arr, int low, int high)
        {
            if(arr.Length < 10)
            {
                InsertionSort(arr);
            }
            else if (low < high)
            {

                /* pi is partitioning index, arr[pi] is  
                now at right place */
                int pi = partition(arr, low, high);

                // Recursively sort elements before 
                // partition and after partition 
                QuickSort(arr, low, pi - 1);
                QuickSort(arr, pi + 1, high);
            }
        }
        static int[] CountingSort(int[]array)
        {
        int[] count = new int[11];

        for (int i = 0; i<array.Length; i++)
        {
            int value = array[i];
        count[value]++;
        }

        for (int i = 1; i<count.Length; i++)
        {
            count[i] = count[i] + count[i - 1];
        }

int[] sorted = new int[array.Length];

        for (int i = array.Length - 1; i >= 0; i--)
        {
            int value = array[i];
int position = count[value] - 1;
sorted[position] = value;

            count[value]--;
        }

        return sorted;
    }
        static void Main(string[] args)
        {
            int[] arr = { 9, 0, 7, 12, 8, 5, 3, 4, 7, 2, 1, 0 };

            Console.Write("Unsorted array : ");
            PrintArray(arr);
            QuickSort(arr);
            Console.Write("Sorted array: ");
            PrintArray(arr);
            Console.ReadKey();


        }
    }
}
