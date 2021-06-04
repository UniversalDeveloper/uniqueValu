using System;
using System.Collections.Generic;
using System.Linq;

namespace uniqueValues
{
    class Program
    {
        public static int[] uniqueNumList(int [] a,int[]b)
        {   var o = uniqueFromFirstArr(a, b);
            var s = uniqueFromFirstArr(b, a);
            var r = toConnect(o, s);          
            return r;
        }
        public static int[] toConnect(int[] x, int[] y) 
        {
            int counter = 0;
            int[] r = new int[x.Length+y.Length];
            for (int i = 0; i < x.Length; i++)
            {
                r[counter++] = x[i];
            }
            for (int k = 0; k< y.Length; k++)
            {
                r[counter++] = y[k];
            }
             return r;
        }
        public static bool  isExist(int[]b,int x)
        {   bool isExist = false;
            for (int k = 0; k < b.Length; k++)
            {
             int   y = b[k];
                if (x == y)
                {
                    isExist = true;
                    break;
                }
            }
            return isExist;
        }
       
        public static int[] uniqueFromFirstArr(int[] a, int[] b)
        {
            int c1 = 0;
            int counter = 0;
            int?[] u = new int?[a.Length];
            
            for (int i = 0; i < a.Length; i++)
            {
                int x = a[i];
                if (isExist(b, x) == false)
                {
                    u[counter++] = (x);
                }
            }
            int[] p = new int[counter];
            for (int i = 0; i <counter; i++)
            {
                if (u[i]!= null)
                {
                    p[c1++] = u[i].Value;
                }
            }
            return p;
        }
        static void Main(string[] args)
        {   //int[] arr_first = { 1, 2, 3 ,4,9,10};
            //  int[] arr_first = { 1, 2, 3, 4, 9, -2 };
            //int[] arr_first = { 1 };
              int[] arr_first = { 0,0,0};
          //  int[] arr_first = { 1, 2, 3,5,9,10 };
            int[] arr_second = { 1, 5, 3,6};
          var r=uniqueNumList(arr_first, arr_second);

            foreach (int item in r)
            {
                Console.WriteLine(item);
            }
        }
    }
}
