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
            foreach (GameObject obj in GameManager.Instance().Players)
            {
                var emptyhand = obj.GetComponent<PlayerAction>().HandSize - obj.GetComponent<PlayerAction>().CurrentHand.Count();
                for (int c = 0; c < emptyhand; c++)
                {
                    obj.GetComponent<PlayerAction>().Draw();
                }
            }
            BattleManager.Currentstate = new ChangePlayerState(CurrentPlayer, BattleManager.objectLoader, BattleManager);
            BattleManager.Currentstate.Action();
        }
    }
}
