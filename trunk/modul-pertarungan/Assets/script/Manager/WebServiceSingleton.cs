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
        public bool isLoadingScreen = false;
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
                responseFromServer = "-3|Error reading stream";
            }
            Debug.Log(methodName + " " /*+ parameter */+ responseFromServer);
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
                if (isLoadingScreen)
                {
                    webClient.DownloadFileAsync(new Uri(fileLocation), pathOnClient);
                }
                else
                {
                    webClient.DownloadFile(new Uri(fileLocation), pathOnClient);
                }
                downloadStatus = "Download Complete";
               // IntegrationTest.Pass(new GameObject("Pass"));
                
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
            fileLocationDictionary.Add("get_friend_request", "http://cws.yowanda.com/files/friend_request_of_");
            fileLocationDictionary.Add("get_partial_profile", "http://cws.yowanda.com/files/partial_profile_of_");
            fileLocationDictionary.Add("get_messages", "http://cws.yowanda.com/files/messages_of_");
            fileLocationDictionary.Add("get_monster_list", "http://cws.yowanda.com/files/monster_of_");
            fileLocationDictionary.Add("get_battle_list", "http://cws.yowanda.com/files/battle_list_of_");
            fileLocationDictionary.Add("get_player_quest", "http://cws.yowanda.com/files/quest_of_");
            fileLocationDictionary.Add("get_trade_request_list", "http://cws.yowanda.com/files/trade_request_list_of_");
            fileLocationDictionary.Add("get_card_request_list", "http://cws.yowanda.com/files/card_request_list_of_");
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
            urlDictionary.Add("get_friend_request", "http://cws.yowanda.com/ClientController/2/request/get_request_list/friend");
            urlDictionary.Add("get_partial_profile", "http://cws.yowanda.com/ClientController/1/player/get_partial_profile");
            urlDictionary.Add("send_friend_request", "http://cws.yowanda.com/ClientController/3/request/do_request/send-friend");
            urlDictionary.Add("accept_friend_request", "http://cws.yowanda.com/ClientController/3/request/do_request/accept-friend");
            urlDictionary.Add("edit_avatar", "http://cws.yowanda.com/ClientController/2/avatar/edit_avatar");
            urlDictionary.Add("update_building", "http://cws.yowanda.com/ClientController/3/building/update_building");
            urlDictionary.Add("ignore_friend_request", "http://cws.yowanda.com/ClientController/3/request/do_request/ignore-friend");
            urlDictionary.Add("remove_friend", "http://cws.yowanda.com/ClientController/2/player/remove_friend");
            urlDictionary.Add("register", "http://cws.yowanda.com/ClientController/3/player/register");
            urlDictionary.Add("send_message", "http://cws.yowanda.com/ClientController/3/message/send_message");
            urlDictionary.Add("get_messages", "http://cws.yowanda.com/ClientController/1/message/get_messages");
            urlDictionary.Add("get_monster_list", "http://cws.yowanda.com/ClientController/1/monster_quest/get_monster_list");
            urlDictionary.Add("get_battle_list", "http://cws.yowanda.com/ClientController/1/monster_quest/get_battle_list");
            urlDictionary.Add("get_player_quest", "http://cws.yowanda.com/ClientController/1/monster_quest/get_player_quest");
            urlDictionary.Add("get_name_by_fb", "http://cws.yowanda.com/ClientController/1/player/get_name_by_fb");
			urlDictionary.Add("send_battle_result", "http://cws.yowanda.com/ClientController/2/battle/send_battle_result");
            urlDictionary.Add("send_trade_request", "http://cws.yowanda.com/ClientController/1/request/send_trade_request");
            urlDictionary.Add("get_trade_request_list", "http://cws.yowanda.com/ClientController/1/request/get_trade_request_list");
            urlDictionary.Add("get_card_request_list", "http://cws.yowanda.com/ClientController/2/request/get_card_request_list");
            urlDictionary.Add("decline_trade_request", "http://cws.yowanda.com/ClientController/1/request/decline_trade_request");
            urlDictionary.Add("accept_trade_request", "http://cws.yowanda.com/ClientController/1/request/accept_trade_request");
            urlDictionary.Add("login", "http://cws.yowanda.com/ClientController/2/player/login");
            urlDictionary.Add("get_gift", "http://cws.yowanda.com/ClientController/2/request/get_gift");
            urlDictionary.Add("share_gift", "http://cws.yowanda.com/ClientController/1/request/share_gift");
            urlDictionary.Add("claim_gift", "http://cws.yowanda.com/ClientController/2/request/claim_gift");
            urlDictionary.Add("get_gift_notif", "http://cws.yowanda.com/ClientController/1/request/get_gift_notif");
            urlDictionary.Add("delete_message", "http://cws.yowanda.com/service/3/message/delete_message");
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
            clientPathDictionary.Add("get_friend_request", "friend_request_of_");
            clientPathDictionary.Add("get_partial_profile", "partial_profile_of_");
            clientPathDictionary.Add("get_messages", "messages_of_");
            clientPathDictionary.Add("get_monster_list", "monster_of");
            clientPathDictionary.Add("get_battle_list", "battle_list_of");
            clientPathDictionary.Add("get_player_quest", "quest_of");
            clientPathDictionary.Add("get_trade_request_list", "trade_request_list_of_");
            clientPathDictionary.Add("get_card_request_list", "card_request_list_of_");
        }

        public void clearData(string path)
        {
            if(Directory.Exists(Path.GetDirectoryName(path)))
            {
                File.Delete(path);
            }
        }
	}
}
