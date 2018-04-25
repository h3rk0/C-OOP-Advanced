using System;
using System.Collections.Generic;
using System.Text;


public class CustomList<T> : List<T> 
	where T : IComparable
{
	private List<T> items { get; }

	public CustomList()
	{
		this.items = new List<T>();
	}

	public new void Add(T element)
	{
		this.items.Add(element);
	}

	public T Remove(int index)
	{
		T element = this.items[index];

		this.items.RemoveAt(index);

		return element;
	}

	public new bool Contains(T element)
	{
		return this.items.Contains(element);
	}

	public void Swap(int firstIndex,int secondIndex)
	{
		T switcher = this.items[firstIndex];
		this.items[firstIndex] = this.items[secondIndex];
		this.items[secondIndex] = switcher;
	}

	public int CountGreaterThan(T element)
	{
		int counter = 0;

		for (int i = 0; i < this.items.Count; i++)
		{
			if(this.items[i].CompareTo(element) > 0)
			{
				counter++;
			}
		}

		return counter;
	}

	public T Max()
	{
		T max = this.items[0];

		for (int i = 0; i < this.items.Count - 1; i++)
		{
			if(this.items[i].CompareTo(this.items[i+1]) < 0)
			{
				max = this.items[i + 1];
			}
		}

		return max;
	}

	public T Min()
	{
		T min = this.items[0];

		for (int i = 0; i < this.items.Count - 1; i++)
		{
			if (this.items[i].CompareTo(this.items[i + 1]) > 0)
			{
				min = this.items[i + 1];
			}
		}

		return min;
	}

	public void Print()
	{
		for (int i = 0; i < this.items.Count; i++)
		{
			Console.WriteLine(this.items[i]);
		}
	}
}

