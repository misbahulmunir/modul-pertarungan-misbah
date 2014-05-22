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

        public Enemy()
        {

        }

        private int _expForPlayer;
        private int _goldForPlayer;
        private List<String> _playerGetItem;
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

        public List<string> PlayerGetItem
        {
            get { return _playerGetItem; }
            set { _playerGetItem = value; }
        }
    }
}
