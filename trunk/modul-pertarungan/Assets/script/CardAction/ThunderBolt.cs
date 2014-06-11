﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ModulPertarungan;
using UnityEngine;

namespace ModelModulPertarungan
{
	public class ThunderBolt:ThunderCard
	{
	    public void OnClick()
	    {
	        Click();
	    }
        void Start()
        {
            this.CardName = "Split Fire";
            this.CardCost = 2;
            this.CardCode = " ";
            this.CardEffect = " Deal 10 BoltDamage damage /n to single enemy";
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
                GameObject obj;
                obj = GameManager.Instance().GameMode == "pvp" ? TargetList[0] : TargetList.Find(GameManager.Instance().CurrentEnemy.Equals);
                var animation = Instantiate(GameObject.Find("Small explosion"), new Vector3(obj.transform.position.x, obj.transform.position.y, -10f), Quaternion.identity) as GameObject;
                if (animation != null)
                {
                    animation.renderer.sortingLayerName = "foreground";
                    animation.particleEmitter.emit = true;
                }
                obj.GetComponent<DamageReceiverAction>().ReceiveDamage(obj.GetComponent<DamageReceiverAction>().Character, this, 10);

            }
            GameManager.Instance().KillObj(Target);
        }
	}
}