using UnityEngine;
using System.Collections.Generic;
using System.Collections;

namespace ModulPertarungan
{
    public class ObjectLoader : MonoBehaviour
    {

        // Use this for initialization
        private int pawnsnumber;
        public List<GameObject> pawns;
        public List<GameObject> pawnsPosisition;
        public List<GameObject> cardpawns;
        private int currentPawnNumber;
        public void loadPlayer()
        {
            for (int c = 0; c < pawns.Count; c++)
            {
                Instantiate(pawns[c], pawnsPosisition[c].transform.position, Quaternion.identity);

            }
        }
        public void loadCards(GameObject pawn)
        {
            for (int c = 0; c < 3; c++)
            {
                GameObject obj = Instantiate(pawn.GetComponent<Pawn1Action>().Hand[c], cardpawns[c].transform.position, Quaternion.identity) as GameObject;
                obj.GetComponent<SpriteRenderer>().sortingOrder = 5;

            }
        }
        
        public void loadEnemy()
        {
        }

        void Start()
        {
            GameMenager.Instance().CurrentPawn = pawns[currentPawnNumber];
            Screen.orientation = ScreenOrientation.LandscapeLeft;
            loadPlayer();
        //    GameMenager.Instance().BattlePhase = "drawphase";
        }

        // Update is called once per frame
        void Update()
        {  
            //State Pattern untuk battle
        }


    }
}
