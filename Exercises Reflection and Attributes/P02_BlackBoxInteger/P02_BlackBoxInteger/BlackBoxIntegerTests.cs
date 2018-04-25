namespace P02_BlackBoxInteger
{
    using System;
	using System.Linq;
	using System.Reflection;

	public class BlackBoxIntegerTests
    {
        public static void Main()
        {
			//TODO put your reflection code here
			Type type = typeof(BlackBoxInteger);

			// instance
			BlackBoxInteger blackBox = (BlackBoxInteger)Activator.CreateInstance(type,true);

			MethodInfo[] methods = type.GetMethods(BindingFlags.Instance |
				BindingFlags.Public | BindingFlags.NonPublic |
				BindingFlags.Static );

			FieldInfo[] fields = type.GetFields(BindingFlags.Instance |
				BindingFlags.Public | BindingFlags.NonPublic |
				BindingFlags.Static);
			FieldInfo innerValue = fields.First(f => f.Name == "innerValue");
			

			while (true)
			{
				string input = Console.ReadLine();

				if(input == "END")
				{
					break;
				}

				string[] inputArgs = input.Split('_');
				string command = inputArgs[0];
				int argument = int.Parse(inputArgs[1]);

				switch (command)
				{
					case "Add":
						methods.First(m => m.Name == command).Invoke(blackBox, new object[] { argument });
						Console.WriteLine(innerValue.GetValue(blackBox).ToString());
						break;
					case "Subtract":
						methods.First(m => m.Name == command).Invoke(blackBox, new object[] { argument });
						Console.WriteLine(innerValue.GetValue(blackBox).ToString());
						break;
					case "Multiply":
						methods.First(m => m.Name == command).Invoke(blackBox, new object[] { argument });
						Console.WriteLine(innerValue.GetValue(blackBox).ToString());
						break;
					case "Divide":
						methods.First(m => m.Name == command).Invoke(blackBox, new object[] { argument });
						Console.WriteLine(innerValue.GetValue(blackBox).ToString());
						break;
					case "LeftShift":
						methods.First(m => m.Name == command).Invoke(blackBox, new object[] { argument });
						Console.WriteLine(innerValue.GetValue(blackBox).ToString());
						break;
					case "RightShift":
						methods.First(m => m.Name == command).Invoke(blackBox, new object[] { argument });
						Console.WriteLine(innerValue.GetValue(blackBox).ToString());
						break;
						
				}
			}
        }
    }
}
