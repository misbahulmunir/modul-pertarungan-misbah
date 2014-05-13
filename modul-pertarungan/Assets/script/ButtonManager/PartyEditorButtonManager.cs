using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System;

namespace ModulPertarungan
{
    public class PartyEditorButtonManager : MonoBehaviour
    {

        public GameObject grid;
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        private void ConfirmParty()
        {
            GameManager.Instance().PartyId = new List<string>();

            foreach (Transform T in grid.transform)
            {
                if (T.GetComponent<Avatar>().PlayerName != null)
                {
                    GameManager.Instance().PartyId.Add(T.GetComponent<Avatar>().PlayerName);
                }
            }

            foreach (string s in GameManager.Instance().PartyId)
            {
                try
                {
                    WebServiceSingleton.GetInstance().processRequest("get_profile|" + s);
                    Debug.Log(WebServiceSingleton.GetInstance().responseFromServer);
                    string path = Application.persistentDataPath + "/player_profile_" + s + ".xml";
                    WebClient webClient = new WebClient();
                    webClient.DownloadFile(new Uri("http://cws.yowanda.com/files/player_profile_" + s + ".xml"), path);

                    WebServiceSingleton.GetInstance().processRequest("player_deck|" + s);
                    Debug.Log(WebServiceSingleton.GetInstance().responseFromServer);
                    path = Application.persistentDataPath + "/deck_of_" + s + ".xml";
                    webClient.DownloadFile(new Uri("http://cws.yowanda.com/files/deck_of_" + s + ".xml"), path);
                }
                catch
                {
                    Debug.Log("Error Reading Player Data");
                }
            }

            Application.LoadLevel("BeforeBattle");
        }
    }
}
