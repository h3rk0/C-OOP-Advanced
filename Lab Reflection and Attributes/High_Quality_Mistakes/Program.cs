using System;

namespace High_Quality_Mistakes
{
    class Program
    {
        static void Main(string[] args)
        {
			Spy spy = new Spy();
			string result = spy.AnalyzeAcessModifiers("Hacker");
			Console.WriteLine(result);
        }
    }
}
