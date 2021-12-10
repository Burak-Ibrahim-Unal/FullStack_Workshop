// See https://aka.ms/new-console-template for more information
using System;
// you can also use other imports, for example:
// using System.Collections.Generic;

// you can write to stdout for debugging purposes, e.g.
// Console.WriteLine("this is a debug message");


int[] numbers = new int[] { 1, 2, 3, 4, 6, 1 };

int Solve(int[] A)
{
    for (int i = 0; i < 1000; i++)
    {
        if (!A.Contains(i+1))
        {
            return i;
        }
    }
    return 1;
}

Solve(numbers);
Console.ReadLine();
