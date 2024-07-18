using UnityEngine;
using System.Runtime.InteropServices;
using System;

public class WebSocketManager : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void connectWebSocket(string url, string clientId);

    [DllImport("__Internal")]
    private static extern void sendWebSocketMessage(System.IntPtr socket, string message);

    [DllImport("__Internal")]
    private static extern void closeWebSocket(System.IntPtr socket);

    [DllImport("__Internal")]
    private static extern void Hello();

    [DllImport("__Internal")]
    private static extern void HelloString(string str);

    [DllImport("__Internal")]
    private static extern void PrintFloatArray(float[] array, int size);

    [DllImport("__Internal")]
    private static extern int AddNumbers(int x, int y);

    [DllImport("__Internal")]
    private static extern string StringReturnValueFunction();

    [DllImport("__Internal")]
    private static extern void BindWebGLTexture(int texture);


    private string webSocketUrl = "ws://localhost:8080/ws";
    private string clientId = "your_client_id";


    private System.IntPtr webSocketInstance;
    void Start()
    {


        //Debug.Log("Hello~ 호출전" );
        //Hello();
        //Debug.Log("Hello~ 호출후");


        //Uri serverUri = new Uri("ws://localhost:8080/ws"); // 서버 주소 설정
        string url = "ws://localhost:8080/ws";
        Debug.Log(webSocketUrl);

        connectWebSocket(webSocketUrl, clientId);

        //webSocketInstance = connectWebSocket(url);

    }

    public void SendMessage(string message)
    {
        Debug.Log("눌렸을껄~" + message);
            sendWebSocketMessage(webSocketInstance, message);
        if (webSocketInstance != System.IntPtr.Zero)
        {
        }
    }

    public void CloseConnection()
    {
        if (webSocketInstance != System.IntPtr.Zero)
        {
            closeWebSocket(webSocketInstance);
            webSocketInstance = System.IntPtr.Zero;
        }
    }

    // JavaScript에서 메시지 수신 시 호출될 메서드
    void OnMessageReceived(string message)
    {
        Debug.Log("[webgl]Received message from WebSocket: " + message);
        // 이곳에서 메시지 처리 로직을 작성합니다.
    }

    void OnDestroy()
    {
        CloseConnection();
    }
}
