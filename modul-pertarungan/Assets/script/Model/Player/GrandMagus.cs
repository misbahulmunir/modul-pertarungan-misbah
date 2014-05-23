using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class GrandMagus : ModelModulPertarungan.Player
{
    public GrandMagus(int MaxHealth, int CurrentHealth, string Name, int HandCapacity)
        : base(MaxHealth, CurrentHealth, Name, HandCapacity)
    {
    }

    public GrandMagus()
    {
    }
}
