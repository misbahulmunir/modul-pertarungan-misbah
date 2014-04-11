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
        public List<GameObject> cards;

        public List<GameObject> Cards
        {
            get { return cards; }
            set { cards = value; }
        }

       

        
       
        void Start()
        {

            this.CurrentHand = new List<GameObject>();
            this.Deck = new Deck(cards);
            this.Warlock = new Warlock(200, 200, this.name, this.HandSize);
            this.SceneObject = this.gameObject;
            this.Character = Warlock;
            this.Deck.Shuffle();
            FirstPawnHand();
        }


        // Update is called once per frame
        void Update()
        {
            
        }


        public override void ReceiveDamage(int damage)
        {
            base.ReceiveDamage(damage);
        }
    }
}
