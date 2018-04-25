using P03_DependencyInversion;
using System;

namespace Dependency_Inversion
{
    class Program
    {
        static void Main()
        {
			PrimitiveCalculator calculator = new PrimitiveCalculator(new AdditionStrategy());

			while (true)
			{
				string input = Console.ReadLine();

				if(input == "End")
				{
					break;
				}

				string[] args = input.Split();
				string command = args[0];
				
				if(command == "mode")
				{
					calculator.ChangeStrategy((char)args[1].ToCharArray()[0]);
				}
				else
				{
					int result = calculator.PerformCalculation(int.Parse(args[0]), int.Parse(args[1]));
					Console.WriteLine(result);
				}
			}
        }
    }
}
