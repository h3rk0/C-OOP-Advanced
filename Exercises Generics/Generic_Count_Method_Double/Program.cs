using System;
using System.Collections.Generic;

namespace Generic_Count_Method_Double
{
    class Program
    {
        static void Main(string[] args)
        {
			List<Box<double>> boxes = new List<Box<double>>();
			int count = int.Parse(Console.ReadLine());

			for (int i = 0; i < count; i++)
			{
				Box<double> box = new Box<double>(double.Parse(Console.ReadLine()));
				boxes.Add(box);
			}

			Box<double> comparator = new Box<double>(double.Parse(Console.ReadLine()));
			int counter = 0;

			for (int i = 0; i < boxes.Count; i++)
			{
				if(boxes[i].Compare(comparator))
				{
					counter++;
				}
			}

			Console.WriteLine(counter);
		}
    }
}
