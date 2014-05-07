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
        void HostRoom()
        {
            Application.LoadLevel("HostRoom");
            
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
            Application.LoadLevel("WaitingRoom");
        }
	}
}
