using System;

namespace HeapSort
{ 
    public class HeapSort
    { 
        public static void Main()
        {
            int[] arr =new int[12];
            Random randint = new Random();
            for (int i=0; i < arr.Length; i++)
            {
                arr[i] = randint.Next(0, 25);
            }
            Console.WriteLine("Unsorted: ");
            PrintArray(arr);
            HeapSort ob = new HeapSort();
            ob.Sort(arr);

            Console.WriteLine("\nSorted: ");
            PrintArray(arr);
        }

        public void Sort(int[] arr)
        {
            int n = arr.Length;

            // Divide the length of the array in half
            // then, send to heap which will sort between left or right
            for (int i = n / 2 - 1; i >= 0; i--)
                Heap(arr, n, i);

            // One by one extract an element from heap 
            for (int i = n - 1; i > 0; i--)
            {
                // Move current root to end 
                int temp = arr[0];
                arr[0] = arr[i];
                arr[i] = temp;

                // call max heapify on the reduced heap 
                Heap(arr, i, 0);
            }
        }

        void Heap(int[] arr, int n, int i)
        {
            int largest = i; // larger node
            int l = 2 * i + 1; // left node 
            int r = 2 * i + 2; // right node

            // If left node is greater than root 
            if (l < n && arr[l] > arr[largest])
                largest = l;

            // If right node is greater than largest so far 
            if (r < n && arr[r] > arr[largest])
                largest = r;

            // If largest is not root 
            if (largest != i)
            {
                int swap = arr[i];
                arr[i] = arr[largest];
                arr[largest] = swap;

                // Repeat method for the original root number
                Heap(arr, n, largest);
            }
        }

        // Print the Array
        static void PrintArray(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
        }
    }
}

