using System;

namespace DatabaseClass
{
    class Program
    {
        static void Main(string[] args)
        {
			//
			int[] test = new int[] { 1};
			//
			Database database = new Database(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16);

			Console.WriteLine(database.FetchDatabase());
			database.Remove();
			database.Remove();
			Console.WriteLine(database.FetchDatabase());
			database.Add(5);
			database.Add(25);
			Console.WriteLine(database.FetchDatabase());


		}
	}
}
