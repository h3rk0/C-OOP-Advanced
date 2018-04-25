using System;

namespace Generic_Scale
{
    class Program
    {
        static void Main(string[] args)
        {
			Scale<string> scale = new Scale<string>("Pesho", "Misho");

			Console.WriteLine(scale.GetHeavier());
        }
    }
}
