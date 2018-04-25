using System;
using System.Collections.Generic;
using System.Linq;

namespace Collection
{
    class Program
    {
        static void Main(string[] args)
        {
			string[] createArgs = Console.ReadLine().Split().ToArray();
			List<string> collection = new List<string>(createArgs.Skip(1));
			ListyIterator<string> list = new ListyIterator<string>(collection);

			while (true)
			{
				try
				{
					string input = Console.ReadLine();

					if (input == "END")
					{
						break;
					}

					string[] inputArgs = input
						.Split(' ')
						.ToArray();
					string command = inputArgs[0];

					switch (command)
					{
						case "HasNext":
							Console.WriteLine(list.HasNext());
							break;
						case "Move":
							Console.WriteLine(list.Move());
							break;
						case "PrintAll":
							list.PrintAll();
							break;
						case "Print":
							list.Print();
							break;
					}
				}
				catch (Exception e)
				{
					Console.WriteLine(e.Message);
				}

			}
		}
    }
}
