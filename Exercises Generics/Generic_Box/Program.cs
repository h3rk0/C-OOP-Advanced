using System;

namespace Generic_Box
{
    class Program
    {
        static void Main(string[] args)
        {
			Box<string> box = new Box<string>("life in a box");
			Console.WriteLine(box);
        }
    }
}
