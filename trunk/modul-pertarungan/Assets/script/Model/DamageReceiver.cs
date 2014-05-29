using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ModulPertarungan;

namespace ModelModulPertarungan
{
    public abstract class DamageReceiver:VisitableObject
    {
        private int maxHealth;
       
        public int MaxHealth
        {
            get { return maxHealth; }
            set { maxHealth = value; }
        }
        private int currentHealth;

        public int CurrentHealth
        {
            get { return currentHealth; }
            set { currentHealth = value; }
        }

        private string element;

        public void ReceiveDamage(int MaxHealth, int Damage)
        {
            

        }

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Element
        {
            get { return element; }
            set { element = value; }
        }

        public DamageReceiver(int MaxHealth)
        {
            this.MaxHealth = MaxHealth;
        }
        public DamageReceiver(int MaxHealth, int CurrentHealth)
            : this(MaxHealth)
        {
            this.CurrentHealth = CurrentHealth;
        }
        public DamageReceiver(int MaxHealth, int CurrentHealth, string Name)
            : this(MaxHealth, CurrentHealth)
        {
            this.Name = Name;
        }
        public DamageReceiver()
        {
        }
    }
}