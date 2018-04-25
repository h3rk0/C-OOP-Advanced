using System;

namespace Chain_of_Responsibility_Command_Design_Pattern
{
    class Program
    {
        static void Main(string[] args)
        {
			CombatLogger logger = new CombatLogger();
			logger.Handle(LogType.ATTACK, "wats up");
        }
    }
}
