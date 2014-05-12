
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
        public override void InstantiateObject()
        {  
            instantiateObjectList = new Dictionary<string, Player>
            {
                {"warlock", new Warlock()},
                {"sorcerer", new Sorcerer()},
                {"magician", new Magician()}
            };
        }
        public override void CreatePlayer(string id, string job, string objectName, GameObject pawnsPosisition)
        {
            instantiateObjectList.TryGetValue(job, out character);

            var obj = Object.Instantiate((GameObject)Resources.Load(objectName, typeof(GameObject)), pawnsPosisition.transform.position, Quaternion.identity) as GameObject;

            try
            {
                XmlSerializer deserializer = new XmlSerializer(typeof(PlayerFromService));
                TextReader textReader = new StreamReader(Application.dataPath + "/XMLFiles/player_profile_" + id + ".xml");

                PlayerFromService playerFromService;
                playerFromService = (PlayerFromService)deserializer.Deserialize(textReader);

                Debug.Log("Nama Player : " + playerFromService.Name);
                Debug.Log("Gold : " + playerFromService.Gold);

                character.CurrentHealth = character.MaxHealth = playerFromService.MaxHP;
                character.MaxSoulPoints = playerFromService.MaxSP;
                character.Name = playerFromService.Name;
                character.Gold = playerFromService.Gold;
                character.Experience = playerFromService.XP;
                character.DeckCostPoint = playerFromService.DPLeft;
                character.Rank = playerFromService.Rank;

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
