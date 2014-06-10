using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ModelModulPertarungan;
using UnityEngine;
namespace ModulPertarungan
{
	public  abstract class EnemyAction:DamageReceiverAction
	{
	    private Enemy enemy;

	    public Enemy Enemy
	    {
	        get { return enemy; }
	        set { enemy = value; }
	    }

	    public virtual void AttackAction()
        {
           
        }

        public override void ReceiveDamage(DamageReceiver damageReceiver, CardsEffect damageGiver, int damage)
        {
            base.ReceiveDamage(damageReceiver, damageGiver, damage);
            if (this.enemy.CurrentHealth <= 0)
            {
                Destroy(this.gameObject);
                GameManager.Instance().PlayerGold += enemy.GoldForPlayer;
                GameManager.Instance().PlayerExp += enemy.ExpForPlayer;

            }
            
            Debug.Log(GameManager.Instance().Enemies.Count);
        }
	}
}
