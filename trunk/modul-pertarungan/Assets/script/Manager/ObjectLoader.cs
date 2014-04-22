using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using ModelModulPertarungan;

namespace ModulPertarungan
{
    public class ObjectLoader : MonoBehaviour
    {

        // Use this for initialization
        private int pawnsnumber;
        public int enemyCount;
        public List<GameObject> pawnsPosisition;
        public List<GameObject> cardpawns;
        private List<GameObject> DisplayedCards;
        private int currentPawnNumber;
        private AbstractFactory factory;

        public void LoadPlayer()
        {
            for (int c = 0; c <GameManager.Instance().Players.Count; c++)
            {
                GameObject obj = Instantiate(GameManager.Instance().Players[c], pawnsPosisition[c].transform.position, Quaternion.identity) as GameObject;
                GameManager.Instance().Players[c] = obj;

            }
            GameManager.Instance().CurrentPawn = GameManager.Instance().Players[0];
           
    
        }
        public void LoadDisplayedCards(GameObject pawn)
        {
            if (pawn != null)
            {
                for (int c = 0; c < pawn.GetComponent<PlayerAction>().CurrentHand.Count; c++)
                {
                    GameObject obj = Instantiate(pawn.GetComponent<PlayerAction>().CurrentHand[c], cardpawns[c].transform.position, Quaternion.identity) as GameObject;
                    obj.GetComponent<SpriteRenderer>().sortingOrder = 5;
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
            
            for (int c = 0; c < enemyCount; c++)
            {
                this.GetComponent<EnemyFactory>().CreateEnemy("FireDragon", c);
                

            }
            
        }
        void Start()
        {
            DisplayedCards = new List<GameObject>();
            
            Screen.orientation = ScreenOrientation.LandscapeLeft;
            LoadEnemy();
            LoadPlayer();

        }

        // Update is called once per frame
        void Update()
        {

            //State Pattern untuk battle
        }


    }
}
