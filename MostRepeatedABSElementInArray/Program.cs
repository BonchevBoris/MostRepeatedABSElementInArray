using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MostRepeatedABSElement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your integer array.\nPlease use separators - ' ', ',', '.', '. ' :");
            char[] separators = new char[] { ',', ' ', '.' };
            int[] arr = Console.ReadLine().Split(separators, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Dictionary<int, List<int>> sortedNumbers = new Dictionary<int, List<int>>();
            for (int i = 0; i < arr.Length; i++)
            {
                if (!sortedNumbers.ContainsKey(Math.Abs(arr[i])))
                {
                    sortedNumbers.Add(Math.Abs(arr[i]), new List<int>());
                    sortedNumbers[Math.Abs(arr[i])].Add(arr[i]);
                }
                else
                {
                    sortedNumbers[Math.Abs(arr[i])].Add(arr[i]);
                }
            }
            sortedNumbers = sortedNumbers.OrderByDescending(c => c.Value.Count)
                            .ThenByDescending( k =>Math.Abs( k.Key))
                            .ToDictionary(c => c.Key, c => c.Value);
            List<int> result = new List<int>();
            foreach (var kvp in sortedNumbers)
            {
                foreach (var num in kvp.Value)
                {
                    result.Add(num);
                }
            }
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("The most repeated elements grouped by absolute value are placed first:");
            sb.AppendLine(string.Join(", ", result));
            Console.WriteLine(sb);
            Console.WriteLine("Press any key to exit . . .");
            Console.ReadKey();
        }

    }
}
