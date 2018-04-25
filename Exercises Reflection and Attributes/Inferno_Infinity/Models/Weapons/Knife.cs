using System;
using System.Collections.Generic;
using System.Text;


public class Knife : Weapon
{
	public Knife(string name, Rarity rarity) 
		:base(name, rarity)
	{
		this.gems = new Gem[2];
		this.minDamage = CalculateDamage(3);
		this.maxDamage = CalculateDamage(4);
	}
}

