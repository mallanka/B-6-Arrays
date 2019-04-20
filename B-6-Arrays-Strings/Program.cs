using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Lesson_6
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] arrayForMax = new int[5, 5]; //B6-P2/6. 3DMassiveMaxInRow
            ArrayMaxNumber(arrayForMax);       //B6-P2/6. 3DMassiveMaxInRow

            int[] arrayForSort = new int[5];    //B6-P3/6. 1DMasiveSort
            for (int i = 0; i < arrayForSort.Length; i++)          //cycle for fill input array with random numbers
            {
                arrayForSort[i] = random.Next(10);
                Console.Write(arrayForSort[i] + " ");
            }
            Console.WriteLine();

            HeapSort hs = new HeapSort();               //B6-P3/6. 1DMasiveSort
            hs.PerformHeapSort(arrayForSort);           //B6-P3/6. 1DMasiveSort

            Console.ReadLine();
        }

        public static void Pyatnashki()             //B6-P4/6. *Pyatnashki
        {
            int[,] array = new int[3,3];
            string numbers = "012345678";
            int indexOfNumber;
            int xCoordForZero = 0;
            int yCoordForZero = 0;

            while (numbers.Length > 0)              //fill the array
            {
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        indexOfNumber = random.Next(numbers.Length);
                        array[i, j] = int.Parse(Convert.ToString(numbers[indexOfNumber]));
                        numbers = numbers.Remove(indexOfNumber, 1);
                        Console.Write(array[i,j]+" ");
                        if (array[i, j] == 0)
                        {
                            xCoordForZero = i;
                            yCoordForZero = j;
                        }
                    }
                    Console.WriteLine();
                }
            }

            Console.WriteLine("for moving Zero use WASD");
            while (true)                                        //starting to play
            {
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.W:
                        if (xCoordForZero != 0)
                        {
                            array[xCoordForZero, yCoordForZero] = array[xCoordForZero - 1, yCoordForZero];
                            array[xCoordForZero - 1, yCoordForZero] = 0;
                            xCoordForZero -= 1;
                        }
                        WriteArray3x3(array);
                        break;
                    case ConsoleKey.A:
                        if (yCoordForZero != 0)
                        {
                            array[xCoordForZero, yCoordForZero] = array[xCoordForZero, yCoordForZero - 1];
                            array[xCoordForZero, yCoordForZero - 1] = 0;
                            yCoordForZero -= 1;
                        }
                        WriteArray3x3(array);
                        break;
                    case ConsoleKey.S:
                        if (xCoordForZero != 2)
                        {
                            array[xCoordForZero, yCoordForZero] = array[xCoordForZero + 1, yCoordForZero];
                            array[xCoordForZero + 1, yCoordForZero] = 0;
                            xCoordForZero += 1;
                        }
                        WriteArray3x3(array);
                        break;
                    case ConsoleKey.D:
                        if (yCoordForZero != 2)
                        {
                            array[xCoordForZero, yCoordForZero] = array[xCoordForZero, yCoordForZero + 1];
                            array[xCoordForZero, yCoordForZero + 1] = 0;
                            yCoordForZero += 1;
                        }
                        WriteArray3x3(array);
                        break;
                }
            }
        }

        public static void WriteArray3x3(int[,] array)      //method for write array 3x3 in console
        {
            Console.WriteLine();
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(array[i,j] + " ");
                }
                Console.WriteLine();
            }
        }

        public static void CutString()          //B6-P5/6. CutString
        {
            string userString = Console.ReadLine();
            if (userString.Length > 13)
            {
                string newString = userString.Remove(13, userString.Length - 13).Insert(13, "...");
                Console.WriteLine(newString);
            }
            else
            {
                Console.WriteLine(userString);
            }
        }

        public static void PoemExample()            //B6-P6/6. ReplaceInPoem
        {
            Console.WriteLine("enter the poem in one row with semocolon between rows");
            string poem = Console.ReadLine();
            string[] array = poem?.Split(';');
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = array[i].Replace('О', 'А').Replace("Л", "ЛЬ").Replace("ТЬ", "Т");
                Console.WriteLine(array[i]);
            }
        }

        static Random random = new Random();
        public static void ArrayMaxNumber(int[,] array)      //B6-P2/6. 3DMassiveMaxInRow
        {
            int max = int.MinValue;
            for (int i = 0; i < array.GetLength(0); i++)
            {
                max = int.MinValue;
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    array[i, j] = random.Next(30);
                    Console.Write(array[i, j] + " ");
                    max = array[i, j] > max ? array[i, j] : max;
                }
                Console.Write("Max number of the row is " + max);
                Console.WriteLine();
            }
        }

    }
    class HeapSort          //B6-P3/6. 1DMasiveSort
    {
        private int heapSize;

        private void BuildHeap(int[] arr)
        {
            heapSize = arr.Length - 1;
            for (int i = heapSize / 2; i >= 0; i--)
            {
                Heapify(arr, i);
            }
        }

        private void Swap(int[] arr, int x, int y)//function to swap elements
        {
            int temp = arr[x];
            arr[x] = arr[y];
            arr[y] = temp;
        }
        private void Heapify(int[] arr, int index)
        {
            int left = 2 * index;
            int right = 2 * index + 1;
            int largest = index;

            if (left <= heapSize && arr[left] > arr[index])
            {
                largest = left;
            }

            if (right <= heapSize && arr[right] > arr[largest])
            {
                largest = right;
            }

            if (largest != index)
            {
                Swap(arr, index, largest);
                Heapify(arr, largest);
            }
        }
        public void PerformHeapSort(int[] arr)
        {
            BuildHeap(arr);
            for (int i = arr.Length - 1; i >= 0; i--)
            {
                Swap(arr, 0, i);
                heapSize--;
                Heapify(arr, 0);
            }
            DisplayArray(arr);
        }
        private void DisplayArray(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write("[{0}]", arr[i]);
            }
        }
    }
}

