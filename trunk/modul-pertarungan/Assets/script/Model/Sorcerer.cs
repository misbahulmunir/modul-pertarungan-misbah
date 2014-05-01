using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModelModulPertarungan
{
    public class Sorcerer : Player
    {
        public Sorcerer(int MaxHealth, int CurrentHealth, string Name, int HandCapacity)
            : base(MaxHealth, CurrentHealth, Name,HandCapacity)
        {
        }
        public Sorcerer()
        {
        }
    }
}
