using UnityEngine;
using System.Collections;
using System.Collections.Generic;
namespace ModulPertarungan
{
    public class Pawn1Action : MonoBehaviour
    {
        // Use this for initialization
        private Deck deck;
        private int pawnName;

        public int PawnName
        {
            get { return pawnName; }
            set { pawnName = value; }
        }
        private int maxPawnHealth;

        public int MaxPawnHealth
        {
            get { return maxPawnHealth; }
            set { maxPawnHealth = value; }
        }
        private int maxPawnSouls;

        public int MaxPawnSouls
        {
            get { return maxPawnSouls; }
            set { maxPawnSouls = value; }
        }
        private int currentPawnHealth;

        public int CurrentPawnHealth
        {
            get { return currentPawnHealth; }
            set { currentPawnHealth = value; }
        }
        private int currentPawnSouls;

        public int CurrentPawnSouls
        {
            get { return currentPawnSouls; }
            set { currentPawnSouls = value; }
        }
        
        
        private int handSize;

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
        private List<GameObject> cards;

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
                Hand.Add(deck.Draw());
            }
        }
        
        void Start()
        {
            deck = new Deck(cards);
            FirstPawnHand();
        }


        // Update is called once per frame
        void Update()
        {
    
        }
    }
}
