using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
namespace ModulPertarungan
{
	public class SendToServer:MonoBehaviour
	{
        public GameObject textField;
        public void OnClick()
        {
            bool succses = false;
            succses = NetworkSingleton.Instance().PlayerClient.Call<bool>("sendMessage", textField.GetComponent<UILabel>().text);
            if (succses)
                Debug.Log("send succes");
            else
                Debug.Log("send false");
            textField.GetComponent<UILabel>().text = null; 
        }
	}
}
