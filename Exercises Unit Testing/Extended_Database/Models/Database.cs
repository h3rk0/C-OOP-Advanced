using Extended_Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExtendedDatabaseClass
{
	public class Database
	{
		private const int DEFAULT_CAPACITY = 16;

		private Person[] persons;
		private int currentIndex;

		public Database(params Person[] persons)
		{
			this.currentIndex = 0;
			this.persons = InitializeArray(persons);
		}

		private Person[] InitializeArray(Person[] persons)
		{
			this.persons = new Person[16];

			try
			{
				//integers = integers.Concat(integers).ToArray();
				Array.Copy(persons, this.persons, persons.Length);
				this.currentIndex = persons.Length;

			}
			catch (ArgumentException e)
			{
				throw new InvalidOperationException("Database is full!", e);
			}
			return this.persons;
		}

		public void Add(Person person)
		{
			if (currentIndex >= DEFAULT_CAPACITY)
			{
				throw new InvalidOperationException("Database is full!");
			}
			
			if (this.persons.Any(p => p != null && p.Username==person.Username)) 
			{
				throw new InvalidOperationException("Database contains person with that name!");
			}

			if (this.persons.Any(p => p != null && p.Id == person.Id))
			{
				throw new InvalidOperationException("Database contains person with that id!");
			}

			this.persons[currentIndex] = person;
			currentIndex++;
		}

		

		public Person Remove()
		{
			if (currentIndex <= 0)
			{
				throw new InvalidOperationException("Database is empty!");
			}

			currentIndex--;
			Person removed = this.persons[currentIndex];
			this.persons[currentIndex] = null;
			return removed;
		}

		public Person FindByUsername(string username)
		{
			if (username == null)
			{
				throw new ArgumentNullException();
			}

			Person person = this.persons.FirstOrDefault(p => p.Username == username);

			if (person == null)
			{
				throw new InvalidOperationException("No such username in database!");
			}

			return person;
		}

		public Person FindById(int id)
		{
			if (id < 0) // Id is negative
			{
				throw new ArgumentOutOfRangeException("no such");
			}

			Person person = this.persons.FirstOrDefault(p => p.Id == id);

			if (person == null)
			{
				throw new InvalidOperationException("No such Id in database!");
			}

			return person;
		}
    }
}
