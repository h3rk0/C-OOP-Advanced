using System;
using System.Linq;

namespace Stack
{
    class Program
    {
        static void Main(string[] args)
        {
			Stack<string> test = new Stack<string>();

			while (true)
			{
				string input = Console.ReadLine();

				if(input == "END")
				{
					break;
				}

				string[] inputArgs = input.Split().ToArray();
				string command = inputArgs[0];
				string[] items = inputArgs.Skip(1).ToArray();
				string itemsString = string.Join("", items);
				string[] resultArgs = itemsString.Split(',').ToArray();
				
				switch (command)
				{
					case "Push":
						test = PushItems(resultArgs, test);
						break;
					case "Pop":
						test.Pop();
						break;
				}
			}

			foreach (var item in test)
			{
				Console.WriteLine(item);
			}
			foreach (var item in test)
			{
				Console.WriteLine(item);
			}
		}

		private static Stack<string> PushItems(string[] items, Stack<string> test)
		{
			for (int i = 0; i < items.Length; i++)
			{
				test.Push(items[i]);
			}

			return test;
		}
	}
}
