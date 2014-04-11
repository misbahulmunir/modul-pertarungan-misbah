﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
namespace ModulPertarungan
{
    public class WaterAttackAction : CardsEffect
    {
        
        // Use this for initialization
        void Start()
        {
            this.CardName = "Watter Attack";
            this.CardCost = 2;
            this.CardCode = "";
            this.CardEffect = "Give 10 watter damage to single enemy";

        }

        // Update is called once per frame
        void Update()
        {
            GameObject obj = GameManager.Instance().Enemies[0];
            GameObject animation = Instantiate(GameObject.Find("WaterFall"), new Vector3(obj.transform.position.x, obj.transform.position.y, -10f), Quaternion.identity) as GameObject;
            animation.renderer.sortingLayerName = "foreground";
            animation.particleEmitter.emit = true;
            obj.GetComponent<DamageReceiverAction>().ReceiveDamage(10);
           
        }

        public override void Effect()
        {
            
        }
    }
}