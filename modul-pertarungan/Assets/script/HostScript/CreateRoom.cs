using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
namespace ModulPertarungan
{
    public class CreateRoom : MonoBehaviour
    {
        public GameObject playerName;
        public GameObject roomName;

        void OnClick()
        {
            UILabel pName = playerName.GetComponent<UILabel>();
            UILabel rName = roomName.GetComponent<UILabel>();
            bool succses = false;
            String protocol = "CreateRoom-" + rName.text + "-" + pName.text;
            succses = NetworkSingleton.Instance().PlayerClient.Call<bool>("sendMessage", protocol);
            if (succses)
                Debug.Log("send succes");
            else
                Debug.Log("send false");
            NetworkSingleton.Instance().RoomName = rName.text;
            Application.LoadLevel("WaitingRoom");
        }

        void Start()
        {
        }

        void Update()
        {
        }
    }
}
