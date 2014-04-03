using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
namespace ModelModulPertarungan
{
    public abstract class Enemy:DamageReceiver
    {
        public Enemy(int MaxHealth, int CurrentHealth, string Name)
            : base(MaxHealth, CurrentHealth, Name)
        {
        }
    }
}
