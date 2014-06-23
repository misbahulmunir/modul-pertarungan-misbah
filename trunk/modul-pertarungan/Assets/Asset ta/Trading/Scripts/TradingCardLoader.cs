using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using System.Xml;
using System.IO;
using System.Xml.Serialization;

namespace ModulPertarungan
{
    public class TradingCardLoader : MonoBehaviour
    {
        public GameObject myTradeGrid;
        public GameObject myTrunkGrid;
        public GameObject hisTradeGrid;
        public GameObject hisTrunkGrid;
        public GameObject myName;
        public GameObject hisName;
        private int totalDeckCostSize;
        private XmlDocument _xmlDoc;
        private XmlNodeList _nameNodes;
        private XmlNodeList _quantityNodes;

        void Start()
        {
            _xmlDoc = new XmlDocument();
            //Debug.Log(GameManager.Instance().PlayerId);
            //LoadCardFromService("trunk_of_", myTrunkGrid);
            //LoadCardFromService("trunk_of_", hisTrunkGrid);
            //LoadCardFromService("deck_of_", hisTradeGrid);
            //LoadCardFromService("deck_of_", myTradeGrid);

            TradeRequest t = new TradeRequest();
            t.RequestedPlayer = "fauzi";
            t.SenderPlayer = "mis";
            t.cards = new List<CardRequest>();

            CardRequest c = new CardRequest();
            c.Name = "Fire Card";
            c.Quantity = 2;
            t.cards.Add(c);

            c.Name = "Water Card";
            c.Quantity = 5;
            t.cards.Add(c);

            XmlSerializer serializer = new XmlSerializer(typeof(TradeRequest));
            using (TextWriter writer = new StreamWriter(Application.persistentDataPath + "/trading_detail.xml"))
            {
                serializer.Serialize(writer, t);
            }

            try
            {
                string text = System.IO.File.ReadAllText(Application.persistentDataPath + "/trading_detail.xml");
                var encoded_string = System.Text.Encoding.UTF8.GetBytes(text);
                WebServiceSingleton.GetInstance().ProcessRequest("send_trade_request", System.Convert.ToBase64String(encoded_string));
                //Debug.Log(text);
            }
            catch (Exception e)
            {
                Debug.Log(e);
            }
        }

        void Update()
        {
        }

        public void AddToGrid(GameObject grid, List<string> list)
        {
            foreach (string s in list)
            {
                NGUITools.AddChild(grid, (GameObject)Resources.Load("DisplayCards/" + s, typeof(GameObject)));
            }
            grid.GetComponent<UIGrid>().Reposition();
        }

        public void LoadCardFromService(string method, GameObject grid)
        {
            List<string> list = new List<string>();
            Boolean _isEmpty = false;
            try
            {
                //Debug.Log(Application.persistentDataPath + "/" + method + GameManager.Instance().PlayerId + ".xml");
                TextReader textReader = new StreamReader(Application.persistentDataPath + "/" + method + GameManager.Instance().PlayerId + ".xml");
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
            }
            catch
            {
                _isEmpty = true;
            }

            if (!_isEmpty) AddToGrid(grid, list);
        }
    }
}