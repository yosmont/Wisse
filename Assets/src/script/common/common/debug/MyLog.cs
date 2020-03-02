

using UnityEngine;
using System.Collections;

public class MyLog : MonoBehaviour
{
    string _myLog;
    Queue _myLogQueue = new Queue();
    GUIStyle _style = new GUIStyle();

    void Start()
    {
        _style.normal.textColor = Color.black;
        Debug.Log("Log1");
        Debug.Log("Log2");
        Debug.Log("Log3");
        Debug.Log("Log4");
    }

    void OnEnable()
    {
        Application.logMessageReceived += HandleLog;
    }

    void OnDisable()
    {
        Application.logMessageReceived -= HandleLog;
    }

    void HandleLog(string logString, string stackTrace, LogType type)
    {
        _myLog = logString;
        string newString = "\n [" + type + "] : " + _myLog;
        _myLogQueue.Enqueue(newString);
        if (type == LogType.Exception) {
            newString = "\n" + stackTrace;
            _myLogQueue.Enqueue(newString);
        }
        _myLog = string.Empty;
        foreach (string mylog in _myLogQueue) {
            _myLog += mylog;
        }
    }

    void OnGUI()
    {
        if (Debug.isDebugBuild)
            GUILayout.Label(_myLog, _style);
    }
}