﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
namespace ModulPertarungan
{
    public class WaterAttackAction : WaterCard
    {
        void OnClick()
        {
            Click();  
        }
        
        // Use this for initialization
        void Start()
        {
            this.CardName = "Watter Attack";
            this.CardCost = 2;
            this.CardCode = "";
            this.CardEffect = "Give 10 watter damage to single enemy";
            this.DeckCost = 2;

        }

        // Update is called once per frame
        void Update()
        {
           
           
        }

        public override void Effect()
        {
            if (TargetList.Count > 0)
            {
                GameObject.Find("Splash").GetComponent<AudioSource>().Play();
                GameObject obj = GameManager.Instance().GameMode == "pvp" ? TargetList[0] : TargetList.Find(GameManager.Instance().CurrentEnemy.Equals);
                GameObject animation = Instantiate(GameObject.Find("WaterFall"), new Vector3(obj.transform.position.x, obj.transform.position.y, -10f), Quaternion.identity) as GameObject;
                animation.renderer.sortingLayerName = "foreground";
                animation.particleEmitter.emit = true;
                obj.GetComponent<DamageReceiverAction>().ReceiveDamage(obj.GetComponent<DamageReceiverAction>().Character, this, 10);
            }
            GameManager.Instance().KillObj(Target);
        }
    }
}
