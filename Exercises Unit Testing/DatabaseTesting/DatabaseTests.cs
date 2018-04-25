using DatabaseClass;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace DatabaseTesting
{
    public class DatabaseTests
    {

		[Test]
		[TestCase(new int[] { 1, 2, 3, 4 })]
		[TestCase(new int[] { int.MinValue })]
		[TestCase(new int[] { int.MaxValue })]
		[TestCase(new int[] { 0 })]
		[TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
		public void TestConstructor(int[] values)
		{
			//int[] values = new int[] { 1, 2, 3, 4, 5 };
			Database db = new Database(values);

			FieldInfo fieldInfo = typeof(Database)
				.GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
				.First(f => f.FieldType == typeof(int[]));

			int[] fieldValues = ((int[])fieldInfo.GetValue(db));
			int[] buffer = new int[fieldValues.Length - values.Length];
			Assert.That(fieldValues, Is.EquivalentTo(values.Concat(buffer)));
		}

		[Test]
		public void TestInvalidConstructor()
		{
			int[] values = new int[17];
			Assert.That(() => new Database(values), Throws.InvalidOperationException);
		}

		[Test]
		[TestCase(int.MaxValue)]
		[TestCase(int.MinValue)]
		[TestCase(0)]
		public void TestAddMethodWorks(int value)
		{
			Database db = new Database();
			db.Add(value);

			FieldInfo valuesField = typeof(Database)
				.GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
				.First(f => f.FieldType == typeof(int[]));

			FieldInfo currentIndexInfo = typeof(Database)
				.GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
				.First(f => f.FieldType == typeof(int));

			int firstValue = ((int[])valuesField.GetValue(db)).First();
			Assert.That(firstValue, Is.EqualTo(value));

			int valuesCount = (int)currentIndexInfo.GetValue(db);
			Assert.That(valuesCount, Is.EqualTo(1));
		}


		[Test]
		public void TestAddMethodInvalid()
		{
			Database db = new Database();

			FieldInfo currentIndexField = typeof(Database).GetFields(BindingFlags.NonPublic
				| BindingFlags.Instance).First(f => f.FieldType == typeof(int));

			currentIndexField.SetValue(db, 16);

			Assert.That(() => db.Add(1), Throws.InvalidOperationException);
		}

		[Test]
		[TestCase(new int[] { 1, 2, 3, 4 })]
		[TestCase(new int[] { int.MinValue })]
		[TestCase(new int[] { int.MaxValue })]
		[TestCase(new int[] { 0 })]
		[TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
		public void TestRemoveMethodValid(int[] values)
		{
			Database db = new Database(values);

			FieldInfo fieldInfo  = typeof(Database).GetFields(BindingFlags.NonPublic
				| BindingFlags.Instance).First(f => f.FieldType == typeof(int[]));

			fieldInfo.SetValue(db, values);

			FieldInfo currentIndexField = typeof(Database).GetFields(BindingFlags.NonPublic
				| BindingFlags.Instance).First(f => f.FieldType == typeof(int));

			currentIndexField.SetValue(db, values.Length);

			db.Remove();
			int[] fieldValues = (int[])fieldInfo.GetValue(db);
			int[] buffer = new int[fieldValues.Length - (values.Length - 1 )];

			values = values
				.Take(values.Length - 1)
				.Concat(buffer)
				.ToArray();

			Assert.That(fieldValues, Is.EquivalentTo(values));
		}

		[Test]
		public void TestRemoveMethodInvalid()
		{
			Database db = new Database();
			FieldInfo currentIndexField = typeof(Database).GetFields(BindingFlags.NonPublic
				| BindingFlags.Instance).First(f => f.FieldType == typeof(int));

			currentIndexField.SetValue(db, 0);
			Assert.That(() => db.Remove(), Throws.InvalidOperationException);
		}

		[Test]
		[TestCase(new int[] { 1, 2, 3, 4 })]
		[TestCase(new int[] { int.MinValue })]
		[TestCase(new int[] { int.MaxValue })]
		[TestCase(new int[] { 0 })]
		[TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
		public void TestFetchMethodValid(int[] values)
		{
			Database db = new Database();

			FieldInfo fieldInfo = typeof(Database).GetFields(BindingFlags.NonPublic
				| BindingFlags.Instance).First(f => f.FieldType == typeof(int[]));

			fieldInfo.SetValue(db, values);

			FieldInfo currentIndexField = typeof(Database).GetFields(BindingFlags.NonPublic
				| BindingFlags.Instance).First(f => f.FieldType == typeof(int));

			currentIndexField.SetValue(db, values.Length);

			Assert.That(db.FetchDatabase(), Is.EquivalentTo(values));
		}

	}
}
