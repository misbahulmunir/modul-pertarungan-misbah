using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
namespace ModulPertarungan
{
	public class LobbyButtonManager:MonoBehaviour
	{
        public GameObject roomName;
        private string rName;
	    private string text;
        public CreateRoom createRoom;
        public MessageBoxScirpt msgbox;
        void HostRoom()
        {
            createRoom.SendMessage("ShowHostMessage");
            
        }

        void JoinRoom()
        {
            if (roomName.GetComponent<UILabel>().text == string.Empty)
            {
                object[] obj = new object[2];
                obj[0] = "Cannot Join Room";
                obj[1] = "Room  is empty";
                msgbox.SendMessage("SetMessage", obj);
                msgbox.SendMessage("ShowMessageBox");
            }
            rName = roomName.GetComponent<UILabel>().text;
            NetworkSingleton.Instance().RoomName = rName;
            bool succses = false;
            succses = NetworkSingleton.Instance().PlayerClient.Call<bool>("sendMessage", "JoinRoom-" + rName +"-"+GameManager.Instance().PlayerId);
            if (succses)
                Debug.Log("send succes");
            else
                Debug.Log("send false");

            
        }

	    public void Record()
	    {
            Application.LoadLevel("PVPRecord");
	    }

	    //public void LobbyPopUpOnChange()
        //{
        //    if (UIPopupList.current != null)
        //    {
        //        text = UIPopupList.current.isLocalized ?
        //            Localization.Get(UIPopupList.current.value) :
        //            UIPopupList.current.value;
        //        if (text.Equals("Host"))
        //        {
        //            Application.LoadLevel("HostRoom");
        //        }
        //        else if(text.Equals("Joint"))
        //        {
        //            rName = roomName.GetComponent<UILabel>().text;
        //            NetworkSingleton.Instance().RoomName = rName;
        //            bool succses = false;
        //            succses = NetworkSingleton.Instance().PlayerClient.Call<bool>("sendMessage", "JoinRoom-" + rName + "-" + GameManager.Instance().PlayerId);
        //            if (succses)
        //                Debug.Log("send succes");
        //            else
        //                Debug.Log("send false");
        //        }
        //    }
        //}

	    
	}
}
