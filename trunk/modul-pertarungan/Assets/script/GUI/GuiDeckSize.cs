using UnityEngine;
using System.Collections;

namespace ModulPertarungan
{
    public class GuiDeckSize : MonoBehaviour
    {

        // Use this for initializatio
        public GameObject deckCount;
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {     
                  deckCount.GetComponent<UILabel>().text=  GameManager.Instance().CurrentPawn.GetComponent<PlayerAction>().Deck.Card.Count.ToString();
      
        }
    }
}