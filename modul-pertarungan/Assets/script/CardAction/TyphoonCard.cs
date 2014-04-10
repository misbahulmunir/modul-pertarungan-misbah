using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
namespace ModulPertarungan
{
	public class TyphoonCard:CardsEffect
	{
        void Start()
        {
            this.CardName = "Typhoon";
            this.CardCost = 5;
            this.CardCode = " ";
            this.CardEffect = " Deal 50 Wind damage to All enemy";
        }

        // Update is called once per frame
        void Update()
        {

        }

        public override void Effect()
        {
            foreach (GameObject obj in GameManager.Instance().Enemies)
            {
                GameObject animation = Instantiate(GameObject.Find("Fluffy Smoke Large"), new Vector3(obj.transform.position.x, obj.transform.position.y, -10f), Quaternion.identity) as GameObject;
                animation.renderer.sortingLayerName = "foreground";
                animation.particleEmitter.emit = true;
                obj.GetComponent<DamageReceiverAction>().ReceiveDamage(50);
            }

        }
	}
}
