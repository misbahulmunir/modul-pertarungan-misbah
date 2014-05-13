using UnityEngine;
using System.Collections;
using System.Net;
using System.ComponentModel;
using System;
using System.Collections.Generic;

namespace ModulPertarungan
{
    public class DownloadFile : MonoBehaviour
    {
        private int totalDownloadedDocuments;
        private int progress;
        private string id;
        public GameObject loadingText;
        private int counter;
        private int totalDocuments;
        private string result;
        private Dictionary<string, string> dict;
        private Boolean isStarted;
        // Use this for initialization
        void Start()
        {
            isStarted = false;
            totalDownloadedDocuments = 0;
            result = "";
            loadingText.GetComponent<UILabel>().text = "Loading";
            totalDocuments = 5;
            id = GameManager.Instance().PlayerId;
            counter = 0;
            progress = 0;
        }

        // Update is called once per frame
        void Update()
        {
            if(!isStarted && counter>5)
            {
                //Application.LoadLevel("BeforeBattle");
                isStarted = true;
                DownloadXMLFile("get_profile");
                DownloadXMLFile("player_deck");
                DownloadXMLFile("player_trunk");
                DownloadXMLFile("friend_list");
                DownloadXMLFile("get_party_member");
            }
            if (totalDownloadedDocuments == totalDocuments)
            {
                loadingText.GetComponent<UILabel>().text = "Loading Complete";
                Application.LoadLevel("BeforeBattle");
            }
            counter++;
        }

        private void DownloadXMLFile(string fileName)
        {
            string value = "";
            if (dict == null) InitDictionary();
            if (dict != null) dict.TryGetValue(fileName, out value);

            WebServiceSingleton.GetInstance().processRequest(fileName + "|" + id);
            if (WebServiceSingleton.GetInstance().responseFromServer == "OK")
            {
                try
                {
                    string path = Application.persistentDataPath + "/" + value + ".xml";
                    WebClient webClient = new WebClient();
                    webClient.DownloadFile(new Uri("http://cws.yowanda.com/files/" + value + ".xml"), path);
                    progress = 100;
                    result = "Loading Complete";
                    totalDownloadedDocuments++;
                }
                catch
                {
                    result = "Download Failed";
                }
            }
            else
            {
                result = "Unable to connect to CWS server";
            }
            Debug.Log(result);
        }

        private void ProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            progress = e.ProgressPercentage;
        }

        private void Completed(object sender, AsyncCompletedEventArgs e)
        {

        }

        private void InitDictionary()
        {
            dict = new Dictionary<string, string>();
            dict.Add("get_profile", "player_profile_" + id);
            dict.Add("friend_list", "friends_of_" + id);
            dict.Add("player_deck", "deck_of_" + id);
            dict.Add("player_trunk", "trunk_of_" + id);
            dict.Add("get_party_member", "party_of_" + id);
        }
    }
}