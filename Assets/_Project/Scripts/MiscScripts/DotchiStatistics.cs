using UnityEngine;

public class DotchiStatistics
{
	public float happiness;
	public float health;
	public string _id;

	public string Stringify()
	{
		return JsonUtility.ToJson(this);
	}
	public static DotchiStatistics Parse(string json)
	{
		return JsonUtility.FromJson<DotchiStatistics>(json);
	}
}
