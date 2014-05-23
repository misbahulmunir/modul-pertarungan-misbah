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

            DownloadXMLFile("get_profile");
            DownloadXMLFile("get_player_deck");
            DownloadXMLFile("get_player_trunk");
            DownloadXMLFile("get_friend_list");
            DownloadXMLFile("get_list_avatar");
            DownloadXMLFile("get_player_avatar");
            DownloadXMLFile("get_building");
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
            Debug.Log(WebServiceSingleton.GetInstance().responseFromServer);
            if (WebServiceSingleton.GetInstance().queryInfo == "Empty Data")
            {
                totalDownloadedDocuments++;
            }

            if (WebServiceSingleton.GetInstance().queryResult > 0)
            { 
                Debug.Log(WebServiceSingleton.GetInstance().DownloadFile(methodName, id));
                totalDownloadedDocuments++;
            }
            //string pathValue = "";
            //string urlValue = "";
            //string downloadStatus = "";
            //if (pathDictionary == null) InitPathDictionary();
            //if (urlDictionary == null) InitUrlDictionary();
            //if (pathDictionary != null) pathDictionary.TryGetValue(fileName, out pathValue);
            //if (urlDictionary != null) urlDictionary.TryGetValue(fileName, out urlValue);

            //string path = Application.persistentDataPath + "/" + pathValue + ".xml";

            //try
            //{
            //    WebClient client = new WebClient();
            //    string result = client.DownloadString(urlValue);
            //    string[] queryResult = result.Split('|');
            //    if (queryResult[1] == "XML File Has Been Successfully Generated")
            //    {
            //        client.DownloadFileAsync(new Uri("http://cws.yowanda.com/files/" + pathValue + ".xml"), path);
            //    }
            //    downloadStatus = "Download Complete";
            //    totalDownloadedDocuments++;
            //    //Debug.Log(result);
            //}
            //catch
            //{
            //    downloadStatus = "Download Failed";
            //}
            //Debug.Log(downloadStatus);
        }

        private void ProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            progress = e.ProgressPercentage;
        }

        private void Completed(object sender, AsyncCompletedEventArgs e)
        {

        }

        private void InitPathDictionary()
        {
            pathDictionary = new Dictionary<string, string>();
            pathDictionary.Add("get_profile", "player_profile_" + id);
            pathDictionary.Add("get_friend_list", "friends_of_" + id);
            pathDictionary.Add("get_player_deck", "deck_of_" + id);
            pathDictionary.Add("get_player_trunk", "trunk_of_" + id);
            pathDictionary.Add("get_list_avatar", "list_avatar_of_" + id);
            pathDictionary.Add("get_player_avatar", "player_avatar_of_" + id);
            pathDictionary.Add("get_building", "building_of_" + id);
        }

        private void InitUrlDictionary()
        {
            urlDictionary = new Dictionary<string, string>();
            urlDictionary.Add("get_profile", "http://cws.yowanda.com/ClientController/1/player/get_profile/" + id);
            urlDictionary.Add("get_friend_list", "http://cws.yowanda.com/ClientController/1/player/get_friend_list/" + id);
            urlDictionary.Add("get_player_deck", "http://cws.yowanda.com/ClientController/2/card/get_cards/deck/" + id);
            urlDictionary.Add("get_player_trunk", "http://cws.yowanda.com/ClientController/2/card/get_cards/trunk/" + id);
            urlDictionary.Add("get_list_avatar", "http://cws.yowanda.com/ClientController/2/avatar/get_avatar/list/" + id);
            urlDictionary.Add("get_player_avatar", "http://cws.yowanda.com/ClientController/2/avatar/get_avatar/player/" + id);
            urlDictionary.Add("get_building", "http://cws.yowanda.com/ClientController/1/building/get_building/" + id);
        }
    }
}