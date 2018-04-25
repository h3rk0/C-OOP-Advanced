using System;

namespace Inferno_Infinity
{
    class StartUp
    {
        static void Main(string[] args)
        {
			//Rarity rarity = Rarity.Uncommon;
			//Weapon weapon = new Knife("Test", rarity);
			//;
			//GemType type = GemType.Flawles;
			//Gem gem = new Ruby(type);
			//Console.WriteLine(weapon);
			//weapon.AddSocket(gem,0);
			//Console.WriteLine(weapon);

			Engine engine = new Engine();
			engine.Run();
        }
    }
}
