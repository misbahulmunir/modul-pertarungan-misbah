﻿using UnityEngine;
using System.Collections;

namespace ModulPertarungan
{
    public abstract class CardsEffect : MonoBehaviour
    {
        private string cardEffect;

        public string CardEffect
        {
            get { return cardEffect; }
            set { cardEffect = value; }
        }

        private string cardName;

        public string CardName
        {
            get { return cardName; }
            set { cardName = value; }
        }
        private string cardCode;

        public string CardCode
        {
            get { return cardCode; }
            set { cardCode = value; }
        }
        private int cardCost;

        public int CardCost
        {
            get { return cardCost; }
            set { cardCost = value; }
        }
        public virtual void Effect()
        {
        }

    }
}