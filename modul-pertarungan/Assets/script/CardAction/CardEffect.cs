﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
namespace ModulPertarungan
{
    public abstract class CardsEffect : MonoBehaviour
    {
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
                var obj = GameObject.Find("BattleStateManager").GetComponent<BattleStateManager>();
                obj.Currentstate = new CardExcutionState(GameManager.Instance().CurrentPawn, obj, this.gameObject);
            }
            GameManager.Instance().CurrentCard = this;
            if (GameManager.Instance().GameMode != "pvp") return;
            var invoke= new Invoker();
            invoke.AddCommand(new CardExecuteCommand(this.CardName));
            invoke.RunCommand();
        }

        public void SetTarget(string Target)
        {
            if (Target != null) this.Target = Target;
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