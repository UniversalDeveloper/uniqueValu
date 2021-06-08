using System;
using System.Collections.Generic;
using System.Linq;

namespace UniqueValues
{
   public class  Program
    {   public static int[] UniqNumbers(int[] a, int[] b){           
            var unieFromArrFirst = WithouDuplInArr(a);
            var unieFromArrSecond = WithouDuplInArr(b);                     
            int?[] uniqNum = new int?[10];
            int counter = 0;
            for (int i = 0; i < unieFromArrFirst .Length; i++){              
                if (IsExist(unieFromArrSecond, unieFromArrFirst[i]) == false){
                    uniqNum[counter++] = unieFromArrFirst[i];
                }
            }
            int[] clearArr = CleanNull(uniqNum, counter);
            return clearArr;
        }
        public static int CountAnUniq(int[] a){
            int notUniqueElcount = 0;
            for (int i = 1; i <a.Length; i++){
                for (int k = i-1; k >=0; k--){ 
                    if (a[i] == a[k])
                        notUniqueElcount++;
                          break;
                }
            }
            return notUniqueElcount;
        }
        public static int[] WithouDuplInArr(int[] a){
            int?[] arrVithNull = new int?[a.Length];
            int flag = 0;
            int[] cleanArr = new int[a.Length];
            int counter = 0;
            bool isExist = false;
            bool isExist2 = false;
            for (int i = 0; i < a.Length; i++){
                isExist = false;               
                for (int k = 0; k < a.Length; k++){
                    if (i == k) continue;
                    if (a[i] == a[k]){
                        isExist = true;
                        flag = 0;
                        break;
                    }
                    if (isExist == false){
                        flag = a[i];
                    }
                    if (isExist2 == true){
                        isExist2 = false;
                        break;
                    }                  
                } 
                if (isExist == false){
                    arrVithNull[counter++] = flag;                    
                }
            }
            int[] clearArr = CleanNull(arrVithNull, counter);         
            return clearArr;
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
            Console.WriteLine();
        }
       public static void UniqueValueTests(){           
            int[] arrA =  { 1, 1, 3 ,1 };
            int[] arrB = { 9, 5, 9 };
            int[] expected1 = { 3, 5 };
            int[] actual1 = Program.UniqEndList(arrA, arrB);
            if (expected1.SequenceEqual(actual1)){
                Console.WriteLine("True: shows unique values of two arrays");
            }
            else{
                Console.WriteLine("False: dose not shows unique values of two arrays");
            }
            int[] arrC = { 1, 4, -2, 8 ,7, 159,0 };
            int[] arrD = { 9, 5, 9 };
            int[] expected2 = { 1, 4, -2, 8, 7, 159 ,5};
            int[] actual3 = Program.UniqEndList(arrC, arrD);
            if (expected2.SequenceEqual(actual3))
            {
                Console.WriteLine("True: shows unique values with negative and long arrey");
            }
            else{
                Console.WriteLine("False: dose not shows unique values with negative and long arrey");
            }           
        }
        static void Main(string[] args){
           int[] arrA = { 1, 1, 3 ,1};
           int[] arrB = {9,5,9};
           ShowResult(arrA, arrB);
           UniqueValueTests();
        }
    }
}
