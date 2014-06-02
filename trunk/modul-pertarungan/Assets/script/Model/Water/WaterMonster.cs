using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace ModelModulPertarungan
{
    public class WaterMonster :Enemy
    {
        public WaterMonster(int MaxHealth, int CurrentHealth, string Name)
            : base(MaxHealth, CurrentHealth, Name)
        {
        }
        public WaterMonster()
        {
        }
    }
}