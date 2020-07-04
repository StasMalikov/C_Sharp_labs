using System;

namespace Discrete_Math
{
    public class Algorithms
    {

        public static string[] RandomArr(int count)
        {
            string[] arr = new string[count];
            Random rnd = new Random();
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rnd.Next(0, 100).ToString();
            }
            return arr;
        }

        public static string[] ToString(int[] arr)
        {
            string[] result = new string[arr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                result[i] = arr[i].ToString();
            }
            return result;
        }


        public static string[] SortArr(int count)
        {
            string[] arr = new string[count];
            for (int i = 0; i < count; i++)
            {
                arr[i] = i.ToString();
            }
            return arr;
        }

        public static string[] BackSortArr(int count)
        {
            string[] arr = new string[count];
            for (int i = 0; i < count; i++)
            {
                arr[i] = (count- i).ToString();
            }
            return arr;
        }

        public static int[] TOINT(string[] arr)
        {
            int[] result = new int[arr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                result[i] = Convert.ToInt32(arr[i]);
            }
            return result;
        }

        public static int SequentialSearch(int[] arr, int findNumber)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == findNumber)
                {
                    return i + 1;
                }
            }
            return 0;
        }

        public static int BinarySearch(int[] arr, int findNumber)
        {
            int start = 0;
            int end = arr.Length - 1;
            int tmp = 0;
            for (int i = 0; start <= end; ++i)
            {
                tmp = (start + end) / 2;
                if (arr[tmp] == findNumber)
                    return i + 1;

                if (arr[tmp] > findNumber)
                    end = tmp - 1;
                else { start = tmp + 1; }
            }
            return 0;
        }
    }
}
