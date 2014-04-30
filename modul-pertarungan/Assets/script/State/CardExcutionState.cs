using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
namespace ModulPertarungan
{
    public class CardExcutionState : BattleState
    {

        private bool isCardConfimed;

        public CardExcutionState(GameObject CurrentPlayer, BattleStateManager BattleManager, GameObject SelectedCard)
            : base(CurrentPlayer, BattleManager, SelectedCard)
        {

        }

        public override void Action()
        {
            GameObject gobj = null;
            SelectedCard.GetComponent<CardsEffect>().SetTarget("enemy");
            SelectedCard.GetComponent<CardsEffect>().Effect();
            foreach (GameObject obj in GameManager.Instance().CurrentPawn.GetComponent<PlayerAction>().CurrentHand)
            {
                if (this.SelectedCard.name == obj.name + "(Clone)")
                {
                    gobj = obj;
                    break;
                }
            }

            GameManager.Instance().CurrentPawn.GetComponent<PlayerAction>().CurrentHand.Remove(gobj);
            Destroy(this.SelectedCard);
            this.BattleManager.Currentstate = new ChangePlayerState(this.CurrentPlayer, this.BattleManager.objectLoader, this.BattleManager);
            this.BattleManager.Currentstate.Action();
        }
    }
}
