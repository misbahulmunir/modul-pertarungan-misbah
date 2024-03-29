﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using System.Xml;
using System.IO;
namespace ModulPertarungan
{
    public class CardManagerLoader : MonoBehaviour
    {
        public GameObject deckGrid;
        public GameObject trunkGrid;
        public GameObject deckCountSize;
        public GameObject playerDeckPoint;
        private int totalDeckCostSize;
        private XmlDocument _xmlDoc;
        private XmlNodeList _nameNodes;
        private XmlNodeList _quantityNodes;

        void Start()
        {
            _xmlDoc = new XmlDocument();
            //Debug.Log(GameManager.Instance().PlayerId);
            LoadCardFromService("deck", deckGrid);
            LoadCardFromService("trunk", trunkGrid);
            ShowPlayerDP();
        }

        void Update()
        {           
            CheckDeckCountSize();
        }

        public void CheckDeckCountSize()
        {
            totalDeckCostSize = 0;
            foreach (Transform t in deckGrid.transform)
            {
                totalDeckCostSize += t.gameObject.GetComponent<CardsEffect>().DeckCost;
            }
            deckCountSize.GetComponent<UILabel>().text = totalDeckCostSize.ToString();

        }

        public void AddToGrid(GameObject grid, List<string> list)
        {
            foreach (string s in list)
            {
                NGUITools.AddChild(grid,(GameObject)Resources.Load("DisplayCards/"+s, typeof(GameObject)));
            }
            grid.GetComponent<UIGrid>().Reposition();
        }

        public void LoadCardFromService(string method, GameObject grid)
        {
            WebServiceSingleton.GetInstance().ProcessRequest("get_player_" + method, GameManager.Instance().PlayerId);
            if (WebServiceSingleton.GetInstance().queryResult > 0)
            {
                List<string> list = new List<string>();
                Boolean _isEmpty = false;
                try
                {
                    //Debug.Log(Application.persistentDataPath + "/" + method + GameManager.Instance().PlayerId + ".xml");
                    //TextReader textReader = new StreamReader(Application.persistentDataPath + "/" + method + "_of_" + GameManager.Instance().PlayerId + ".xml");
                    TextReader textReader = new StringReader(WebServiceSingleton.GetInstance().queryInfo);
                    _xmlDoc.Load(textReader);
                    _nameNodes = _xmlDoc.GetElementsByTagName("Name");
                    _quantityNodes = _xmlDoc.GetElementsByTagName("Quantity");

                    //Debug.Log("Method Name : " + method);
                    for (int i = 0; i < _nameNodes.Count; i++)
                    {
                        for (int j = 0; j < int.Parse(_quantityNodes[i].InnerXml); j++)
                        {
                            list.Add(_nameNodes[i].InnerXml);
                            //Debug.Log("Card Name : " + _nameNodes[i].InnerXml);
                        }
                    }
                    IntegrationTest.Pass(this.gameObject);
                }
                catch
                {
                    _isEmpty = true;
                }

                if (!_isEmpty) AddToGrid(grid, list);
            }
        }

        public void ShowPlayerDP()
        {
            WebServiceSingleton.GetInstance().ProcessRequest("get_profile", GameManager.Instance().PlayerId);
            //TextReader textReader = new StreamReader(Application.persistentDataPath + "/player_profile_" + GameManager.Instance().PlayerId + ".xml");
            TextReader textReader = new StringReader(WebServiceSingleton.GetInstance().queryInfo);
            _xmlDoc.Load(textReader);
            _nameNodes = _xmlDoc.GetElementsByTagName("MaxDP");
            playerDeckPoint.GetComponent<UILabel>().text = _nameNodes[0].InnerXml;
        }
    }
}
