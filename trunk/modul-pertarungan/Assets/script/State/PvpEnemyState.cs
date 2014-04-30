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
            throw new NotImplementedException();
        }
    }
}
