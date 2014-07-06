using UnityEngine;
using System.Collections;

namespace ModulPertarungan
{
    public class GuiHandler : MonoBehaviour
    {

       
        public GUIStyle style;
        public GameObject effectLabel;
        public GameObject cardNameLabel;
        public UILabel cardCost;
        // Use this for initialization
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
            if (GameManager.Instance().CurrentCard != null)
            {
                cardNameLabel.GetComponent<UILabel>().text = GameManager.Instance().CurrentCard.CardName;
                effectLabel.GetComponent<UILabel>().text = GameManager.Instance().CurrentCard.CardEffect;
                    cardCost.text = GameManager.Instance().CurrentCard.CardCost.ToString();
               
            }
        }
    }
}
