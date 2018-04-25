using Hack;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace HackTests
{
    public class HackClassTests
    {
		[Test]
		[TestCase(-124.35)]
		[TestCase(24.643)]
		public void TestAbsMethodWorks(double num)
		{
			Mock<MathClass> math = new Mock<MathClass>();

			int expected = math.Object.Abs(num);
			Assert.That(math.Object.Abs(num), Is.EqualTo(Math.Abs(num)));
		}
    }
}
