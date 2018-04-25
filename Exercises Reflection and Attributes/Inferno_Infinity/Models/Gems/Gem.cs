public abstract class Gem : IStats, IGemRareable
{
	protected Gem(GemType gemType)
	{
		this.GemType = gemType;
	}

	public int Strength {get; protected set;}

	public int Agility { get; protected set; }

	public int Vitality { get; protected set; }

	public GemType GemType { get; protected set; }

	protected int CalculateStats(int stats)
	{
		return (int)this.GemType + stats;
	}

}