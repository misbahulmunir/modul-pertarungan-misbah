﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
namespace ModulPertarungan
{
    public class ChangePlayerState : BattleState
    {
        public ChangePlayerState(GameObject CurrentPlayer, GameObject ObjectLoader, BattleStateManager BattleManager)
            : base(CurrentPlayer, ObjectLoader,BattleManager)
        {

        }
        public override void Action()
        {
           
            this.ObjectLoader.GetComponent<BattleObjectLoader>().DestroyDisplayedCards();
            this.ObjectLoader.GetComponent<BattleObjectLoader>().LoadDisplayedCards(this.CurrentPlayer);
        }
    }
}