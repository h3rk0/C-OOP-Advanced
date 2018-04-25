using System;
using System.Collections.Generic;
using System.Linq;

namespace Equality_Logic
{
    class Program
    {
        static void Main(string[] args)
        {

			SortedSet<Person> sortedSet = new SortedSet<Person>();
			HashSet<Person> hashSet = new HashSet<Person>();

			int count = int.Parse(Console.ReadLine());

			for (int personIndex = 0; personIndex < count; personIndex++)
			{
				string[] personArgs = Console.ReadLine()
					.Split()
					.ToArray();

				string name = personArgs[0];
				int age = int.Parse(personArgs[1]);

				Person person = new Person(name, age);
				sortedSet.Add(person);
				hashSet.Add(person);
			}

			Console.WriteLine(sortedSet.Count);
			Console.WriteLine(hashSet.Count);
		}
    }
}
