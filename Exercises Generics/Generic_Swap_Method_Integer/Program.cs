using System;
using System.Collections.Generic;
using System.Linq;

namespace Generic_Swap_Method_Integer
{
    class Program
    {
        static void Main(string[] args)
		{
			List<Box<int>> boxes = new List<Box<int>>();
			int count = int.Parse(Console.ReadLine());

			for (int i = 0; i < count; i++)
			{
				Box<int> box = new Box<int>(int.Parse(Console.ReadLine()));
				boxes.Add(box);
			}

			int[] integers = Console.ReadLine()
				.Split()
				.Select(int.Parse)
				.ToArray();

			SwapElements(boxes, integers[0], integers[1]);

			foreach (var box in boxes)
			{
				Console.WriteLine(box);
			}
		}

		private static void SwapElements(List<Box<int>> boxes, int first, int second)
		{
			Box<int> switcher = boxes[first];
			boxes[first] = boxes[second];
			boxes[second] = switcher;
		}
	}
}
