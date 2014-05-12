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
            totalDocuments = 3;
            id = GameManager.Instance().PlayerId;
            counter = 0;
            progress = 0;
        }

        // Update is called once per frame
        void Update()
        {
            if(!isStarted && counter>5)
            {
                //counter = 0;
                isStarted = true;
                DownloadXMLFile("get_profile");
                DownloadXMLFile("player_deck");
                DownloadXMLFile("player_trunk");
            }
            if (totalDownloadedDocuments == totalDocuments)
            {
                loadingText.GetComponent<UILabel>().text = "Loading Complete";
                Application.LoadLevel("BeforeBattle");
            }
            counter++;
            //if (counter % 30 == 0)
            //{
            //    loadingText.GetComponent<UILabel>().text += " .";
            //}
            //if (counter >= 150)
            //{
            //    loadingText.GetComponent<UILabel>().text = "Downloading Deck Data";
            //    counter = 0;
            //}
            //if (progress == 100 && totalDocuments == 1)
            //{
            //    loadingText.GetComponent<UILabel>().text = result;
            //    totalDocuments = 2;
            //}
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
                    string path = Application.dataPath + "/XMLFiles/" + value + ".xml";
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
            dict.Add("friend_list", "http://cws.yowanda.com/files/friends_of_");
            dict.Add("player_deck", "deck_of_" + id);
            dict.Add("player_trunk", "trunk_of_" + id);
        }
    }
}