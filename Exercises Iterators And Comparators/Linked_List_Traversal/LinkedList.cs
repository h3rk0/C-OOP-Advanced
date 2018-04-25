using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;


public class LinkedList<T> : IEnumerable<T>
{
	private List<T> items;

	public LinkedList()
	{
		this.items = new List<T>();
	}

	public void Add(T element)
	{
		this.items.Add(element);
	}

	public bool Remove(T element)
	{
		if(this.items.Contains(element))
		{
			this.items.Remove(element);
			return true;
		}
		return false;
	}

	public int Count => this.items.Count;

	public IEnumerator<T> GetEnumerator()
	{
		for (int i = 0; i < this.items.Count; i++)
		{
			yield return this.items[i];
		}
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		for (int i = 0; i < this.items.Count; i++)
		{
			yield return this.items[i];
		}
	}
}

