using System;
using System.Collections.Generic;
using System.Text;


public class Scale<T>
	where T : IComparable<T>
{
	private T left { get; }
	private T right { get; }
	public Scale(T left,T right)
	{
		this.left = left;
		this.right = right;
	}

	public T GetHeavier()
	{
		int compare = this.left.CompareTo(this.right);

		if (compare > 0) 
		{
			return this.left;
		}

		if (compare < 0) 
		{
			return this.right;
		}

		return default(T);
	}
}

