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

    // Complete the repeatedString function below.
    static long repeatedString(string s, long n)
    {
        //First convert the string into an array and check how many a's are present.
        char[] letters = s.ToCharArray();
        List<int> aLoc = new List<int>(); 

        for(int i = 0; i < letters.Length; i++)
        {
            if(letters[i] == 'a')
            {
                aLoc.Add(i);
            }
        }

        int aOcc = aLoc.Count;

        //Count all the a's in the part of the string where the full substring is present.
        long startAmount = n / letters.Length * aOcc;

        long leftoverLength = n % letters.Length;

        int leftoverAmount = 0;

        //Check how many a's are present in the final part of the string that may contain a non full substring.
        for(int i = 0; i < leftoverLength; i++)
        {
            if(letters[i] == 'a')
            {
                leftoverAmount++;
            }
        }

        return startAmount + leftoverAmount;

    }

    static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string s = Console.ReadLine();

        long n = Convert.ToInt64(Console.ReadLine());

        long result = repeatedString(s, n);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
