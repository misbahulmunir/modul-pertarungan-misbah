using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace ModulPertarungan
{
    public class HealingLight100 : HealingCard
    {
        void OnClick()
        {
            //Click();
        }
        // Use this for initialization
        void Start()
        {
            this.CardName = "Healing Light 100";
            this.CardCost = 7;
            this.CardCode = " ";
            this.CardEffect = "Call a Light from heaven that heal self 100 HP";
            this.DeckCost = 7;
            this.CardPower = 100;
        }

        // Update is called once per frame
        void Update()
        {

        }

        public override void Effect()
        {
            if (GameManager.instance.Players.Count > 0)
            {
                var obj = GameManager.Instance().CurrentPawn;
                obj.GetComponent<PlayerAction>().Character.CurrentHealth += CardPower;
            }

        }
    }
}
