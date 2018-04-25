using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class Engine
{
	private IKing king;

	public Engine(IKing king)
	{
		this.king = king;
	}

	public void Run()
	{
		while (true)
		{
			string input = Console.ReadLine();

			if(input == "End")
			{
				break;
			}

			string[] args = input.Split();
			string command = args[0];
			
			if(command == "Attack")
			{
				king.GetAttacked();
			}
			else if (command == "Kill")
			{
				string subName = args[1];
				ISubordinate subordinate = king.Subordinates.First(s => s.Name == subName);
				subordinate.TakeDamage();
			}
		}
	}
}

