using System.Collections;
using System.Collections.Generic;
using Socket.Quobject.SocketIoClientDotNet.Client;
using UnityEngine;

public class TestObject : MonoBehaviour {
  private QSocket socket;

  void Start () {
    Debug.Log ("start");
    socket = IO.Socket ("https://dotchiapi.herokuapp.com");

    socket.On (QSocket.EVENT_CONNECT, () => {
      Debug.Log ("Connected");
      socket.Emit ("chat", "test");
    });

    socket.On ("updatedStatistics/C4:5B:BE:8C:60:F0", data => {
      Debug.Log ("data : " + data);
    });
  }

  private void OnDestroy () {
    socket.Disconnect ();
  }
}