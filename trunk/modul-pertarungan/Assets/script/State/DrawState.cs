using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
namespace ModulPertarungan
{
	public class DrawState:BattleState
	{

        public DrawState(GameObject CurrentPlayer)
            : base(CurrentPlayer)
        {
        }

        public override void Action()
        {
            this.CurrentPlayer.GetComponent<WarlockAction>().Draw();
        }
    }
}
