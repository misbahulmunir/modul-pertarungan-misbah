using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using ModelModulPertarungan;
namespace ModulPertarungan
{
    public class WarlockAction : PlayerAction
    {
        // Use this for initialization
        public string Name;
        private Deck deck;
       
        private Warlock warlock;

        public Warlock Warlock
        {
            get { return warlock; }
            set { warlock = value; }
        }
        public int handSize;

        public int HandSize
        {
            get { return handSize; }
            set { handSize = value; }
        }

        private List<GameObject> hand;

        public List<GameObject> Hand
        {
            get { return hand; }
            set { hand = value; }
        }
        public List<GameObject> cards;

        public List<GameObject> Cards
        {
            get { return cards; }
            set { cards = value; }
        }

        public void AddCardtoHand()
        {
            hand.Add(deck.Draw());
        }
        public void FirstPawnHand()
        {
            for (int c = 0; c < handSize; c++)
            {
                if (deck.Card.Count > 0)
                {
                    this.CurrentHand.Add(deck.Draw());

                }
            }

            if (GameManager.Instance().CurrentPawn.GetComponent<WarlockAction>().warlock.Name == this.Warlock.Name)
            {
                GameObject.Find("Objcetloader").GetComponent<ObjectLoader>().LoadDisplayedCards(this.gameObject);
            }
        }
        public void Draw()
        {
            this.CurrentHand.Add(deck.Draw());
        }
       
        void Start()
        {

            this.CurrentHand = new List<GameObject>();
            deck = new Deck(cards);
            this.Warlock = new Warlock(200, 200, this.name, this.HandSize);
            this.Character = Warlock;
            deck.Shuffle();
            FirstPawnHand();
        }


        // Update is called once per frame
        void Update()
        {
           
        }

        public override void ReceiveDamage(int damage)
        {
            this.Warlock.ReceiveDamage(Warlock.MaxHealth, damage);
        }
    }
}
