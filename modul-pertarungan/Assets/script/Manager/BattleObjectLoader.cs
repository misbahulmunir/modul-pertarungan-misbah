using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using ModelModulPertarungan;
using System.Net;
using System;

namespace ModulPertarungan
{
    public class BattleObjectLoader : MonoBehaviour
    {

        // Use this for initialization
        private int pawnsnumber;
        public int enemyCount;
        public List<GameObject> pawnsPosisition;
        public GameObject grid;
        private List<GameObject> DisplayedCards;
        private int currentPawnNumber;
        private AbstractFactory factory;
        public List<GameObject> enemyPosition; 
        public GameObject enemyOnlinePosisiton;

        public void LoadBackground()
        {
            factory=new BackgroundFactory();
            factory.InstantiateObject();
            factory.CreateBackground(TextureSingleton.Instance().TextureTiles);
        }
        public void LoadPlayer()
        {
            factory = new PlayerFactory();
            factory.InstantiateObject();
            if (GameManager.Instance().GameMode == "pvp")
            {
                factory.CreatePlayer(GameManager.Instance().PlayerId,pawnsPosisition[0]);
            }
            else
            {
                factory.CreatePlayer(GameManager.Instance().PlayerId,pawnsPosisition[0]);
                if (GameManager.Instance().PartyId != null)
                { 
                    LoadParty();
                }
            }
           
        }

        public void LoadParty()
        {
            int temp = 1;
            foreach (string party in GameManager.Instance().PartyId)
            {
                factory = new PlayerFactory();
                factory.InstantiateObject();
                factory.CreatePlayer(party, pawnsPosisition[temp]);
                temp++;
                Debug.Log(party);
            }
            temp = 0;
        }

        public void LoadDisplayedCards(GameObject pawn)
        {
            if (pawn != null)
            {
                
                foreach (GameObject t in pawn.GetComponent<PlayerAction>().CurrentHand)
                {
                    var obj = NGUITools.AddChild(grid,t);
                    DisplayedCards.Add(obj);
                }
               
            }
        }

        public void DestroyDisplayedCards()
        {
            foreach (GameObject obj in DisplayedCards)
            {
                Destroy(obj);    
            }
           
           
        }

        public void LoadEnemy()
        {
            if (GameManager.Instance().GameMode == "pvp")
            {
                factory = new OnlineEnemyFactory();
                factory.InstantiateObject();
                factory.CreatePlayer(
                    GameManager.Instance().PlayerId.ToLower() != NetworkSingleton.Instance().HostPlayer
                        ? NetworkSingleton.Instance().HostPlayer
                        : NetworkSingleton.Instance().JoinPlayer,
                    enemyOnlinePosisiton);
            }
            else
            { 
                if (TextureSingleton.Instance().TextureTiles == "Lavaland")
                {
                    factory = new EnemyFactory();
                    factory.InstantiateObject();
                    factory.CreateEnemy("FireSlime", enemyPosition[0]);
                    factory.CreateEnemy("FireDragon", enemyPosition[1]);
                }
                else if (TextureSingleton.Instance().TextureTiles == "Greenland")
                {
                    factory = new EnemyFactory();
                    factory.InstantiateObject();
                    factory.CreateEnemy("EarthSlime", enemyPosition[0]);
                    factory.CreateEnemy("EarthKingSlime", enemyPosition[1]);
                }
                else if (TextureSingleton.Instance().TextureTiles == "Iceland")
                {
                    factory = new EnemyFactory();
                    factory.InstantiateObject();
                    factory.CreateEnemy("WaterSlime", enemyPosition[0]);
                    factory.CreateEnemy("WaterKingSlime", enemyPosition[1]);
                }
                else if (TextureSingleton.Instance().TextureTiles == "Wetland")
                {
                    factory = new EnemyFactory();
                    factory.InstantiateObject();
                    factory.CreateEnemy("ThunderSlime", enemyPosition[0]);
                    factory.CreateEnemy("ThunderKingSlime", enemyPosition[1]);
                }
                else if (TextureSingleton.Instance().TextureTiles == "Windyhill")
                {
                    factory = new EnemyFactory();
                    factory.InstantiateObject();
                    factory.CreateEnemy("WindSlime", enemyPosition[0]);
                    factory.CreateEnemy("WindKingSlime", enemyPosition[1]);
                }
            }
            
        }
        void Awake()
        {   LoadBackground();
            DisplayedCards = new List<GameObject>();
            Screen.orientation = ScreenOrientation.LandscapeLeft;
            LoadEnemy();
            LoadPlayer();
        }
        void Start()
        {

            //if (GameManager.Instance().GameMode == "pvp")
            //{
              //GameManager.Instance().PauseGame = false;
            //}
            //else
            //{
            //    GameManager.instance.PauseGame = false;
            //}
        }

        // Update is called once per frame
        void Update()
        {
            grid.GetComponent<UIGrid>().Reposition();
            //State Pattern untuk battle
        }

       
    }
}
