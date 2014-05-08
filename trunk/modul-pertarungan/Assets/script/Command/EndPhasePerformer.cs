using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModulPertarungan
{
	public class EndPhasePerformer
	{
	    public void EndPhaseExecute(EndPhaseCommand cmd)
	    {
            cmd.BStateManager.Currentstate=new DrawState(GameManager.Instance().CurrentPawn,cmd.BStateManager.objectLoader,cmd.BStateManager);
            cmd.BStateManager.Currentstate.Action();
	    }
	}
}
