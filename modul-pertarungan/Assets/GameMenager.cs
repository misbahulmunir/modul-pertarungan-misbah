using UnityEngine;
using System.Collections;

namespace ModulPertarungan
{
    public class GameMenager
    {

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
