using System;
using System.Linq;

namespace Create_Custom_Class_Attribute
{
    class Program
    {
        static void Main(string[] args)
        {
			while (true)
			{
				string input = Console.ReadLine();
				Type type = typeof(Weapon);

				var attributes = type.GetCustomAttributes(false);
				ReviewAttribute attribute = (ReviewAttribute)attributes.First();

				if(input == "END")
				{
					break;
				}

				switch (input)
				{
					case "Author":
						Console.WriteLine($"Author: {attribute.Author}");
						break;
					case "Revision":
						Console.WriteLine($"Revision: {attribute.Revision}");
						break;
					case "Description":
						Console.WriteLine($"Class description: {attribute.Description}");
						break;
					case "Reviewers":
						Console.WriteLine($"Reviewers: {string.Join(", ", attribute.Reviewers)}");
						break;
				}
			}
        }
    }
}
