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
            
            WebServiceSingleton.GetInstance().ProcessRequest("get_profile", id);
            //WebServiceSingleton.GetInstance().DownloadFile("get_profile", id);
            XmlSerializer deserializer = new XmlSerializer(typeof(PlayerFromService));
            TextReader textReader = new StreamReader(Application.persistentDataPath + "/player_profile_" + id + ".xml");
            PlayerFromService playerFromService;
            playerFromService = (PlayerFromService)deserializer.Deserialize(textReader);
            _instantiateObjectList.TryGetValue(playerFromService.Job, out character);
            character.CurrentHealth = character.MaxHealth = playerFromService.MaxHP;
            character.MaxSoulPoints = playerFromService.MaxSP;
            character.Name = playerFromService.Name;
            NetworkSingleton.Instance().EnemyName = playerFromService.Name; 
            character.Gold = playerFromService.Gold;
            character.Experience = playerFromService.XP;
            character.DeckCostPoint = playerFromService.MaxDP;
            character.Rank = playerFromService.Rank;
            character.Job = playerFromService.Job;
            var obj = Object.Instantiate((GameObject)Resources.Load("Character/" + character.Job + "/" + "GameObject" + "/" + character.Rank, typeof(GameObject)), pawnsPosisition.transform.position, Quaternion.identity) as GameObject;
            if (obj != null)
            {
                obj.transform.Rotate(new Vector3(0f, 180f, 0f));
                obj.GetComponent<PlayerAction>().Character = character;
                GameManager.Instance().AddEnemy(obj);
                GameManager.Instance().CurrentEnemy = obj;
                obj.GetComponent<PlayerAction>().IsEnemy = true;
            }

            //Debug.Log(GameManager.Instance().Players[0].GetComponent<PlayerAction>().Character.Name);

        }
	}
}
