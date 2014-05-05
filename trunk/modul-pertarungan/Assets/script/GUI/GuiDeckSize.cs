using UnityEngine;
using System.Collections;

namespace ModulPertarungan
{
    public class GuiDeckSize : MonoBehaviour
    {

        // Use this for initializatio
        public GameObject deckCount;
        public GameObject playerName;
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (GameManager.Instance().CurrentPawn!= null&&GameManager.Instance().CurrentPawn.GetComponent<PlayerAction>().Deck!=null)
            {
                playerName.GetComponent<UILabel>().text = GameManager.Instance().CurrentPawn.GetComponent<PlayerAction>().Character.Name;
                deckCount.GetComponent<UILabel>().text = GameManager.Instance().CurrentPawn.GetComponent<PlayerAction>().Deck.Card.Count.ToString();
            }
        }
    }
}