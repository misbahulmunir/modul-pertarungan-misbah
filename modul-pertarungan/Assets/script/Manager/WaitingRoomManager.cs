using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
namespace ModulPertarungan
{
    public class WaitingRoomManager : MonoBehaviour
    {
        public GameObject firstPlayerName;
        public GameObject secondPlayerName;
        void Start()
        {
            bool succses = false;
            succses = NetworkSingleton.Instance().PlayerClient.Call<bool>("sendMessage", "GetPlayerList-"+NetworkSingleton.Instance().RoomName);
            if (succses)
                Debug.Log("send succes");
            else
                Debug.Log("send false");
        }
        void Update()
        {
            string serverMessage = NetworkSingleton.Instance().ServerMessage;
            Debug.Log(serverMessage);
            if (serverMessage.Contains("PlayerList"))
            {  
                string[] message=serverMessage.Split('-');
                firstPlayerName.GetComponent<UILabel>().text = message[1];
                secondPlayerName.GetComponent<UILabel>().text = message[2];
                NetworkSingleton.Instance().ServerMessage = "";

            }
            else if(serverMessage.Contains("JoinedRoom"))
            {
                secondPlayerName.name = serverMessage.Split('-')[2];
                NetworkSingleton.Instance().ServerMessage = "";
            }

        }
    }
}