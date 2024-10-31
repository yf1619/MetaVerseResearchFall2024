using UnityEngine;
using NativeWebSocket;
//This file is sepcific to AI-backend connection.
//The connection command must be: python server.py --port 8080
//This file is created to maintain the connection with the server and to receive the messages from the server.
public class WebSocketConnection : MonoBehaviour {
    WebSocket websocket;

    async void Start() {
        websocket = new WebSocket("ws://localhost:8080");
        websocket.OnMessage += (bytes) => {
            Debug.Log("Received: " + System.Text.Encoding.UTF8.GetString(bytes));
        };
        await websocket.Connect();
    }

    void Update() {
        #if !UNITY_WEBGL || UNITY_EDITOR
        websocket?.DispatchMessageQueue();
        #endif
    }

    private async void OnApplicationQuit() {
        await websocket.Close();
    }
}
