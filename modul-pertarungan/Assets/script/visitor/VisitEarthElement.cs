﻿using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ModelModulPertarungan;
namespace ModulPertarungan
{
    public class VisitEarthElement : Visitor
    {
        public override void ReceiveDamage(VisitableObject visitableObject, CardsEffect damageGiver, int damage)
        {
            if (visitableObject is EarthMonster|| visitableObject is Magician)
            {
                
                var character = (DamageReceiver)visitableObject;
                Debug.Log(character.Name);
                var value=0;
                if (GameManager.Instance().GameMode == "pvp")
                {
                    value = NetworkSingleton.Instance().Chance;
                }
                else
                {
                    value = Random.Range(1, 3);
                }
                if (damageGiver is FireCard)
                {
                        damage *= value;
                }
                else if (damageGiver is WindCard)
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
