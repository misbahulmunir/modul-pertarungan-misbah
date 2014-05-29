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
        private BuffState _currenState;
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

        public BuffState CurrenState
        {
            get { return _currenState; }
            set { _currenState = value; }
        }

	    private List<Visitor> visitors;
	    private List<DamageReceiver> damageReceivers;

	    public void Instantiate()
	    {
	        visitors= new List<Visitor>();
            visitors.Add(new visitWaterElement());
            visitors.Add(new VisitEarthElement());
            visitors.Add(new VisitThunderElement());
            visitors.Add(new VisitFireElement());
            visitors.Add(new VisitFireElement());
            damageReceivers= new List<DamageReceiver>();
	    }
	    public virtual void ReceiveDamage(DamageReceiver damageReceiver,CardsEffect damageGiver,int damage)
	    {
	        Instantiate();
	        foreach (var visit in visitors)
	        {
	            damageReceiver.AcceptVisitor(visit,damageGiver,damage);
	        }
	        //if ((character.CurrentHealth - damage)<=0)
	        //{
	        //    character.CurrentHealth = 0;
	        //}
	        //else
	        //{
	        //    character.CurrentHealth -= damage;
	        //}

	    }
	}
}
