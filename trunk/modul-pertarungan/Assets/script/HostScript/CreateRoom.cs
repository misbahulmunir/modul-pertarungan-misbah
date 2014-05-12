﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
namespace ModulPertarungan
{
    public class CreateRoom : MonoBehaviour
    {
        public GameObject roomName;

        void OnClick()
        {
            UILabel rName = roomName.GetComponent<UILabel>();
            bool succses = false;
            String protocol = "CreateRoom-" + rName.text + "-" + GameManager.Instance().PlayerId;
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