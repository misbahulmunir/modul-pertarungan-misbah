using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace ModelModulPertarungan
{
    public class Magician : Player
    {
        public Magician(int MaxHealth, int CurrentHealth, string Name, int HandCapacity)
            : base(MaxHealth, CurrentHealth, Name, HandCapacity )
        {
        }
        public Magician()
        {
        }
    }
}
