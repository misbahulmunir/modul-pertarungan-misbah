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
            for (int c = 0; c < GameManager.Instance().PlayerNumber; c++)
            {
                factory = new PlayerFactory();
                factory.InstantiateObject();
                factory.CreatePlayer("boncu", "warlock","FirstWarlock", pawnsPosisition[c]);
                Debug.Log("name" + GameManager.Instance().Players[0].GetComponent<PlayerAction>().Character.Name);
            }
        }

        public void LoadDisplayedCards(GameObject pawn)
        {
            if (pawn != null)
            {
                for (int c = 0; c < pawn.GetComponent<PlayerAction>().CurrentHand.Count; c++)
                {
                    GameObject obj = NGUITools.AddChild(grid,pawn.GetComponent<PlayerAction>().CurrentHand[c]);
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
                factory = new PlayerFactory();
                factory.InstantiateObject();
                factory.CreatePlayer("boncu", "warlock", "FirstWarlock", enemyOnlinePosisiton);
             
            }
            else
            {
                for (int c = 0; c < enemyCount; c++)
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
