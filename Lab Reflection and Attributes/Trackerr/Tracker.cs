using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Trackerr;

public class Tracker
{
	public void PrintMethodsByAuthor()
	{
		Type type = typeof(StartUp);
		MethodInfo[] methods = type.GetMethods(BindingFlags.Instance |
			BindingFlags.Static | BindingFlags.Public);

		foreach (MethodInfo method in methods)
		{
			if(method.CustomAttributes.Any(n => n.AttributeType == typeof(SoftUniAttribute)))
			{
				var attributes = method.GetCustomAttributes(false);
				foreach (SoftUniAttribute attribute in attributes)
				{
					Console.WriteLine($"{method.Name} is written by {attribute.Name}");
				}
			}
		}
	}
}

