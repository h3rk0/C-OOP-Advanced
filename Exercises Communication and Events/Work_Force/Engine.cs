using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class Engine
{
	private JobsApi api;

	public Engine(JobsApi api)
	{
		this.api = api;
	}

	public void Run()
	{


		while (true)
		{
			// reading commands
			string input = Console.ReadLine();
			if(input == "End")
			{
				break;
			}

			string[] inputArgs = input
				.Split()
				.ToArray();

			string command = inputArgs[0];

			switch (command)
			{
				case "Job":
					this.api.AddJob(inputArgs);
					break;
				case "StandardEmployee":
					this.api.AddEmployee(inputArgs);
					break;
				case "PartTimeEmployee":
					this.api.AddEmployee(inputArgs);
					break;
				case "Pass":
					this.api.PassWeek();
					break;
				case "Status":
					Console.WriteLine(this.api.Status());
					break;

			}
		}
	}
}

