using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using ModelModulPertarungan;

namespace ModulPertarungan
{
    public class EarthSlimeScript : EnemyAction
    {
        private EarthSlime earthslime;
        // Use this for initialization
        public override void AttackAction()
        {

            foreach (GameObject player in GameManager.Instance().Players)
            {
                GameObject animation = Instantiate(GameObject.Find("Small explosion"), new Vector3(player.transform.position.x, player.transform.position.y, -10f), Quaternion.identity) as GameObject;
                animation.renderer.sortingLayerName = "foreground";
                animation.particleEmitter.emit = true;
                player.GetComponent<DamageReceiverAction>().ReceiveDamage(10);

            }
            GameManager.Instance().KillObj("player");
        }
        void Start()
        {
            this.earthslime = new EarthSlime(200, 200, "earthslime");
            this.Character = earthslime;
        }


        // Update is called once per frame
        void Update()
        {

        }
        public override void ReceiveDamage(int damage)
        {
            base.ReceiveDamage(damage);
            if (this.earthslime.CurrentHealth <= 0)
            {
                Destroy(this.gameObject);
            }

            Debug.Log(GameManager.Instance().Enemies.Count);
        }
    }
}