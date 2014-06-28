using UnityEngine;
using System.Collections;
using ModulPertarungan;
using System.Xml.Serialization;
using System.IO;
using System;
using System.Collections.Generic;
using System.Xml;
using Holoville.HOTween;

public class FriendProfileManager : MonoBehaviour {
    
    TextReader textReader;
    PartialProfileFromService player;
    private XmlDocument _xmlDoc;
    private XmlNodeList _nameNodes;
    private XmlNodeList _quantityNodes;
    public GameObject friendNameLabel;
    public GameObject friendJobLabel;
    public GameObject friendRankLabel;
    public GameObject friendLevelLabel;
    public GameObject friendCardGrid;

    public GameObject messageContainer;
    public GameObject messageContainerPosition;
    public GameObject messageContainerStart;
    public GameObject mailSubject;
    public GameObject mailText;

	// Use this for initialization
	void Start () {
        viewFriendProfile(GameManager.Instance().FriendName); 
        _xmlDoc = new XmlDocument();
        //Debug.Log(GameManager.Instance().PlayerId);
        LoadCardFromService("deck_of_", friendCardGrid);
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    void viewFriendProfile(string name)
    {
         WebServiceSingleton.GetInstance().ProcessRequest("get_partial_profile", GameManager.Instance().FriendName);
         if (WebServiceSingleton.GetInstance().queryResult > 0)
         {
             try
             {
                 XmlSerializer deserializer = new XmlSerializer(typeof(PartialProfileFromService));
                 textReader = new StreamReader(Application.persistentDataPath + "/partial_profile_of_" + name + ".xml");
                 object obj = deserializer.Deserialize(textReader);
                 player = (PartialProfileFromService)obj;
                 friendNameLabel.GetComponent<UILabel>().text = player.Name;
                 friendJobLabel.GetComponent<UILabel>().text = player.Job;
                 friendRankLabel.GetComponent<UILabel>().text = player.Rank;
                 friendLevelLabel.GetComponent<UILabel>().text = player.Level.ToString();
                 textReader.Close();
             }
             catch (Exception e)
             {
                 Debug.Log(e);
             }
         }
    }

    void AddToGrid(GameObject grid, List<string> list)
    {
        foreach (string s in list)
        {
            NGUITools.AddChild(grid, (GameObject)Resources.Load("DisplayCards/" + s, typeof(GameObject)));
        }
        grid.GetComponent<UIGrid>().Reposition();
    }

    void LoadCardFromService(string method, GameObject grid)
    {
        List<string> list = new List<string>();
        Boolean _isEmpty = false;
        try
        {
            //Debug.Log(Application.persistentDataPath + "/" + method + GameManager.Instance().PlayerId + ".xml");
            TextReader textReader = new StreamReader(Application.persistentDataPath + "/" + method + GameManager.Instance().FriendName + ".xml");
            _xmlDoc.Load(textReader);
            _nameNodes = _xmlDoc.GetElementsByTagName("Name");
            _quantityNodes = _xmlDoc.GetElementsByTagName("Quantity");

            //Debug.Log("Method Name : " + method);
            for (int i = 0; i < _nameNodes.Count; i++)
            {
                for (int j = 0; j < int.Parse(_quantityNodes[i].InnerXml); j++)
                {
                    list.Add(_nameNodes[i].InnerXml);
                    //Debug.Log("Card Name : " + _nameNodes[i].InnerXml);
                }
            }
            IntegrationTest.Pass(this.gameObject);
        }
        catch
        {
            _isEmpty = true;
        }

        if (!_isEmpty) AddToGrid(grid, list);
    }

    void BackButton()
    {
        Application.LoadLevel("FriendManagementNew");
    }

    void TweenObjectIn(GameObject from, GameObject to)
    {
        var parms = new TweenParms();
        parms.Prop("position", to.transform.position);
        HOTween.To(from.transform, 1f, parms);
    }


    void TweenObjectOut(GameObject from, GameObject to)
    {
        from.transform.position = to.transform.position;
    }

    void SendMessage()
    {
        var encoded_subject = System.Text.Encoding.UTF8.GetBytes(mailSubject.GetComponent<UILabel>().text);
        var encoded_text = System.Text.Encoding.UTF8.GetBytes(mailText.GetComponent<UILabel>().text);

        WebServiceSingleton.GetInstance().ProcessRequest("send_message", GameManager.Instance().PlayerId + "-" + GameManager.Instance().FriendName + "|" + System.Convert.ToBase64String(encoded_subject) + "|" + System.Convert.ToBase64String(encoded_text));
        Debug.Log(WebServiceSingleton.GetInstance().responseFromServer);
        //TweenObjectOut(messageContainer, messageContainerStart);
        TweenObjectIn(messageContainer, messageContainerStart);
    }

    void CancelMessage()
    {
        TweenObjectIn(messageContainer, messageContainerStart);
        mailSubject.GetComponent<UILabel>().text = "Subject";
        mailText.GetComponent<UILabel>().text = "Text";
    }

    void ViewMailContainer()
    {
        TweenObjectIn(messageContainer, messageContainerPosition);
    }

    void GoToTrade()
    {
        Application.LoadLevel("TradingScene");
    }
}
