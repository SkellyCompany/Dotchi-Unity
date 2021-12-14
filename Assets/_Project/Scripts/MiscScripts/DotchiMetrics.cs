using UnityEngine;

public class DotchiMetrics
{
	public float temperature;
	public float humidity;
	public float light_intensity;
	public float sound_intensity;
	public string _id;


	public string Stringify()
	{
		return JsonUtility.ToJson(this);
	}
	public static DotchiMetrics Parse(string json)
	{
		return JsonUtility.FromJson<DotchiMetrics>(json);
	}
}
