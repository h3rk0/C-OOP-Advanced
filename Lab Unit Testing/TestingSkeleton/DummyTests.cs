using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestingSkeleton
{
    public class DummyTests
    {
		[Test]
		public void DummyLossesHealthAfterAttack()
		{
			Axe axe = new Axe(5, 10);
			Dummy dummy = new Dummy(10, 10);

			axe.Attack(dummy);

			Assert.That(dummy.Health, Is.EqualTo(5));
		}

		[Test]
		public void DeadDummyThrowsExceptionIfAttacked()
		{
			Axe axe = new Axe(5, 10);
			Dummy dummy = new Dummy(0, 10);

			axe.Attack(dummy);
			

		}

		[Test]
		public void DeadDummyGivesExp()
		{
			Dummy dummy = new Dummy(10, 10);
			Axe axe = new Axe(10, 10);
			while(!dummy.IsDead())
			{
				dummy.TakeAttack(axe.AttackPoints);

			}

			var exp = dummy.GiveExperience();

			Assert.That(exp, Is.EqualTo(10));
		}

		[Test]
		public void AliveDummyDoesntGiveExp()
		{
			Dummy dummy = new Dummy(10, 10);
			Axe axe = new Axe(5, 10);

			dummy.TakeAttack(axe.AttackPoints);

			var exp = dummy.GiveExperience();

			Assert.That(exp, Is.EqualTo(0));
		}
    }
}
