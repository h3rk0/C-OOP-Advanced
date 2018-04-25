using DateTimeNow.Contracts;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace DateTime_Tests
{
    public class DateTimeTests
    {
		[Test]
		public void AddDayToTheMiddleOfTheMonthWorks()
		{
			Mock<IDateTime> date = new Mock<IDateTime>();
			date.Setup(p => p.Now()).Returns(DateTime.Now);
			// ?????????
			date.Object.Now().AddDays(2);
		}
    }
}
