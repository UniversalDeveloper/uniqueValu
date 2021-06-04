using System;
using System.Collections.Generic;
using System.Linq;

namespace uniqueValues
{
    class Program
    {
        
        public static int[] toConnect(int[] x, int[] y){
            int counter = 0;
            int[] r = new int[x.Length+y.Length];
            for (int i = 0; i < x.Length; i++)
            {
                r[counter++] = x[i];
            }
            for (int i = 0; i< y.Length; i++)
            {
                r[counter++] = y[i];
            }
             return r;
        }
        public static bool  isExist(int[]b,int x){
           
            for (int k = 0; k < b.Length; k++){
                 int   y = b[k];
                if (x == y) return true;
               }
            return false;
        }
       
        public static int[] uniqueFromFirstArr(int[] a, int[] b){          
            int?[] u = new int?[a.Length];

            int counter = 0;
            for (int i = 0; i < a.Length; i++){
                int x = a[i];
                if (isExist(b, x) == false){
                    u[counter++] = x;
                }
            }


            int[] p = new int[counter];
            int count1 = 0;
            for (int i = 0; i <counter; i++)
            {
                if (u[i] != null) 
                {
                    p[count1++] = u[i].Value;
                }
            }
            return p;
        }
        public static int[] uniqueNumList(int[] a, int[] b)
        {
            var o = uniqueFromFirstArr(a, b);
            var s = uniqueFromFirstArr(b, a);
            var r = toConnect(o, s);
            return r;
        }
        static void Main(string[] args){
            //int[] arr_first = { 1, 2, 3 ,4,9,10};
            //  int[] arr_first = { 1, 2, 3, 4, 9, -2 };
            //int[] arr_first = { 1 };
            //  int[] arr_first = { 0,0,0};
           int[] arr_first = { 1, 2, 3,5,9,10 };
            int[] arr_second = { 1, 5, 3,6};
          var r=uniqueNumList(arr_first, arr_second);

            foreach (int item in r){
                Console.WriteLine(item);
            }
        }
    }
}
