using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        public override Player CreatePlayer(string Id, string Job)
        {
            instantiateObjectList.TryGetValue(Job, out character);
            // isi dari data base


            //
            return Character;
        }
	}
}
