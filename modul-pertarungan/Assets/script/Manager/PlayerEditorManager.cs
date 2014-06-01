using System;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.IO;
using Avatar = UnityEngine.Avatar;

namespace ModulPertarungan
{
    public class PlayerEditorManager : MonoBehaviour
    {
        public GameObject grid;
        public GameObject avatar;
        public GameObject playerAvatar;
        private XmlDocument xmlFromServer;
        private XmlNodeList attributeNodes;
        private List<string> friendList;
        void Update()
        {

        }


        void Start()
        {
            playerAvatar.GetComponent<Avatar>().PlayerName = GameManager.Instance().PlayerId;
            GetAvatarList(GameManager.Instance().PlayerId);
            foreach (string s in friendList)
            {
                Debug.Log("nama : " + s);
                GameObject obj = NGUITools.AddChild(grid, avatar);
                obj.GetComponent<Avatar>().PlayerName = s;
            }

        }

        public void GetAvatarList(string id)
        {
            friendList = new List<string>();
            xmlFromServer = new XmlDocument();
            TextReader textReader = new StreamReader(Application.persistentDataPath + "/friends_of_" + GameManager.Instance().PlayerId + ".xml");
            xmlFromServer.Load(textReader);
            attributeNodes = xmlFromServer.GetElementsByTagName("Name");

            for (int i = 0; i < attributeNodes.Count; i++)
            {
                friendList.Add(attributeNodes[i].InnerXml);
            }
        }
    }
}
