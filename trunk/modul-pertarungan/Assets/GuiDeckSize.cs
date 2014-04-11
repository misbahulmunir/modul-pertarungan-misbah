using UnityEngine;
using System.Collections;

namespace ModulPertarungan
{
    public class GuiDeckSize : MonoBehaviour
    {

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            this.gameObject.GetComponent<GUIText>().text = 
            GameManager.Instance().CurrentPawn.GetComponent<PlayerAction>().Deck.Card.Count.ToString();
        }
    }
}