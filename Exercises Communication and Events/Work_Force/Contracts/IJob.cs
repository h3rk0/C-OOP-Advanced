using System;
using System.Collections.Generic;
using System.Text;

public delegate void JobDoneEventHandler(object sender);
public interface IJob : INameable
{
	event JobDoneEventHandler JobDone;

	IEmployee Employee { get; }

	int WorkHoursRequired { get; }

	void Update();
}

