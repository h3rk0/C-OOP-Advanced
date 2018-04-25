using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;


public class Stack<T> : IEnumerable<T>
{
	private List<T> items;

	public Stack()
	{
		this.items = new List<T>();
	}

	public void Push(T item)
	{
		this.items.Add(item);
	}

	public void Pop()
	{
		if(this.items.Count == 0)
		{
			Console.WriteLine("No elements");
			return;
		}

		this.items.RemoveAt(this.items.Count - 1);
	}

	public IEnumerator<T> GetEnumerator()
	{
		for (int i = this.items.Count - 1; i >= 0; i--)
		{
			yield return this.items[i];
		}
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		for (int i = this.items.Count - 1; i >= 0; i--)
		{
			yield return this.items[i];
		}
	}
}

