using Hack.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hack
{
	public class MathClass : IMath
	{
		public MathClass()
		{
			this.Value = default(int);
		}

		public double Value { get; set; }

		public int Abs(double num)
		{
			this.Value = Math.Abs(num);
			return (int)this.Value;
		}

		public int Floor(double num)
		{
			this.Value = Math.Floor(num);
			return (int)this.Value;
		}
	}
}
