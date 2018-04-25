using System;
using System.Collections.Generic;
using System.Text;



public class Amethyst : Gem
{
	public Amethyst(GemType gemType) : base(gemType)
	{
		this.Strength = this.CalculateStats(2);
		this.Agility = this.CalculateStats(8);
		this.Vitality = this.CalculateStats(4);
	}
}

