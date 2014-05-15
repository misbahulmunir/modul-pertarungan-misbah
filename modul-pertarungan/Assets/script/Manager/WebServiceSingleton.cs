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
        private Dictionary<string, string> serverDict;
      
        public WebServiceSingleton()
        {
        }

        public static WebServiceSingleton GetInstance()
        {
            if (_instance == null)
                _instance = new WebServiceSingleton();
            return _instance;
        }

        public void ProcessRequest(string parameter)
        {
            if (serverDict == null) InitServerDictionary();   
            string[] param = parameter.Split('|');
            string temp = "param";
            try
            {
                string urlx = "http://cws.yowanda.com/ClientController";
                using (WebClient client = new WebClient())
                {
                    var data = new NameValueCollection();
                    data.Add("method", param[0]);
                    for(int i=1;i<=param.Length-1;i++)
                    {
                        data.Add(temp+i.ToString(CultureInfo.InvariantCulture), param[i]);
                    }
                    var bytecode = client.UploadValues(urlx, data);
                    responseFromServer = Encoding.UTF8.GetString(bytecode, 0, bytecode.Length);
                }
            }
            catch
            {
                responseFromServer = "-3|Error reading stream";
            }
            Debug.Log(responseFromServer);
            string[] response = responseFromServer.Split('|');
            queryResult = int.Parse(response[0]);
            queryInfo = response[1];

            //if (responseFromServer == "XML File Has Been Successfully Generated")
            //{
            //    responseFromServer = "OK";
                //string value = "";
                //var document = new XmlDocument();
                //if (dict != null) dict.TryGetValue(param[0], out value);
                //document.Load(value + param[1] + ".xml");
                //xmLFromServer = document;
            //}
        }

        public string DownloadFile(string url, string path)
        {
            WebClient webClient = new WebClient();
            string downloadStatus = "";
            try
            {
                webClient.DownloadFile(new Uri(url), path);
                downloadStatus = "Download Complete";
            }
            catch
            {
                downloadStatus = "Download Failed";
            }
            return downloadStatus;
        }

        private void InitServerDictionary()
        {
            serverDict = new Dictionary<string, string>();
            serverDict.Add("get_profile", "http://cws.yowanda.com/files/player_profile_");
            serverDict.Add("friend_list", "http://cws.yowanda.com/files/friends_of_");
            serverDict.Add("player_deck", "http://cws.yowanda.com/files/deck_of_");
            serverDict.Add("player_trunk", "http://cws.yowanda.com/files/trunk_of_");
        }
	}
}
