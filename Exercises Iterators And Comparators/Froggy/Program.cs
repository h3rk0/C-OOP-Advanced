using System;
using System.Linq;

namespace Froggy
{
    class Program
    {
        static void Main(string[] args)
        {
			int[] stones = Console.ReadLine()
				.Split(new string[] { ", " },
				StringSplitOptions.RemoveEmptyEntries)
				.Select(int.Parse)
				.ToArray();

			Lake lake = new Lake(stones);
			lake.Print();
			//foreach (var stone in lake)
			//{
			//	Console.WriteLine(stone);
			//}
        }
    }
}
