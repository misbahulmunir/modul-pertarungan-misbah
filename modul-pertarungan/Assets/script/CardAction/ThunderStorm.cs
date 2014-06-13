﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using System.Collections;

namespace ModulPertarungan
{
	public class ThunderStorm:ThunderCard
	{
        void OnClick()
        {
            Click();
        }
        void Start()
        {
            this.CardName = "Thunder Storm";
            this.CardCost = 25;
            this.CardCode = "";
            this.CardEffect = "Give Thunder Attack To all enemies";
            this.DeckCost = 10;
        }
        void Update()
        {


        }
        public override void Effect()
        {
            
         
        }
        public IEnumerator ThunderStormEffect()
        {
            if (TargetList.Count > 0)
            {
                
                foreach (GameObject obj in TargetList)
                {
                    var animation = Instantiate(GameObject.Find("FlareCoreAutumn"), new Vector3(obj.transform.position.x, obj.transform.position.y, -10f), Quaternion.identity) as GameObject;
                    animation.GetComponent<ParticleSystem>().Play();
                    Destroy(animation, animation.particleSystem.duration);
                    if (animation != null)
                    {
                        animation.renderer.sortingLayerName = "foreground";

                    }
                    obj.GetComponent<DamageReceiverAction>().ReceiveDamage(obj.GetComponent<DamageReceiverAction>().Character, this, 50);
                }
                GameManager.Instance().KillObj(Target);
                yield return new WaitForSeconds(10);
                Debug.Log("ten Seconds After yeild");
                
            }
        }
	}
}
