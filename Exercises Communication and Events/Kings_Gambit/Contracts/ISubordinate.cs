
public delegate void DeathEventHandler(object sender);

public interface ISubordinate : INameable , IKillable
{
	event DeathEventHandler Death;

	string Action { get; }

	void ReactToAttack();
}
