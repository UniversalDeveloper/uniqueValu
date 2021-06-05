using System;
using System.Collections.Generic;
using System.Linq;

namespace uniqueValues
{
    class Program
    {    public static int[] uniqNumbers(int[] a, int[] b){          
            int?[] uniqNum = new int?[a.Length];
            int counter = 0;
            for (int i = 0; i < a.Length; i++){              
                if (isExist(b, a[i]) == false){
                    uniqNum[counter++] = a[i];
                }
            }
            int[] clearArr = cleanNull(uniqNum, counter);
            return clearArr;
        }
        public static bool isExist(int[] b, int x){
            for (int i = 0; i < b.Length; i++){               
                if (x == b[i]) return true;
            }
            return false;
        }
        public static int[] cleanNull(int?[] a, int len){
            int[] clearArr = new int[len];
            int counter = 0;
            for (int i = 0; i < len; i++){
                if (a[i] != null){
                    clearArr[counter++] = a[i].Value;
                }
            }
            return clearArr;
        }
        public static int[] toConnect(int[] a, int[] b){
            int counter = 0;
            int[] pickedArr = new int[a.Length+b.Length];
            for (int i = 0; i < a.Length; i++){
                pickedArr[counter++] = a[i];
            }
            for (int i = 0; i< b.Length; i++){
                pickedArr[counter++] = b[i];
            }
            return pickedArr;
        }
        public static int[] uniqEndList(int[] a, int[] b){
            var uniqNumFirstArr = uniqNumbers(a, b);
            var uniqNumSecArr = uniqNumbers(b, a);
            var collectedArr = toConnect(uniqNumFirstArr, uniqNumSecArr);
            return collectedArr;
        }
        static void showResult(int[] a, int[] b){
            var unicNum  = uniqEndList(a, b);
            foreach (int item in unicNum){
                Console.Write(item);
            }
        }
        static void Main(string[] args){           
            int[] arrA = {1, 2, 3, 5, 9, 10};
            int[] arrB = {1, 5, 3, 6};
            showResult(arrA, arrB);
        }
    }
}
