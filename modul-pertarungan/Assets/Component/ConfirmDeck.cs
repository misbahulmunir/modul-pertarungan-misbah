using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System;
namespace ModulPertarungan
{
    public class ConfirmDeck : MonoBehaviour
    {   
        // Use this for initialization
        public GameObject grid;
        public GameObject deckPointCost;
        public GameObject playerDP;
        private List<string> cardList;
        private List<int> cardQuantity;
        private int totalDeckCost;

        public void OnClick()
        {
            totalDeckCost = 0;
            cardList = new List<string>();
            cardQuantity = new List<int>();

            int DPCost = int.Parse(deckPointCost.GetComponent<UILabel>().text);
            int DPLeft = int.Parse(playerDP.GetComponent<UILabel>().text);

            GameManager.Instance().AllSelectedCard= new List<string>();
            foreach (Transform t in grid.transform)
            {
                string s = t.name.Split('(')[0];
                GameManager.Instance().AllSelectedCard.Add(s);   

                bool is_distinguish = true;
                for(int i=0;i<cardList.Count;i++)
                {
                    if (cardList[i] == s)
                    {
                        is_distinguish = false;
                        cardQuantity[i]++;
                        totalDeckCost += t.gameObject.GetComponent<CardsEffect>().CardCost;
                        break;
                    }
                }
                if (is_distinguish)
                {
                    cardList.Add(s);
                    cardQuantity.Add(1);
                    totalDeckCost += t.gameObject.GetComponent<CardsEffect>().CardCost;
                }
            }

            if (DPCost <= DPLeft)
            {
                WebServiceSingleton.GetInstance().ProcessRequest("clear_deck|" + GameManager.Instance().PlayerId);

                for (int i = 0; i < cardList.Count; i++)
                {
                    WebServiceSingleton.GetInstance().ProcessRequest("insert_to_deck|" + GameManager.Instance().PlayerId + "|" + cardList[i] + "|" + cardQuantity[i]);
                    Debug.Log(WebServiceSingleton.GetInstance().responseFromServer);
                }
                
                //for (int i = 1; i <= 2; i++)
                //{
                    //try
                    //{
                    //    //string param = "";
                    //    //if (i == 1) param = "deck";
                    //    //else param = "trunk";

                WebClient webClient = new WebClient();
                WebServiceSingleton.GetInstance().ProcessRequest("player_deck|" + GameManager.Instance().PlayerId);
                Debug.Log("query result : " + WebServiceSingleton.GetInstance().responseFromServer);
                WebServiceSingleton.GetInstance().ProcessRequest("player_trunk|" + GameManager.Instance().PlayerId);
                Debug.Log("query result : " + WebServiceSingleton.GetInstance().responseFromServer);

                string path = Application.persistentDataPath + "/deck_of_" + GameManager.Instance().PlayerId + ".xml";

                webClient.DownloadFile(new Uri("http://cws.yowanda.com/files/deck_of_" + GameManager.Instance().PlayerId + ".xml"), path);
                //webClient.DownloadFile(new Uri("http://cws.yowanda.com/files/deck_of_" + GameManager.Instance().PlayerId + ".xml"), path);
                //webClient.DownloadFile(new Uri("http://cws.yowanda.com/files/deck_of_" + GameManager.Instance().PlayerId + ".xml"), path);
                //webClient.DownloadFile(new Uri("http://cws.yowanda.com/files/deck_of_" + GameManager.Instance().PlayerId + ".xml"), path);

                path = Application.persistentDataPath + "/trunk_of_" + GameManager.Instance().PlayerId + ".xml";


                webClient.DownloadFile(new Uri("http://cws.yowanda.com/files/trunk_of_" + GameManager.Instance().PlayerId + ".xml"), path);
                webClient.DownloadFile(new Uri("http://cws.yowanda.com/files/trunk_of_" + GameManager.Instance().PlayerId + ".xml"), path);
                webClient.DownloadFile(new Uri("http://cws.yowanda.com/files/trunk_of_" + GameManager.Instance().PlayerId + ".xml"), path);
                webClient.DownloadFile(new Uri("http://cws.yowanda.com/files/trunk_of_" + GameManager.Instance().PlayerId + ".xml"), path);
                    //}
                    //catch
                    //{
                    //    Debug.Log("Error connecting to CWS server");
                    //}
                    
                //}


                //WebServiceSingleton.GetInstance().ProcessRequest("player_deck|agil");
                //string url = "http://cws.yowanda.com/files/deck_of_agil.xml";
                //string path = Application.persistentDataPath + "/deck_of_agil.xml";
                //Debug.Log("result : " + WebServiceSingleton.GetInstance().DownloadFile(url, path));

                Application.LoadLevel("BeforeBattle");
            }
            else
            {
                Debug.Log("Not Enough DP");
            }
              
        }
    
       
        void Start()
        {
            totalDeckCost = 0;
        }

        // Update is called once per frame
        void Update()
        {

        }
        void instantiate()
        {
          
        }
    }
}