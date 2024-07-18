using UnityEngine;
using System.Runtime.InteropServices;
using System;

public class JavaScriptTest : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void Hello();


    private System.IntPtr webSocketInstance;
    void Start()
    {
        Hello();
    }
}