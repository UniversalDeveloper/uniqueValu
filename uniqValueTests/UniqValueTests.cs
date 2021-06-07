using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using UniqueValues;
using Xunit;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace UniqValueTests
{


    public class UniqValueTests
    {
        [Fact]
        public void UniqEndList_1_2and1_5_returned_2_5(){           
            int[] arrA = { 1, 2 };
            int[] arrB = { 1, 5 };
            int[] expected = { 2, 5 };          
            int[] actual = Program.uniqEndList(arrA, arrB);            
            CollectionAssert.AreEqual(expected, actual);
        }
        [Fact]
        public void UniqEndListWith0_0_0and1_5_returned0_0_2_5(){
            int[] arrA = { 0, 0 };
            int[] arrB = { 1, 5 };
            int[] expected = { 0, 0, 1, 5 };
            int[] actual = Program.uniqEndList(arrA, arrB);          
            CollectionAssert.AreEqual(expected, actual);
        }
        [Fact]
        public void UniqEndListWith_nulland1_2_returned_Fals()
        {
            int[] arrA = new int[5];
            int[] arrB = { 1, 5 };
            int[] expected = { 0, 0, 1, 5 };
            int[] actual = Program.uniqEndList(arrA, arrB);
            CollectionAssert.AreEqual(expected, actual);
        }


    }
}
