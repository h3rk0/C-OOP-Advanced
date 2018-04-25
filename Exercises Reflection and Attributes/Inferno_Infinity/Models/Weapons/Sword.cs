using System;
using System.Collections.Generic;
using System.Text;


public class Sword : Weapon
{
	public Sword(string name, Rarity rarity) 
		:base(name, rarity)
	{
		this.gems = new Gem[3];
		this.minDamage = CalculateDamage(4);
		this.maxDamage = CalculateDamage(6);
	}
}

