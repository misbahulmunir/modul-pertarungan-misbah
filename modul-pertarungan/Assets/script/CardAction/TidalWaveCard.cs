using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
namespace ModulPertarungan
{
	public class TidalWaveCard:CardsEffect
	{

       
        void Start()
        {
            this.CardName = "Tidal Wave";
            this.CardCost = 2;
            this.CardCode = "";
            this.CardEffect = "Give 50 Water Attack To all enemies";
        }
        void Update()
        {
            foreach (GameObject obj in GameManager.Instance().Enemies)
            {
                GameObject animation = Instantiate(GameObject.Find("WaterFall"), new Vector3(obj.transform.position.x, obj.transform.position.y, -10f), Quaternion.identity) as GameObject;
                animation.renderer.sortingLayerName = "foreground";
                animation.particleEmitter.emit = true;
                obj.GetComponent<DamageReceiverAction>().ReceiveDamage(50);
            }
           
        }
	}
}
