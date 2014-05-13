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
            //Debug.Log("Total DP Cost : " + totalDeckCost);

            if (DPCost <= DPLeft)
            {
                WebServiceSingleton.GetInstance().processRequest("clear_deck|" + GameManager.Instance().PlayerId);
                //Debug.Log(WebServiceSingleton.GetInstance().responseFromServer);

                for (int i = 0; i < cardList.Count; i++)
                {
                    WebServiceSingleton.GetInstance().processRequest("insert_to_deck|" + GameManager.Instance().PlayerId + "|" + cardList[i] + "|" + cardQuantity[i]);
                    Debug.Log(WebServiceSingleton.GetInstance().responseFromServer);
                    //Debug.Log("Keterangan : "+ cardList[i] + " => " + cardQuantity[i]);
                }
                try
                {
                    WebServiceSingleton.GetInstance().processRequest("player_deck|" + GameManager.Instance().PlayerId);
                    Debug.Log(WebServiceSingleton.GetInstance().responseFromServer);
                    string path = Application.persistentDataPath + "/deck_of_" + GameManager.Instance().PlayerId + ".xml";
                    Debug.Log(path);
                    WebClient webClient = new WebClient();
                    webClient.DownloadFile(new Uri("http://cws.yowanda.com/files/deck_of_" + GameManager.Instance().PlayerId + ".xml"), path);

                    WebServiceSingleton.GetInstance().processRequest("player_trunk|" + GameManager.Instance().PlayerId);
                    Debug.Log(WebServiceSingleton.GetInstance().responseFromServer);
                    path = Application.persistentDataPath + "/trunk_of_" + GameManager.Instance().PlayerId + ".xml";
                    Debug.Log(path);
                    webClient.DownloadFile(new Uri("http://cws.yowanda.com/files/trunk_of_" + GameManager.Instance().PlayerId + ".xml"), path);

                    Application.LoadLevel("BeforeBattle");
                }
                catch
                {
                    Debug.Log(Application.persistentDataPath + "/deck_of_" + GameManager.Instance().PlayerId + ".xml");
                    Debug.Log("http://cws.yowanda.com/files/deck_of " + GameManager.Instance().PlayerId + ".xml");
                    Debug.Log("Error connecting to CWS server");
                }
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