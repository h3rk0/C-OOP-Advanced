using Logger.Models.Contracts;
using Logger.Models.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logger
{
    public class Engine
    {
		private ILogger logger;
		private ErrorFactory errorFactory;
		public Engine(ILogger logger, ErrorFactory errorFactory)
		{
			this.logger = logger;
			this.errorFactory = errorFactory;
		}

		public void Run()
		{
			while (true)
			{
				string input = Console.ReadLine();

				if(input == "END")
				{
					break;
				}

				string[] args = input.Split('|').ToArray();

				string level = args[0];
				string dateTime = args[1];
				string message = args[2];

				IError error = errorFactory.CreateError(dateTime, level, message);
				logger.Log(error);
			}

			Console.WriteLine("Logger info");
			foreach (IAppender appender in this.logger.Appenders)
			{
				Console.WriteLine(appender);
			}
		}
    }
}
