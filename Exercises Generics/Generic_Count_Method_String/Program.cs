using System;
using System.Collections.Generic;
using System.Linq;

namespace Generic_Count_Method_String
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

			Box<string> comparator = new Box<string>(Console.ReadLine());
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
