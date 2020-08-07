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

    // Complete the hourglassSum function below.
    static int hourglassSum(int[][] arr)
    {
        int max = int.MinValue;

        for (int j = 1; j < 5; j++)
        {
            for (int i = 1; i < 5; i++)
            {
                //Calculate the value of the current hourglass
                int cur = calcHourglass(arr, j, i);

                //Update maximum value if needed
                if (cur > max) max = cur;

            }
        }

        return max;
    }

    static int calcHourglass(int[][] arr, int i, int j)
    {
        //Return the sum of all values in an hourglass shape around coordinates i,j
        int a, b, c, d, e, f, g;
        a = arr[i-1][j-1];
        b = arr[i-1][j];
        c = arr[i-1][j+1];
        d = arr[i][j];
        e = arr[i+1][j-1];
        f = arr[i+1][j];
        g = arr[i+1][j+1];


        return a + b + c + d + e + f + g;
    }

    static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int[][] arr = new int[6][];

        for (int i = 0; i < 6; i++)
        {
            arr[i] = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp));
        }

        int result = hourglassSum(arr);


        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
