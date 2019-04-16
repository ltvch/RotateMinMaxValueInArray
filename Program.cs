using System;
using System.Collections.Generic;
using System.Linq;

namespace FindMinMaxElementInArray
{
    internal class Program
    {
        private static int FindMax(int[] array)
        {
            int max = array[0];
            foreach (int item in array)
            {
                if (item >= max)
                {
                    max = item;
                }
            }
            return max;
        }

        private static void ChangeMaxMin(int[] array)
        {
            int max = array.Max();
            int min = array.Min();

            array[Array.IndexOf(array, min)] = array.Max();
            array[Array.IndexOf(array, max)] = array.Min();

        }

        public static void RotateRight(int[] array, int positions)
        {
            int size = array.Length;

            for (int i = 0; i < positions; i++)
            {
                int temp = array[size - 1];

                for (int j = size - 1; j > 0; j--)
                {
                    array[j] = array[j - 1];
                }

                array[0] = temp;
            }
        }

        public static void RotateLeft(int[] array, int positions)
        {
            int size = array.Length;

            for (int i = 0; i < positions; i++)
            {
                int temp = array[0];

                for (int j = 0; j < size - 1; j++)
                {
                    array[j] = array[j + 1];
                }

                array[size - 1] = temp;
            }
        }

        /// <summary>
        /// Циклический сдвиг слева направо на некоторую величину используя Linq
        /// </summary>
        /// <param name="array"> Array parameter </param>
        /// <param name="size"> Size of removal </param>
        /// <returns> Array as Enumerable with offset on some position</returns>
        private static IEnumerable<int> RoteteArrayUseLinq(int[] array, int size)
        {
            //будем пропускать все елементы до начала смещения включительно (фактически отрежем кусок массива)
            //и затем добавим к нему кусок елементов из маcсива равное смещению  
            //отрезание и добавление кусков фактичеcки сделают смещение массива
             return array.Skip(size).Concat(array.Take(size));
        }


        private static void Main(string[] args)
        {
            // int[] array = new int[] { 10, 3, 2, 1, 8, 3, 9, 0, 5, 5, 1 };
            int[] array = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            Console.WriteLine("Array -> [{0}]", string.Join(", ", array));
            Console.WriteLine("\nMax value in array is {0}", FindMax(array));

            Console.WriteLine("\nMin value in array is {0} (we use linq)", array.Min());

            // ChangeMaxMin(array);
            var array1 = RoteteArrayUseLinq(array, 3);

            //RotateLeft(array, 5);//true and work
            //RotateRight(array, 5);//true and work

            Console.WriteLine("Array -> [{0}]", string.Join(", ", array1/**/));

            Console.WriteLine("\nPress any key to continue..");
            Console.ReadKey();
        }
    }
}
