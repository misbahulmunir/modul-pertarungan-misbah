using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
namespace ModulPertarungan
{
    public class TyphoonCard : WindCard
    {
        void OnClick()
        {
            Click();  
        }
        void Start()
        {
            this.CardName = "Typhoon";
            this.CardCost = 5;
            this.CardCode = " ";
            this.CardEffect = " Deal 50 Wind damage to All enemy";
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
                foreach (GameObject obj in TargetList)
                {
                    GameObject animation = Instantiate(GameObject.Find("Fluffy Smoke Large"), new Vector3(obj.transform.position.x, obj.transform.position.y, -10f), Quaternion.identity) as GameObject;
                    if (animation != null)
                    {
                        animation.renderer.sortingLayerName = "foreground";
                        animation.particleEmitter.emit = true;
                    }
                    obj.GetComponent<DamageReceiverAction>().ReceiveDamage(50);
                }
                GameManager.Instance().KillObj(Target);
            }
        }
    }
}
