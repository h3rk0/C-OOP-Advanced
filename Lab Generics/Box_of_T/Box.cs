using System;
using System.Collections.Generic;
using System.Text;


    public class Box<T>
    {
		private List<T> items { get; }

		public Box()
		{
			this.items = new List<T>();
		}

		public void Add(T element)
		{
			this.items.Add(element);
		}

		public T Remove()
		{
			T element = this.items[this.items.Count - 1];

			this.items.RemoveAt(this.items.Count - 1);

			return element;
		}

		public int Count => this.items.Count;
    }

