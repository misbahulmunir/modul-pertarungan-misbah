using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace ModelModulPertarungan
{
    public class FireNymph : FireMonster
    {
        public FireNymph(int MaxHealth, int CurrentHealth, string MonsterName)
            : base(MaxHealth, CurrentHealth, MonsterName)
        {

        }
        public FireNymph(int MaxHealth, int CurrentHealth, string MonsterName, int gold, int exp)
            : base(MaxHealth, CurrentHealth, MonsterName, gold, exp)
        {

        }
        public FireNymph()
        {

        }
    }
}
