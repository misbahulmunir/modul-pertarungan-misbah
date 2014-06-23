using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
namespace ModulPertarungan
{
    public class PvpEnemyState : BattleState
    {
        public PvpEnemyState(BattleStateManager battleStateManager) : base(battleStateManager)
        {

        }

        public override void Action()
        {
            try
            {
                BattleManager.endButton.SetActive(false);
                GameObject.Find("StatusLabel").GetComponent<UILabel>().text = "Enemy Turn";
            }
            catch (Exception e)
            {
                Debug.Log("errorpvpstate" + e.Message);
            }
        }
    }
}
