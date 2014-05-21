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
            Application.LoadLevel("BeforeBattle");
        }

        void Update()
        {
            
        }

        private void DownloadXMLFile(string fileName)
        {
            string value = "";
            if (dict == null) InitDictionary();
            if (dict != null) dict.TryGetValue(fileName, out value);

            string path = Application.persistentDataPath + "/" + value + ".xml";

            WebClient client = new WebClient();
            string result = client.DownloadString("http://cws.yowanda.com/ClientController/1/player/get_profile/agil");
            client.DownloadFile(new Uri("http://cws.yowanda.com/files/" + value + ".xml"), path);
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