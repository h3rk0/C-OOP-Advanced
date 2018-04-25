using System;
using System.Collections.Generic;
using System.Text;


public class JobFactory
{
	public Job CreateJob(string[] args,IEmployee employee)
	{
		//nameOfJob hoursOfWorkRequired employeeName
		string jobName = args[1];
		int worksHours = int.Parse(args[2]);

		Job job = new Job(jobName, employee, worksHours);

		return job;
	}
}

