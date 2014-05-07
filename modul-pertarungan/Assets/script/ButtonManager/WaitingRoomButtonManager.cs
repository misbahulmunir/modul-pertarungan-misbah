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
	}
}
