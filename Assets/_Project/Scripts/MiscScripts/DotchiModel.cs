public struct DotchiModel
{
	public string dotchi_id;
	public DotchiState state;
	public DotchiStatistics statistics;
	public DotchiMetrics metrics;
	public DotchiEnvironment environment;

}

public struct DotchiEnvironment
{
	public float min_temperature;
	public float max_temperature;
	public float min_humidity;
	public float max_humidity;
	public float min_light_intensity;
	public float max_light_intensity;
	public float min_sound_intensity;
	public float max_sound_intensity;
}

public struct DotchiMetrics
{
	public float temperature;
	public float humidity;
	public float light_intensity;
	public float sound_intensity;

}

public struct DotchiState
{
	public bool alive;
}

public struct DotchiStatistics
{
	public float health;
	public float happiness;
}