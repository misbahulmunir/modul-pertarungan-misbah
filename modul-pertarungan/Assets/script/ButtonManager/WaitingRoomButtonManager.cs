using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
namespace ModulPertarungan
{
	public class WaitingRoomButtonManager:MonoBehaviour
	{
        void StartGame()
        {
            bool succses = false;
            succses = NetworkSingleton.Instance().PlayerClient.Call<bool>("sendMessage", "GetPlayerList-" + NetworkSingleton.Instance().RoomName);
            Debug.Log(succses ? "send succes" : "send false");
        }

        void GotoHome()
        {
            NetworkSingleton.Instance().Disconnect();
            Application.LoadLevel("CrateRoom");
        }

	    private void Confirm()
	    {
            bool succses = false;
            succses = NetworkSingleton.Instance().PlayerClient.Call<bool>("sendMessage", "Confirmation-" + NetworkSingleton.Instance().RoomName+"-"+GameManager.Instance().PlayerId);
            Debug.Log(succses ? "send succes" : "send false");
	    }

	    private void StartOnlineBattle()
	    {
            bool succses = false;
            succses = NetworkSingleton.Instance().PlayerClient.Call<bool>("sendMessage", "StartGame-" + NetworkSingleton.Instance().RoomName);
            Debug.Log(succses ? "send succes" : "send false");
	    }
	}
}
