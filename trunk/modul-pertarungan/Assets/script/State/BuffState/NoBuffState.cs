using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace ModulPertarungan
{
	public class NoBuffState:BuffState
	{
	    public NoBuffState(GameObject buffgGameObject, DamageReceiverAction dmReceiverAction) : base(buffgGameObject, dmReceiverAction)
	    {
	    }

        public override void Action()
        {
            throw new NotImplementedException();
        }
    }
}
