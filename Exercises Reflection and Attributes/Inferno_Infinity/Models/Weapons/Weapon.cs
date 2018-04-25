using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


[Review("Pesho",3, "Used for C# OOP Advanced Course - Enumerations and Attributes.", "Pesho", "Svetlio")]
public abstract class Weapon : INameable, IDamageable, IRareable, ISocketable, IStats
{
	// Fields
	private string name;
	protected int minDamage;
	protected Gem[] gems;
	protected int maxDamage;
	private Rarity rarity;
	protected int strength;
	protected int agility;
	protected int vitality;
	

	// Constructor
	protected Weapon(string name,Rarity rarity)
	{
		this.Name = name;
		this.Rarity = rarity;
		this.Strength = 0;
		this.Agility = 0;
		this.Vitality = 0;
	}

	// Properties
	public string Name
	{
		get
		{
			return this.name;
		}
		private set
		{
			this.name = value;
		}
	}

	public int MinDamage
	{
		get
		{
			return this.minDamage + CalculateMinBonus();
		}
		private set
		{
			this.minDamage = value;
		}
	}

	private int CalculateMinBonus()
	{
		return this.strength * 2 + this.agility * 1;

	}

	public int MaxDamage
	{
		get
		{
			return this.maxDamage + CalculateMaxBonus();
		}
		private set
		{
			this.maxDamage = value;
		}
	}

	private int CalculateMaxBonus()
	{
		return this.strength * 3 + this.agility * 4;
	}

	public Rarity Rarity
	{
		get
		{
			return this.rarity;
		}
		private set
		{
			this.rarity = value;
		}
	}

	public IReadOnlyCollection<Gem> Gems => (IReadOnlyCollection<Gem>) this.gems;

	public int Strength
	{
		get
		{
			return this.strength;
		}
		private set
		{
			this.strength = value;
		}
	}

	public int Agility
	{
		get
		{
			return this.agility ;
		}
		private set
		{
			this.agility = value;
		}
	}

	public int Vitality
	{
		get
		{
			return this.vitality ;
		}
		private set
		{
			this.vitality = value;
		}
	}

	protected virtual int CalculateDamage(int damage)
	{
		return damage * (int)this.Rarity;
	}

	public override string ToString()
	{
		return $"{this.Name}: {this.MinDamage}-{this.MaxDamage} Damage, +{this.Strength} Strength, +{this.Agility} Agility, +{this.Vitality} Vitality";
	}

	public void AddSocket(Gem gem,int socketIndex)
	{
		if(socketIndex < 0 || socketIndex > this.gems.Length - 1)
		{
			return;
		}
		if(this.gems[socketIndex]!=null)
		{
			this.RemoveSocket(socketIndex);
		}
		this.strength += gem.Strength;
		this.agility += gem.Agility;
		this.vitality += gem.Vitality;
		this.gems[socketIndex] = gem;

	}

	public void RemoveSocket(int socketIndex)
	{
		if(socketIndex<0 || socketIndex>this.Gems.Count-1)
		{
			return;
		}
		Gem gem = this.gems[socketIndex];
		this.strength -= gem.Strength;
		this.agility -= gem.Agility;
		this.vitality -= gem.Vitality;
		this.gems[socketIndex] = null;
	}
}

