using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
namespace ModulPertarungan
{
	public class NetworkSingleton
	{
	    private int chance;

        private string hostPlayer;

        public string HostPlayer
        {
            get { return hostPlayer; }
            set { hostPlayer = value; }
        }
        private string joinPlayer;

        public string JoinPlayer
        {
            get { return joinPlayer; }
            set { joinPlayer = value; }
        }
        private string roomName;

        public string RoomName
        {
            get { return roomName; }
            set { roomName = value; }
        }
        private string serverMessage;

        public string ServerMessage
        {
            get { return serverMessage; }
            set { serverMessage = value; }
        }
        private string host;

        public string Host
        {
            get { return host; }
            set { host = value; }
        }
        private string udpPort;

        public string UdpPort
        {
            get { return udpPort; }
            set { udpPort = value; }
        }
        private string tcpPort;

        public string TcpPort
        {
            get { return tcpPort; }
            set { tcpPort = value; }
        }
        private AndroidJavaClass unityPlayer;

        public AndroidJavaClass UnityPlayer
        {
            get { return unityPlayer; }
            set { unityPlayer = value; }
        }
        private AndroidJavaObject activity;

        public AndroidJavaObject Activity
        {
            get { return activity; }
            set { activity = value; }
        }
        private AndroidJavaObject playerClient;

        public AndroidJavaObject PlayerClient
        {
            get { return playerClient; }
            set { playerClient = value; }
        }

	    public int Chance
	    {
	        get { return chance; }
	        set { chance = value; }
	    }

	    public  static NetworkSingleton instance;
        public static NetworkSingleton Instance()
        {
            if (instance == null)
            {
                instance = new NetworkSingleton();
            }
            return instance;
        }
        public void Connect()
        {
            var args = new string[3];
            args[0] = host;
            args[1] = tcpPort;
            args[2] = udpPort;
            unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            activity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
            activity.Call("runOnUiThread", new AndroidJavaRunnable(() =>
            {
                playerClient = new AndroidJavaObject("com.its.warlocksaga.AndroidUnityListener", args);
            }));
        }
        public void Disconnect()
        {
            PlayerClient.Call("CloseConnection");
        }
	}
}
