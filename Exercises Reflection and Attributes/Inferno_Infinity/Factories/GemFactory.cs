using System;
using System.Collections.Generic;
using System.Text;


public class GemFactory
{
	public Gem CreateGem(string[] inputArgs)
	{
		string gemInput = inputArgs[3];
		string[] gemArgs = gemInput.Split();
		bool isTypeValid = Enum.TryParse<GemType>(gemArgs[0], out GemType gemType);
		string gemName = gemArgs[1];
		//if(!isTypeValid)
		//{
		//	throw new ArgumentException($"Gem type is not Valid!");
		//}

		Gem gem = null;

		switch (gemName)
		{
			case "Ruby":
				gem = new Ruby(gemType);
				break;
			case "Amethyst":
				gem = new Amethyst(gemType);
				break;
			case "Emerald":
				gem = new Emerald(gemType);
				break;
		}

		return gem;
	}
}

