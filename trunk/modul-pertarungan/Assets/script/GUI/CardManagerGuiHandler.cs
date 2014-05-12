using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
namespace ModulPertarungan
{
	public class CardManagerGuiHandler:MonoBehaviour
	{
        public GameObject cardName;
        public GameObject cardCost;
        public GameObject cardEffect;
        private CardsEffect currentCard;
	    public GameObject deckCost;
        void Start()
        {
            
        }
        void Update()
        {
            currentCard = GameManager.Instance().CurrentCard;
            if (currentCard != null)
            {
                cardName.GetComponent<UILabel>().text = currentCard.CardName;
                cardCost.GetComponent<UILabel>().text = currentCard.CardCost.ToString();
                cardEffect.GetComponent<UILabel>().text = currentCard.CardEffect;
                deckCost.GetComponent<UILabel>().text = currentCard.DeckCost.ToString();
            }
        }
	}
}
