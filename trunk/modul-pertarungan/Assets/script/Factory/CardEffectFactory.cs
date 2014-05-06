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
            CreateCardList.Add("Fire Storm",card);
            card = new SplitFireCard();
            CreateCardList.Add("Split Fire", card);
            card = new TyphoonCard();
            CreateCardList.Add("Typhoon", card);
            card = new WindStorm();
            CreateCardList.Add("WindStrom", card);
            card = new TidalWaveCard();
            CreateCardList.Add("Tidal Wave", card);
            card = new WaterAttackAction();
            CreateCardList.Add("Water Attack", card);    
        }
        
        public override void CreateCard(string objectName,string target)
        {
            CreateCardList.TryGetValue(objectName, out card);
            card.SetTarget(target);
            card.Effect();
        }
	}
}
