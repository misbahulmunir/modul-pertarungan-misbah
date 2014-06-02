
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ModelModulPertarungan;
using  UnityEngine;

namespace ModulPertarungan
{
	public class VisitFireElement:Visitor
	{
        public override void ReceiveDamage(VisitableObject visitableObject, CardsEffect damageGiver, int damage)
        {
            if (visitableObject is FireMonster|| visitableObject is Sorcerer)
            {
                var character = (DamageReceiver)visitableObject;
                Debug.Log(character.Name);
                var value = Random.Range(1, 3);
                if (damageGiver is WaterCard)
                {
                    damage *= value;
                    Debug.Log(value);
                }
                else if(damageGiver is WindCard)
                {
                    damage /= value;
                }
                if ((character.CurrentHealth - damage) <= 0)
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
}
