using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using System.Xml;
using System.IO;
using System.Xml.Serialization;
using ModulPertarungan;

public class TradingConfirmation : MonoBehaviour
{
    public GameObject myRequestedCardGrid;
    public GameObject hisOfferGrid;
    private XmlDocument _xmlDoc;
    private XmlNodeList _nameNodes;
    private XmlNodeList _quantityNodes;
    TextReader textReader;
    private List<string> myTradeList;
    private List<string> hisTradeList;

	// Use this for initialization
	void Start () 
    {
        _xmlDoc = new XmlDocument();
        //Debug.Log(GameManager.Instance().PlayerId);
        LoadOffer("card_request_list_of_", GameManager.Instance().PlayerId);
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    public void AddToGrid(GameObject grid, List<string> list)
    {
        foreach (string s in list)
        {
            NGUITools.AddChild(grid, (GameObject)Resources.Load("DisplayCards/" + s, typeof(GameObject)));
        }
        grid.GetComponent<UIGrid>().Reposition();
    }

    public void LoadOffer(string method, string name)
    {
        myTradeList = new List<string>();
        hisTradeList = new List<string>();
        Boolean _isEmpty = false;
        try
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(CardRequestFromService));
            textReader = new StreamReader(Application.persistentDataPath + "/card_request_list_of_" + GameManager.Instance().PlayerId + ".xml");
            object obj = deserializer.Deserialize(textReader);
            CardRequestFromService cardReqList = (CardRequestFromService)obj;
            foreach (var _card in cardReqList.requestedCards)
            {
                for (int i = 0; i < _card.Quantity; i++)
                {
                    myTradeList.Add(_card.Name);
                }
            }
            foreach (var _card in cardReqList.offeredCards)
            {
                for (int i = 0; i < _card.Quantity; i++)
                {
                    hisTradeList.Add(_card.Name);
                }
            }
            textReader.Close();
        }
        catch (Exception e)
        {
            Debug.Log(e);
        }

        if (!_isEmpty)
        {
            AddToGrid(myRequestedCardGrid, myTradeList);
            AddToGrid(hisOfferGrid, hisTradeList);
        }

        myRequestedCardGrid.GetComponent<UIGrid>().Reposition();
        hisOfferGrid.GetComponent<UIGrid>().Reposition();

    }

    public void AcceptTradeRequest()
    {
        WebServiceSingleton.GetInstance().ProcessRequest("accept_trade_request", GameManager.Instance().TradeID);
        Debug.Log(WebServiceSingleton.GetInstance().DownloadFile("get_player_trunk", GameManager.Instance().PlayerId));
        Application.LoadLevel("HouseEditor");
    }

    public void DeclineTradeRequest()
    {
        WebServiceSingleton.GetInstance().ProcessRequest("decline_trade_request", GameManager.Instance().TradeID);
        Application.LoadLevel("HouseEditor");
    }
}
