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

        private Deck deck;
        private GameObject sceneObject;

        public GameObject SceneObject
        {
            get { return sceneObject; }
            set { sceneObject = value; }
        }
        private List<GameObject> currentHand;
        public Deck Deck
        {
            get { return deck; }
            set { deck = value; }
        }

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

            if (GameManager.Instance().CurrentPawn.name == this.Character.Name)
            {
                GameObject.Find("Objcetloader").GetComponent<ObjectLoader>().LoadDisplayedCards(this.sceneObject);
            }
        }
        public void Draw()
        {
            if (Deck.Card.Count > 0 && currentHand.Count < 3)
            {
                
                currentHand.Add(Deck.Draw());
            }
        }
    }
}
