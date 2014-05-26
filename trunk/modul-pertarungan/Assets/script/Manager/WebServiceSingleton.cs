using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;
using System.Net;
using System.Collections.Specialized;
using UnityEngine;

namespace ModulPertarungan
{
	public class WebServiceSingleton
	{
        private static WebServiceSingleton _instance;
        public string responseFromServer = "";
        public string queryInfo = "";
        public int queryResult = 0;
        private Dictionary<string, string> fileLocationDictionary;
        private Dictionary<string, string> urlDictionary;
        private Dictionary<string, string> clientPathDictionary;

        public WebServiceSingleton()
        {
        }

        public static WebServiceSingleton GetInstance()
        {
            if (_instance == null)
                _instance = new WebServiceSingleton();
            return _instance;
        }

        public void ProcessRequest(string methodName, string parameter)
        {
            string urlTarget = "";
            if (urlDictionary == null) InitUrlDictionary();
            if (urlDictionary != null) urlDictionary.TryGetValue(methodName, out urlTarget);
            string[] param = parameter.Split('|');
            foreach (string s in param)
            {
                urlTarget += "/" + s;
            }

            try
            {
                WebClient client = new WebClient();
                responseFromServer = client.DownloadString(urlTarget);
            }
            catch
            {
                responseFromServer = urlTarget;//"-3|Error reading stream";
            }
            //Debug.Log(responseFromServer);
            string[] response = responseFromServer.Split('|');
            queryResult = int.Parse(response[0]);
            queryInfo = response[1];
        }

        public string DownloadFile(string methodName, string parameter)
        {
            string fileLocation = "";
            string clientPath = "";
            if (fileLocationDictionary == null) InitFileLocationDictionary();
            if (clientPathDictionary == null) InitPathDictionary();

            if (fileLocationDictionary != null) fileLocationDictionary.TryGetValue(methodName, out fileLocation);
            if (clientPathDictionary != null) clientPathDictionary.TryGetValue(methodName, out clientPath);

            WebClient webClient = new WebClient();
            string downloadStatus = "";
            string pathOnClient = "";

            if (methodName == "get_player_ranking")
            {
                pathOnClient = Application.persistentDataPath + "/" + clientPath + ".xml";
                fileLocation = fileLocation + ".xml";
            }
            else
            {
                pathOnClient = Application.persistentDataPath + "/" + clientPath + parameter + ".xml";
                fileLocation = fileLocation + parameter + ".xml";
            }

            try
            {
                webClient.DownloadFileAsync(new Uri(fileLocation), pathOnClient);
                downloadStatus = "Download Complete";
            }
            catch
            {
                downloadStatus = "Download Failed";
            }
            return downloadStatus;
        }

        private void InitFileLocationDictionary()
        {
            fileLocationDictionary = new Dictionary<string, string>();
            fileLocationDictionary.Add("get_profile", "http://cws.yowanda.com/files/player_profile_");
            fileLocationDictionary.Add("get_friend_list", "http://cws.yowanda.com/files/friends_of_");
            fileLocationDictionary.Add("get_player_deck", "http://cws.yowanda.com/files/deck_of_");
            fileLocationDictionary.Add("get_player_trunk", "http://cws.yowanda.com/files/trunk_of_");
            fileLocationDictionary.Add("get_list_avatar", "http://cws.yowanda.com/files/list_avatar_of_");
            fileLocationDictionary.Add("get_player_avatar", "http://cws.yowanda.com/files/player_avatar_of_");
            fileLocationDictionary.Add("get_building", "http://cws.yowanda.com/files/building_of_");
            fileLocationDictionary.Add("get_battle_rank", "http://cws.yowanda.com/files/battle_rank_of_");
            fileLocationDictionary.Add("get_player_ranking", "http://cws.yowanda.com/files/player_rank");
        }

        private void InitUrlDictionary()
        {
            urlDictionary = new Dictionary<string, string>();
            urlDictionary.Add("get_profile", "http://cws.yowanda.com/ClientController/1/player/get_profile");
            urlDictionary.Add("get_friend_list", "http://cws.yowanda.com/ClientController/1/player/get_friend_list");
            urlDictionary.Add("get_player_deck", "http://cws.yowanda.com/ClientController/2/card/get_cards/deck");
            urlDictionary.Add("get_player_trunk", "http://cws.yowanda.com/ClientController/2/card/get_cards/trunk");
            urlDictionary.Add("clear_deck", "http://cws.yowanda.com/ClientController/1/card/clear_deck");
            urlDictionary.Add("insert_to_deck", "http://cws.yowanda.com/ClientController/3/card/insert_to_deck");
            urlDictionary.Add("get_list_avatar", "http://cws.yowanda.com/ClientController/2/avatar/get_avatar/list");
            urlDictionary.Add("get_player_avatar", "http://cws.yowanda.com/ClientController/2/avatar/get_avatar/player");
            urlDictionary.Add("get_building", "http://cws.yowanda.com/ClientController/1/building/get_building");
            urlDictionary.Add("get_battle_rank", "http://cws.yowanda.com/ClientController/1/battle/show_battle_rank");
            urlDictionary.Add("get_player_ranking", "http://cws.yowanda.com/ClientController/0/battle/show_player_ranking");
        }

        private void InitPathDictionary()
        {
            clientPathDictionary = new Dictionary<string, string>();
            clientPathDictionary.Add("get_profile", "player_profile_");
            clientPathDictionary.Add("get_friend_list", "friends_of_");
            clientPathDictionary.Add("get_player_deck", "deck_of_");
            clientPathDictionary.Add("get_player_trunk", "trunk_of_");
            clientPathDictionary.Add("get_list_avatar", "list_avatar_of_");
            clientPathDictionary.Add("get_player_avatar", "player_avatar_of_");
            clientPathDictionary.Add("get_building", "building_of_");
            clientPathDictionary.Add("get_battle_rank", "battle_rank_of_");
            clientPathDictionary.Add("get_player_ranking", "player_rank");
        }
	}
}
