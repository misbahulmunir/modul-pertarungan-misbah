using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using ModelModulPertarungan;
namespace ModulPertarungan
{
    public class WarlockAction : PlayerAction
    {
        // Use this for initialization
        private Warlock warlock;

        public Warlock Warlock
        {
            get { return warlock; }
            set { warlock = value; }
        }
        
        void Awake()
        {  
            
        }
        void Start()
        {
            InstanceCard();
            this.CurrentHand = new List<GameObject>();
            this.Deck = new Deck(cards);
            this.SceneObject = this.gameObject;
            this.Deck.Shuffle();
            FirstHand();  
        }


        // Update is called once per frame
        void Update()
        {
           
        }



        public override void ReceiveDamage(DamageReceiver damageReceiver, CardsEffect damageGiver, int damage)
        {
            base.ReceiveDamage(damageReceiver, damageGiver, damage);
            if (this.Character.CurrentHealth <= 0)
            {
                GameManager.Instance().CurrentPawn = null;
                Destroy(this.gameObject);
            }

        }
    }
}
