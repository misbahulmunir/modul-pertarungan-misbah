
using System.Collections.Generic;
using UnityEngine;
using ModelModulPertarungan;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace ModulPertarungan
{
	public class PlayerFactory:AbstractFactory
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
                {"warlock", new Warlock()},
                {"sorcerer", new Sorcerer()},
                {"magician", new Magician()}
            };
            //objectNamePath= new Dictionary<string, string>
            //{
            //  //  {"sorcerer",s}
            //};
        }

	   
        public override void CreatePlayer(string id, string job, string objectName, GameObject pawnsPosisition)
        {

            instantiateObjectList.TryGetValue(job, out character);

            var obj = Object.Instantiate((GameObject)Resources.Load(objectName, typeof(GameObject)), pawnsPosisition.transform.position, Quaternion.identity) as GameObject;

            try
            {
                XmlSerializer deserializer = new XmlSerializer(typeof(PlayerFromService));
                TextReader textReader = new StreamReader(Application.persistentDataPath+ "/player_profile_" + id + ".xml");

                PlayerFromService playerFromService;
                playerFromService = (PlayerFromService)deserializer.Deserialize(textReader);

                character.CurrentHealth = character.MaxHealth = playerFromService.MaxHP;
                character.MaxSoulPoints = playerFromService.MaxSP;
                character.Name = playerFromService.Name;
                character.Gold = playerFromService.Gold;
                character.Experience = playerFromService.XP;
                character.DeckCostPoint = playerFromService.MaxDP;
                character.Rank = playerFromService.Rank;

                textReader = new StreamReader(Application.persistentDataPath + "/deck_of_" + id + ".xml");
                xmlFromServer = new XmlDocument();
                xmlFromServer.Load(textReader);
                nameNodes = xmlFromServer.GetElementsByTagName("Name");
                quantityNodes = xmlFromServer.GetElementsByTagName("Quantity");
                character.DeckList = new List<string>();
                
                for(int i=0;i<nameNodes.Count;i++)
                {
                    for (int j = 0; j < int.Parse(quantityNodes[i].InnerXml); j++)
                    {
                        character.DeckList.Add(nameNodes[i].InnerXml);
                    }
                }
                textReader.Close();
            }
            catch
            {
                Debug.Log("Error Reading Player Data");
            }

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
