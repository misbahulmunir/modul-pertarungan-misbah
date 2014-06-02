using System.Collections.Generic;
using System.Linq;
using System.Text;
using ModelModulPertarungan;
using UnityEngine;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
namespace ModulPertarungan
{
	public class OnlineEnemyFactory:AbstractFactory
	{
        private XmlDocument xmlFromServer;
        private XmlNodeList attributeNodes;
        private Dictionary<string, Player> _instantiateObjectList;

        public Dictionary<string, Player> InstantiateObjectList
        {
            get { return _instantiateObjectList; }
            set { _instantiateObjectList = value; }
        }
        private Player character;

        public Player Character
        {
            get { return character; }
            set { character = value; }
        }
        public override void InstantiateObject()
        {
            _instantiateObjectList = new Dictionary<string, Player>
            {
               {"Warlock", new Warlock()},
                {"Sorcerer", new Sorcerer()},
                {"Magician", new Magician()},
                {"Grand Magus", new GrandMagus()},
                {"Wizard",new Wizard()}
            };
        }
        public override void CreatePlayer(string id, GameObject pawnsPosisition)
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(PlayerFromService));
            TextReader textReader = new StreamReader(Application.persistentDataPath + "/player_profile_" + id + ".xml");

            PlayerFromService playerFromService;
            playerFromService = (PlayerFromService)deserializer.Deserialize(textReader);
            _instantiateObjectList.TryGetValue(playerFromService.Job, out character);
            character.CurrentHealth = character.MaxHealth = playerFromService.MaxHP;
            character.MaxSoulPoints = playerFromService.MaxSP;
            character.Name = playerFromService.Name;
            character.Gold = playerFromService.Gold;
            character.Experience = playerFromService.XP;
            character.DeckCostPoint = playerFromService.MaxDP;
            character.Rank = playerFromService.Rank;
            character.Job = playerFromService.Job;
            var obj = Object.Instantiate((GameObject)Resources.Load("Character/" + character.Job + "/" + "GameObject" + "/" + character.Rank, typeof(GameObject)), pawnsPosisition.transform.position, Quaternion.identity) as GameObject;
            obj.GetComponent<PlayerAction>().Character = character;
            GameManager.Instance().AddEnemy(obj);
            GameManager.Instance().CurrentEnemy = obj;
            obj.GetComponent<PlayerAction>().IsEnemy = true;
            
            //Debug.Log(GameManager.Instance().Players[0].GetComponent<PlayerAction>().Character.Name);

        }
	}
}
