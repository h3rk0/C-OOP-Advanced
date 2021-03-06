﻿using System;
using System.Collections.Generic;
using System.Text;


public class Box<T>
{
	public T Value { get; }

	public Box(T value)
	{
		this.Value = value;
	}

	public override string ToString()
	{
		return $"{this.Value.GetType().FullName}: {this.Value}";
	}
}

