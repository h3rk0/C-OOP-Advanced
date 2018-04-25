using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DatabaseClass
{
    public class Database
    {
		private const int DEFAULT_CAPACITY = 16;

		private int[] array;
		private int currentIndex;

		public Database(params int[] integers)
		{
			this.currentIndex = 0;
			this.array = InitializeArray(integers);
		}

		private int[] InitializeArray(int[] integers)
		{
			this.array = new int[16];
			try
			{
				//integers = integers.Concat(integers).ToArray();
				Array.Copy(integers, this.array, integers.Length);
				this.currentIndex = integers.Length;

			}
			catch (ArgumentException e)
			{
				throw new InvalidOperationException("Array is full!", e);
			}
			return this.array;
		}
		
		public void Add(int element)
		{
			if(currentIndex >= DEFAULT_CAPACITY)
			{
				throw new InvalidOperationException("Database is full!");
			}

			this.array[currentIndex] = element;
			currentIndex++;
		}

		public int Remove()
		{
			if(currentIndex <= 0)
			{
				throw new InvalidOperationException("Database is empty!");
			}

			currentIndex--;
			int removed = this.array[currentIndex];
			this.array[currentIndex] = default(int);
			return removed;
		}

		public int[] FetchDatabase()
		{
			return this.array;
		}
    }
}
