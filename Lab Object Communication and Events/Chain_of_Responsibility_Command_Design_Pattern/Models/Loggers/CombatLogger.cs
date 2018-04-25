using System;
using System.Collections.Generic;
using System.Text;
using Chain_of_Responsibility_Command_Design_Pattern;

public class CombatLogger : Logger
{
	public override void Handle(LogType type, string str)
	{
		switch (type)
		{
			case LogType.ATTACK:
				Console.WriteLine(type.ToString() + ": " + str);
				break;
			case LogType.MAGIC:
				Console.WriteLine(type.ToString() + ": " + str);
				break;
			default:
				break;
		}
	}
}

