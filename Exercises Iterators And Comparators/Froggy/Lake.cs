using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;


public class Lake : IEnumerable<int>
{
	private List<int> stones;

	public Lake(int[] stones)
	{
		this.stones = new List<int>(stones);
	}

	public void Print()
	{
		List<int> result = new List<int>();
		foreach (var item in this)
		{
			result.Add(item);
		}
		Console.WriteLine(string.Join(", ", result));
	}

	public IEnumerator<int> GetEnumerator()
	{
		for (int stoneIndex = 0; stoneIndex < this.stones.Count; stoneIndex++)
		{
			if(stoneIndex % 2 == 0)
			{
				yield return this.stones[stoneIndex];
			}
		}

		for (int stoneIndex = this.stones.Count - 1; stoneIndex >= 0; stoneIndex--)
		{
			if (stoneIndex % 2 != 0)
			{
				yield return this.stones[stoneIndex];
			}
		}
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		for (int stoneIndex = 0; stoneIndex < this.stones.Count; stoneIndex++)
		{
			if (stoneIndex % 2 != 0)
			{
				yield return this.stones[stoneIndex];
			}
		}

		for (int stoneIndex = this.stones.Count - 1; stoneIndex >= 0; stoneIndex--)
		{
			if (stoneIndex % 2 == 0)
			{
				yield return this.stones[stoneIndex];
			}
		}
	}
}

