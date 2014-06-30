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
        public MessageBoxScirpt msgBox;
        private float t;
        float t2;
        bool flag = false;
        bool flag2 = false;
        public GameObject loading;
        public GameObject button1;
        public GameObject button2;
        public GameObject input;

        void TryConnect()
        {
            flag = false;
            flag2 = true;
            loading.SetActive(true);
            button1.SetActive(false);
            button2.SetActive(false);
            input.SetActive(false);
            NetworkSingleton.Instance().Host = host.GetComponent<UIInput>().value;
          
           NetworkSingleton.Instance().Connect();
            t2 = Time.time;
            

        }
        // Use this for initialization

        void Start()
        {
           
            NetworkSingleton.Instance().TcpPort = tcpPort;
            NetworkSingleton.Instance().UdpPort = udpPort;
           StartCoroutine(chekclogin());
           
           
        }
        // Update is called once per frame
        private void Update()
        {
            
            if (NetworkSingleton.Instance().ServerMessage != null)
            {
                if (NetworkSingleton.Instance().ServerMessage.Contains("Connected-to-server"))
                {
                    StopAllCoroutines();
                    Application.LoadLevel("LobbyRoom");
                    NetworkSingleton.Instance().ServerMessage = "";
                    
                }
            }
            if (flag2 == true)
            {
                t += Time.deltaTime;
            }
            if (t > 15)
            {
                if (flag == false)
                {
                    var obj = new object[2];
                    obj[0] = "Time is up";
                    obj[1] = "connection failed cannot contact server";
                    msgBox.SendMessage("SetMessage", obj);
                    msgBox.SendMessage("ShowMessageBox");
                    StopAllCoroutines();
                    t = 0.0f;
                }
                flag = true;
                flag2 = false;
                button1.SetActive(true);
                button2.SetActive(true);
                input.SetActive(true);
                loading.SetActive(false);
            }
            //Debug.Log(t);
        }
        IEnumerator chekclogin()
        {
            while (true)
            {
                
                NetworkSingleton.Instance().Connect();
                yield return new WaitForSeconds(0.5f);
               
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