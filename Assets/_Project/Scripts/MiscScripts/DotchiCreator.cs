using UnityEngine;

public static class DotchiCreator
{
	public static DotchiModel Create()
	{
		DotchiMetrics dotchiMetrics = new DotchiMetrics() { temperature = 0, humidity = 0, light_intensity = 0, sound_intensity = 0};
		DotchiState dotchiState = new DotchiState() { alive = true };
		DotchiStatistics dotchiStatistics = new DotchiStatistics() { happiness = 100, health = 100 };
		DotchiEnvironment dotchiEnvironment = GenerateDotchiEnvironment();

		DotchiModel dotchiModel = new DotchiModel() { dotchi_id = "HARDCODED", metrics = dotchiMetrics, environment = dotchiEnvironment,
			state = dotchiState, statistics = dotchiStatistics };
		return dotchiModel;
	}

	private static DotchiEnvironment GenerateDotchiEnvironment()
	{
		DotchiEnvironment dotchiEnvironment = new DotchiEnvironment();
		dotchiEnvironment.min_temperature = Random.Range(0, 10);
		dotchiEnvironment.max_temperature = Random.Range(50, 60);

		dotchiEnvironment.min_humidity = Random.Range(0, 10);
		dotchiEnvironment.max_humidity = Random.Range(50, 60);

		dotchiEnvironment.min_sound_intensity = Random.Range(0, 10);
		dotchiEnvironment.max_sound_intensity = Random.Range(50, 60);

		dotchiEnvironment.min_light_intensity = Random.Range(0, 10);
		dotchiEnvironment.max_light_intensity = Random.Range(50, 60);

		return dotchiEnvironment;
	}
}
