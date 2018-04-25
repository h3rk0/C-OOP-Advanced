using System;

namespace Custom_List
{
    class Program
    {
        static void Main()
        {
			CustomList<string> list = new CustomList<string>();

			while (true)
			{
				string input = Console.ReadLine();

				if(input == "END")
				{
					break;
				}

				string[] args = input.Split();
				string command = args[0];

				switch (command)
				{
					case "Add":
						list.Add(args[1]);
						break;

					case "Remove":
						list.Remove(int.Parse(args[1]));
						break;

					case "Contains":
						Console.WriteLine(list.Contains(args[1]));
						break;

					case "Swap":
						list.Swap(int.Parse(args[1]), int.Parse(args[2]));
						break;

					case "Greater":
						Console.WriteLine(list.CountGreaterThan(args[1]));
						break;

					case "Max":
						Console.WriteLine(list.Max());
						break;

					case "Min":
						Console.WriteLine(list.Min());
						break;

					case "Print":
						list.Print();
						break;
				}
			}
        }
    }
}
