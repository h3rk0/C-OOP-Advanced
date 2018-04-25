 namespace P01_HarvestingFields
{
    using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Reflection;
	using System.Text;

	public class HarvestingFieldsTest
    {
		
        public static void Main()
        {
			Type type = typeof(HarvestingFields);
			FieldInfo[] fields = type.GetFields(BindingFlags.Public |
				BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Static);
			StringBuilder sb = new StringBuilder();
			while (true)
			{
				string command = Console.ReadLine();

				if(command == "HARVEST")
				{
					break;
				}

				switch (command)
				{
					case "private":
						sb.AppendLine(FormatString(fields.Where(f => f.IsPrivate)));
						break;
					case "public":
						sb.AppendLine(FormatString(fields.Where(f => f.IsPublic)));
						break;
					case "protected":
						sb.AppendLine(FormatString(fields.Where(f => f.IsFamily)));
						break;
					case "all":
						string formatted = FormatString(fields);
						sb.AppendLine(formatted);
						break;
				}
			}

			Console.WriteLine(sb.ToString().Trim());
        }

		private static string FormatString(IEnumerable<FieldInfo> fields)
		{
			StringBuilder sb = new StringBuilder();
			foreach (FieldInfo field in fields)
			{
				string accessModifier = field.Attributes.ToString().ToLower();
				if(accessModifier == "family")
				{
					accessModifier = "protected";
				}
				sb.AppendLine($"{accessModifier} {field.FieldType.Name} {field.Name}");
			}

			return sb.ToString().Trim();
		}
	}
}
