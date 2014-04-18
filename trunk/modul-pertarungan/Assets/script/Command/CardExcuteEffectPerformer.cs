using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModulPertarungan
{
	class CardExcuteEffectPerformer
	{
        private AbstractFactory factory;
        public void CardExecute(CardExecuteCommand cmd )
        {
            factory = new CardFactory();
            factory.InstatiateObject();
            factory.CreateCard(cmd.CardName);
        }
	}
}
