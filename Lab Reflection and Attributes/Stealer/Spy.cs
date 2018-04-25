using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Linq;

public class Spy
{
	public string StealFieldInfo(string classString, params string[] fields)
	{
		Type type = Type.GetType(classString);
		StringBuilder sb = new StringBuilder();

		var classFields = type.GetFields(BindingFlags.Instance |
			BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
		Object classInstance = Activator.CreateInstance(type, new object[] { });

		sb.AppendLine($"Class under investigation: {classString}");

		foreach (FieldInfo field in classFields.Where(f => fields.Contains(f.Name)))
		{
			sb.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
		}

		return sb.ToString().Trim();
	}
}

