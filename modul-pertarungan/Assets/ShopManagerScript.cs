using UnityEngine;
using System.Collections;
using Holoville.HOTween;

namespace ModulPertarungan
{
    public class ShopManagerScript : MonoBehaviour
    {
        public GameObject OkButton;
        public GameObject ConfirmationButton;
        public GameObject CancelButton;
        public UILabel ServerMessage;
        public GameObject ShopBoard;
        private string cardName;
        Vector3 startPosition;
        public void ShowPurchase(object obj)
        {
            cardName = obj as string;
            ShowMessageBox(ShopBoard.transform.position);
            ServerMessage.text = "Do You Want To buy This "+cardName+" ?";
        }
        public void ShowOkButton(bool Status)
        {
            if (Status)
            {
                OkButton.SetActive(true);
                ConfirmationButton.SetActive(false);
                CancelButton.SetActive(false);
                ServerMessage.text = WebServiceSingleton.GetInstance().queryInfo;
            }
            else
            {
                OkButton.SetActive(false);
                ConfirmationButton.SetActive(true);
                CancelButton.SetActive(true);
            }

        }
        public void Purchase()
        {
            if (cardName != null)
            {
                WebServiceSingleton.GetInstance().ProcessRequest("buy_card", GameManager.Instance().PlayerId + "|" + cardName + "|1");
                ShowOkButton(true);
            }
        }
        public void Confirm()
        {
            ShowOkButton(false);
            CloseConfirmationBoard();
        }
        public void ShowMessageBox(Vector3 Position)
        {
            var parms = new TweenParms();
            parms.Prop("position", Position);
            HOTween.To(this.transform, 0f, parms);
        }

        public void CloseConfirmationBoard()
        {
            var parms = new TweenParms();
            parms.Prop("position", startPosition);
            HOTween.To(this.transform, 0f, parms);
        }
        void Start()
        {
            startPosition = this.transform.position;
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}