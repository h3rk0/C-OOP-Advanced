using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public static class Sorter<T> 
	where T : IComparable
{
	public static CustomList<T> Sort(CustomList<T> list)
	{
		bool swapped;
		do
		{
			swapped = false;
			for (int i = 0; i < list.Items.Length - 1; i++)
			{
				if (list.Items[i].CompareTo(list.Items[i+1])> 0)
				{
					list.Swap(i, i + 1); // todo: write swap method
					swapped = true;
				}
			}
		} while (swapped);

		return list;
	}
}

