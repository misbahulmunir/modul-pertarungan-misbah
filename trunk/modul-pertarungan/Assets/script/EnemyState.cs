using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
namespace ModulPertarungan
{
    public class EnemyState:BattleState
	{


        public EnemyState(GameObject CurrentPlayer, List<GameObject> Enemy)
            : base(CurrentPlayer, Enemy)
        {
 
        }
        public override void Action()
        {
            throw new NotImplementedException();
        }
    }
}
