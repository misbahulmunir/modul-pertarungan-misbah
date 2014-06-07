using UnityEngine;
using System.Collections;
using System.Net;
using System.ComponentModel;
using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;

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
        private Dictionary<string, string> pathDictionary;
        private Dictionary<string, string> urlDictionary;
        private Boolean isStarted;

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

            WebServiceSingleton.GetInstance().isLoadingScreen = true;

            DownloadXMLFile("get_profile");
            DownloadXMLFile("get_player_deck");
            DownloadXMLFile("get_player_trunk");
            DownloadXMLFile("get_friend_list");
            DownloadXMLFile("get_list_avatar");
            DownloadXMLFile("get_player_avatar");
            DownloadXMLFile("get_building");
            DownloadXMLFile("get_battle_rank");
            DownloadXMLFile("get_player_ranking");
            DownloadXMLFile("get_friend_request");

            Application.LoadLevel("BeforeBattle");
        }

        void Update()
        {
            //if (!isStarted && counter > 0)
            //{
            //    isStarted = true;
                
            //}
            //if (totalDownloadedDocuments == totalDocuments)
            //{
            //    loadingText.GetComponent<UILabel>().text = "Loading Complete";
            //    Debug.Log("Total Time in Frame : " + counter);
            //    Application.LoadLevel("BeforeBattle");
            //}
            //counter++;
            //Debug.Log("counter : " + counter);
        }

        private void DownloadXMLFile(string methodName)
        {
            WebServiceSingleton.GetInstance().ProcessRequest(methodName, id);
            //Debug.Log(WebServiceSingleton.GetInstance().responseFromServer);
            if (WebServiceSingleton.GetInstance().queryInfo == "Empty Data")
            {
                totalDownloadedDocuments++;
            }

            if (WebServiceSingleton.GetInstance().queryResult > 0)
            { 
                Debug.Log(WebServiceSingleton.GetInstance().DownloadFile(methodName, id));
                totalDownloadedDocuments++;
            }
        }

        private void ProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            progress = e.ProgressPercentage;
        }

        private void Completed(object sender, AsyncCompletedEventArgs e)
        {

        }
    }
}