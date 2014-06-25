using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace ModelModulPertarungan
{
    public class WindKingSlime : WindMonster
    {
        public WindKingSlime(int MaxHealth, int CurrentHealth, string Name)
            : base(MaxHealth, CurrentHealth, Name)
        {
        }
        public WindKingSlime(int MaxHealth, int CurrentHealth, string Name, int gold, int exp)
            : base(MaxHealth, CurrentHealth, Name, gold, exp)
        {
        }
        public WindKingSlime()
        {
        }
    }
}
