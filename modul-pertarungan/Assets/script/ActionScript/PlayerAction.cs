using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using ModelModulPertarungan;
namespace ModulPertarungan
{
	public abstract class PlayerAction:DamageReceiverAction
	{

        private List<GameObject> currentHand;

        public List<GameObject> CurrentHand
        {
            get { return currentHand; }
            set { currentHand = value; }
        }
	}
}
