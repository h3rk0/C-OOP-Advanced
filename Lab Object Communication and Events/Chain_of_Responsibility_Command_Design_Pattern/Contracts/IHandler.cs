using Chain_of_Responsibility_Command_Design_Pattern;
using System;
using System.Collections.Generic;
using System.Text;


public interface IHandler
{
	void Handle(LogType type, string str);
	void SetSuccessor(IHandler handler);
}

