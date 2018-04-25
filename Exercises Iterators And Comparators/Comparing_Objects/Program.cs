using System;
using System.Collections.Generic;
using System.Linq;

namespace Comparing_Objects
{
    class Program
    {
        static void Main()
        {
			Statistics stats = new Statistics();
			while (true)
			{
				string input = Console.ReadLine();

				if(input == "END")
				{
					break;
				}

				string[] args = input
					.Split()
					.ToArray();

				string name = args[0];
				int age = int.Parse(args[1]);
				string town = args[2];

				Person person = new Person(name, age, town);
				stats.AddPerson(person);
			}

			int index = int.Parse(Console.ReadLine());
			Console.WriteLine(stats.CalculateEqual(index));
        }
    }
}
