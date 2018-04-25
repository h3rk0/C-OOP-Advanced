using System;
using System.Collections.Generic;
using System.Text;


public class Tuple<T1,T2,T3>
{
	private T1 first;
	private T2 second;
	private T3 third;

	public Tuple(T1 first,T2 second,T3 third)
	{
		this.first = first;
		this.second = second;
		this.third = third;
	}

	public override string ToString()
	{
		return $"{this.first.ToString()} -> {this.second.ToString()} -> {this.third.ToString()}";
	}
}

