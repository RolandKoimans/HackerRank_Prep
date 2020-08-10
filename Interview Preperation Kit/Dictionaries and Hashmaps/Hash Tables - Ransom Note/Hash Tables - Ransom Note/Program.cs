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

    // Complete the checkMagazine function below.
    static void checkMagazine(string[] magazine, string[] note)
    {

        Hashtable magazineTable = new Hashtable();

        //Save the amount of times each words is present in a hashtable
        foreach(string str in magazine)
        {
            if (!magazineTable.ContainsKey(str))
            {
                magazineTable.Add(str, 1);
            }
            else
            {
                magazineTable[str] = (int)magazineTable[str] + 1;
            }
        }

        //Check for each word in the note if it is present in the hashtable, and if so, if there are enough occurences to make the note.
        foreach(string str in note)
        {
            if (!magazineTable.ContainsKey(str))
            {
                Console.WriteLine("No");
                return;
            }
            else if((int)magazineTable[str] == 0)
            {
                Console.WriteLine("No");
                return;
            }
            else
            {
                magazineTable[str] = (int)magazineTable[str] - 1;
            }
        }

        Console.WriteLine("Yes");

    }

    static void Main(string[] args)
    {
        string[] mn = Console.ReadLine().Split(' ');

        int m = Convert.ToInt32(mn[0]);

        int n = Convert.ToInt32(mn[1]);

        string[] magazine = Console.ReadLine().Split(' ');

        string[] note = Console.ReadLine().Split(' ');

        checkMagazine(magazine, note);
    }
}
