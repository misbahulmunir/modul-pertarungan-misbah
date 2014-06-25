using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using ModelModulPertarungan;
namespace ModulPertarungan
{
    public class WaterNymphScript : WaterEnemyAction
    {
        private WaterNymph waternymph;
        // Use this for initialization
        public override void AttackAction()
        {

            foreach (GameObject player in GameManager.Instance().Players)
            {
                GameObject animation = Instantiate(GameObject.Find("Small explosion"), new Vector3(player.transform.position.x, player.transform.position.y, -10f), Quaternion.identity) as GameObject;
                animation.renderer.sortingLayerName = "foreground";
                animation.particleEmitter.emit = true;
                player.GetComponent<DamageReceiverAction>().ReceiveDamage(player.GetComponent<DamageReceiverAction>().Character, new WaterCard(), 10);

            }
            GameManager.Instance().KillObj("player");
        }
        void Start()
        {
            this.waternymph = new WaterNymph(200, 200, "waternymph", 200, 200);
            this.Character = waternymph;
        }


        // Update is called once per frame
        void Update()
        {

        }
        public override void ReceiveDamage(DamageReceiver damageReceiver, CardsEffect damageGiver, int damage)
        {
            this.Enemy = waternymph;
            base.ReceiveDamage(damageReceiver, damageGiver, damage);
  
        }
    }
}