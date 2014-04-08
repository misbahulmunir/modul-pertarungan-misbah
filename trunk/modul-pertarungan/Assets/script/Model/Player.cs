using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace ModelModulPertarungan
{
    public abstract class Player : DamageReceiver
    {

        private int currentSoulPoints;

        public int CurrentSoulPoints
        {
            get { return currentSoulPoints; }
            set { currentSoulPoints = value; }
        }
        private int maxSoulPoints;

        public int MaxSoulPoints
        {
            get { return maxSoulPoints; }
            set { maxSoulPoints = value; }
        }

        private int handCapacity;

        public int HandCapacity
        {
            get { return handCapacity; }
            set { handCapacity = value; }
        }
        public Player(int MaxHealth, int CurrentHealth, string Name, int HandCapacity)
            : base(MaxHealth, CurrentHealth, Name)
        {
            this.HandCapacity = HandCapacity;
        }
    }
}