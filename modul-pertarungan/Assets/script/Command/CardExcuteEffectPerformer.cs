using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModulPertarungan
{
	class CardExcuteEffectPerformer
	{
        private AbstractFactory _factory;
        public void CardExecute(CardExecuteCommand cmd )
        {
            _factory = new CardEffecFactory();
            _factory.InstantiateObject();
            _factory.CreateCard(cmd.CardName,"player");
        }
	}
}
