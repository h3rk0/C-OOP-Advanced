using Iterator_Test.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Iterator_Test
{
    class Program
    {
        static void Main(string[] args)
        {
			////// TEST
			//List<string> testList = new List<string>();
			//testList.Add("Pesho");
			//testList.Add("Misho");
			//testList.Add("Gosho");
			//ListIterator test = new ListIterator(testList);
			//Console.WriteLine(test.Move());
			//Console.WriteLine(test.Move());
			//Console.WriteLine(test.Move());

			string[] createArgs = Console.ReadLine()
				.Split()
				.ToArray();
			List<string> argsForPass = createArgs.Skip(1).ToList();
			ListIterator list = new ListIterator(argsForPass);

			while (true)
			{
				string input = Console.ReadLine();

				if(input == "END")
				{
					break;
				}

				try
				{
					switch (input)
					{
						case "HasNext":
							Console.WriteLine(list.HasNext());
							break;
						case "Print":
							list.Print();
							break;
						case "Move":
							Console.WriteLine(list.Move());
							break;
					}
				}
				catch (InvalidOperationException e)
				{
					Console.WriteLine(e.Message);
				}
			
			}

		}
    }
}
