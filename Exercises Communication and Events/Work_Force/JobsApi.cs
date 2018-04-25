using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class JobsApi
{
	private List<Job> jobs;
	private List<IEmployee> employees;
	private EmployeeFactory employeeFactory;
	private JobFactory jobFactory;

	public JobsApi()
	{
		this.jobs = new List<Job>();
		this.employees = new List<IEmployee>();
		this.employeeFactory = new EmployeeFactory();
		this.jobFactory = new JobFactory();
	}

	public void AddEmployee(string[] args)
	{
		IEmployee employee = this.employeeFactory.CreateEmployee(args);
		this.employees.Add(employee);
	}

	public void AddJob(string[] args)
	{
		//Job FeedTheFishes 45 Pesho
		string employeName = args[3];
		IEmployee employee = this.employees.FirstOrDefault(e => e.Name == employeName);
		Job job = jobFactory.CreateJob(args, employee);
		this.jobs.Add(job);
		job.JobDone += this.OnJobDone;
	}

	public void PassWeek()
	{
		List<Job> jobss = new List<Job>(this.jobs);
		for (int i = 0; i < jobss.Count; i++)
		{
			jobss[i].Update();
		}
	}

	private void OnJobDone(object sender)
	{
		Console.WriteLine($"Job {((Job)sender).Name} done!");
		this.jobs.Remove((Job)sender);
	}

	public string Status()
	{
		StringBuilder sb = new StringBuilder();

		foreach (Job job in this.jobs)
		{
			sb.AppendLine($"Job: {job.Name} Hours Remaining: {job.WorkHoursRequired}");
		}

		return sb.ToString().Trim();
	}
}

