using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using ModelModulPertarungan;
namespace ModulPertarungan
{
    public class Pawn1Action : MonoBehaviour
    {
        // Use this for initialization
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
            Debug.Log(GameMenager.Instance().CurrentPawn.GetComponent<Pawn1Action>().warlock.Name);

            for (int c = 0; c < handSize; c++)
            {
                if (deck.Card.Count > 0)
                {
                    Hand.Add(deck.Draw());

                }
            }

            if (GameMenager.Instance().CurrentPawn.GetComponent<Pawn1Action>().Warlock.Name == this.Warlock.Name)
            {
                GameObject.Find("Objcetloader").GetComponent<ObjectLoader>().LoadDisplayedCards(this.gameObject);
            }
        }
        public void Draw()
        {
            this.Hand.Add(deck.Draw());
        }
       
        void Start()
        {

            hand = new List<GameObject>();
            deck = new Deck(cards);
            deck.Shuffle();
            FirstPawnHand();
        }


        // Update is called once per frame
        void Update()
        {
           
        }
    }
}
