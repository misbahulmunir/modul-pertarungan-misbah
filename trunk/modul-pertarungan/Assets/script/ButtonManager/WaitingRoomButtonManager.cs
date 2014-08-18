using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
namespace ModulPertarungan
{
	public class WaitingRoomButtonManager:MonoBehaviour
	{
        public UILabel textbox1;
        public UILabel textbox2;
        public MessageBoxScirpt msgbox;
        void StartGame()
        {
            
            bool succses = false;
            succses = NetworkSingleton.Instance().PlayerClient.Call<bool>("sendMessage", "GetPlayerList-" + NetworkSingleton.Instance().RoomName);
            Debug.Log(succses ? "send succes" : "send false");

        }

        void GotoHome()
        {

            NetworkSingleton.Instance().Disconnect();
            NetworkSingleton.instance = null;
            Application.LoadLevel("HouseEditor");
        }

	    private void Confirm()
	    {
            bool succses = false;
            succses = NetworkSingleton.Instance().PlayerClient.Call<bool>("sendMessage", "Confirmation-" + NetworkSingleton.Instance().RoomName+"-"+GameManager.Instance().PlayerId);
            Debug.Log(succses ? "send succes" : "send false");
	    }

	    private void StartOnlineBattle()
	    {
            if (textbox1.text == ""|| textbox2.text == "")
            {
                object[] obj = new object[2];
                obj[0] = "Cannot StartGame";
                obj[1] = "Player is empty";
                msgbox.SendMessage("SetMessage", obj);
                msgbox.SendMessage("ShowMessageBox");
            }
            bool succses = false;
            succses = NetworkSingleton.Instance().PlayerClient.Call<bool>("sendMessage", "StartGame-" + NetworkSingleton.Instance().RoomName);
            Debug.Log(succses ? "send succes" : "send false");
	    }
	}
}
