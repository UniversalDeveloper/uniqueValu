using System;
using System.Collections.Generic;
using System.Linq;

namespace UniqueValues
{
   public class  Program
    {    public static int[] UniqNumbers(int[] a, int[] b){
          DuplicatClean(a);
          

            int?[] uniqNum = new int?[a.Length];
            int counter = 0;
            for (int i = 0; i < a.Length; i++){              
                if (IsExist(b, a[i]) == false){
                    uniqNum[counter++] = a[i];
                }
            }
            int[] clearArr = CleanNull(uniqNum, counter);
            return clearArr;
        }




        public static int[] DuplicatClean(int[] a) {
              int?[] unicNum = new int?[5];
                     int counter = 0;
            int buf = 0;
            for (int i = 0; i < a.Length; i++){
                bool isEsi = true;
                for (int j = 1; j < a.Length; j++) {
                    if (a[i] == a[j]) {
                        isEsi = false;
                    }
                    else {
                        if (isEsi == true) {
                            buf = a[i];
                        } else if (buf != a[j]) {
                            unicNum[counter++] = a[i];
                        }
                } 
                }
            }
            int[] cleanArr = CleanNull(unicNum,counter);

            foreach (int item in cleanArr){

                Console.Write(item);
                Console.WriteLine();
            }
            return cleanArr;
        }






        public static bool IsExist(int[] b, int x){
            for (int i = 0; i < b.Length; i++){               
                if (x == b[i]) return true;
            }
            return false;
        }
        public static int[] CleanNull(int?[] a, int len){
            int[] clearArr = new int[len];
            int counter = 0;
            for (int i = 0; i < len; i++){
                if (a[i] != null){
                    clearArr[counter++] = a[i].Value;
                }
            }
            return clearArr;
        }
        public static int[] ToConnect(int[] a, int[] b){
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
        public static int[] UniqEndList(int[] a, int[] b){
            var uniqNumFirstArr = UniqNumbers(a, b);
            var uniqNumSecArr = UniqNumbers(b, a);
            var collectedArr =ToConnect(uniqNumFirstArr, uniqNumSecArr);
            return collectedArr;
        }
        static void ShowResult(int[] a, int[] b){
            var unicNum  = UniqEndList(a, b);
            foreach (int item in unicNum){
                Console.Write(item);
            }
        }
       public static void UniqueValueTests(){           
            int[] arrC = { 1, 2,3,5,9,7,-10,0,11,1};
            int[] arrD = { 1, 2, 3, 5, 9, 7, -10, 0, 11, 189 };
            int[] expected1 = { 189 };
            int[] actual1 = Program.UniqEndList(arrC, arrD);
            if (expected1.SequenceEqual(actual1)){
                Console.WriteLine("True LongArr and NegativeNumber");
            }
            else{
                Console.WriteLine("False LongArr and NegativeNumber");
            }

            int[] arrA = { 0,0,0};
            int[] arrB = { 1, 2, 3,0 };
            int[] expected = {1,2,3 };
            int[] actual = Program.UniqEndList(arrA, arrB);
            if (expected.SequenceEqual(actual))
            {
                Console.WriteLine("True with '0'");
            }
            else
            {
                Console.WriteLine("False LongArr and NegativeNumber");
            }

        }
        static void Main(string[] args){
            // int[] arrA = new int[6];
            int[] arrA = {0, 1, 8, 0};
            int[] arrB = {9};
            ShowResult(arrA, arrB);
          //  UniqueValueTests();
        }
    }
}
