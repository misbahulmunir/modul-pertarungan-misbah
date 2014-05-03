using UnityEngine;
using System.Collections;

namespace ModulPertarungan
{
    public class RefreshRoomList : MonoBehaviour
    {

        // Use this for initialization
        void OnClick()
        {
            bool succses = false;
            succses = NetworkSingleton.Instance().PlayerClient.Call<bool>("sendMessage", "GetRoomList");
            if (succses)
                Debug.Log("send succes");
            else
                Debug.Log("send false");
        }
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}