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
        public MessageBoxScirpt messageBox;
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
            if (grid.transform.childCount == 3)
            {
                GameManager.Instance().PartyId = new List<string>();

                foreach (Transform T in grid.transform)
                {
                    if (T.GetComponent<Avatar>().PlayerName != GameManager.Instance().PlayerId)
                    {
                        GameManager.Instance().PartyId.Add(T.GetComponent<Avatar>().PlayerName);
                    }
                }


                foreach (string s in GameManager.Instance().PartyId)
                {
                    try
                    {
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
                Application.LoadLevel("HouseEditor");
            }
            else
            {
                var obj = new object[2];
                obj[0] = "Notification";
                obj[1] = "Maximum party capacity is 3 player";
                messageBox.SendMessage("SetMessage", obj);
                messageBox.SendMessage("ShowMessageBox");
            }
        }

        void OnClick()
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (Input.GetMouseButtonUp(0))
            {
                if (hit.collider != null)
                {
                    GameObject obj = hit.collider.gameObject as GameObject;
                    Debug.Log(obj.name);
                }
            }
        }
    }
}
