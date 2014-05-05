using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;
using System.Net;
using System.Collections.Specialized;

namespace ModulPertarungan
{
	public class WebServiceSingleton
	{
        private static WebServiceSingleton _instance;
        public XmlDocument xmLFromServer;
        public string responseFromServer = "";
        private Dictionary<string, string> dict;
      
        public WebServiceSingleton()
        {
        }

        public static WebServiceSingleton GetInstance()
        {
            if (_instance == null)
                _instance = new WebServiceSingleton();
            return _instance;
        }

        public void createXMLDocument(string parameter)
        {
            if (dict == null) initDictionary();   
            string[] param = parameter.Split('|');
            string temp = "param";
            try
            {
                string urlx = "http://localhost/MortalWorld/ClientController";
                using (WebClient client = new WebClient())
                {
                    var data = new NameValueCollection();
                    data.Add("method", param[0]);
                    for(int i=1;i<=param.Length-1;i++)
                    {
                        data.Add(temp+i.ToString(), param[i]);
                    }
                    var Bytecode = client.UploadValues(urlx, data);
                    responseFromServer = Encoding.UTF8.GetString(Bytecode, 0, Bytecode.Length);
                }
            }
            catch
            {
                responseFromServer = "Error reading stream";
            }

            if (responseFromServer == "XML File Has Been Successfully Generated")
            {
                string value = "";
                XmlDocument document = new XmlDocument();
                dict.TryGetValue(param[0], out value);
                document.Load(value + param[1] + ".xml");
                xmLFromServer = document;
            }
        }

        private void initDictionary()
        {
            dict = new Dictionary<string, string>();
            dict.Add("get_profile", "http://localhost/MortalWorld/files/player_profile_");
            dict.Add("friend_list", "http://localhost/MortalWorld/files/friends_of_");
        }
	}
}
