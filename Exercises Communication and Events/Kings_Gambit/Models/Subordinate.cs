using System;
using System.Collections.Generic;
using System.Text;


public abstract class Subordinate : ISubordinate
{
	public Subordinate(string name,string action,int hitPoints)
	{
		this.Name = name;
		this.Action = action;
		this.HitPoints = hitPoints;


		this.IsAlive = true;
	}

	public string Name { get; }
	public string Action { get; }
	public bool IsAlive { get; private set; }

	public int HitPoints { get; private set; }

	public event DeathEventHandler Death;

	public void Die()
	{
		this.IsAlive = false;
		if(this.Death != null)
		{
			this.Death.Invoke(this);
		}
		
	}

	public virtual void ReactToAttack()
	{
		if(this.IsAlive==true)
		{
			Console.WriteLine($"{this.GetType().Name} {this.Name} is {this.Action}!");
		}
	}

	public void TakeDamage()
	{
		this.HitPoints--;
		if(this.HitPoints <= 0)
		{
			this.Die();
		}
	}
}

