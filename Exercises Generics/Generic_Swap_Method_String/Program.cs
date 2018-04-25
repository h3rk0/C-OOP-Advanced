using System;
using System.Collections.Generic;
using System.Linq;

namespace Generic_Swap_Method_String
{
    class Program
    {
        static void Main(string[] args)
        {
			List<Box<string>> boxes = new List<Box<string>>();
			int count = int.Parse(Console.ReadLine());

			for (int i = 0; i < count; i++)
			{
				Box<string> box = new Box<string>(Console.ReadLine());
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

		private static void SwapElements(List<Box<string>> boxes, int first, int second)
		{
			var switcher = boxes[first];
			boxes[first] = boxes[second];
			boxes[second] = switcher;
		}
		
    }
}
