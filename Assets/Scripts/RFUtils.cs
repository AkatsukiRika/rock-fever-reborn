using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public static class RFUtils
{
    public static int[] GetIntArray(int num) {
        List<int> listOfInts = new List<int>();
        while (num > 0) {
            listOfInts.Add(num % 10);
            num /= 10;
        }
        listOfInts.Reverse();
        return listOfInts.ToArray();
    }
}
