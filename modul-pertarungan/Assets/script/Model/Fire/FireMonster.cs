﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModelModulPertarungan
{
    public class FireMonster : Enemy
    {
        public FireMonster(int MaxHealth, int CurrentHealth, string Name)
            : base(MaxHealth, CurrentHealth, Name)
        {

        }
           public FireMonster(int MaxHealth, int CurrentHealth, string Name, int gold, int exp)
            : base(MaxHealth, CurrentHealth, Name, gold,  exp)
        {
            
        }
        public FireMonster()
        {

        }
    }
}