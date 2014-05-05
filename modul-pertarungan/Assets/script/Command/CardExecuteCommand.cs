using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModulPertarungan
{
	public class CardExecuteCommand:Command
	{
        public string CardName;
        public override void Initialization()
        {
            
        }
        public override void Execute()
        {
            new CardExcuteEffectPerformer().CardExecute(this);
        }

        
    }
}
