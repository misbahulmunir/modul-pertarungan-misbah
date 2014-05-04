using UnityEngine;
using System.Collections;
using System.Collections.Generic;
namespace ModulPertarungan
{
    public class GameManager
    {
        private int playerNumber;

        public int PlayerNumber
        {
            get { return playerNumber; }
            set { playerNumber = value; }
        }
        private string gameMode;

        public string GameMode
        {
            get { return gameMode; }
            set { gameMode = value; }
        }
        private List<string> allSelectedCard;

        public List<string> AllSelectedCard
        {
            get { return allSelectedCard; }
            set { allSelectedCard = value; }
        }

       
        private string gameStatus;

        public string GameStatus
        {
            get { return gameStatus; }
            set { gameStatus = value; }
        }
        private int playerExp;

        public int PlayerExp
        {
            get { return playerExp; }
            set { playerExp = value; }
        }
        private int playerGold;

        public int PlayerGold
        {
            get { return playerGold; }
            set { playerGold = value; }
        }
        private int currentPlayerDeckSize;
        
        public int CurrentPlayerDeckSize
        {
            get { return currentPlayerDeckSize; }
            set { currentPlayerDeckSize = value; }
        }
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
        private List<GameObject> playerDeck;

        public List<GameObject> PlayerDeck
        {
            get { return playerDeck; }
            set { playerDeck = value; }
        }
        public static GameManager instance;
     
      
        public GameManager()
        {
            
        }
        
        public static GameManager Instance()
        {
            if (instance == null)
            {
                instance = new GameManager();
            }
            return instance;
        }
        public void KillObj(string Side)
        {
            if(Side == "enemy")
            {
                instance.enemies.RemoveAll(item => item.GetComponent<DamageReceiverAction>().Character.CurrentHealth <= 0);
            }
            else
            {
                instance.Players.RemoveAll(item => item.GetComponent<DamageReceiverAction>().Character.CurrentHealth <= 0);
            }
        }
        public void AddPlayer(GameObject obj)
        {
            if (this.players == null)
            {
                this.players = new List<GameObject>();
            }
            players.Add(obj);
        }
        public void AddEnemy(GameObject obj)
        {
            if (this.enemies == null)
            {
                this.enemies = new List<GameObject>();
            }
            enemies.Add(obj);
        }
        
    }
}
