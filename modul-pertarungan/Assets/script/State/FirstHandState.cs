using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
namespace ModulPertarungan
{
    public class FirstHandState : BattleState
    {
        public FirstHandState(GameObject CurrentPlayer)
            : base(CurrentPlayer)
        {
        }
        public override void Action()
        {
            CurrentPlayer.GetComponent<WarlockAction>().FirstHand();
        }
    }
}
