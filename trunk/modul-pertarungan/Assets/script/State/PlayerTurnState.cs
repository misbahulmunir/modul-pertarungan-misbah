using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
namespace ModulPertarungan
{
	public class PlayerTurnState:BattleState
	{
        public PlayerTurnState(GameObject CurrentPlayer, BattleStateManager BattleManager)
            : base(CurrentPlayer, BattleManager)
        {

        }

       
        public override void Action()
        {
            throw new NotImplementedException();
        }
    }
}
