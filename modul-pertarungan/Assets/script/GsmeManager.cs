using UnityEngine;
using System.Collections.Generic;
using System.Collections;

namespace GsmeManager
{
    public class GsmeManager : MonoBehaviour
    {

        // Use this for initialization
        public List<GameObject> players;
        public List<GameObject> pawns;
        public List<GameObject> cards;
        public List<GameObject> cardpawns;
        public void loadPlayer()
        {
            for (int c = 0; c < 3; c++)
            {
                Instantiate(players[c], pawns[c].transform.position, Quaternion.identity);

            }
        }
        public void loadCards()
        {
            for (int c = 0; c < 3; c++)
            {
                GameObject obj = Instantiate(cards[c], cardpawns[c].transform.position, Quaternion.identity) as GameObject;
                obj.GetComponent<SpriteRenderer>().sortingOrder = 5;

            }
        }
        
        public void loadEnemy()
        {
        }

        void Start()
        {
            loadCards();
            loadPlayer();

        }

        // Update is called once per frame
        void Update()
        {
            
        }


    }
}
