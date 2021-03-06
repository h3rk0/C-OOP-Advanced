﻿using _03BarracksFactory.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace P03_BarraksWars.Core.Commands
{
	public class CommandInterpreter : ICommandInterpreter
	{
		private IServiceProvider serviceProvider;

		public CommandInterpreter(IServiceProvider serviceProvider)
		{
			this.serviceProvider = serviceProvider;
		}

		public IExecutable InterpretCommand(string[] data, string commandName)
		{
			Assembly assembly = Assembly.GetCallingAssembly();
			Type commandType = assembly
				.GetTypes()
				.FirstOrDefault(c => c.Name.ToLower() == commandName + "command");

			if (commandType == null)
			{
				throw new ArgumentException($"Invalid Command!");
			}

			if (!typeof(IExecutable).IsAssignableFrom(commandType))
			{
				throw new ArgumentException($"{commandName} Is not a Command!");
			}

			FieldInfo[] fieldsToInject = commandType
				.GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
				.Where(f => f.CustomAttributes.Any(ca => ca.AttributeType == typeof(InjectAttribute))).ToArray();

			object[] injectArgs = fieldsToInject.Select(f => this.serviceProvider.GetService(f.FieldType)).ToArray();

			object[] constrArgs = new object[] { data }.Concat(injectArgs).ToArray();
			IExecutable instance =(IExecutable) Activator.CreateInstance(commandType, constrArgs);

			return instance;

			//MethodInfo method = typeof(IExecutable).GetMethods().First();

			//try
			//{
			//	string result = (string)method.Invoke(instance, null);
			//	return result;
			//}
			//catch (TargetInvocationException e)
			//{

			//	throw e.InnerException;
			//}
		}
	}
}
