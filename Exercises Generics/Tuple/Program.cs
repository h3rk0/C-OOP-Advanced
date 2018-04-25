using System;
using System.Linq;

namespace Tuple
{
    class Program
    {
        static void Main(string[] args)
        {
			string[] inputArgs = Console.ReadLine().Split().ToArray();
			string name = $"{inputArgs[0]} {inputArgs[1]}";
			string address = inputArgs[2];
			Console.WriteLine(new Tuple<string,string>(name,address));

			inputArgs = Console.ReadLine().Split().ToArray();
			string secondName = inputArgs[0];
			int litersOfBeer = int.Parse(inputArgs[1]);
			Console.WriteLine(new Tuple<string,int>(secondName,litersOfBeer));

			inputArgs = Console.ReadLine().Split().ToArray();
			int thirdName = int.Parse(inputArgs[0]);
			double dbl = double.Parse(inputArgs[1]);
			Console.WriteLine(new Tuple<int, double>(thirdName, dbl));
		}
    }
}
