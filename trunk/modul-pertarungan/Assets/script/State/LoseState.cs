using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace ModulPertarungan
{
	public class LoseState:BattleState
	{
        public LoseState(BattleStateManager battleStateManager) : base(battleStateManager)
        {

        }
        public override void Action()
        {
            GameManager.Instance().GameStatus = "lose";
            Application.LoadLevel("AfterBattle2");
        }
    }
}
