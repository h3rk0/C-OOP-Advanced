using System;
using System.Collections.Generic;
using System.Text;


public class Job : IJob
{
	public Job(string name, IEmployee employee ,int workHours)
	{
		this.Name = name;
		this.Employee = employee;
		this.WorkHoursRequired = workHours;
	}

	public IEmployee Employee { get; }

	public int WorkHoursRequired { get; private set; }

	public string Name { get; }

	public event JobDoneEventHandler JobDone;

	public void Update()
	{
		this.WorkHoursRequired -= this.Employee.WorkHours;

		if(this.WorkHoursRequired <= 0)
		{
			this.WorkHoursRequired = 0;
			this.JobDone.Invoke(this);
		}

	}
}

