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

class Result
{

    /*
     * Complete the 'cavityMap' function below.
     *
     * The function is expected to return a STRING_ARRAY.
     * The function accepts STRING_ARRAY grid as parameter.
     */

    public static List<string> cavityMap(List<string> grid)
    {
        int n = grid.Count;
        List<string> result = new List<string>();
        
        for (int i = 0; i < n; i++)
        {
            char[] rowChars = grid[i].ToCharArray();
            for (int j = 0; j < n; j++)
            {
                if (i > 0 && i < n - 1 && j > 0 && j < n - 1)
                {
                    int val = rowChars[j] - '0';
                    int up = grid[i - 1][j] - '0';
                    int down = grid[i + 1][j] - '0';
                    int left = rowChars[j - 1] - '0';
                    int right = rowChars[j + 1] - '0';
                    
                    if (val > up && val > down && val > left && val > right)
                    {
                        rowChars[j] = 'X';
                    }
                }
            }
            result.Add(new string(rowChars));
        }
        
        return result;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<string> grid = new List<string>();

        for (int i = 0; i < n; i++)
        {
            string gridItem = Console.ReadLine();
            grid.Add(gridItem);
        }

        List<string> result = Result.cavityMap(grid);

        textWriter.WriteLine(String.Join("\n", result));

        textWriter.Flush();
        textWriter.Close();
    }
}
