using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Solution
{

    // Complete the arrayManipulation function below.
    static long arrayManipulation(int n, int[][] queries, int m)
    {
        int[] manArr = new int[n];

        //Keep track of the changes in value. +X on the first position and -X after the last position.
        for (int i = 0; i < m; i++)
        {
            manArr[queries[i][0] - 1] += queries[i][2];
            if (queries[i][1] < n)
            {
                manArr[queries[i][1]] -= queries[i][2];
            }

        }


        //Go over the array, calculate at each position what the final value is and keep check of the maximum.
        int max = 0;
        int count = 0;

        for(int i = 0; i < manArr.Length; i++)
        {
            count += manArr[i];
            if (count > max) max = count;
        }

        return max;
    }

    static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string[] nm = Console.ReadLine().Split(' ');

        int n = Convert.ToInt32(nm[0]);

        int m = Convert.ToInt32(nm[1]);

        int[][] queries = new int[m][];

        for (int i = 0; i < m; i++)
        {
            queries[i] = Array.ConvertAll(Console.ReadLine().Split(' '), queriesTemp => Convert.ToInt32(queriesTemp));
        }

        long result = arrayManipulation(n, queries, m);

        textWriter.WriteLine(result);
       
        textWriter.Flush();
        textWriter.Close();
    }
}
