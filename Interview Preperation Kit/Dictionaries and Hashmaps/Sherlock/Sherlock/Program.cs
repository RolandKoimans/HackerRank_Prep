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

    // Complete the sherlockAndAnagrams function below.
    static int sherlockAndAnagrams(string s)
    {

        int count = 0;

        for(int i = 1; i <= s.Length; i++)
        {
            for(int j = 0;j <= s.Length - i - 1; j++)
            {
                string s1sub = s.Substring(j, i);
                char[] s1subChar = s1sub.ToCharArray();
                Array.Sort(s1subChar);
                    
                for(int k = j+1; k <= s.Length - i; k++)
                {
                    string s2sub = s.Substring(k, i);
                    char[] s2subChar = s2sub.ToCharArray();
                    Array.Sort(s2subChar);


                    var anagram = true;
                    for (var n = 0; n < s1subChar.Length; n++)
                    {
                        if (s1subChar[n] != s2subChar[n])
                        {
                            anagram = false;
                            break;
                        }
                    }

                    if (anagram) { count++; }
                    //if (CheckAnagram(s1subChar, s2subChar)){
                    //    count++;
                    //}
                }
            }
        }

        return count;
    }


    static bool CheckAnagram(char[] s1Char, char[] s2Char)
    {

        for (int i = 0; i < s1Char.Length; i++)
        {
            if(s1Char[i] != s2Char[i])
            {
                return false;
            }
        }

        return true;

    }

    static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int q = Convert.ToInt32(Console.ReadLine());

        for (int qItr = 0; qItr < q; qItr++)
        {
            string s = Console.ReadLine();

            int result = sherlockAndAnagrams(s);

           textWriter.WriteLine(result);
        }

        textWriter.Flush();
        textWriter.Close();
    }
}
