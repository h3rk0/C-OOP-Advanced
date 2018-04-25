using BubbleSort;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BubbleSort_Testing
{
    public class BubbleSortTesting
    {
		[Test]
		[TestCase(0, 1, 5, 14, 22, 7, 4, 65, 27, 65, 61)]
		[TestCase(int.MaxValue,int.MinValue,0)]
		public void TestSortMethodWorks(params int[] parameters)
		{
			Bubble<int> test = new Bubble<int>();

			int[] result = test.Sort(parameters);

			Assert.That(parameters.OrderBy(p => p), Is.EquivalentTo(result));
		}
    }
}
