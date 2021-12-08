using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public static class HttpController
{
    public static IEnumerator Get(string uri)
    {
        UnityWebRequest unityWebRequest = UnityWebRequest.Get(uri);
        yield return unityWebRequest.SendWebRequest();

        CheckResult(unityWebRequest);
    }

    public static IEnumerator Post(string uri, object model)
    {
        Debug.Log(model);
        string json = JsonUtility.ToJson(model);
        Debug.Log(json);
        UnityWebRequest unityWebRequest = UnityWebRequest.Post(uri, "");
        unityWebRequest.uploadHandler = new UploadHandlerRaw(System.Text.Encoding.UTF8.GetBytes(json));
        unityWebRequest.SetRequestHeader("Content-Type", "application/json");
        yield return unityWebRequest.SendWebRequest();

        CheckResult(unityWebRequest);
    }

    public static IEnumerator Put(string uri)
    {
        byte[] data = System.Text.Encoding.UTF8.GetBytes("Test");
        UnityWebRequest unityWebRequest = UnityWebRequest.Put(uri, data);
        yield return unityWebRequest.SendWebRequest();

        CheckResult(unityWebRequest);
    }

    public static IEnumerator Delete(string uri)
    {
        UnityWebRequest unityWebRequest = UnityWebRequest.Delete(uri);
        yield return unityWebRequest.SendWebRequest();

        CheckResult(unityWebRequest);
    }

    private static void CheckResult(UnityWebRequest unityWebRequest)
    {
        if (unityWebRequest.result == UnityWebRequest.Result.ConnectionError)
        {
            Debug.Log($"Error: {unityWebRequest.error}");
        }
        else
        {
            Debug.Log($"Completed:  {unityWebRequest.downloadHandler.text}");
        }
    }
}