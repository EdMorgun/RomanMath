using System;
using RomanMath.Impl;

namespace RomanMath.Console
{
	class Program
	{
		/// <summary>
		/// Use this method for local debugging only. The implementation should remain in RomanMath.Impl project.
		/// See TODO.txt file for task details.
		/// </summary>
		/// <param name="args"></param>
        
		static void Main(string[] args)
		{
            try
            {
                var result = Service.Evaluate("*X");
                //var result = Service.Evaluate("2+2*2+5055-55");
                System.Console.WriteLine(result);
                System.Console.ReadKey();
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e);
            }
        }
	}
}
