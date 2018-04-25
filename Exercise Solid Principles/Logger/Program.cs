using Logger.Models;
using Logger.Models.Contracts;
using Logger.Models.Factories;
using System;
using System.Collections.Generic;

namespace Logger
{
    class Program
    {
        static void Main(string[] args)
        {
			//ILayout layout = new SimpleLayout();

			//IAppender appender = new ConsoleAppender(layout, Enums.ErrorLevel.INFO);

			//ILogger logger = new Logger.Models.Logger(new IAppender[] { appender });

			//IError error = new Error(DateTime.Now, Enums.ErrorLevel.CRITICAL, "Critical error!");

			//logger.Log(error);

			ILogger logger = InitiallizeLogger();
			ErrorFactory errorFactory = new ErrorFactory();
			Engine engine = new Engine(logger, errorFactory);
			engine.Run();
        }

		static ILogger InitiallizeLogger()
		{
			ICollection<IAppender> appenders = new List<IAppender>();
			LayoutFactory layoutFactor = new LayoutFactory();
			AppenderFactory appenderFactory = new AppenderFactory(layoutFactor);

			int appenderCount = int.Parse(Console.ReadLine());

			for (int i = 0; i < appenderCount; i++)
			{
				string[] inputArgs = Console.ReadLine().Split();
				string appenderType = inputArgs[0];
				string layoutType = inputArgs[1];
				string errorLevel = "INFO";

				if(inputArgs.Length == 3)
				{
					errorLevel = inputArgs[2];
				}

				IAppender appender = appenderFactory.CreateAppender(appenderType, errorLevel, layoutType);
				appenders.Add(appender);			}


			ILogger logger = new Models.Logger(appenders);
			return logger; 
		}
    }
}
