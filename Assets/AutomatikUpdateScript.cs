using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class AutomatikUpdateScript : MonoBehaviour
{
    public string versionUrl = "";
    public int index;
    /*public string currentVersion;
    private string latesversion;*/
    //public GameObject newVersionAvailable;
    public static string presentVersion="0.0";
    public static string Newupdate="Something";

    void Start()
    {
        StartCoroutine(LoadTxtData(versionUrl, index));
        StartCoroutine(LoadTxtData(versionUrl, index));
    }

    private IEnumerator LoadTxtData(string url, int index)
    {
        UnityWebRequest loaded = new UnityWebRequest(url);
        loaded.downloadHandler = new DownloadHandlerBuffer();
        yield return loaded.SendWebRequest();
        if (index == 1) { 
        presentVersion = loaded.downloadHandler.text;
            }
        else
            if (index == 2)
        {
            Newupdate = loaded.downloadHandler.text;
        }
        /*latesversion = loaded.downloadHandler.text;
        CheckVersion();*/
    }

    public void CheckVersion()
    {
        /*Version versionDevice = new Version(currentVersion);
        Debug.Log(versionDevice);
        Version versionServer = new Version(latesversion);
        int result = versionDevice.CompareTo(versionServer);

        if((latesversion!="")&&(result<0))
        {
            newVersionAvailable.SetActive(true);
        }
        else
        {
            gameObject.GetComponent<LogInRegisztrelScript>().egybolbejelentkezes();
        }*/
    }

}
