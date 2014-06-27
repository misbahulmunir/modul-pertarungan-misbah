using System;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.IO;
using Avatar = UnityEngine.Avatar;
using System.Xml.Serialization;

namespace ModulPertarungan
{
    public class PlayerEditorManager : MonoBehaviour
    {
        public GameObject grid;
        public GameObject avatar;
        public GameObject playerAvatar;
        private XmlDocument xmlFromServer;
        private XmlNodeList attributeNodes;
        private List<PlayerFromService> friends;
        TextReader textReader;
        void Update()
        {
           
        }


        void Start()
        {
            friends = new List<PlayerFromService>();
            playerAvatar.GetComponent<Avatar>().PlayerName = GameManager.Instance().PlayerId;
            GetAvatarList(GameManager.Instance().PlayerId);
            foreach (var s in friends)
            {
               
                GameObject obj = NGUITools.AddChild(grid, avatar);
                obj.GetComponent<Avatar>().PlayerName = s.Name;
                obj.GetComponent<Avatar>().Job = s.Job;
                obj.GetComponent<Avatar>().Rank = s.Rank;
                obj.GetComponent<Avatar>().Level = s.Level.ToString();
            }
            grid.GetComponent<UIGrid>().Reposition();
        }

        public void GetAvatarList(string id)
        {
            WebServiceSingleton.GetInstance().ProcessRequest("get_friend_list", GameManager.Instance().PlayerId);
            WebServiceSingleton.GetInstance().DownloadFile("get_friend_list", GameManager.Instance().PlayerId);
            if (WebServiceSingleton.GetInstance().queryResult > 0)
            {
                try
                {
                    XmlSerializer deserializer = new XmlSerializer(typeof(FriendListFromService));
                    textReader = new StreamReader(Application.persistentDataPath + "/friends_of_" + GameManager.Instance().PlayerId + ".xml");
                    object obj = deserializer.Deserialize(textReader);
                    FriendListFromService friendlist = (FriendListFromService)obj;
                    foreach (var player in friendlist.players)
                    {
                        var p = new PlayerFromService();
                        p.Name = player.Name;
                        p.Rank = player.Rank;
                        p.Level = player.Level;
                        p.Job = player.Job;
                        friends.Add(p);
                    }
                    textReader.Close();
                }
                catch (Exception e)
                {
                    Debug.Log(e);
                }
            }
            //friendList = new List<string>();
            //xmlFromServer = new XmlDocument();
            //TextReader textReader = new StreamReader(Application.persistentDataPath + "/friends_of_" + GameManager.Instance().PlayerId + ".xml");
            //xmlFromServer.Load(textReader);
            //attributeNodes = xmlFromServer.GetElementsByTagName("Name");

            //for (int i = 0; i < attributeNodes.Count; i++)
            //{
            //    friendList.Add(attributeNodes[i].InnerXml);
               
            //}
            
        }
    }
}
