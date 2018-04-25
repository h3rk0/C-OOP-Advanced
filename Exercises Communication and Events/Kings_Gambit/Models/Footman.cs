using System;
using System.Collections.Generic;
using System.Text;

namespace Kings_Gambit.Models
{
	public class Footman : Subordinate
	{
		public Footman(string name) 
			:base(name, "panicking", 2)
		{
		}
	}
}
