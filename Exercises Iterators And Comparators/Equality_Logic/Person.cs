using System;
using System.Collections.Generic;
using System.Text;


public class Person : IComparable<Person>
{
	public Person(string name,int age)
	{
		this.Name = name;
		this.Age = age;
	}

	public string Name { get; set; }
	public int Age { get; set; }

	public override int GetHashCode()
	{
		return this.Name.GetHashCode() + this.Age.GetHashCode();
	}

	public override bool Equals(object obj)
	{
		if(obj is Person person)
		{
			return this.Name == person.Name && this.Age == person.Age;
		}
		return false;
	}

	public override string ToString()
	{
		return $"{this.Name} {this.Age}";
	}

	public int CompareTo(Person other)
	{
		int result = this.Name.CompareTo(other.Name);
		if(result == 0)
		{
			result = this.Age.CompareTo(other.Age);
		}
		return result;
	}
}

