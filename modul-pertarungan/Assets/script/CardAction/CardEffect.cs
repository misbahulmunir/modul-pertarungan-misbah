﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
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
        private string target;

        public string Target
        {
            get { return target; }
            set { target = value; }
        }
        private List<GameObject> targetList;

        public List<GameObject> TargetList
        {
            get { return targetList; }
            set { targetList = value; }
        }
        public void Click()
        {
            if (Application.loadedLevelName == "Battle")
            {
                GameManager.Instance().CurrentCard = this;
                BattleStateManager obj = GameObject.Find("BattleStateManager").GetComponent<BattleStateManager>();
                obj.Currentstate = new CardExcutionState(GameManager.Instance().CurrentPawn, obj, this.gameObject);
            }
            GameManager.Instance().CurrentCard = this;
        }

        public void SetTarget(string Target)
        {
            this.Target = Target;
            if (target.Equals("enemy"))
            {
                this.TargetList = GameManager.Instance().Enemies;
            }
            else if(target.Equals("player"))
            {
                this.TargetList=GameManager.Instance().Players;
            }
        }

    }
}