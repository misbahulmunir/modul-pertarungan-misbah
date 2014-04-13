using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModulPertarungan
{
	public class CardFactory:AbstractFactory
	{
        private Dictionary<string, CardsEffect> CreateCardList;
        private CardsEffect card;
        
        public override void InstatiateObject()
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
        
        public override void CreateCard(string Objectname)
        {
            base.CreateCard(Objectname);
        }
	}
}
