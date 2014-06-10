using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModelModulPertarungan
{
    public class EarthMonster : Enemy
    {
        public EarthMonster(int MaxHealth, int CurrentHealth, string Name)
            : base(MaxHealth, CurrentHealth, Name)
        {
        }
          public EarthMonster(int MaxHealth, int CurrentHealth, string Name, int gold, int exp)
            : this(MaxHealth, CurrentHealth, Name)
        {
            
        }

        public EarthMonster()
        {

        }
    }
}
