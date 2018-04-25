using System;
using System.Collections.Generic;
using System.Text;

namespace Kings_Gambit.Contracts
{
    public interface IBoss
    {
		IReadOnlyCollection<ISubordinate> Subordinates { get; }

		void AddSubordinate(ISubordinate subordinate);

		void OnSubordinateDeath(object sender);
    }
}
