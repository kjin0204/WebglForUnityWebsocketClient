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


        //Debug.Log("Hello~ ȣ����" );
        //Hello();
        //Debug.Log("Hello~ ȣ����");


        //Uri serverUri = new Uri("ws://localhost:8080/ws"); // ���� �ּ� ����
        string url = "ws://localhost:8080/ws";
        Debug.Log(webSocketUrl);

        connectWebSocket(webSocketUrl, clientId);

        //webSocketInstance = connectWebSocket(url);

    }

    public void SendMessage(string message)
    {
        Debug.Log("��������~" + message);
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

    // JavaScript���� �޽��� ���� �� ȣ��� �޼���
    void OnMessageReceived(string message)
    {
        Debug.Log("[webgl]Received message from WebSocket: " + message);
        // �̰����� �޽��� ó�� ������ �ۼ��մϴ�.
    }

    void OnDestroy()
    {
        CloseConnection();
    }
}
