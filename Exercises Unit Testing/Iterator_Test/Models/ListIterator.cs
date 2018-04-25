using System;
using System.Collections.Generic;
using System.Text;

namespace Iterator_Test.Models
{
    public class ListIterator
    {
		private List<string> strings;
		private int currentIndex;
		private IEnumerable<string> enumerable;

		public ListIterator()
		{
			this.strings = new List<string>();
		}

		public ListIterator(List<string> strings)
			:this()
		{
			ValidateInputStrings(strings);
			this.currentIndex = 0;
			this.strings = new List<string>(strings);
		}

		public ListIterator(IEnumerable<string> enumerable)
		{
			this.enumerable = enumerable;
		}

		public bool Move() => ++this.currentIndex < this.strings.Count;

		public bool HasNext() => this.currentIndex < this.strings.Count - 1;

		private void ValidateInputStrings(List<string> strings)
		{
			if(strings == null )
			{
				throw new ArgumentNullException();
			}
		}

		public void Print()
		{
			if(this.strings.Count == 0)
			{
				throw new InvalidOperationException($"Invalid Operation!");
			}

			Console.WriteLine(this.strings[this.currentIndex]);
		}
	}
}
