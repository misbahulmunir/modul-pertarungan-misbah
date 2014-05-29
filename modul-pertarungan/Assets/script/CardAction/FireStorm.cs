using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ModelModulPertarungan;
using UnityEngine;
namespace ModulPertarungan
{
    public class FireStorm : FireCard
    {

        void OnClick()
        {
            Click();  
        }
        // Use this for initialization
        void Start()
        {
            this.CardName = "Fire Storm";
            this.CardCost = 5;
            this.CardCode = " ";
            this.CardEffect = " Deal 50 fire damage to All enemy";
            this.DeckCost = 5;
        }

        // Update is called once per frame
        void Update()
        {

        }

        public override void Effect()
        {
            if (TargetList.Count > 0)
            {
                foreach (var obj in TargetList)
                {
                    var o = Instantiate(GameObject.Find("Small explosion"), new Vector3(obj.transform.position.x, obj.transform.position.y, -10f), Quaternion.identity) as GameObject;
                    if (o != null)
                    {
                        o.renderer.sortingLayerName = "foreground";
                        o.particleEmitter.emit = true;
                    }
                    obj.GetComponent<DamageReceiverAction>().ReceiveDamage(obj.GetComponent<DamageReceiverAction>().Character, this, 50);
                }
                GameManager.Instance().KillObj(Target);
            }

        }
    }
}
