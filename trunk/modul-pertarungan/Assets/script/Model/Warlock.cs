﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace ModelModulPertarungan
{
    public class Warlock : Player
    {
        public Warlock(int MaxHealth, int CurrentHealth, string Name, int HandCapacity,int MaxSoulPoints, int currentSoulPoints)
            : base(MaxHealth, CurrentHealth,Name ,HandCapacity,MaxSoulPoints,currentSoulPoints)
        {
        }
        public Warlock()
        {
        }
    }
}
