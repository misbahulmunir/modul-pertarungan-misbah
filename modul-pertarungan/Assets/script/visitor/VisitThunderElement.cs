using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ModelModulPertarungan;
using Random = UnityEngine.Random;

namespace ModulPertarungan
{
	public class VisitThunderElement:Visitor
	{
        public override void ReceiveDamage(VisitableObject visitableObject, CardsEffect damageGiver, int damage)
        {

            if (visitableObject is ThunderMonster||visitableObject is Wizard)
            {
                var character = (DamageReceiver)visitableObject;
                var value = Random.Range(1, 3);
                if (damageGiver is WindCard)
                {
                    if (GameManager.Instance().GameMode == "pvp")
                    {
                        damage *= NetworkSingleton.Instance().Chance;
                    }
                    else
                    {
                        damage *= value;
                    }

                }
                else if (damageGiver is WaterCard)
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
