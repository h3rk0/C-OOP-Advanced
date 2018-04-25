using System;
using System.Collections.Generic;
using System.Text;


public class Ruby : Gem
{
	public Ruby(GemType gemType) : base(gemType)
	{
		this.Strength = this.CalculateStats(7);
		this.Agility = this.CalculateStats(2);
		this.Vitality = this.CalculateStats(5);
	}
}

