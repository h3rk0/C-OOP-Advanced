using System;
using System.Collections.Generic;
using System.Text;


public class WeaponFactory
{
	//Create;Common Axe;Axe of Misfortune
	public Weapon CreateWeapon(string[] inputArgs)
	{
		string weaponType = inputArgs[1];
		string name = inputArgs[2];
		string[] weaponArgs = weaponType.Split();
		bool isValid = Enum.TryParse<Rarity>(weaponArgs[0], out Rarity rarity);

		//if(!isValid)
		//{
		//	throw new ArgumentException("Invalid weapon Type!");
		//}

		Weapon weapon = null;

		switch (weaponArgs[1])
		{
			case "Axe":
				weapon = new Axe(name, rarity);
				break;
			case "Sword":
				weapon = new Sword(name, rarity);
				break;
			case "Knife":
				weapon = new Knife(name, rarity);
				break;
		}

		return weapon;
	}
}

