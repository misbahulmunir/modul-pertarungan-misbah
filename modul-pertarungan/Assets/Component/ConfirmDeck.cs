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
        private string id = GameManager.Instance().PlayerId;

        public void OnClick()
        { 
            totalDeckCost = 0;
            cardList = new List<string>();
            cardQuantity = new List<int>();

            int DPCost = int.Parse(deckPointCost.GetComponent<UILabel>().text);
            int DPLeft = int.Parse(playerDP.GetComponent<UILabel>().text);

          
            foreach (Transform t in grid.transform)
            {
                string s = t.name.Split('(')[0];
                

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
                WebServiceSingleton.GetInstance().ProcessRequest("clear_deck", id);
                Debug.Log(WebServiceSingleton.GetInstance().responseFromServer);
                for (int i = 0; i < cardList.Count; i++)
                {
                    WebServiceSingleton.GetInstance().ProcessRequest("insert_to_deck", id + "|" + cardList[i] + "|" + cardQuantity[i]);
                    Debug.Log(WebServiceSingleton.GetInstance().responseFromServer);
                }

                for (int i = 1; i <= 2; i++)
                {
                    try
                    {
                        string param = "";
                        if (i == 1) param = "deck";
                        else param = "trunk";
                        WebClient webClient = new WebClient();
                        WebServiceSingleton.GetInstance().ProcessRequest("get_player_" + param, id);
                        Debug.Log("response : " + WebServiceSingleton.GetInstance().responseFromServer);
                        Debug.Log(WebServiceSingleton.GetInstance().DownloadFile("get_player_" + param, id));
                        Debug.Log(WebServiceSingleton.GetInstance().isLoadingScreen);
                    }
                    catch
                    {
                        Debug.Log("Error connecting to CWS server");
                    }

                }
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