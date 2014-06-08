using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace ModulPertarungan
{
	public class WinState: BattleState
	{
        public WinState(BattleStateManager battleStateManager) : base(battleStateManager)
        {

        }
        public override void Action()
        {
            GameManager.Instance().GameStatus = "win";
            GameManager.Instance().PlayerExp = 100;
            GameManager.Instance().PlayerGold = 100;
            Application.LoadLevel("AfterBattle2");
        }
    }
}
