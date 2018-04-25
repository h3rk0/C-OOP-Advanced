using System;
using System.Collections.Generic;
using System.Text;

namespace DateTimeNow.Contracts
{
    public interface IDateTime
    {
		DateTime Now();

		void AddDays(DateTime date, int days);
    }
}
