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
                if (T.GetComponent<Avatar>().PlayerName != GameManager.Instance().PlayerId)
                {
                    GameManager.Instance().PartyId.Add(T.GetComponent<Avatar>().PlayerName);
                }
            }

            WebServiceSingleton.GetInstance().ProcessRequest("clear_party", GameManager.Instance().PlayerId);
            foreach (string s in GameManager.Instance().PartyId)
            {
                try
                {
                    WebServiceSingleton.GetInstance().ProcessRequest("insert_to_party", GameManager.Instance().PlayerId + "|" + s);
                    Debug.Log(WebServiceSingleton.GetInstance().responseFromServer);

                    WebServiceSingleton.GetInstance().ProcessRequest("get_profile", s);
                    //Debug.Log(WebServiceSingleton.GetInstance().responseFromServer);
                    Debug.Log(WebServiceSingleton.GetInstance().DownloadFile("get_profile", s));

                    WebServiceSingleton.GetInstance().ProcessRequest("get_player_deck", s);
                    //Debug.Log(WebServiceSingleton.GetInstance().responseFromServer);
                    Debug.Log(WebServiceSingleton.GetInstance().DownloadFile("get_player_deck", s));
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
