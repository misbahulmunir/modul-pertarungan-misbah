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
            if (GameManager.Instance().GameMode == "pvp")
            {
                bool succses = false;
                succses = NetworkSingleton.Instance().PlayerClient.Call<bool>("sendMessage", "SendMessage-" +GameManager.Instance().PartyId+"-"+GameManager.Instance().CurrentCard);
                Debug.Log(succses ? "send succes" : "send false");
            }
            else
            {
                SelectedCard.GetComponent<CardsEffect>().SetTarget("enemy");
                SelectedCard.GetComponent<CardsEffect>().Effect();
                var gobj = GameManager.Instance().CurrentPawn.GetComponent<PlayerAction>().CurrentHand.FirstOrDefault(obj => this.SelectedCard.name == obj.name + "(Clone)");
                GameManager.Instance().CurrentPawn.GetComponent<PlayerAction>().CurrentHand.Remove(gobj);
                Destroy(this.SelectedCard);
                this.BattleManager.Currentstate = new ChangePlayerState(this.CurrentPlayer,
                this.BattleManager.objectLoader, this.BattleManager);
                this.BattleManager.Currentstate.Action();
            }
        }
    }
}
