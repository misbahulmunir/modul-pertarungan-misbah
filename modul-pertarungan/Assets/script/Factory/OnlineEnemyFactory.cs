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
                {"warlock", new Warlock()}
            };
        }
        public override void CreatePlayer(string id, string job, string objectName, GameObject pawnsPosisition)
        {
            _instantiateObjectList.TryGetValue(job, out character);

         
            var obj = Object.Instantiate((GameObject)Resources.Load(objectName, typeof(GameObject)), pawnsPosisition.transform.position, Quaternion.identity) as GameObject;
            if (obj == null) return;
            obj.transform.Rotate(new Vector3(0f,180f,0f));

            XmlSerializer deserializer = new XmlSerializer(typeof(PlayerFromService));
            TextReader textReader = new StreamReader(Application.persistentDataPath + "/player_profile_" + id + ".xml");

            PlayerFromService playerFromService;
            playerFromService = (PlayerFromService)deserializer.Deserialize(textReader);

            character.CurrentHealth = character.MaxHealth = playerFromService.MaxHP;
            character.MaxSoulPoints = playerFromService.MaxSP;
            character.Name = playerFromService.Name;
            character.Gold = playerFromService.Gold;
            character.Experience = playerFromService.XP;
            character.DeckCostPoint = playerFromService.MaxDP;
            character.Rank = playerFromService.Rank;
            obj.GetComponent<PlayerAction>().Character = character;
            GameManager.Instance().AddEnemy(obj);
            GameManager.Instance().CurrentEnemy = obj;
            obj.GetComponent<PlayerAction>().IsEnemy = true;
            
            //Debug.Log(GameManager.Instance().Players[0].GetComponent<PlayerAction>().Character.Name);

        }
	}
}
