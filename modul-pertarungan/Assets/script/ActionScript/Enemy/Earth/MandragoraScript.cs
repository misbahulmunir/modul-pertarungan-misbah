﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using ModelModulPertarungan;

namespace ModulPertarungan
{
    public class MandragoraScript : EarthEnemyAction
    {
        private Mandragora mandragora;
        // Use this for initialization
        public override void AttackAction()
        {

            foreach (GameObject player in GameManager.Instance().Players)
            {
                GameObject animation = Instantiate(GameObject.Find("Small explosion"), new Vector3(player.transform.position.x, player.transform.position.y, -10f), Quaternion.identity) as GameObject;
                animation.renderer.sortingLayerName = "foreground";
                animation.particleEmitter.emit = true;
                player.GetComponent<DamageReceiverAction>().ReceiveDamage(player.GetComponent<DamageReceiverAction>().Character, new EarthCard(), 10);

            }
            GameManager.Instance().KillObj("player");
        }
        void Start()
        {
            this.mandragora = new Mandragora(200, 200, "mandragora", 200, 200);
            this.Character = mandragora;
        }


        // Update is called once per frame
        void Update()
        {

        }
        public override void ReceiveDamage(DamageReceiver damageReceiver, CardsEffect damageGiver, int damage)
        {
            this.Enemy = mandragora;
            base.ReceiveDamage(damageReceiver, damageGiver, damage);
        }
    }
}