using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public static class HttpController
{
    private static readonly string _url = "https://dotchiapi.herokuapp.com";


    public static IEnumerator Get(string uri, Action<DotchiModel> action)
    {
        UnityWebRequest unityWebRequest = UnityWebRequest.Get(uri);
        yield return unityWebRequest.SendWebRequest();
        CheckResult(unityWebRequest);
        action(JsonUtility.FromJson<DotchiModel>(unityWebRequest.downloadHandler.text));
        yield return action;
    }

    public static IEnumerator Post(string uri, object model)
    {
        UnityWebRequest unityWebRequest = UnityWebRequest.Post(uri, "");
        if (model != null)
        {
            string json = JsonUtility.ToJson(model);
            unityWebRequest.uploadHandler = new UploadHandlerRaw(System.Text.Encoding.UTF8.GetBytes(json));
            unityWebRequest.SetRequestHeader("Content-Type", "application/json");
        }
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
            Debug.Log($"Http Error");
        }
        else
        {
            Debug.Log($"Http Completed");
        }
    }
}
