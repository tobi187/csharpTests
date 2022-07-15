using System;
using System.Linq;

namespace Program
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            //var file = File.ReadAllLines(@"C:\Users\fischert\Desktop\projects\learn\csharpTests\ColorCodeJson\pw.txt");

            // 

            var output = new List<string>();

            for (var i = 1; i < 101; i++)
            {
                output.Add("carlos");
                if (i % 2 == 0)
                {
                    output.Add("wiener");
                }
            }

            File.AppendAllLines(@"C:\Users\fischert\Desktop\projects\learn\csharpTests\ColorCodeJson\res_user.txt", output.ToArray());

        }
    }
}