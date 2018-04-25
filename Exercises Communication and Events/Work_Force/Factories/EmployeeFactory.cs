using System;
using System.Collections.Generic;
using System.Text;


public class EmployeeFactory
{
	public IEmployee CreateEmployee(string[] args)
	{
		string type = args[0];
		string name = args[1];
		IEmployee employee = null;
		switch (type)
		{
			case "PartTimeEmployee":
				employee = new PartTimeEmployee(name);
				break;
			case "StandardEmployee":
				employee = new StandardEmployee(name);
				break;
		}

		if(employee == null)
		{
			throw new ArgumentException();
		}

		return employee;
	}
}

