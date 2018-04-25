using System;
using System.Linq;

namespace Traffic_Lights
{
    class StartUp
    {
        static void Main(string[] args)
        {
			Light[] lights = Console.ReadLine().Split().Select(Enum.Parse<Light>).ToArray();
			TrafficLight trafficLight = new TrafficLight(lights);
			int n = int.Parse(Console.ReadLine());

			for (int i = 0; i < n; i++)
			{
				Console.WriteLine(trafficLight.ChangeLights());
			}
        }
    }
}
