using System;
using System.Collections.Generic;
using System.Text;


public class Emerald : Gem
{
	public Emerald(GemType gemType) : base(gemType)
	{
		this.Strength = this.CalculateStats(1);
		this.Agility = this.CalculateStats(4);
		this.Vitality = this.CalculateStats(9);
	}
}

