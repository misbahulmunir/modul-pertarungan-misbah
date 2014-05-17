using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using ModelModulPertarungan;
namespace ModulPertarungan
{
	public  abstract class DamageReceiverAction:MonoBehaviour
	{
	    private BattleState _currenState;
        private Boolean isEnemy;

        public Boolean IsEnemy
        {
            get { return isEnemy; }
            set { isEnemy = value; }
        }
        private DamageReceiver character;

        public DamageReceiver Character
        {
            get { return character; }
            set { character = value; }
        }

	    public BattleState CurrenState
	    {
	        get { return _currenState; }
	        set { _currenState = value; }
	    }

	    public virtual void ReceiveDamage(int damage)
        {
            if ((character.CurrentHealth - damage)<=0)
            {
                character.CurrentHealth = 0;
            }
            else
            {
                character.CurrentHealth -= damage;
            }
           
        }
	}
}
