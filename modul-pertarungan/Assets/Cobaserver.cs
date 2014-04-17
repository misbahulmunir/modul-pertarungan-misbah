using UnityEngine;
using System.Collections;

namespace ModulPertarungan
{
    public class Cobaserver : MonoBehaviour
    {
        public string host;
        public string port;
        private AndroidJavaClass unityPlayer;
        private AndroidJavaObject activity;
        private AndroidJavaObject playerClient;

        void OnClick()
        {
            bool succses = false;
            succses = playerClient.Call<bool>("sendMessage", "halo-halo");
            if (succses)
                Debug.Log("send succes");
            else
                Debug.Log("send false");
        }
        // Use this for initialization
        void Start()
        {
            string[] args = new string[2];
            args[0] = host;
            args[1] = port;
            unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            activity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
            activity.Call("runOnUiThread", new AndroidJavaRunnable(() =>
                {

                    playerClient = new AndroidJavaObject("com.its.warlocksaga.AndroidUnityListener", args);

                }));
        }

        public void ReceiveMessage(string Message)
        {
            Debug.Log(Message);
        }

        
        // Update is called once per frame
        void Update()
        {

        }
    }
}