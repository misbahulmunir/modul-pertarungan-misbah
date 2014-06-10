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
            if (GameManager.Instance().GameMode != "pvp")
            {
                factory = new BackgroundFactory();
                factory.InstantiateObject();
                factory.CreateBackground(TextureSingleton.Instance().TextureTiles);
                Debug.Log("Bg " + TextureSingleton.Instance().TextureTiles);
            }
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
                if (TextureSingleton.Instance().TextureTiles == "0_Lavaland")
                {
                    if (TextureSingleton.Instance().IdButton == "@Fire_0")
                    {
                        factory = new EnemyFactory();
                        factory.InstantiateObject();
                        factory.CreateEnemy("FireSlime", enemyPosition[0]);
                        factory.CreateEnemy("FireKingSlime", enemyPosition[1]);

                    }
                    else if (TextureSingleton.Instance().IdButton == "@Fire_1")
                    {
                        factory = new EnemyFactory();
                        factory.InstantiateObject();
                        factory.CreateEnemy("FireNymph", enemyPosition[0]);
                        factory.CreateEnemy("FireNymph", enemyPosition[1]);
                    }
                    else
                    {
                        factory = new EnemyFactory();
                        factory.InstantiateObject();
                        factory.CreateEnemy("FireDragon", enemyPosition[0]);
                        factory.CreateEnemy("FireDragon", enemyPosition[1]);
                    }
                }
                else if (TextureSingleton.Instance().TextureTiles == "0_Greenland")
                {
                    if (TextureSingleton.Instance().IdButton == "@Earth_0")
                    {
                        factory = new EnemyFactory();
                        factory.InstantiateObject();
                        factory.CreateEnemy("EarthSlime", enemyPosition[0]);
                        factory.CreateEnemy("EarthKingSlime", enemyPosition[1]);
                    }
                    else if (TextureSingleton.Instance().IdButton == "@Earth_1")
                    {
                        factory = new EnemyFactory();
                        factory.InstantiateObject();
                        factory.CreateEnemy("EarthNymph", enemyPosition[0]);
                        factory.CreateEnemy("EarthNymph", enemyPosition[1]);
                    }
                    else if (TextureSingleton.Instance().IdButton == "@Earth_2")
                    {
                        factory = new EnemyFactory();
                        factory.InstantiateObject();
                        factory.CreateEnemy("Mandrake", enemyPosition[0]);
                        factory.CreateEnemy("Mandragora", enemyPosition[1]);
                    }
                    else
                    {
                        factory = new EnemyFactory();
                        factory.InstantiateObject();
                        factory.CreateEnemy("Canotre", enemyPosition[0]);
                        factory.CreateEnemy("Treant", enemyPosition[1]);
                    }
                }
                else if (TextureSingleton.Instance().TextureTiles == "0_Iceland")
                {
                    if (TextureSingleton.Instance().IdButton == "@Water_0")
                    {
                        factory = new EnemyFactory();
                        factory.InstantiateObject();
                        factory.CreateEnemy("WaterSlime", enemyPosition[0]);
                        factory.CreateEnemy("WaterKingSlime", enemyPosition[1]);
                    }
                    else if (TextureSingleton.Instance().IdButton == "@Water_1")
                    {
                        factory = new EnemyFactory();
                        factory.InstantiateObject();
                        factory.CreateEnemy("WaterNymph", enemyPosition[0]);
                        factory.CreateEnemy("WaterNymph", enemyPosition[1]);
                    }
                    else
                    {
                        factory = new EnemyFactory();
                        factory.InstantiateObject();
                        factory.CreateEnemy("WaterKingSlime", enemyPosition[0]);
                        factory.CreateEnemy("WaterKingSlime", enemyPosition[1]);
                    }
                }
                else if (TextureSingleton.Instance().TextureTiles == "0_Wetland")
                {
                    if (TextureSingleton.Instance().IdButton == "@Thunder_0")
                    {
                        factory = new EnemyFactory();
                        factory.InstantiateObject();
                        factory.CreateEnemy("ThunderSlime", enemyPosition[0]);
                        factory.CreateEnemy("ThunderKingSlime", enemyPosition[1]);
                    }
                    else if (TextureSingleton.Instance().IdButton == "@Thunder_1")
                    {
                        factory = new EnemyFactory();
                        factory.InstantiateObject();
                        factory.CreateEnemy("ThunderNymph", enemyPosition[0]);
                        factory.CreateEnemy("ThunderNymph", enemyPosition[1]);
                    }
                    else
                    {
                        factory = new EnemyFactory();
                        factory.InstantiateObject();
                        factory.CreateEnemy("ThunderKingSlime", enemyPosition[0]);
                        factory.CreateEnemy("ThunderKingSlime", enemyPosition[1]);
                    }
                }
                else if (TextureSingleton.Instance().TextureTiles == "0_Windyhill")
                {
                    if (TextureSingleton.Instance().IdButton == "@Wind_0")
                    {
                        factory = new EnemyFactory();
                        factory.InstantiateObject();
                        factory.CreateEnemy("WindSlime", enemyPosition[0]);
                        factory.CreateEnemy("WindKingSlime", enemyPosition[1]);
                    }
                    else if (TextureSingleton.Instance().IdButton == "@Wind_1")
                    {
                        factory = new EnemyFactory();
                        factory.InstantiateObject();
                        factory.CreateEnemy("WindNymph", enemyPosition[0]);
                        factory.CreateEnemy("WindNymph", enemyPosition[1]);
                    }
                    else
                    {
                        factory = new EnemyFactory();
                        factory.InstantiateObject();
                        factory.CreateEnemy("WindKingSlime", enemyPosition[0]);
                        factory.CreateEnemy("WindKingSlime", enemyPosition[1]);
                    }
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
