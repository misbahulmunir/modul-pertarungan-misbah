
using System.Collections.Generic;
using UnityEngine;
using ModelModulPertarungan;
using System.Xml;

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
            WebServiceSingleton.GetInstance().createXMLDocument("get_profile|" + id);
            xmlFromServer = WebServiceSingleton.GetInstance().xmLFromServer;
            Debug.Log(WebServiceSingleton.GetInstance().responseFromServer);
            var obj = Object.Instantiate((GameObject)Resources.Load(objectName, typeof(GameObject)), pawnsPosisition.transform.position, Quaternion.identity) as GameObject;
            //terhubung dengan web service dan database lokal......
            //untuk mencoba apk tanpa terhubung web service, comment bagian ini dan un-comment bagian yang ada di bawah
            //batas awal comment
            attributeNodes = xmlFromServer.GetElementsByTagName("MaxHP");
            character.CurrentHealth = character.MaxHealth = int.Parse(attributeNodes[0].InnerXml);
            attributeNodes = xmlFromServer.GetElementsByTagName("MaxSP");
            character.MaxSoulPoints = int.Parse(attributeNodes[0].InnerXml);
            attributeNodes = xmlFromServer.GetElementsByTagName("Name");
            character.Name = attributeNodes[0].InnerXml;
            attributeNodes = xmlFromServer.GetElementsByTagName("Gold");
            character.Gold = int.Parse(attributeNodes[0].InnerXml);
            //batas akhir comment
            //batas awal un-comment
            //character.CurrentHealth = 200;
            //character.MaxHealth = 200;
            //character.MaxSoulPoints = 99;
            //character.Name = Id;
            //batas akhir un-commen
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
