using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class Statistics
{
	private List<Person> persons { get; set; }

	public Statistics()
	{
		this.persons = new List<Person>();
	}

	public void AddPerson(Person person)
	{
		this.persons.Add(person);
	}
	
	public string CalculateEqual(int personIndex)
	{
		Person thisPerson = this.persons[personIndex - 1];

		//List<Person> rest = this.persons
		//	.Skip(personIndex)
		//	.ToList();
		
		string resultString = "No matches";
		if(this.persons.Where(p => p.CompareTo(thisPerson)==0).Count() > 1)
		{
			int equalPeople = this.persons.Where(p => p.CompareTo(thisPerson) == 0).Count();
			int unequalPeople = this.persons.Where(p => p.CompareTo(thisPerson) != 0).Count();
			resultString = $"{equalPeople} {unequalPeople} {this.persons.Count}";
		}

		return resultString;
	}
}

