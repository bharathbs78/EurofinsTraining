using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpellChecker.Checker
{
    public class Levenshteindistance
    {
        public static int CalculateDistance(string str1,string str2)
        {
            var str1Length = str1.Length;
            var str2Length = str2.Length;

            var matrix = new int[str1Length + 1, str2Length + 1];

            // First calculation, if one entry is empty return full length
            if (str1Length == 0)
                return str2Length;

            if (str2Length == 0)
                return str1Length;

            // Initialization of matrix with row size str1Length and columns size str2Length
            for (var i = 0; i <= str1Length; matrix[i, 0] = i++) { }
            for (var j = 0; j <= str2Length; matrix[0, j] = j++) { }

            // Calculate rows and collumns distances
            for (var i = 1; i <= str1Length; i++)
            {
                for (var j = 1; j <= str2Length; j++)
                {
                    var cost = (str2[j - 1] == str1[i - 1]) ? 0 : 1;

                    matrix[i, j] = Math.Min(
                        Math.Min(matrix[i - 1, j] + 1, matrix[i, j - 1] + 1),
                        matrix[i - 1, j - 1] + cost);
                }
            }
            // return result
            return matrix[str1Length, str2Length];
        }
    }
}
