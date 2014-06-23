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
            if (GameManager.Instance().GameMode == "pvp")
            {
                WebServiceSingleton.GetInstance().ProcessRequest("send_battle_result", GameManager.Instance().PlayerId + "|" + GameManager.Instance().CurrentEnemy.GetComponent<PlayerAction>().Character.Name);
            }
            GameManager.Instance().GameStatus = "win";
            Application.LoadLevel("AfterBattle2");
        }
    }
}
