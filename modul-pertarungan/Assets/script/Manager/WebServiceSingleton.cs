using System;
using System.Collections.Generic;
using System.Globalization;
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
            if (dict == null) InitDictionary();   
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
                responseFromServer = "Error reading stream";
            }

            if (responseFromServer == "XML File Has Been Successfully Generated")
            {
                string value = "";
                var document = new XmlDocument();
                if (dict != null) dict.TryGetValue(param[0], out value);
                document.Load(value + param[1] + ".xml");
                xmLFromServer = document;
            }
        }

        private void InitDictionary()
        {
            dict = new Dictionary<string, string>();
            dict.Add("get_profile", "http://cws.yowanda.com/files/player_profile_");
            dict.Add("friend_list", "http://cws.yowanda.com/files/friends_of_");
        }
	}
}
