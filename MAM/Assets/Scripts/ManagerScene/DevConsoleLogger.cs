using UnityEngine;
using System.Runtime.InteropServices;

public class DevConsoleLogger : MonoBehaviour
{
#if UNITY_STANDALONE_WIN && DEVELOPMENT_BUILD
    [DllImport("kernel32.dll")]
    private static extern bool AllocConsole();

    void Awake()
    {
        AllocConsole();  // 콘솔창 생성
        Debug.Log("Console initialized.");
    }
#endif
}