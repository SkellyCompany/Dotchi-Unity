using Socket.Quobject.SocketIoClientDotNet.Client;
using UnityEngine;

public class WebSocketController : MonoBehaviour
{
	[SerializeField] private Dotchi _dotchi = default;
	private QSocket _socket;
	private object _object;
	private bool _update;


	void Start()
	{
		_socket = IO.Socket("https://dotchiapi.herokuapp.com");

		_socket.On(QSocket.EVENT_CONNECT, () => {
			Debug.Log("WebSocket Connected");
		});

		_socket.On("updatedStatistics/C4:5B:BE:8C:60:F0", data => {
			_object = data;
			_update = true;
		});
	}

	void Update()
	{
		if (_update)
		{
			DotchiStatistics dotchiStatistics = DotchiStatistics.Parse(_object.ToString());
			_dotchi.SetHappiness(dotchiStatistics.happiness);
			_dotchi.SetHealth(dotchiStatistics.health);
			_update = false;
		}
	}

	void OnDestroy()
	{
		_socket.Disconnect();
	}
}
