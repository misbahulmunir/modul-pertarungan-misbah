using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ModulPertarungan;
using UnityEngine;
using System.Collections;

namespace ModulPertarungan
{
    public class ThunderBolt : ThunderCard
    {
        public void OnClick()
        {
            Click();
        }
        void Start()
        {
            this.CardName = "Thunder Bolt";
            this.CardCost = 5;
            this.CardCode = " ";
            this.CardEffect = " Deal 10 Thunder Damage s to single enemy";
            this.DeckCost = 5;

        }

        // Update is called once per frame
        void Update()
        {
            CheckIfCardCanBeCast();
        }

        public override void Effect()
        {
            if (TargetList.Count > 0)
            {
                GameObject.Find("Lightning").GetComponent<AudioSource>().Play();
                GameObject obj;
                obj = GameManager.Instance().GameMode == "pvp" ? TargetList[0] : TargetList.Find(GameManager.Instance().CurrentEnemy.Equals);
                var animation = Instantiate(GameObject.Find("FlareCoreAutumn"), new Vector3(obj.transform.position.x, obj.transform.position.y, -10f), Quaternion.identity) as GameObject;
                animation.GetComponent<ParticleSystem>().Play();
                Destroy(animation, animation.particleSystem.duration);
                if (animation != null)
                {
                    animation.renderer.sortingLayerName = "foreground";

                }
                obj.GetComponent<DamageReceiverAction>().ReceiveDamage(obj.GetComponent<DamageReceiverAction>().Character, this, 10);

            }
            GameManager.Instance().KillObj(Target);
        }

    }
}
