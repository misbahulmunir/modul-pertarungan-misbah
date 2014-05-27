﻿using UnityEngine;
using System.Collections;
namespace ModulPertarungan
{
    public class LobbyManager : MonoBehaviour
    {

        public GameObject grid;
        public GameObject roomButton;
        // Use this for initialization
        void Start()
        {
            bool succses = false;
            succses = NetworkSingleton.Instance().PlayerClient.Call<bool>("sendMessage", "GetRoomList");
            if (succses)
                Debug.Log("send succes");
            else
                Debug.Log("send false");
        }

        // Update is called once per frame
        void Update()
        {
            string serverMessage = NetworkSingleton.Instance().ServerMessage;
            Debug.Log(serverMessage);
            if (serverMessage.Contains("RoomList"))
            {
                RefreshGrid();
                string[] message = serverMessage.Split('-');
                foreach (string m in message)
                {
                    if (m != "RoomList"&&m!="")
                    {
                        foreach (Transform t in roomButton.transform)
                        {
                            t.GetComponent<UILabel>().text = m;
                        }
                        roomButton.name = m;
                        NGUITools.AddChild(grid, roomButton);
                    }
                    grid.GetComponent<UIGrid>().Reposition();
                }
                
                NetworkSingleton.Instance().ServerMessage = "";
               
            }
            else if (serverMessage.Contains("JoinedRoom"))
            {
                NetworkSingleton.Instance().ServerMessage = "";
                Application.LoadLevel("WaitingRoom");
               
            }
            grid.GetComponent<UIGrid>().Reposition();
        }
        public void RefreshGrid()
        {
            foreach (Transform t in grid.transform)
            {
                Destroy(t.gameObject);
            }
            
        }
    }
}