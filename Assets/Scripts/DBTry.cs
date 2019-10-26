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

    /*
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
    */

    public Text messageText;
    public Text currentUploadInfo;
    public Text valueText;
    
    readonly string getURL = "http://localhost/Get.php"; //add the php get file to the end of this
    readonly string postURL = "http://localhost/Post.php"; //add the php post file to the end of this

    void Start()
    {
        messageText.text = "Start";
    }

    public void ButtonUpload()
    {
        StartCoroutine(GetRequest());
    }

    IEnumerator GetRequest()
    {
        UnityWebRequest www = UnityWebRequest.Get(getURL);
        yield return www.SendWebRequest();

        if(www.isNetworkError || www.isHttpError)
        {
            Debug.LogError(www.error);
        }
        else
        {
            messageText.text = www.downloadHandler.text;
        }
    }

    IEnumerator PostRequest(string curUpload, int value)
    {
        List<IMultipartFormSection> wwwForm = new List<IMultipartFormSection>();
        //curUpload has to be the name of card or value, case matters
        wwwForm.Add(new MultipartFormDataSection("cur"+curUpload, value.ToString()));
        UnityWebRequest www = UnityWebRequest.Post(postURL, wwwForm);
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.LogError(www.error);
        }
        else
        {
            messageText.text = www.downloadHandler.text;
        }
    }

    public void OnButtonSend()
    {
        if(currentUploadInfo.text == string.Empty)
        {
            messageText.text = "Empty";
        }
        else
        {
            messageText.text = "Sending";
            //this is to manually send the updated info
            StartCoroutine(PostRequest(currentUploadInfo.text, int.Parse(valueText.text)));
        }
    }
    
}