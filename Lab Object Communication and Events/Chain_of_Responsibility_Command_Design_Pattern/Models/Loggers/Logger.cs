using System;
using System.Collections.Generic;
using System.Text;
using Chain_of_Responsibility_Command_Design_Pattern;

public abstract class Logger : IHandler
{
	private IHandler successor;

	public abstract void Handle(LogType type, string str);

	protected void PassToSuccessor(LogType type,string message)
	{
		if(this.successor != null)
		{
			this.successor.Handle(type, message);
		}
	}

	public void SetSuccessor(IHandler handler)
	{
		this.successor = handler;
	}
}

