using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace ModelModulPertarungan
{
	public class Mandrake : EarthMonster
	{
        public Mandrake(int MaxHealth, int CurrentHealth, string MonsterName)
            : base(MaxHealth, CurrentHealth, MonsterName)
        {

        }
        public Mandrake(int MaxHealth, int CurrentHealth, string MonsterName, int gold, int exp)
            : base(MaxHealth, CurrentHealth, MonsterName, gold, exp)
        {

        }
        public Mandrake()
        {

        }
	}
}
