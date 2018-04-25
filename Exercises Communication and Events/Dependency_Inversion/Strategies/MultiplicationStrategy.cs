﻿using P03_DependencyInversion;
using System;
using System.Collections.Generic;
using System.Text;


public class MultiplicationStrategy : ICalculateStrategy
{
	public int Calculate(int firstOperand, int secondOperand)
	{
		return firstOperand * secondOperand;
	}
}

