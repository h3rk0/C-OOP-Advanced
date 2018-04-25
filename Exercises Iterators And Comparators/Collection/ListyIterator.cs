using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class ListyIterator<T> : IEnumerable<T>
{
	private int currentIndex;
	
	public ListyIterator(List<T> collection)
	{
		this.collection = collection;
		this.currentIndex = 0;
	}

	public List<T> collection;

	public bool HasNext()
	{
		return this.currentIndex + 1 < this.collection.Count;
	}

	public bool Move()
	{
		if(HasNext())
		{
			this.currentIndex++;
			return true;
		}
		return false;
	}

	public void Print()
	{
		if(!this.collection.Any())
		{
			throw new ArgumentException($"Invalid Operation!");
		}

		Console.WriteLine(this.collection[currentIndex]);
	}

	public void PrintAll()
	{
		foreach (var item in this)
		{
			Console.Write($"{item} ");
		}
		Console.WriteLine();
	}

	public IEnumerator<T> GetEnumerator()
	{
		for (int i = 0; i < this.collection.Count; i++)
		{
			yield return this.collection[i];
		}
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return this.GetEnumerator();
	}
}

