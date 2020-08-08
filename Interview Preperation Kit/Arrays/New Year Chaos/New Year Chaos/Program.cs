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

    // Complete the minimumBribes function below.
    static void minimumBribes(int[] q)
    {
        int bribes = 0;
        bool chaotic = false;

        //Go over array and check for every person how many times they were overtaken.
        for(int i = 0; i < q.Length; i++)
        {
            //Check which person is standing in this place in the queue
            int person = q[i];

            //Think of this as a 1-based array
            int place = i + 1;

            //If more than 2 places left of original position, too many bribes
            if(person - place > 2)
            {
                Console.WriteLine("Too chaotic");
                chaotic = true;
                break;
            }

            //Check how many people have overtaken this person
            for(int j = Math.Max(0, q[i] - 2); j < i; j++)
            {
                if(q[j] > q[i])
                {
                    bribes++;
                }
            }

        }

        if (!chaotic)
        {
            Console.WriteLine(bribes);
        }

    }

    static void Main(string[] args)
    {
        int t = Convert.ToInt32(Console.ReadLine());

        for (int tItr = 0; tItr < t; tItr++)
        {
            int n = Convert.ToInt32(Console.ReadLine());

            int[] q = Array.ConvertAll(Console.ReadLine().Split(' '), qTemp => Convert.ToInt32(qTemp))
            ;
            minimumBribes(q);
        }

    }
}
