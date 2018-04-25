using System;

namespace Mission_Private_Impossible
{
    class Program
    {
        static void Main(string[] args)
        {
			Spy spy = new Spy();

			string result = spy.RevealPrivateMethods("Hacker");
			Console.WriteLine(result);
        }
    }
}
