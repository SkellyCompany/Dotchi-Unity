using Socket.Quobject.SocketIoClientDotNet.Client;
using UnityEngine;

public class WebSocketController : MonoBehaviour
{
	[SerializeField] private Dotchi _dotchi = default;
	[SerializeField] private WorldStats _worldStats = default;
	private QSocket _socket;
	private object _statisticsObject;
	private object _metricsObject;
	private bool _updateStatistics;
	private bool _updateMetrics;


	public string DotchiId { get; private set; }

	void Start()
	{
		_socket = IO.Socket("https://dotchiapi.herokuapp.com");

		_socket.On(QSocket.EVENT_CONNECT, () => {
			Debug.Log("WebSocket Connected");
		});
	}

	public void StartListening(string dotchiId)
	{
		DotchiId = dotchiId;

		_socket.On($"updatedStatistics/{DotchiId}", data => {
			Debug.Log("WebSocket updated statistics");
			_statisticsObject = data;
			_updateStatistics = true;
		});

		_socket.On($"updatedMetrics/{DotchiId}", data => {
			Debug.Log("WebSocket updated metrics");
			_metricsObject = data;
			_updateMetrics = true;
		});
	}

	void Update()
	{
		if (_updateStatistics)
		{
			DotchiStatistics dotchiStatistics = DotchiStatistics.Parse(_statisticsObject.ToString());
			_dotchi.SetHappiness(dotchiStatistics.happiness);
			_dotchi.SetHealth(dotchiStatistics.health);
			_updateStatistics = false;
		}
		if (_updateMetrics)
		{
			DotchiMetrics dotchiMetrics = DotchiMetrics.Parse(_metricsObject.ToString());
			_worldStats.SetLight(dotchiMetrics.light_intensity);
			_worldStats.SetTemperature(dotchiMetrics.temperature);
			_worldStats.SetHumidity(dotchiMetrics.humidity);
			_worldStats.SetSound(dotchiMetrics.sound_intensity);
			_updateMetrics = false;
		}
	}

	void OnDestroy()
	{
		_socket.Disconnect();
	}
}
