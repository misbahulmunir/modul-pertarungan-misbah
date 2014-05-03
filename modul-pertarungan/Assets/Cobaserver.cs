﻿using UnityEngine;
using System.Collections;

namespace ModulPertarungan
{
    public class Cobaserver : MonoBehaviour
    {
        public GameObject host;
        public string tcpPort;
        public string udpPort;
        public string protocol;
       

        void OnClick()
        {
            NetworkSingleton.Instance().Host = host.GetComponent<UILabel>().text;
            NetworkSingleton.Instance().TcpPort = tcpPort;
            NetworkSingleton.Instance().UdpPort = udpPort;
            NetworkSingleton.Instance().Connect();
            
        }
        // Use this for initialization

        void Start()
        {
            
        }

       

        
        // Update is called once per frame
        void Update()
        {
            if (NetworkSingleton.Instance().ServerMessage.ToLower().Contains("connected"))
            {
                Application.LoadLevel("LobbyRoom");
            }
        }
        //private void Connect()
        //{
        //    string[] args = new string[3];
        //    args[0] = host.GetComponent<UILabel>().text;
        //    args[1] = tcpPort;
        //    args[2] = udpPort;
        //    unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        //    NetworkSingleton.Instance().UnityPlayer = unityPlayer;
        //    activity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
        //    NetworkSingleton.Instance().Activity = activity;
        //    activity.Call("runOnUiThread", new AndroidJavaRunnable(() =>
        //    {

        //        playerClient = new AndroidJavaObject("com.its.warlocksaga.AndroidUnityListener", args);
        //        NetworkSingleton.Instance().PlayerClient = playerClient;

        //    }));
        //}
    }
}