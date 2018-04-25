using System;
using System.Linq;

namespace Threeuple
{
    class Program
    {
        static void Main(string[] args)
        {
			string[] inputArgs = Console.ReadLine().Split().ToArray();
			string name = $"{inputArgs[0]} {inputArgs[1]}";
			string address = inputArgs[2];
			string town = inputArgs[3];
			Console.WriteLine(new Tuple<string, string, string>(name, address, town));

			inputArgs = Console.ReadLine().Split().ToArray();
			string secondName = inputArgs[0];
			int litersOfBeer = int.Parse(inputArgs[1]);
			string drunkOrNot = inputArgs[2];
			bool drunk = false;
			if(drunkOrNot == "drunk")
			{
				drunk = true;
			}
			Console.WriteLine(new Tuple<string, int, bool>(secondName, litersOfBeer, drunk));

			inputArgs = Console.ReadLine().Split().ToArray();
			string thirdName = inputArgs[0];
			double dbl = double.Parse(inputArgs[1]);
			string bankName = inputArgs[2];
			Console.WriteLine(new Tuple<string, double, string>(thirdName, dbl, bankName));
		}
    }
}
