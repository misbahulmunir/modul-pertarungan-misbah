using UnityEngine;
using System.Collections;

namespace ModulPertarungan
{
    public class Cobaserver : MonoBehaviour
    {
        public GameObject host;
        public string tcpPort;
        public string udpPort;
        public string protocol;
        public GameObject label;
        private AndroidJavaClass unityPlayer;
        private AndroidJavaObject activity;
        private AndroidJavaObject playerClient;

        void OnClick()
        {
            Connect();
        }
        // Use this for initialization

        void Start()
        {
            
        }

        public void ReceiveMessage(string Message)
        {
            label.GetComponent<UILabel>().text = Message;
        }

        
        // Update is called once per frame
        void Update()
        {

        }
        private void Connect()
        {
            string[] args = new string[3];
            args[0] = host.GetComponent<UILabel>().text;
            args[1] = tcpPort;
            args[2] = udpPort;
            unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            NetworkSingleton.Instance().UnityPlayer = unityPlayer;
            activity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
            NetworkSingleton.Instance().Activity = activity;
            activity.Call("runOnUiThread", new AndroidJavaRunnable(() =>
            {

                playerClient = new AndroidJavaObject("com.its.warlocksaga.AndroidUnityListener", args);
                NetworkSingleton.Instance().PlayerClient = playerClient;

            }));
        }
    }
}