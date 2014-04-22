using UnityEngine;
using System.Collections;

namespace ModulPertarungan
{
    public class GuiDeckSize : MonoBehaviour
    {

        // Use this for initialization
        public GUIStyle style;
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (GameManager.Instance().CurrentPawn!=null&&GameManager.Instance().CurrentPawn.GetComponent<PlayerAction>().Deck.Card.Count != null)
            {
                this.gameObject.GetComponent<GUIText>().text =
                GameManager.Instance().CurrentPawn.GetComponent<PlayerAction>().Deck.Card.Count.ToString();
            }
            else
            {
                
            }

        }
    }
}