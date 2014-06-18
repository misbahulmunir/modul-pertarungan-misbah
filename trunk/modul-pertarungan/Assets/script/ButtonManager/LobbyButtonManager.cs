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
        void HostRoom()
        {
            createRoom.SendMessage("ShowHostMessage");
            
        }

        void JoinRoom()
        {   rName = roomName.GetComponent<UILabel>().text;
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
