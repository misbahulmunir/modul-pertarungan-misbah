using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
namespace ModulPertarungan
{
    public class FireStorm : CardsEffect
    {
        
       
        // Use this for initialization
        void Start()
        {
            this.CardName = "Fire Storm";
            this.CardCost = 5;
            this.CardCode = " ";
            this.CardEffect = " Deal 50 fire damage to All enemy";
        }

        // Update is called once per frame
        void Update()
        {

        }

        public override void Effect()
        {
            if (GameManager.Instance().Enemies.Count > 0)
            {
                foreach (GameObject obj in GameManager.Instance().Enemies)
                {
                    GameObject animation = Instantiate(GameObject.Find("Small explosion"), new Vector3(obj.transform.position.x, obj.transform.position.y, -10f), Quaternion.identity) as GameObject;
                    animation.renderer.sortingLayerName = "foreground";
                    animation.particleEmitter.emit = true;
                    obj.GetComponent<DamageReceiverAction>().ReceiveDamage(50);
                }
                GameManager.Instance().KillObj("enemy");
            }

        }
    }
}
