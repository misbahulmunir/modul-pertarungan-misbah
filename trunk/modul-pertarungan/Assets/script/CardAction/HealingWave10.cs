﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace ModulPertarungan
{
    public class HealingWave10 : HealingCard
    {
        void OnClick()
        {
            //Click();
        }
        // Use this for initialization
        void Start()
        {
            this.CardName = "Healing Wave 10";
            this.CardCost = 5;
            this.CardCode = " ";
            this.CardEffect = "Send a healing wave that heal all party 10 HP";
            this.DeckCost = 5;
            this.CardPower = 10;
        }

        // Update is called once per frame
        void Update()
        {

        }

        public override void Effect()
        {
            if (GameManager.instance.Players.Count > 0)
            {
                foreach (var obj in GameManager.instance.Players)
                {
                    var o = Instantiate(GameObject.Find("Small explosion"), new Vector3(obj.transform.position.x, obj.transform.position.y, -10f), Quaternion.identity) as GameObject;
                    if (o != null)
                    {
                        o.renderer.sortingLayerName = "foreground";
                        o.particleEmitter.emit = true;
                    }
                    //obj.GetComponent<DamageReceiverAction>().ReceiveDamage(50);
                    obj.GetComponent<PlayerAction>().Character.CurrentHealth += CardPower;
                }
            }

        }
    }
}