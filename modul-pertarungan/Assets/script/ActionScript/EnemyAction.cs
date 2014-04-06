using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
namespace ModulPertarungan
{
	public  abstract class EnemyAction: MonoBehaviour
	{
        public virtual void AttackAction()
        {
        }
        public virtual void ReceiveDamage()
        {
        }
	}
}
