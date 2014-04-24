using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
namespace ModulPertarungan
{
	public class CardFactory:AbstractFactory
	{
        Dictionary<String, GameObject> ListCard;
        GameObject card;
        public override void InstantiateObject()
        {
            ListCard = new Dictionary<string, GameObject>();
            foreach (GameObject obj in GameManager.Instance().AllCards)
            {
                ListCard.Add(obj.GetComponent<CardsEffect>().name, obj);
            }
        }
        public override void CreateObject(string Objectname)
        {
            ListCard.TryGetValue(Objectname, out card);
        }
	}
}
