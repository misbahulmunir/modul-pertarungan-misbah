using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using ModelModulPertarungan;
namespace ModulPertarungan
{
    public class FireDragonScript : EnemyAction
    {


        private FireDragon firedragon;
        // Use this for initialization
        public override void AttackAction()
        {
            List<GameObject> death = new List<GameObject>();
            foreach (GameObject player in GameManager.Instance().Players)
            {
                GameObject animation = Instantiate(GameObject.Find("Small explosion"), new Vector3(player.transform.position.x, player.transform.position.y, -10f), Quaternion.identity) as GameObject;
                animation.renderer.sortingLayerName = "foreground";
                animation.particleEmitter.emit = true;
                player.GetComponent<DamageReceiverAction>().ReceiveDamage(100);
         
            }
            GameManager.Instance().KillObj("player");
        }
        void Start()
        {
            firedragon = new FireDragon(200, 200, name);
            this.Character = firedragon;
            
        }


        // Update is called once per frame
        void Update()
        {
            
        }
        public override void ReceiveDamage(int damage)
        {
            base.ReceiveDamage( damage);
            if (this.firedragon.CurrentHealth <= 0)
            {
                
                GameManager.Instance().KillObj("enemy");
                Destroy(this.gameObject);
            }
           
            Debug.Log(GameManager.Instance().Enemies.Count);
        }
    }
}