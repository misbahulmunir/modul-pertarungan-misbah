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
        private XmlDocument _xmlFromServer;
        private XmlNodeList _nameNodes;
        private XmlNodeList _quantityNodes;
        private Boolean _isEmpty;
        void Start()
        {
            _isEmpty = false;
            Debug.Log(GameManager.Instance().PlayerId);
            LoadCardFromService("player_deck");
            LoadCardFromService("player_trunk");
            if (!_isEmpty)
            {
                AddToGrid(deckGrid);
                AddToGrid(trunkGrid);
            }
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
            _xmlFromServer = WebServiceSingleton.GetInstance().xmLFromServer;
            Debug.Log("Load Card : " + WebServiceSingleton.GetInstance().responseFromServer);

            _nameNodes = _xmlFromServer.GetElementsByTagName("Name");
            _quantityNodes = _xmlFromServer.GetElementsByTagName("Quantity");
            if (WebServiceSingleton.GetInstance().responseFromServer != "Deck is Empty" && WebServiceSingleton.GetInstance().responseFromServer != "Trunk is Empty")
            {
                Debug.Log("Method Name : " + method);
                for (int i = 0; i < _nameNodes.Count; i++)
                {
                    for (int j = 0; j < int.Parse(_quantityNodes[i].InnerXml); j++)
                    {
                        cardList.Add(_nameNodes[i].InnerXml);
                        Debug.Log("Card Name : " + _nameNodes[i].InnerXml);
                    }
                }
                _isEmpty = true;
            }
            
        }
       
    }
}
