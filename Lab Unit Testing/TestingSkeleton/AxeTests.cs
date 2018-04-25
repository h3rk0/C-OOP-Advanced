using NUnit.Framework;
using System;

namespace TestingSkeleton
{
    public class AxeTests
    {

		//(assert equals vs assert true)
		[Test]
		public void AxeLossesDurabilityAfterAttack()
		{
			Axe axe = new Axe(10, 10);
			Dummy dummy = new Dummy(10, 10);
			axe.Attack(dummy);

			Assert.That(axe.DurabilityPoints, Is.EqualTo(9), "Axe Durability doesn't change after attack.");
		}

		[Test]
		public void AttackingWithBrokenWeapon()
		{
			Axe axe = new Axe(5, 0);

			Dummy dummy = new Dummy(10, 10);
			axe.Attack(dummy);
			Assert.That(dummy.Health, Is.EqualTo(5));
		}
    }
}
