using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
namespace ModulPertarungan
{
	public class GetMessageFromServer:MonoBehaviour
	{
        public GameObject label;
        private string pesan;

        void Update()
        {
            if (pesan == "putus")
            {
                Application.Quit();
            }
        }

        void Start()
        {
          
        }

        public void ReceiveMessage(string Message)
        {
            pesan = Message;
           NetworkSingleton.Instance().ServerMessage = Message;
          // DontDestroyOnLoad(this.gameObject);
           //label.GetComponent<UILabel>().text = NetworkSingleton.Instance().ServerMessage;
        }
	}
}
