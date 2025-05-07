#if UNITY_EDITOR
using System;
using UnityEngine;
using UnityEngine.Networking;

public class GoogleSheetLoader
{
    private const string URL = "https://docs.google.com/spreadsheets/d/";
    private const string SHEET_FORMAT = "/export?format=tsv&gid=";

    public void LoadSheet(string sheetID, string sheetNum, Action<string> callbackTSV)
    {
        if (callbackTSV == null)
        {
            Debug.Log("callback 없음");
            return;
        }

        UnityWebRequest request = UnityWebRequest.Get(
            URL + sheetID + SHEET_FORMAT + sheetNum);
        UnityWebRequestAsyncOperation op = request.SendWebRequest();
        op.completed += (aop) => OnCompletedLoadSheet(request, callbackTSV);
    }

    private void OnCompletedLoadSheet(UnityWebRequest request, Action<string> callbackTSV)
    {
        string data1 = request.downloadHandler.text;

        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError(request.error);
            return;
        }
        
        data1 = data1.Replace("\r", "");
        callbackTSV(data1);
    }
}
#endif