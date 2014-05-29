﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
namespace ModulPertarungan
{
    public abstract class CardsEffect : MonoBehaviour
    {
        private int _deckCost;
        private string _cardEffect;

        public string CardEffect
        {
            get { return _cardEffect; }
            set { _cardEffect = value; }
        }

        private string _cardName;

        public string CardName
        {
            get { return _cardName; }
            set { _cardName = value; }
        }
        private string _cardCode;

        public string CardCode
        {
            get { return _cardCode; }
            set { _cardCode = value; }
        }
        private int _cardCost;

        public int CardCost
        {
            get { return _cardCost; }
            set { _cardCost = value; }
        }
        public virtual void Effect()
        {
        }
        private string _target;

        public string Target
        {
            get { return _target; }
            set { _target = value; }
        }
        private List<GameObject> _targetList;

        public List<GameObject> TargetList
        {
            get { return _targetList; }
            set { _targetList = value; }
        }

        public int DeckCost
        {
            get { return _deckCost; }
            set { _deckCost = value; }
        }

        private int _cardPower;

        public int CardPower
        {
            get { return _cardPower; }
            set { _cardPower = value; }
        }

        public void Click()
        {
            if (Application.loadedLevelName == "Battle"||Application.loadedLevelName=="OnlineBattle")
            {
                if (!(GameManager.Instance().BattleState is PvpEnemyState)&&!GameManager.Instance().PauseGame)
                {
                    GameManager.Instance().CurrentCard = this;
                    var obj = GameObject.Find("BattleStateManager").GetComponent<BattleStateManager>();
                    obj.Currentstate = new CardExcutionState(GameManager.Instance().CurrentPawn, obj, this.gameObject);
                }

            }
            GameManager.Instance().CurrentCard = this;
        }

        public void SetTarget(string targetEffect)
        {
            if (targetEffect != null) this.Target = targetEffect;
            if (_target.Equals("enemy"))
            {
                this.TargetList = GameManager.Instance().Enemies;
            }
            else if(_target.Equals("player"))
            {
                this.TargetList=GameManager.Instance().Players;
            }
        }
    }
}