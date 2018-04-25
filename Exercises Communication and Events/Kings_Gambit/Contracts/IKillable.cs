using System;
using System.Collections.Generic;
using System.Text;


public interface IKillable
{
	

	bool IsAlive { get; }

	int HitPoints { get; }

	void TakeDamage();

	void Die();
}

