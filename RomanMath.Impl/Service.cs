using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;

namespace RomanMath.Impl
{
    public static class Service
    {
        /// <summary>
        /// See TODO.txt file for task details.
        /// Do not change contracts: input and output arguments, method name and access modifiers
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>

        //Written by Eduard Morgun

        private static readonly Dictionary<char, int> RomanMap = new Dictionary<char, int>
        {
            {'I', 1}, {'V', 5}, {'X', 10}, {'L', 50}, {'C', 100}, {'D', 500}, {'M', 1000}
        };

        public static int Evaluate(string expression)
        {
            if (string.IsNullOrEmpty(expression))
            {
                throw new ArgumentException("String Empty or Null");
            }

            expression = expression.Replace(" ", "");

            var re = new Regex(@"[^I,V,X,L,C,D,M,+,\-,*]");
            if (re.Match(expression).Success)
            {
                throw new ArgumentException("Incorrect Symbols");
            }

            // Finding Roman numbers in the equation 
            var romeNumbers = expression.Split('+', '-', '*');

            // Convert Rome equation to Arabic equation 
            foreach (var romeNumber in romeNumbers)
            {
                if (string.IsNullOrEmpty(romeNumber))
                {
                    throw new ArgumentException("Incorrect mathematical expression");
                }

                var arabicNumber = ConvertRomeToArabic(romeNumber);
                expression = expression.Replace(romeNumber, arabicNumber);
            }

            // Convert Arabic string to mathematical equation 
            var loDataTable = new DataTable();
            var loDataColumn = new DataColumn("Eval", typeof(double), expression);
            loDataTable.Columns.Add(loDataColumn);
            loDataTable.Rows.Add(0);
            return (int) (double) loDataTable.Rows[0]["Eval"];
        }

        public static string ConvertRomeToArabic(string romeNumber)
        {
            // LINQ function for sum rome symbols 
            var result = romeNumber.Sum(letter => RomanMap[letter]);

            if (romeNumber.Contains("IV") || romeNumber.Contains("IX"))
                result -= 2;

            if (romeNumber.Contains("XL") || romeNumber.Contains("XC"))
                result -= 20;

            if (romeNumber.Contains("CD") || romeNumber.Contains("CM")) 
                result -= 200;

            return result.ToString();
        }
    }
}
