using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using ModelModulPertarungan;
namespace ModulPertarungan
{
    public abstract class PlayerAction : DamageReceiverAction
    {
      

        private List<string> dataBaseCard;

        public List<string> DataBaseCard
        {
            get { return dataBaseCard; }
            set { dataBaseCard = value; }
        }
        private Deck deck;
        public Deck Deck
        {
            get { return deck; }
            set { deck = value; }
        }
        public List<GameObject> cards;

        public List<GameObject> Cards
        {
            get { return cards; }
            set { cards = value; }
        }
        private GameObject sceneObject;

        public GameObject SceneObject
        {
            get { return sceneObject; }
            set { sceneObject = value; }
        }
        private List<GameObject> currentHand;
       

        public int handSize;

        public int HandSize
        {
            get { return handSize; }
            set { handSize = value; }
        }


        public List<GameObject> CurrentHand
        {
            get { return currentHand; }
            set { currentHand = value; }
        }
        public void FirstPawnHand()
        {
            for (int c = 0; c < handSize; c++)
            {
                if (Deck.Card.Count > 0)
                {
                    this.CurrentHand.Add(Deck.Draw());

                }
            }
           
            if (GameManager.Instance().CurrentPawn.GetComponent<PlayerAction>().Character.Name == this.Character.Name&&GameManager.Instance().PlayerId!=null)
            {
                GameObject.Find("Objcetloader").GetComponent<BattleObjectLoader>().LoadDisplayedCards(this.sceneObject);
            }
        }
        public void Draw()
        {
            if (Deck.Card.Count > 0 && currentHand.Count < 3)
            {
                
                currentHand.Add(Deck.Draw());
            }
        }
        public void GetAllCard()
        {

            cards = new List<GameObject>();
            foreach (string t in GameManager.Instance().AllSelectedCard)
            {
                Cards.Add((GameObject)Resources.Load(t, typeof(GameObject)));
            }

        }
    }
}
