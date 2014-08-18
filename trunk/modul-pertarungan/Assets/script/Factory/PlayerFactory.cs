
using System;
using System.Collections.Generic;
using UnityEngine;
using ModelModulPertarungan;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using Object = UnityEngine.Object;

namespace ModulPertarungan
{
    public class PlayerFactory : AbstractFactory
    {
        private XmlDocument xmlFromServer;
        private XmlNodeList attributeNodes;

        private XmlNodeList nameNodes;
        private XmlNodeList quantityNodes;

        private Dictionary<string, Player> instantiateObjectList;

        public Dictionary<string, Player> InstantiateObjectList
        {
            get { return instantiateObjectList; }
            set { instantiateObjectList = value; }
        }
        private Player character;

        public Player Character
        {
            get { return character; }
            set { character = value; }
        }

        public Dictionary<string, string> ObjectNamePath
        {
            get { return objectNamePath; }
            set { objectNamePath = value; }
        }


        private Dictionary<string, string> objectNamePath;
        public override void InstantiateObject()
        {
            instantiateObjectList = new Dictionary<string, Player>
            {
                {"Warlock", new Warlock()},
                {"Sorcerer", new Sorcerer()},
                {"Magician", new Magician()},
                {"Grand Magus", new GrandMagus()},
                {"Wizard",new Wizard()}
            };
            //objectNamePath= new Dictionary<string, string>
            //{
            //  //  {"sorcerer",s}
            //};
        }


        public override void CreatePlayer(string id, GameObject pawnsPosisition)
        {
            WebServiceSingleton.GetInstance().ProcessRequest("get_profile", id);
            XmlSerializer deserializer = new XmlSerializer(typeof(PlayerFromService));
            //TextReader textReader = new StreamReader(Application.persistentDataPath + "/player_profile_" + id + ".xml");
            TextReader textReader = new StringReader(WebServiceSingleton.GetInstance().queryInfo);
            PlayerFromService playerFromService;
            playerFromService = (PlayerFromService)deserializer.Deserialize(textReader);
            instantiateObjectList.TryGetValue(playerFromService.Job, out character);
            character.CurrentHealth = character.MaxHealth = playerFromService.MaxHP;
            character.MaxSoulPoints = playerFromService.MaxSP;
            character.CurrentSoulPoints = 50;
            character.Name = playerFromService.Name;
            character.Gold = playerFromService.Gold;
            character.Experience = playerFromService.XP;
            character.DeckCostPoint = playerFromService.MaxDP;
            character.Rank = playerFromService.Rank;
            character.Job = playerFromService.Job;
            try
            {
                WebServiceSingleton.GetInstance().ProcessRequest("get_player_deck", id);
                //textReader = new StreamReader(Application.persistentDataPath + "/deck_of_" + id + ".xml");
                textReader = new StringReader(WebServiceSingleton.GetInstance().queryInfo);
                xmlFromServer = new XmlDocument();
                xmlFromServer.Load(textReader);
                nameNodes = xmlFromServer.GetElementsByTagName("Name");
                quantityNodes = xmlFromServer.GetElementsByTagName("Quantity");
                character.DeckList = new List<string>();

                for (int i = 0; i < nameNodes.Count; i++)
                {
                    for (int j = 0; j < int.Parse(quantityNodes[i].InnerXml); j++)
                    {
                        character.DeckList.Add(nameNodes[i].InnerXml);
                    }
                }
                textReader.Close();
            }
            catch (Exception e)
            {
                Debug.Log("NoDeck");
            }
            var obj = Object.Instantiate((GameObject)Resources.Load("Character/" + character.Job+"/"+"GameObject"+"/"+character.Rank, typeof(GameObject)), pawnsPosisition.transform.position, Quaternion.identity) as GameObject;
            if (obj != null)
            {
                obj.GetComponent<PlayerAction>().Character = character;
                obj.GetComponent<PlayerAction>().IsEnemy = false;
                GameManager.Instance().AddPlayer(obj);
                GameManager.Instance().CurrentPawn = obj;
            }
            //Debug.Log(GameManager.Instance().Players[0].GetComponent<PlayerAction>().Character.Name);
        }
    }
}
