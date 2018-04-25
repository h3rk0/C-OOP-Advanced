using System;
using System.Collections.Generic;
using System.Text;

namespace BubbleSort
{
    public class Bubble<T>
		where T : IComparable<T>
    {
		public T[] Sort(params T[] elements)
		{
			bool swapped = true;

			while(swapped)
			{
				swapped = false;

				for (int i = 1	; i < elements.Length; i++)
				{
					if (elements[i - 1].CompareTo(elements[i]) > 0)
					{
						var temp = elements[i - 1];
						elements[i - 1] = elements[i];
						elements[i] = temp;
						swapped = true;
					}
				}
			}

			return elements;
		}
    }
}
