using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
namespace ModulPertarungan
{
    public class EnemyState : BattleState
    {


        public EnemyState(List<GameObject> Players, List<GameObject> Enemy, BattleStateManager BattleManager)
            : base(Players, Enemy, BattleManager)
        {

        }
        public override void Action()
        {
            foreach (GameObject obj in this.Enemy)
            {
                obj.GetComponent<EnemyAction>().AttackAction();
            }

            BattleManager.EndButton.renderer.enabled = true;
            BattleManager.Cursor.renderer.enabled = true;
            BattleManager.Currentstate = new ChangePlayerState(GameManager.Instance().CurrentPawn, BattleManager.objectLoader, BattleManager);

        }
    }
}
