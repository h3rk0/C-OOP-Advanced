using System;
using System.Collections.Generic;
using System.Text;


public class Box<T>
	where T : IComparable
{
	public T Value { get; }

	public Box(T value)
	{
		this.Value = value;
	}

	public bool Compare(Box<T> box)
	{
		int result = this.Value.CompareTo(box.Value);

		if(result > 0)
		{
			return true;
		}

		return false;
	}

	public override string ToString()
	{
		return $"{this.Value.GetType().FullName}: {this.Value}";
	}
}

