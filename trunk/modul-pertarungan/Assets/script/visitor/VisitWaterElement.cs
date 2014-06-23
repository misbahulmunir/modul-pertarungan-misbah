using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ModelModulPertarungan;
using Random = UnityEngine.Random;

namespace ModulPertarungan
{
    public class visitWaterElement : Visitor
    {
        public override void ReceiveDamage(VisitableObject visitableObject, CardsEffect damageGiver, int damage)
        {
            if (visitableObject is WaterMonster || visitableObject is Warlock)
            {
                var value = 0;
                var character = (DamageReceiver)visitableObject;
                if (GameManager.Instance().GameMode == "pvp")
                {
                    value = NetworkSingleton.Instance().Chance;
                }
                else
                {
                    value = Random.Range(1, 3);
                }
                if (damageGiver is ThunderCard)
                {
                        damage *= value;
                }
                else if(damageGiver is FireCard)
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
