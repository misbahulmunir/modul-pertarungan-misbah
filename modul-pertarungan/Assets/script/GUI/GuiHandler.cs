using UnityEngine;
using System.Collections;

namespace ModulPertarungan
{
    public class GuiHandler : MonoBehaviour
    {

        private Vector2 scrollPosition = Vector2.zero;
        public GUIStyle style;
        public GameObject effectLabel;
        public GameObject cardNameLabel;

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
            }
        }
    }
}
