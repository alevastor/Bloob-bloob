using System;
using System.IO;
using System.Collections;
using UnityEngine;

public class ExceptionHandler : MonoBehaviour
{
    private string debugText = "";
    private GoogleAnalyticsV3 googleAnalytics;

    void Awake()
    {
        Application.RegisterLogCallback(HandleException);
        googleAnalytics = GameObject.FindGameObjectWithTag("GoogleAnalyticsObject").GetComponent<GoogleAnalyticsV3>();
    }

    IEnumerator SendDebugToGoogle()
    {
        googleAnalytics.LogException(new ExceptionHitBuilder().SetExceptionDescription(debugText).SetFatal(true));
        yield return googleAnalytics;
    }

    private void HandleException(string condition, string stackTrace, LogType type)
    {
        if (type == LogType.Exception)
        {
            debugText = type + ": " + condition + " Stack Trace: " + stackTrace;
            StartCoroutine(SendDebugToGoogle());
        }
    }
}