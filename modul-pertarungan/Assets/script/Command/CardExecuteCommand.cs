using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace ModulPertarungan
{
	public class CardExecuteCommand:Command
	{
        public string CardName;
	    public string Target;
        public override void Initialization()
        {
            
        }
        public override void Execute()
        {
            Debug.Log(CardName);
            new CardExcuteEffectPerformer().CardExecute(this);
        }

	    public CardExecuteCommand(String cardName,String target)
	    {
	        this.CardName = cardName;
	    }

	}
}
