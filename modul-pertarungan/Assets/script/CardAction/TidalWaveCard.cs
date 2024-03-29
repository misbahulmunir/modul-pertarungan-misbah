﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
namespace ModulPertarungan
{
	public class TidalWaveCard:WaterCard
	{

        void OnClick()
        {
            Click();  
        }
        void Start()
        {
            this.CardName = "Tidal Wave";
            this.CardCost = 10;
            this.CardCode = "";
            this.CardEffect = "Give 50 Water Attack To all enemies";
            this.DeckCost = 10;
        }
        void Update()
        {
            CheckIfCardCanBeCast();
           
        }
        public override void Effect()
        {
            if (TargetList.Count > 0)
            {
                GameObject.Find("Splash").GetComponent<AudioSource>().Play();
                foreach (GameObject obj in TargetList)
                {
                    var animation = Instantiate(GameObject.Find("WaterFall"), new Vector3(obj.transform.position.x, obj.transform.position.y, -10f), Quaternion.identity) as GameObject;
                    if (animation != null)
                    {
                        animation.renderer.sortingLayerName = "foreground";
                        animation.particleEmitter.emit = true;
                    }
                    obj.GetComponent<DamageReceiverAction>().ReceiveDamage(obj.GetComponent<DamageReceiverAction>().Character,this,50);
                }
                GameManager.Instance().KillObj(Target);
            }
        }
	}
}
