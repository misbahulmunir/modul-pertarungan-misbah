using UnityEngine;
using System.Collections;
using ModelModulPertarungan;
namespace ModulPertarungan
{
    public class GuiDeckSize : MonoBehaviour
    {

        // Use this for initializatio
        public GameObject deckCount;
        public GameObject playerName;
        public UILabel currentSoulPoint;
        public UILabel enemyName;
        void Start()
        {
            if(GameManager.Instance().GameMode == "pvp")
            {
                enemyName.text = NetworkSingleton.Instance().EnemyName;
            }
        }

        // Update is called once per frame
        void Update()
        {
            if (GameManager.Instance().CurrentPawn!= null&&GameManager.Instance().CurrentPawn.GetComponent<PlayerAction>().Deck!=null)
            {
                playerName.GetComponent<UILabel>().text = GameManager.Instance().CurrentPawn.GetComponent<PlayerAction>().Character.Name;
                deckCount.GetComponent<UILabel>().text = GameManager.Instance().CurrentPawn.GetComponent<PlayerAction>().Deck.Card.Count.ToString();
                //currentSoulPoint.text = (GameManager.Instance().CurrentPawn.GetComponent<PlayerAction>().Character as Player).CurrentSoulPoints.ToString();
            }
        }
    }
}