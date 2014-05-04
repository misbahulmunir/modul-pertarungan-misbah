
using System.Collections.Generic;
using UnityEngine;
using ModelModulPertarungan;
namespace ModulPertarungan
{
	public class PlayerFactory:AbstractFactory
	{
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
            instantiateObjectList = new Dictionary<string, Player>();
            instantiateObjectList.Add("warlock", new Warlock());
            instantiateObjectList.Add("sorcerer", new Sorcerer());
            instantiateObjectList.Add("magician", new Magician());
        }
        public override void CreatePlayer(string Id, string Job, string ObjectName, GameObject pawnsPosisition)
        {
            instantiateObjectList.TryGetValue(Job, out character);
            GameObject obj = Object.Instantiate((GameObject)Resources.Load(ObjectName, typeof(GameObject)), pawnsPosisition.transform.position, Quaternion.identity) as GameObject;
            character.CurrentHealth = 200;
            character.MaxHealth = 200;
            character.MaxSoulPoints = 99;
            character.Name = Id;
            character.Gold = 100;
            obj.GetComponent<PlayerAction>().Character = character;
            GameManager.Instance().AddPlayer(obj);
            GameManager.Instance().CurrentPawn = obj;
            //Debug.Log(GameManager.Instance().Players[0].GetComponent<PlayerAction>().Character.Name);
          
        }
	}
}
