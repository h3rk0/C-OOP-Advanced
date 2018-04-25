namespace _03BarracksFactory.Core.Factories
{
    using System;
	using System.Linq;
	using System.Reflection;
	using Contracts;

    public class UnitFactory : IUnitFactory
    {
        public IUnit CreateUnit(string unitType)
        {
			//TODO: implement for Problem 3
			Assembly assembly = Assembly.GetExecutingAssembly();
			Type type = assembly.GetTypes().FirstOrDefault(t => t.Name == unitType);

			if(type == null)
			{
				throw new ArgumentException($"Invalid Unit Type!");
			}

			if (!typeof(IUnit).IsAssignableFrom(type))
			{
				throw new ArgumentException($"{type} type is Not a Unit Type!");
			}

			IUnit unit = (IUnit)Activator.CreateInstance(type);
			return unit;
		}
    }
}
