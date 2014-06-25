using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModelModulPertarungan
{
	public class Canotre : EarthMonster
	{
        public Canotre(int MaxHealth, int CurrentHealth, string MonsterName)
            : base(MaxHealth, CurrentHealth, MonsterName)
        {

        }
        public Canotre(int MaxHealth, int CurrentHealth, string MonsterName, int gold, int exp)
            : base(MaxHealth, CurrentHealth, MonsterName, gold, exp)
        {

        }
        public Canotre()
        {

        }
	}
}
