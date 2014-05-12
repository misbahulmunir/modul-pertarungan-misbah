using System;
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
        public List<GameObject> listcard;
        public GameObject deckGrid;
        public GameObject trunkGrid;
        public List<string> deckList;
        public List<string> trunkList;
        private XmlDocument _xmlFromServer;
        private XmlNodeList _nameNodes;
        private XmlNodeList _quantityNodes;
        private Boolean _isDeckEmpty;
        private Boolean _isTrunkEmpty;

        void Start()
        {
            deckList = new List<string>();
            trunkList = new List<string>();
            _xmlFromServer = new XmlDocument();
            _isDeckEmpty = false;
            _isTrunkEmpty = false;
            Debug.Log(GameManager.Instance().PlayerId);
            LoadCardFromService("deck_of_", deckGrid);
            LoadCardFromService("trunk_of_", trunkGrid);
        }

        void Update()
        {
            

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
            List<string> list = new List<string>();
            Boolean _isEmpty = false;
            try
            {
                Debug.Log(Application.dataPath + "/XMLFiles/" + method + GameManager.Instance().PlayerId + ".xml");
                TextReader textReader = new StreamReader(Application.dataPath + "/XMLFiles/" + method + GameManager.Instance().PlayerId + ".xml");
                _xmlFromServer.Load(textReader);
                _nameNodes = _xmlFromServer.GetElementsByTagName("Name");
                _quantityNodes = _xmlFromServer.GetElementsByTagName("Quantity");

                Debug.Log("Method Name : " + method);
                for (int i = 0; i < _nameNodes.Count; i++)
                {
                    for (int j = 0; j < int.Parse(_quantityNodes[i].InnerXml); j++)
                    {
                        list.Add(_nameNodes[i].InnerXml);
                        Debug.Log("Card Name : " + _nameNodes[i].InnerXml);
                    }
                }
            }
            catch
            {
                _isEmpty = true;
            }

            if(!_isEmpty) AddToGrid(grid, list);
        }
       
    }
}
