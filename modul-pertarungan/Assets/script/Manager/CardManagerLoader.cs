using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using System.Xml;
namespace ModulPertarungan
{
    public class CardManagerLoader : MonoBehaviour
    {
        public List<GameObject> listcard;
        public GameObject deckGrid;
        public GameObject trunkGrid;
        public List<string> cardList;
        private XmlDocument xmlFromServer;
        private XmlNodeList nameNodes;
        private XmlNodeList quantityNodes;

        void Start()
        {
            Debug.Log(GameManager.Instance().PlayerId);
            LoadCardFromService("player_deck");
            AddToGrid(deckGrid);
            LoadCardFromService("player_trunk");   
            AddToGrid(trunkGrid);
        }


        void Update()
        {
            

        }
        public void AddToGrid(GameObject grid)
        {
            foreach (string s in cardList)
            {
                NGUITools.AddChild(grid,(GameObject)Resources.Load("DisplayCards/"+s, typeof(GameObject)));
            }


            //foreach (GameObject obj in listcard)
            //{
            //    NGUITools.AddChild(grid, obj);
            //}
            grid.GetComponent<UIGrid>().Reposition();
        }

        public void LoadCardFromService(string method)
        {
            cardList = new List<string>();

            WebServiceSingleton.GetInstance().createXMLDocument(method + "|" + GameManager.Instance().PlayerId);
            xmlFromServer = WebServiceSingleton.GetInstance().xmLFromServer;
            Debug.Log(WebServiceSingleton.GetInstance().responseFromServer);

            nameNodes = xmlFromServer.GetElementsByTagName("Name");
            quantityNodes = xmlFromServer.GetElementsByTagName("Quantity");
            if (WebServiceSingleton.GetInstance().responseFromServer != "Deck is Empty" && WebServiceSingleton.GetInstance().responseFromServer != "Trunk is Empty")
            {
                Debug.Log("Method Name : " + method);
                for (int i = 0; i < nameNodes.Count; i++)
                {
                    for (int j = 0; j < int.Parse(quantityNodes[i].InnerXml); j++)
                    {
                        cardList.Add(nameNodes[i].InnerXml);
                        Debug.Log("Card Name : " + nameNodes[i].InnerXml);
                    }
                }
            }
            
        }
       
    }
}
