﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModelModulPertarungan
{
    public class EarthSpirit : EarthMonster
    {
        public EarthSpirit(int MaxHealth, int CurrentHealth, string MonsterName)
            : base(MaxHealth, CurrentHealth, MonsterName)
        {

        }

        public EarthSpirit()
        {

        }
    }
}