using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace ModelModulPertarungan
{
    public abstract class Player : DamageReceiver
    {
        private List<string> deckList;

        public List<string> DeckList
        {
            get { return deckList; }
            set { deckList = value; }
        }
      

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
        private int experience;

        public int Experience
        {
            get { return experience; }
            set { experience = value; }
        }
        private int gold;

        public int Gold
        {
            get { return gold; }
            set { gold = value; }
        }

        private int rank;

        public int Rank
        {
            get { return rank; }
            set { rank = value; }
        }

        public Player(int MaxHealth, int CurrentHealth, string Name, int HandCapacity)
            : base(MaxHealth, CurrentHealth, Name)
        {
            this.HandCapacity = HandCapacity;
        }
        public Player(int MaxHealth, int CurrentHealth, string Name, int HandCapacity, int MaxSoulPoints, int CurrentSoulPoints)
            : this(MaxHealth, CurrentHealth, Name, HandCapacity)
        {
            this.maxSoulPoints = MaxSoulPoints;
            this.currentSoulPoints = CurrentSoulPoints;
        }

        public Player(int MaxHealth, int CurrentHealth, string Name, int MaxSoulPoints, int CurrentSoulPoints, int HandCapacity, int Experience, int Gold)
            : this
                (MaxHealth, CurrentHealth, Name, HandCapacity, MaxSoulPoints, CurrentSoulPoints)
        {
            this.Experience = Experience;
            this.Gold = Gold;
            this.Rank = Rank;
        }

        public Player()
        {
        }


    }
}