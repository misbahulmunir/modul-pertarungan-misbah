using UnityEngine;
using System.Collections;
using System.Collections.Generic;
namespace ModulPertarungan
{
    public class ConfirmDeck : MonoBehaviour
    {   
        // Use this for initialization
        public GameObject grid;
        private List<string> cardList;
        private List<int> cardQuantity;
        private int totalDeckCost;

        public void OnClick()
        {
            totalDeckCost = 0;
            cardList = new List<string>();
            cardQuantity = new List<int>();

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
            Debug.Log("Total DP Cost : " + totalDeckCost);
            //foreach (string s in GameManager.Instance().AllSelectedCard)
            //{
            //    bool is_distinguish = true;
            //    for(int i=0;i<cardList.Count;i++)
            //    {
            //        if (cardList[i] == s)
            //        {
            //            is_distinguish = false;
            //            cardQuantity[i]++;
            //            break;
            //        }
            //    }
            //    if (is_distinguish)
            //    {
            //        cardList.Add(s);
            //        cardQuantity.Add(1);
            //    }
            //}

            //WebServiceSingleton.GetInstance().createXMLDocument("clear_deck|" + GameManager.Instance().PlayerId);
            //Debug.Log(WebServiceSingleton.GetInstance().responseFromServer);

            for(int i=0;i<cardList.Count;i++)
            {
                //WebServiceSingleton.GetInstance().createXMLDocument("insert_to_deck|" + GameManager.Instance().PlayerId + "|" + cardList[i] + "|" + cardQuantity[i]);
                //Debug.Log(WebServiceSingleton.GetInstance().responseFromServer);
                //Debug.Log("Keterangan : "+ cardList[i] + " => " + cardQuantity[i]);
            }
            Application.LoadLevel("BeforeBattle");   
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