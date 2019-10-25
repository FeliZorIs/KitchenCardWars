using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class DBTry : MonoBehaviour
{
    /*
    void Start()
    {
        StartCoroutine(GetText());
    }

    IEnumerator GetText()
    {
        using (UnityWebRequest request = UnityWebRequest.Get("http://unity3d.com/"))
        {
            yield return request.Send();

            if (request.isNetworkError) // Error
            {
                Debug.Log(request.error);
            }
            else // Success
            {
                Debug.Log(request.downloadHandler.text);
            }
        }
    }
    */
    void Start()
    {
        //A correct website page.
        StartCoroutine(GetRequest("https://unity3d.com/"));

        //A non-existing page.
        //StartCoroutine(GetRequest("https://error.html"));
    }

    IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            //Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            string[] pages = uri.Split('/');
            int page = pages.Length - 1;

            string[] info;

            if (webRequest.isNetworkError)
            {
                Debug.Log(pages[page] + ": Error: " + webRequest.error);
            }
            else
            {
                //Here is where we mess with the info
                Debug.Log(pages[page] + ":\nReceived: " + webRequest.downloadHandler.text);
                info = webRequest.downloadHandler.text.Split('<');
                for (int i = 0; i < info.Length - 1; i++)
                {
                    
                    if(info[i].Contains("Google"))
                    {
                        Debug.Log(info[i]);
                    }
                }
            }
        }
    }
}