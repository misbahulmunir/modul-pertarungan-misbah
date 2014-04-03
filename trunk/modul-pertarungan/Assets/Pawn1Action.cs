using UnityEngine;
using System.Collections;
using System.Collections.Generic;
namespace ModulPertarungan
{
    public class Pawn1Action : MonoBehaviour
    {
        // Use this for initialization
        private Deck deck;
        public string pawnName;

        public string PawnName
        {
            get { return pawnName; }
            set { pawnName = value; }
        }
        public int maxPawnHealth;

        public int MaxPawnHealth
        {
            get { return maxPawnHealth; }
            set { maxPawnHealth = value; }
        }
        public int maxPawnSouls;

        public int MaxPawnSouls
        {
            get { return maxPawnSouls; }
            set { maxPawnSouls = value; }
        }
        public int currentPawnHealth;

        public int CurrentPawnHealth
        {
            get { return currentPawnHealth; }
            set { currentPawnHealth = value; }
        }
        public int currentPawnSouls;

        public int CurrentPawnSouls
        {
            get { return currentPawnSouls; }
            set { currentPawnSouls = value; }
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
            Debug.Log(GameMenager.Instance().CurrentPawn);
            if (GameMenager.Instance().CurrentPawn == this.pawnName)
            {
                for (int c = 0; c < handSize; c++)
                {
                    if (deck.Card.Count > 0)
                    {
                        Hand.Add(deck.Draw());

                    }
                }


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
