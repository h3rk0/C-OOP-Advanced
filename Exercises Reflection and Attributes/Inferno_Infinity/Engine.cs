using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class Engine : IRunnable
{
	private List<Weapon> weaponRepository;
	private WeaponFactory weaponFactory;
	private GemFactory gemFactory;

	public Engine()
	{
		this.weaponRepository = new List<Weapon>();
		this.weaponFactory = new WeaponFactory();
		this.gemFactory = new GemFactory();
	}

	public void Run()
	{
		while (true)
		{
			string input = Console.ReadLine();

			if(input == "END")
			{
				break;
			}

			string[] inputArgs = input.Split(';');
			string command = inputArgs[0];

			Weapon weapon = null;
			string name;
			int socketIndex;

			switch (command)
			{
				case "Create":
					weapon = this.weaponFactory.CreateWeapon(inputArgs);
					this.weaponRepository.Add(weapon);
					break;
				case "Add":
					name = inputArgs[1];
					socketIndex = int.Parse(inputArgs[2]);
					Gem gem = gemFactory.CreateGem(inputArgs);
					weapon = this.weaponRepository.FirstOrDefault(w => w.Name == name);
					weapon.AddSocket(gem,socketIndex);
					break;
				case "Remove":
					name = inputArgs[1];
					socketIndex = int.Parse(inputArgs[2]);
					weapon = this.weaponRepository.FirstOrDefault(w => w.Name == name);
					weapon.RemoveSocket(socketIndex);
					break;
				case "Print":
					name = inputArgs[1];
					weapon = this.weaponRepository.FirstOrDefault(w => w.Name == name);
					Console.WriteLine(weapon);
					break;
				case "Author":
					string author = GetClassAuthor();
					Console.WriteLine(author);
					break;
				case "Revision":
					string revision = GetClassRevision();
					Console.WriteLine(revision);
					break;
				case "Description":
					string description = GetClassDescription();
					Console.WriteLine(description);
					break;
				case "Reviewers":
					string reviewers = GetClassReviewers();
					Console.WriteLine(reviewers);
					break;
			}
		}
	}

	private string GetClassReviewers()
	{
		ReviewAttribute attribute = GetAttribute();
		return $"Reviewers: {string.Join(", ",attribute.Reviewers)}";
	}

	private string GetClassDescription()
	{
		ReviewAttribute attribute = GetAttribute();
		return $"Description: {attribute.Description}";
	}

	private string GetClassRevision()
	{
		ReviewAttribute attribute = GetAttribute();
		return $"Revision: {attribute.Revision}";
	}

	private string GetClassAuthor()
	{
		ReviewAttribute attribute = GetAttribute();
		return $"Author: {attribute.Author}";
	}

	private ReviewAttribute GetAttribute()
	{
		Type type = typeof(Weapon);
		var attributes = type.GetCustomAttributes(false);
		return (ReviewAttribute)attributes.First();
	}
}

