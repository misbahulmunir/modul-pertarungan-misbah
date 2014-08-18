using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Holoville.HOTween;
namespace ModulPertarungan
{
    public class CreateRoom : MonoBehaviour
    {
        public UILabel roomName;
        Vector3 startPosition;
        void OnClick()
        {
            UILabel rName = roomName;
            bool succses = false;
            string toserver = rName.text.Replace("-",String.Empty);
            String protocol = "CreateRoom-" + toserver + "-" + GameManager.Instance().PlayerId;
            succses = NetworkSingleton.Instance().PlayerClient.Call<bool>("sendMessage", protocol);
            if (succses)
                Debug.Log("send succes");
            else
                Debug.Log("send false");
            NetworkSingleton.Instance().RoomName =toserver;
        //    Application.LoadLevel("WaitingRoom");
        }
    
        void ShowHostMessage()
        {
            var parms = new TweenParms();
            parms.Prop("position", new Vector3(0f, 0f, 1f));
            HOTween.To(this.transform.parent.transform, 1f, parms);
        }
        public void CloseMessageBox()
        {
            var parms = new TweenParms();
            parms.Prop("position", startPosition);
            HOTween.To(this.transform.parent.transform, 1f, parms);
        }
        void Start()
        {
            startPosition = this.transform.parent.transform.position;
        }

        void Update()
        {
            if (NetworkSingleton.Instance().ServerMessage.Contains("created succesfully"))
            {
                NetworkSingleton.Instance().ServerMessage = "";
                Application.LoadLevel("WaitingRoom");
            }
        }
    }
}
