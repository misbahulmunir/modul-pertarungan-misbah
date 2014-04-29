using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
namespace ModulPertarungan
{
	public class NetworkSingleton
	{
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
        private static NetworkSingleton instance;
        public static NetworkSingleton Instance()
        {
            if (instance == null)
            {
                instance = new NetworkSingleton();
            }
            return instance;
        }
	}
}
