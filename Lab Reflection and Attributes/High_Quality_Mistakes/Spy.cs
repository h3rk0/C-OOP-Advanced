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

	public string AnalyzeAcessModifiers(string className)
	{
		StringBuilder sb = new StringBuilder();
		Type type = Type.GetType(className);
		FieldInfo[] fields = type.GetFields(BindingFlags.Instance | BindingFlags.Public |
			BindingFlags.Static);
		MethodInfo[] publicMethods = type.GetMethods(BindingFlags.Instance | BindingFlags.Public |
			BindingFlags.Static);
		MethodInfo[] nonPublicMethods = type.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic |
			BindingFlags.Static);
		foreach (FieldInfo field in fields)
		{
			sb.AppendLine($"{field.Name} must be private!");
		}

		foreach (MethodInfo method in nonPublicMethods.Where(m => m.Name.StartsWith("get")))
		{
			sb.AppendLine($"{method.Name} have to be public!");
		}

		foreach (MethodInfo method in publicMethods.Where(m => m.Name.StartsWith("set")))
		{
			sb.AppendLine($"{method.Name} have to be private!");
		}

		return sb.ToString().Trim();
	}
}

