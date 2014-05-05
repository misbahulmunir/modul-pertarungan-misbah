using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModulPertarungan
{
	public class CardEffecFactory:AbstractFactory
	{
        private Dictionary<string, CardsEffect> CreateCardList;
        private CardsEffect card;
        
        public override void InstantiateObject()
        {
            CreateCardList = new Dictionary<string, CardsEffect>();
            card= new FireStorm();
            CreateCardList.Add("FireStormCard",card);
            card = new SplitFireCard();
            CreateCardList.Add("SplitFireCard", card);
            card = new TyphoonCard();
            CreateCardList.Add("TyphoonCard", card);
            card = new WindStorm();
            CreateCardList.Add("WindStromCard", card);
            card = new TidalWaveCard();
            CreateCardList.Add("TidalWaveCard", card);
            card = new WaterAttackAction();
            CreateCardList.Add("WaterAttack", card);    
        }
        
        public override void CreateCard(string Objectname,string Target)
        {
            CreateCardList.TryGetValue(Objectname, out card);
            card.SetTarget(Target);
            card.Effect();
        }
	}
}
