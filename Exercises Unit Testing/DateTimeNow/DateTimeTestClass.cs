using DateTimeNow.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace DateTimeNow
{
	public class DateTimeTestClass : IDateTime
	{
		public void AddDays(DateTime date, int days)
		{
			date.AddDays(days);
		}

		public DateTime Now()
		{
			return DateTime.Now;
		}
	}
}
