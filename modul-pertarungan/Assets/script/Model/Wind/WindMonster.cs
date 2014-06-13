using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace ModelModulPertarungan
{
    public class WindMonster : Enemy
    {
        public WindMonster(int MaxHealth, int CurrentHealth, string Name)
            : base(MaxHealth, CurrentHealth, Name)
        {
        }
        public WindMonster(int MaxHealth, int CurrentHealth, string Name, int gold, int exp)
            : base(MaxHealth, CurrentHealth, Name)
        {
            
        }

        public WindMonster()
        {
        }
    }
}
