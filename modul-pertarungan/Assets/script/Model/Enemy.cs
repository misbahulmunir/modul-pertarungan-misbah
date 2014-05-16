using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
namespace ModelModulPertarungan
{
    public abstract class Enemy:DamageReceiver
    {
        public Enemy(int MaxHealth, int CurrentHealth, string Name)
            : base(MaxHealth, CurrentHealth, Name)
        {
        }

        private int _expForPlayer;
        private int _goldForPlayer;

        public int ExpForPlayer
        {
            get { return _expForPlayer; }
            set { _expForPlayer = value; }
        }

        public int GoldForPlayer
        {
            get { return _goldForPlayer; }
            set { _goldForPlayer = value; }
        }
    }
}
