using UnityEngine;
using System.Collections;
using System.Net;
using System.ComponentModel;
using System;

public class DownloadFile : MonoBehaviour {

    int progress;
	// Use this for initialization
	void Start () {
        progress = 0;
        DownloadXMLFile();
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log("Loading : " + progress + "% complete");
	}

    private void DownloadXMLFile()
    {
      string path = Application.dataPath + "/myfile.xml";
      WebClient webClient = new WebClient();
      webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
      webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);
      webClient.DownloadFileAsync(new Uri("http://cws.yowanda.com/files/player_profile_agil.xml"), path);
    }

    private void ProgressChanged(object sender, DownloadProgressChangedEventArgs e)
    {
      progress = e.ProgressPercentage;
    }

    private void Completed(object sender, AsyncCompletedEventArgs e)
    {
      
    }

}
