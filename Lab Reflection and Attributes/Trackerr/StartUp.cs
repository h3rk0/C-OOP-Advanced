using System;

namespace Trackerr
{
	[SoftUni("Ventsi")]
	class StartUp
    {
		[SoftUni("Gosho")]
        static void Main(string[] args)
        {
			Tracker tracker = new Tracker();
			tracker.PrintMethodsByAuthor();
        }
    }
}
