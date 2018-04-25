using System;

namespace Tracker2
{
	[SoftUni("Ventsi")]
	class StartUp
    {
		[SoftUni("Gosho")]
		public static void Main(string[] args)
        {
			Tracker tracker = new Tracker();
			tracker.PrintMethodsByAuthor();
		}
    }
}
