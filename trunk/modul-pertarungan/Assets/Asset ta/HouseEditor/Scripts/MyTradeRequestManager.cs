using UnityEngine;
using System.Collections;
using Holoville.HOTween;
using ModulPertarungan;
using System.Xml.Serialization;
using System.IO;
using System;
using System.Collections.Generic;

public class MyTradeRequestManager : MonoBehaviour {

    public GameObject tradeRequestPanel;
    public GameObject messagePanelPosition;
    public GameObject messagePanelPositionStart;
    public GameObject newTradeRequest;
    public GameObject viewTradeButton;
    public GameObject tradeRequestTable;
    string tradeFrom;
    string tradeID;

    TextReader textReader;
    TradeRequestFromService myTradeRequest;
	// Use this for initialization
	void Start () {
        WebServiceSingleton.GetInstance().isLoadingScreen = false;
        ViewTradeRequest();       
	}
	
	// Update is called once per frame
	void Update () {
	}

    void TweenObjectIn(GameObject from, GameObject to)
    {
        var parms = new TweenParms();
        parms.Prop("position", to.transform.position);
        HOTween.To(from.transform, 1f, parms);
    }

    void ReloadGrid()
    {
        List<GameObject> messageChild = new List<GameObject>();
        foreach (Transform mChild in tradeRequestTable.transform)
        {
            Destroy(mChild.gameObject);
        }
    }

    void TweenObjectOut(GameObject from, GameObject to)
    {
        from.transform.position = to.transform.position;
    }

    void MessageTweenOut()
    {
        TweenObjectOut(tradeRequestPanel, messagePanelPositionStart);
        GameManager.Instance().UpdatePaused = false;
    }

    void ViewTradeRequest()
    {
        ReloadGrid();
        WebServiceSingleton.GetInstance().ProcessRequest("get_trade_request_list", GameManager.Instance().PlayerId);
        if (WebServiceSingleton.GetInstance().queryResult > 0)
        {
            //Debug.Log(WebServiceSingleton.GetInstance().DownloadFile("get_trade_request_list", GameManager.Instance().PlayerId));
            try
            {
                XmlSerializer deserializer = new XmlSerializer(typeof(TradeRequestFromService));
                //textReader = new StreamReader(Application.persistentDataPath + "/trade_request_list_of_" + GameManager.Instance().PlayerId + ".xml");
                textReader = new StringReader(WebServiceSingleton.GetInstance().queryInfo);
                object obj = deserializer.Deserialize(textReader);
                TradeRequestFromService tradeList = (TradeRequestFromService)obj;
                foreach (var from in tradeList.players)
                {
                    newTradeRequest.name = from.ID + "_" + "tradeFrom_";
                    viewTradeButton.name = from.ID + "_" + "tradeID_" ;
                    newTradeRequest.GetComponent<UILabel>().text = "trade request from : " + from.Name;
                    var newFromButton = NGUITools.AddChild(tradeRequestTable, viewTradeButton);
                    var newFrom = NGUITools.AddChild(tradeRequestTable, newTradeRequest);
                }
                textReader.Close();
                tradeRequestTable.GetComponent<UITable>().Reposition();
            }
            catch (Exception e)
            {
                Debug.Log(e);
            }
        }
    }

    void ViewTradeRequestPanel()
    {
        ViewTradeRequest();
        if (!GameManager.Instance().UpdatePaused)
        {
            TweenObjectIn(tradeRequestPanel, messagePanelPosition);
            GameManager.Instance().UpdatePaused = true;
        }
    }

    void GoToTradeRequest(object value)
    {
        tradeID = value as string;
        GameManager.Instance().TradeID = tradeID;
        WebServiceSingleton.GetInstance().ProcessRequest("get_card_request_list", GameManager.Instance().PlayerId + "|" + tradeID);
        if (WebServiceSingleton.GetInstance().queryResult > 0)
        {
            //Debug.Log(WebServiceSingleton.GetInstance().DownloadFile("get_card_request_list", GameManager.Instance().PlayerId));
        }
        Application.LoadLevel("TradingConfirmationScene");
    }
}
