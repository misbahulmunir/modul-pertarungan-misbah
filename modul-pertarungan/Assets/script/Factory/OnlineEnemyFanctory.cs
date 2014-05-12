using System.Collections.Generic;
using System.Linq;
using System.Text;
using ModelModulPertarungan;
using UnityEngine;
using System.Xml;
namespace ModulPertarungan
{
	public class OnlineEnemyFanctory:AbstractFactory
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

            WebServiceSingleton.GetInstance().processRequest("get_profile|" + id);
            xmlFromServer = WebServiceSingleton.GetInstance().xmLFromServer;
            var obj = Object.Instantiate((GameObject)Resources.Load(objectName, typeof(GameObject)), pawnsPosisition.transform.position, Quaternion.identity) as GameObject;
            if (obj == null) return;
            obj.transform.Rotate(new Vector3(0f,180f,0f));

            attributeNodes = xmlFromServer.GetElementsByTagName("MaxHP");
            character.CurrentHealth = character.MaxHealth = int.Parse(attributeNodes[0].InnerXml);
            attributeNodes = xmlFromServer.GetElementsByTagName("MaxSP");
            character.MaxSoulPoints = int.Parse(attributeNodes[0].InnerXml);
            attributeNodes = xmlFromServer.GetElementsByTagName("Name");
            character.Name = attributeNodes[0].InnerXml;
            attributeNodes = xmlFromServer.GetElementsByTagName("Gold");
            character.Gold = int.Parse(attributeNodes[0].InnerXml);

            //character.CurrentHealth = 200;
            //character.MaxHealth = 200;
            //character.MaxSoulPoints = 99;
            character.Name = id;
            //character.Gold = 100;
            obj.GetComponent<PlayerAction>().Character = character;
            GameManager.Instance().AddEnemy(obj);
            obj.GetComponent<PlayerAction>().IsEnemy = true;
            //Debug.Log(GameManager.Instance().Players[0].GetComponent<PlayerAction>().Character.Name);

        }
	}
}
