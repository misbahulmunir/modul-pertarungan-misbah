using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModulPertarungan
{
	public class EndPhaseCommand:Command
	{
	    public BattleStateManager BStateManager;
        public override void Execute()
        {
           new EndPhasePerformer().EndPhaseExecute(this);
        }

	    public EndPhaseCommand(BattleStateManager BStateManager)
	    {
	        this.BStateManager = BStateManager;

	    }

	    public override void Initialization()
        {
            
        }

    }
}
