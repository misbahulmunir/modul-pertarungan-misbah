using UnityEngine;
using System.Collections;
using System.Collections.Generic;
namespace ModulPertarungan
{
    public class GameMenager
    {

        private List<GameObject> enemies;
        private CardsEffect currentCard;

        public CardsEffect CurrentCard
        {
            get { return currentCard; }
            set { currentCard = value; }
        }

      
        public List<GameObject> Enemies
        {
            get { return enemies; }
            set { enemies = value; }
        }
        private List<GameObject> players;

        public List<GameObject> Players
        {
            get { return players; }
            set { players = value; }
        }
        private string battlePhase;
        private GameObject currentPawn;

        public GameObject CurrentPawn
        {
            get { return currentPawn; }
            set { currentPawn = value; }
        }
        public string BattlePhase
        {
            get { return battlePhase; }
            set { battlePhase = value; }
        }
        public static GameMenager instance;
        public GameMenager()
        {
            
        }
        public static GameMenager Instance()
        {
            if (instance == null)
            {
                instance = new GameMenager();
            }
            return instance;
        }
        
    }
}
