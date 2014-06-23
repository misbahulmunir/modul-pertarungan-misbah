using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
namespace ModulPertarungan
{
    public class DrawState : BattleState
    {
        public DrawState(GameObject CurrentPlayer, GameObject Objectloader, BattleStateManager BattleManager)
            : base(CurrentPlayer, Objectloader, BattleManager)
        {
        }

        public override void Action()
        {
            if (GameManager.Instance().GameMode == "pvp")
            {
                GameObject.Find("StatusLabel").GetComponent<UILabel>().text = "Your Turn";
            }
            int totalCards=0;
            foreach (GameObject obj in GameManager.Instance().Players)
            {
                totalCards += obj.GetComponent<PlayerAction>().Deck.Card.Count +
                              obj.GetComponent<PlayerAction>().CurrentHand.Count;
                var emptyhand = obj.GetComponent<PlayerAction>().HandSize - obj.GetComponent<PlayerAction>().CurrentHand.Count();
                for (int c = 0; c < emptyhand; c++)
                {
                    obj.GetComponent<PlayerAction>().Draw();
                }
               
            }
            if (totalCards == 0)
            {
                BattleManager.Currentstate= new LoseState(BattleManager);
                BattleManager.Currentstate.Action();
            }
            BattleManager.Currentstate = new ChangePlayerState(CurrentPlayer, BattleManager.objectLoader, BattleManager);
            BattleManager.Currentstate.Action();
        }
    }
}
