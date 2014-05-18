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
        public GameObject textList;
        public GameObject startButton;
        public void EnableStartGame()
        {
            if (GameManager.Instance().PlayerId.Equals(firstPlayerName.GetComponent<UILabel>().text))
            {
                startButton.SetActive(true);
            }
        }

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
            EnableStartGame();
            string serverMessage = NetworkSingleton.Instance().ServerMessage;
            Debug.Log(serverMessage);
            string[] message=serverMessage.Split('-');
            if (serverMessage.Contains("PlayerList"))
            {  
                firstPlayerName.GetComponent<UILabel>().text = message[1];
                if(message.Count()>2)
                secondPlayerName.GetComponent<UILabel>().text = message[2];
                NetworkSingleton.Instance().ServerMessage = "";
            }
            else if(serverMessage.Contains("JoinedRoom"))
            {   
                //if(firstPlayerName.GetComponent<UILabel>().text.Equals(""))
                //{
                //     firstPlayerName.GetComponent<UILabel>().text =message[1];
                //}
                //else if (secondPlayerName.GetComponent<UILabel>().text.Equals(""))
                //{
                //     secondPlayerName.GetComponent<UILabel>().text=message[1];
                //}
                bool succses = false;
                succses = NetworkSingleton.Instance().PlayerClient.Call<bool>("sendMessage", "GetPlayerList-" + NetworkSingleton.Instance().RoomName);
                if (succses)
                    Debug.Log("send succes");
                else
                    Debug.Log("send false");
                NetworkSingleton.Instance().ServerMessage = "";
            }
            else if (serverMessage.Contains("Disconnected"))
            {
                if(firstPlayerName.GetComponent<UILabel>().text.Equals(message[1]))
                {
                     firstPlayerName.GetComponent<UILabel>().text ="";
                }
                else if (secondPlayerName.GetComponent<UILabel>().text.Equals(message[1]))
                {
                     secondPlayerName.GetComponent<UILabel>().text="";
                }
                NetworkSingleton.Instance().ServerMessage = "";
            }
            else if(serverMessage.Contains("Chat"))
            {
                textList.GetComponent<UITextList>().Add(message[1]);
                NetworkSingleton.Instance().ServerMessage = "";
            }
            else if (serverMessage.Contains("StartGame"))
            {
                NetworkSingleton.Instance().HostPlayer = firstPlayerName.GetComponent<UILabel>().text;
                NetworkSingleton.Instance().JoinPlayer = secondPlayerName.GetComponent<UILabel>().text;
                Application.LoadLevel("OnlineBattle");
            }
        }

        
    }
}