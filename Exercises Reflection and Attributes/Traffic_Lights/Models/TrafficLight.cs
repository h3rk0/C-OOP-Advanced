using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class TrafficLight
{
	private List<Light> lights;

	public TrafficLight(Light[] lights)
	{
		this.lights = new List<Light>(lights);
	}

	public string ChangeLights()
	{
		StringBuilder sb = new StringBuilder();
		this.lights = RotateLights();
		foreach (Light light in this.lights)
		{
			sb.Append($"{light.ToString()} ");
		}

		return sb.ToString();
	}

	private List<Light> RotateLights()
	{
		for (int lightIndex = 0; lightIndex < this.lights.Count; lightIndex++)
		{
			int enumIndex = (int)this.lights[lightIndex];

			enumIndex++;
			if(enumIndex > 2)
			{
				enumIndex = 0;
			}

			Light light = (Light)enumIndex;
			this.lights[lightIndex] = light;
		}
		return this.lights;
	}
}

