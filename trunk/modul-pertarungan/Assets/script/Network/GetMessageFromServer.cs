﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
namespace ModulPertarungan
{
	public class GetMessageFromServer:MonoBehaviour
	{
        public GameObject label;
        void Update()
        {
            
        }

        void Start()
        {

        }

        public void ReceiveMessage(string Message)
        {
           NetworkSingleton.Instance().ServerMessage = Message;
           label.GetComponent<UILabel>().text = NetworkSingleton.Instance().ServerMessage;
        }
	}
}
