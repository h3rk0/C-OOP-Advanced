using System;

namespace Event_Implementation
{
    class Program
    {
        static void Main(string[] args)
        {
			INameChangeable dispatcher = new Dispatcher("Pesho");
			INameChangeHandler handler = new Handler();

			dispatcher.NameChange += handler.OnDispatcherNameChange;

			while (true)
			{
				string input = Console.ReadLine();

				if(input == "End")
				{
					break;
				}

				dispatcher.Name = input;
			}
        }


    }
}
