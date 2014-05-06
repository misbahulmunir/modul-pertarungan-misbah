using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using ModelModulPertarungan;

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
        public GameObject warlock;
        public GameObject enemyOnlinePosisiton;
     
        public void LoadPlayer()
        {
        //    for (int c = 0; c < GameManager.Instance().PlayerNumber; c++)
        //    {
        //        factory = new PlayerFactory();
        //        factory.InstantiateObject();
        //        factory.CreatePlayer("boncu", "warlock","FirstWarlock", pawnsPosisition[c]);
        //        Debug.Log("name" + GameManager.Instance().Players[0].GetComponent<PlayerAction>().Character.Name);
        //    }
            factory = new PlayerFactory();
            factory.InstantiateObject();
            if (GameManager.Instance().GameMode == "pvp")
            {
                factory.CreatePlayer(GameManager.Instance().PlayerId, "warlock", "FirstWarlock", pawnsPosisition[0]);
            }
            else
            {
                factory.CreatePlayer(GameManager.Instance().PlayerId, "warlock", "FirstWarlock", pawnsPosisition[0]);
                //LoadParty();
            }
           
        }

        public void LoadParty()
        {
            int temp = 1;
            foreach (string s in GameManager.Instance().PartyId)
            {
                factory = new PlayerFactory();
                factory.InstantiateObject();
                factory.CreatePlayer(s, "warlock", "FirstWarlock", pawnsPosisition[temp]);
                temp++;
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
                    //  obj.GetComponent<SpriteRenderer>().sortingOrder = 5;
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
                factory = new OnlineEnemyFanctory();
                factory.InstantiateObject();
                factory.CreatePlayer(NetworkSingleton.Instance().JoinPlayer, "warlock", "FirstWarlock", enemyOnlinePosisiton);
             
            }
            else
            {
                for (var c = 0; c < enemyCount; c++)
                {
                    this.GetComponent<EnemyFactory>().CreateEnemy("FireDragon", c);
                }
            }
            
        }
        void Awake()
        {
            DisplayedCards = new List<GameObject>();
            Screen.orientation = ScreenOrientation.LandscapeLeft;
            LoadEnemy();
            LoadPlayer();
        }
        void Start()
        {
            

        }

        // Update is called once per frame
        void Update()
        {
            grid.GetComponent<UIGrid>().Reposition();
            //State Pattern untuk battle
        }


    }
}
