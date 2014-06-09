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
            if (GameManager.Instance().GameMode == "pvp")
            {
                var succses = false;
                succses = NetworkSingleton.Instance().PlayerClient.Call<bool>("sendMessage", "SendMessage-" + NetworkSingleton.Instance().RoomName + "-" + GameManager.Instance().PlayerId + "-" + "Disconnected" + "-" + "Disconnected");
                Debug.Log(succses ? "send succes" : "send false");
            }
            GameManager.Instance().GameStatus = "lose";
            Application.LoadLevel("AfterBattle2");
        }
    }
}
