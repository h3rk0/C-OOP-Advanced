using Iterator_Test.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Iterator_TestTests
{
    public class ListIteratorTests
    {

		[Test]
		public void TestConstructorValid()
		{
			List<string> strings = new List<string> { "Gosho", "Misho", "Pesho" };
			ListIterator iterator = new ListIterator(strings);

			FieldInfo fieldList = typeof(ListIterator)
				.GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
				.First(f => f.FieldType == typeof(List<string>));

			Assert.That(fieldList.GetValue(iterator), Is.EqualTo(strings));
		}

		[Test]
		public void TestConstructorThrowsExceptionWhenParameterNull()
		{
			Assert.That(() => new ListIterator(null), Throws.ArgumentNullException);
		}

		[Test]
		public void TestMoveMethodIsTrue()
		{
			List<string> strings = new List<string> { "Gosho", "Misho", "Pesho" };

			ListIterator iterator = new ListIterator();

			FieldInfo fieldList = typeof(ListIterator)
				.GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
				.First(f => f.FieldType == typeof(List<string>));

			fieldList.SetValue(iterator, strings);
			
			Assert.That(true, Is.EqualTo(iterator.Move()));
		}

		[Test]
		public void TestMoveMethodIsFalse()
		{
			List<string> strings = new List<string> { "Gosho", "Misho", "Pesho" };

			ListIterator iterator = new ListIterator();

			FieldInfo fieldList = typeof(ListIterator)
				.GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
				.First(f => f.FieldType == typeof(List<string>));

			fieldList.SetValue(iterator, strings);

			FieldInfo currentIndex = typeof(ListIterator)
				.GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
				.First(f => f.FieldType == typeof(int));
			
			currentIndex.SetValue(iterator, 2);

			Assert.That(false, Is.EqualTo(iterator.Move()));
		}

		[Test]
		public void TestHasNextMethodIsTrue()
		{
			List<string> strings = new List<string> { "Gosho", "Pesho" };

			ListIterator iterator = new ListIterator();

			FieldInfo fieldList = typeof(ListIterator)
				.GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
				.First(f => f.FieldType == typeof(List<string>));

			fieldList.SetValue(iterator, strings);

			FieldInfo currentIndex = typeof(ListIterator)
				.GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
				.First(f => f.FieldType == typeof(int));

			currentIndex.SetValue(iterator, 0);

			Assert.That(true, Is.EqualTo(iterator.HasNext()));
		}

		[Test]
		public void TestHasNextMethodIsFalse()
		{
			List<string> strings = new List<string> { "Gosho", "Pesho" };

			ListIterator iterator = new ListIterator();

			FieldInfo fieldList = typeof(ListIterator)
				.GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
				.First(f => f.FieldType == typeof(List<string>));

			FieldInfo currentIndex = typeof(ListIterator)
				.GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
				.First(f => f.FieldType == typeof(int));
			
			fieldList.SetValue(iterator, strings);
			currentIndex.SetValue(iterator, 1);

			Assert.That(false, Is.EqualTo(iterator.HasNext()));
		}

		[Test]
		public void TestPrintMethodThrowsException()
		{
			List<string> strings = new List<string>();
			ListIterator iterator = new ListIterator();

			FieldInfo fieldList = typeof(ListIterator)
				.GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
				.First(f => f.FieldType == typeof(List<string>));

			fieldList.SetValue(iterator, strings);

			Assert.That(() => iterator.Print(), Throws.InvalidOperationException);

			
		}
    }
}
