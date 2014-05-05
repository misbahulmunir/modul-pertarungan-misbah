using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
namespace ModulPertarungan
{
    public class PvpEnemyState : BattleState
    {
        public PvpEnemyState(List<GameObject> Players, List<GameObject> Enemy, BattleStateManager BattleManager)
            : base(Players, Enemy, BattleManager)
        {

        }
        public override void Action()
        {
            string serverMessage = NetworkSingleton.Instance().ServerMessage;
            Debug.Log(serverMessage);
            string[] message = serverMessage.Split('-');
            if (serverMessage.Contains("PlayerList"))
            {
                BattleManager.EndButton.renderer.enabled = true;
                BattleManager.Cursor.renderer.enabled = true;
                BattleManager.Currentstate = new ChangePlayerState(GameManager.Instance().CurrentPawn, BattleManager.objectLoader, BattleManager);
                BattleManager.Currentstate.Action();
            }
          
        }
    }
}
