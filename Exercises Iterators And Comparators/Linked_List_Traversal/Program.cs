using System;
using System.Linq;

namespace Linked_List_Traversal
{
    class Program
    {
        static void Main()
        {
			int n = int.Parse(Console.ReadLine());
			LinkedList<int> list = new LinkedList<int>();

			for (int i = 0; i < n; i++)
			{

				string[] args = Console.ReadLine()
					.Split()
					.ToArray();

				string command = args[0];
				int argument = int.Parse(args[1]);

				switch (command)
				{
					case "Add":
						list.Add(argument);
						break;
					case "Remove":
						list.Remove(argument);
						break;
				}
			}

			Console.WriteLine(list.Count);
			foreach (var item in list)
			{
				Console.Write($"{item} ");
			}
			Console.WriteLine();
        }
    }
}
