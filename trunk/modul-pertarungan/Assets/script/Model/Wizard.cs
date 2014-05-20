using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Wizard : ModelModulPertarungan.Player
{
    public Wizard(int MaxHealth, int CurrentHealth, string Name, int HandCapacity)
        : base(MaxHealth, CurrentHealth, Name, HandCapacity)
    {
    }

    public Wizard()
    {

    }
}
