using System;
using System.Collections.Generic;
using System.Text;


public class Axe : Weapon
{
	public Axe(string name, Rarity rarity) 
		:base(name, rarity)
	{
		this.gems = new Gem[4];
		this.minDamage = CalculateDamage(5);
		this.maxDamage = CalculateDamage(10);
		
	}
	
}

