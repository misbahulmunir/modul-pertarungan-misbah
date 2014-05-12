using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using System.Xml;
namespace ModulPertarungan
{
    public class PlayerEditorManager : MonoBehaviour
    {
        public GameObject grid;
        public GameObject avatar;

        private XmlDocument xmlFromServer;
        private XmlNodeList attributeNodes;
        private List<string> friendList;
        void Update()
        {

        }


        void Start()
        {
            GetFriendList(GameManager.Instance().PlayerId);
            foreach (string s in friendList)
            {
                Debug.Log("nama : " + s);
                GameObject obj = NGUITools.AddChild(grid, avatar);
                obj.GetComponent<Avatar>().PlayerName = s;
            }

        }

        public void GetFriendList(string id)
        {
            friendList = new List<string>();
            WebServiceSingleton.GetInstance().processRequest("friend_list|" + id);
            xmlFromServer = WebServiceSingleton.GetInstance().xmLFromServer;
            attributeNodes = xmlFromServer.GetElementsByTagName("Name");

            for (int i = 0; i < attributeNodes.Count; i++)
            {
                friendList.Add(attributeNodes[i].InnerXml);
            }
        }
    }
}
