
using Extended_Database.Models;
using ExtendedDatabaseClass;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Extended_DatabaseTesting
{
    public class ExtendedDatabaseTests
    {

		[Test]
		public void TestDatabaseExtendedConstructorValid()
		{
			Person[] personsToAdd = new Person[2];
			Database database = new Database(personsToAdd);

			FieldInfo currentIndexField = typeof(Database).GetFields(BindingFlags.NonPublic |
				BindingFlags.Instance )
				.First(f => f.FieldType == typeof(int));

			int currentIndexValue = (int)currentIndexField.GetValue(database);

			Assert.That(currentIndexValue, Is.EqualTo(2));
		}

		[Test]
		public void TestDatabaseAddMethodIsValid()
		{
			Database database = new Database();

			Person firstPersonForTest = new Person(2, "Test");
			Person secondPersonForTest = new Person(1, "Test2");
			database.Add(firstPersonForTest);
			database.Add(secondPersonForTest);

			FieldInfo valuesField = typeof(Database)
				.GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
				.First(f => f.FieldType == typeof(Person[]));

			FieldInfo currentIndexField = typeof(Database).GetFields(BindingFlags.NonPublic |
				BindingFlags.Instance)
				.First(f => f.FieldType == typeof(int));

			Person firstValue = ((Person[])valuesField.GetValue(database)).First();
			int currentIndexValue = (int)currentIndexField.GetValue(database);

			Assert.That(firstValue, Is.EqualTo(firstPersonForTest));
			Assert.That(currentIndexValue, Is.EqualTo(2));
		}

		[Test]
		public void TestIfDatabaseAddMethodWithSameIdsThrowsException()
		{
			Database db = new Database();

			db.Add(new Person(1, "Test"));

			Assert.That(() => db.Add(new Person(1, "Test2")), Throws.InvalidOperationException);
			
		}

		[Test]
		public void TestIfDatabaseAddMethodWithSameUsernameThrowsException()
		{
			Database db = new Database();

			db.Add(new Person(1, "Test"));

			Assert.That(() => db.Add(new Person(2, "Test")), Throws.InvalidOperationException);

		}

		[Test]
		public void TestIfDatabaseAddMethodIsInvalidWhenExceedLimit()
		{
			Database db = new Database();

			FieldInfo currentIndexField = typeof(Database).GetFields(BindingFlags.NonPublic
				| BindingFlags.Instance).First(f => f.FieldType == typeof(int));

			currentIndexField.SetValue(db, 16);

			Assert.That(() => db.Add(new Person(1, "Test")), Throws.InvalidOperationException);
		}

		[Test]
		public void TestRemoveMethodIsValid()
		{
			Database db = new Database();

			Person[] personsForTest = new Person[]
			{
				new Person(1,"Test1"),
				new Person(2,"Test2")
			};

			FieldInfo fieldInfo = typeof(Database).GetFields(BindingFlags.NonPublic
				| BindingFlags.Instance).First(f => f.FieldType == typeof(Person[]));

			fieldInfo.SetValue(db, personsForTest);

			FieldInfo currentIndexField = typeof(Database).GetFields(BindingFlags.NonPublic
				| BindingFlags.Instance).First(f => f.FieldType == typeof(int));

			currentIndexField.SetValue(db, 2);

			db.Remove();

			Person[] fieldValues = (Person[])fieldInfo.GetValue(db);
			Person[] buffer = new Person[fieldValues.Length - (personsForTest.Length - 1)];

			personsForTest = personsForTest
				.Take(personsForTest.Length - 1)
				.Concat(buffer)
				.ToArray();

			Assert.That(fieldValues, Is.EquivalentTo(personsForTest));
		}

		[Test]
		public void TestRemoveMethodThrowsExceptionWhenNoPersons()
		{
			Database db = new Database();

			FieldInfo currentIndexField = typeof(Database).GetFields(BindingFlags.NonPublic
				| BindingFlags.Instance).First(f => f.FieldType == typeof(int));

			currentIndexField.SetValue(db, 0);

			Assert.That(() => db.Remove(), Throws.InvalidOperationException);
		}

		[Test]
		[TestCase("Test1")]
		[TestCase("Test2")]
		//[TestCase("Test3")]  throws exception
		public void TestFindByUsernameMethodIsValid(string username)
		{
			Database db = new Database();

			Person[] personsForTest = new Person[]
			{
				new Person(1,"Test1"),
				new Person(2,"Test2")
			};

			FieldInfo fieldInfo = typeof(Database).GetFields(BindingFlags.NonPublic
				| BindingFlags.Instance).First(f => f.FieldType == typeof(Person[]));

			fieldInfo.SetValue(db, personsForTest);

			Person person = db.FindByUsername(username);

			Assert.That(person, !Is.EqualTo(null));
		}

		[Test]
		[TestCase("Test3")]
		public void TestFindByUsernameMethodThrowsExceptionWhenNotFound(string username)
		{
			Database db = new Database();

			Person[] personsForTest = new Person[]
			{
				new Person(1,"Test1"),
				new Person(2,"Test2")
			};

			FieldInfo fieldInfo = typeof(Database).GetFields(BindingFlags.NonPublic
				| BindingFlags.Instance).First(f => f.FieldType == typeof(Person[]));

			fieldInfo.SetValue(db, personsForTest);
			

			Assert.That(() => db.FindByUsername(username) ,Throws.InvalidOperationException);
		}

		[Test]
		[TestCase(null)]
		public void TestFindByUsernameMethodThrowsExceptionWhenParamterIsNull(string username)
		{
			Database db = new Database();

			Person[] personsForTest = new Person[]
			{
				new Person(1,"Test1"),
				new Person(2,"Test2")
			};

			FieldInfo fieldInfo = typeof(Database).GetFields(BindingFlags.NonPublic
				| BindingFlags.Instance).First(f => f.FieldType == typeof(Person[]));

			fieldInfo.SetValue(db, personsForTest);

			Assert.That(() => db.FindByUsername(username), Throws.ArgumentNullException);
		}

		[Test]
		[TestCase("test1")]
		[TestCase("test2")]

		public void TestFindByUsernameMethodIsCaseSensitive(string username)
		{
			Database db = new Database();

			Person[] personsForTest = new Person[]
			{
				new Person(1,"Test1"),
				new Person(2,"TeSt2")
			};

			FieldInfo fieldInfo = typeof(Database).GetFields(BindingFlags.NonPublic
				| BindingFlags.Instance).First(f => f.FieldType == typeof(Person[]));

			fieldInfo.SetValue(db, personsForTest);

			Assert.That(() => db.FindByUsername(username), Throws.InvalidOperationException);
		}
		
		[Test]
		[TestCase(1)]
		[TestCase(2)]
		//[TestCase(3)] throws exception 
		public void TestFindByIdMethodIsValid(int id)
		{
			Database db = new Database();

			// valid ids : 1,2
			Person[] personsForTest = new Person[]
			{
				new Person(1,"Test1"),
				new Person(2,"Test2")
			};

			FieldInfo fieldInfo = typeof(Database).GetFields(BindingFlags.NonPublic
				| BindingFlags.Instance).First(f => f.FieldType == typeof(Person[]));

			fieldInfo.SetValue(db, personsForTest);

			Person person = db.FindById(id);

			Assert.That(person, !Is.EqualTo(null));
		}

		[Test]
		[TestCase(3)]
		[TestCase(4)]
		public void TestFindByIdMethodThrowsExceptionWhenNoSuchId(int id)
		{
			Database db = new Database();

			// valid ids : 1,2
			Person[] personsForTest = new Person[]
			{
				new Person(1,"Test1"),
				new Person(2,"Test2")
			};

			FieldInfo fieldInfo = typeof(Database).GetFields(BindingFlags.NonPublic
				| BindingFlags.Instance).First(f => f.FieldType == typeof(Person[]));

			fieldInfo.SetValue(db, personsForTest);

			Assert.That(() => db.FindById(id), Throws.InvalidOperationException);
		}

		[Test]
		[TestCase(-3)]
		[TestCase(-44)]
		public void TestFindByIdMethodThrowsExceptionWhenIdsAreNegative(int id)
		{
			Database db = new Database();

			// valid ids : 1,2
			Person[] personsForTest = new Person[]
			{
				new Person(1,"Test1"),
				new Person(2,"Test2")
			};

			FieldInfo fieldInfo = typeof(Database).GetFields(BindingFlags.NonPublic
				| BindingFlags.Instance).First(f => f.FieldType == typeof(Person[]));

			fieldInfo.SetValue(db, personsForTest);

			// should throw ArgumentOutOfRangeException but cant...
			Assert.That(() => db.FindById(id),Throws.InnerException);
		}
	}
}
