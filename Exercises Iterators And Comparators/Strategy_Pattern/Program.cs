using System;
using System.Collections.Generic;
using System.Linq;

namespace Strategy_Pattern
{
    class Program
    {
        static void Main(string[] args)
        {
			int count = int.Parse(Console.ReadLine());
			List<Person> persons = new List<Person>();
			for (int personIndex = 0; personIndex < count; personIndex++)
			{
				string[] personArgs = Console.ReadLine()
					.Split()
					.ToArray();

				string name = personArgs[0];
				int age = int.Parse(personArgs[1]);

				Person person = new Person(name, age);
				persons.Add(person);
			}
			SortedSet<Person> sorted = new SortedSet<Person>(persons, new NameComparator());

			foreach (Person person in new SortedSet<Person>(persons, new NameComparator()))
			{
				Console.WriteLine(person);
			}

			foreach (Person person in new SortedSet<Person>(persons, new AgeComparator()))
			{
				Console.WriteLine(person);
			}
		}
    }
}
