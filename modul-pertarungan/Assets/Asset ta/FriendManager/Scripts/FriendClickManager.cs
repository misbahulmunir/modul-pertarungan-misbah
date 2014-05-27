using UnityEngine;
using System.Collections;
using ModulPertarungan;
using System.Xml.Serialization;
using System.IO;
using System;

public class FriendClickManager : MonoBehaviour {

    public GameObject friendSearchResultLabel;
    public GameObject friendSearchInputLabel;
    public GameObject friendRequestPanel;
    public GameObject friendRequestLabel;
    public GameObject friendRequestActionButton;

    public GameObject friendlistTab, viewFriendRequestTab, findFriendTab;
    int posY;
    string nama;
    TextReader textReader;
    PartialProfileFromService players;
	// Use this for initialization
	void Start () {
        //ViewFriendRequest();
	}
	
	// Update is called once per frame
	void Update () {
        friendRequestPanel.GetComponent<UIGrid>().Reposition();
	}

    void DownloadXML()
    {
        string alamat = Application.persistentDataPath + "/partial_profile_of" + friendSearchInputLabel.GetComponent<UILabel>().text + ".xml";
        WebServiceSingleton.GetInstance().clearData(alamat);
        WebServiceSingleton.GetInstance().DownloadFile("get_partial_profile", friendSearchInputLabel.GetComponent<UILabel>().text);
    }

    void SearchByNickname()
    {
        //friendSearchResultLabel.GetComponent<UILabel>().text = "";
        Debug.Log(friendSearchInputLabel.GetComponent<UILabel>().text);
        WebServiceSingleton.GetInstance().ProcessRequest("get_partial_profile", friendSearchInputLabel.GetComponent<UILabel>().text);
        //Debug.Log(WebServiceSingleton.GetInstance().responseFromServer);

        if (WebServiceSingleton.GetInstance().queryResult > 0)
        {
            DownloadXML();
            //Debug.Log(WebServiceSingleton.GetInstance().DownloadFile("get_partial_profile", friendSearchInputLabel.GetComponent<UILabel>().text));
            try
            {
                XmlSerializer deserializer = new XmlSerializer(typeof(PartialProfileFromService));
                textReader = new StreamReader(Application.persistentDataPath + "/partial_profile_of_" + friendSearchInputLabel.GetComponent<UILabel>().text + ".xml");
                object obj = deserializer.Deserialize(textReader);
                players = (PartialProfileFromService)obj;
                friendSearchResultLabel.GetComponent<UILabel>().text = "Nickname: " + players.Name + "\nJob: " + players.Job + "\nRank: " + players.Rank + "\nLevel: " + players.Level;
                textReader.Close();
                Debug.Log("bisa");
            }
            catch (Exception e)
            {
                Debug.Log(e);
            }
        }
        else
        {
            friendSearchResultLabel.GetComponent<UILabel>().text = "Player doesn't exist";
        }
    }

    void AddFriend()
    {
        //WebServiceSingleton.GetInstance().ProcessRequest("send_friend_request", GameManager.Instance().PlayerId + "|" + players.Name);
        WebServiceSingleton.GetInstance().ProcessRequest("send_friend_request", "zendra|" + players.Name);
        Debug.Log(WebServiceSingleton.GetInstance().queryInfo);
        friendSearchResultLabel.GetComponent<UILabel>().text += "Status: " + WebServiceSingleton.GetInstance().queryInfo;
    }

    void RefreshGrid()
    {
        foreach (Transform objGrid in friendRequestPanel.transform)
        {
            Destroy(objGrid.gameObject);
        }
    }

    public void ViewFriendRequest()
    {
        viewFriendRequestTab.SetActive(true);
        //friendlistTab.SetActive(false);
        findFriendTab.SetActive(false);
        RefreshGrid();
        try
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(RequestFromService));
            textReader = new StreamReader(Application.persistentDataPath + "/friend_request_of_" + GameManager.Instance().PlayerId + ".xml");
            object obj = deserializer.Deserialize(textReader);
            RequestFromService friendRequest = (RequestFromService)obj;
            foreach (var player in friendRequest.players)
            {
                friendRequestLabel.GetComponent<UILabel>().text = player.Name + "   " + player.Job + "   Rank " + player.Rank + "   Level " + player.Level;
                var objL = NGUITools.AddChild(friendRequestPanel, friendRequestLabel);
                objL.name = player.Name + "_label";
                var objB = NGUITools.AddChild(friendRequestPanel, friendRequestActionButton);
                objB.name = player.Name + "_request_button";
           } 
            textReader.Close();
        }
        catch (Exception e)
        {
            Debug.Log(e);
        }
        //for (int i = 0; i < 10; i++)
        //{
        //    //friendRequestLabel.GetComponent<UILabel>().text = i.ToString();
        //    //var obj = NGUITools.AddChild(friendRequestPanel, friendRequestLabel);
        //    //obj.name = i.ToString();
        //    //var objB = NGUITools.AddChild(friendRequestPanel, friendRequestActionButton);
        //    //objB.name = i.ToString()+"button";
        //}
    }

    void ReloadFriendRequestXML()
    {
        string alamat = Application.persistentDataPath + "/friend_request_of_zendra.xml";
        WebServiceSingleton.GetInstance().clearData(alamat);
        Debug.Log(WebServiceSingleton.GetInstance().DownloadFile("get_friend_request", GameManager.Instance().PlayerId));
    }

    void AcceptFriendRequest(object value)
    {
        nama = value as string;
        Debug.Log(nama);
        WebServiceSingleton.GetInstance().ProcessRequest("accept_friend_request", GameManager.Instance().PlayerId + "|" + nama);
        ReloadFriendRequestXML();
        ViewFriendRequest();
    }

    void IgnoreFriendRequest(object value)
    {
        nama = value as string;
        Debug.Log(nama);
        WebServiceSingleton.GetInstance().ProcessRequest("ignore_friend_request", GameManager.Instance().PlayerId + "|" + nama);
        ReloadFriendRequestXML();
        ViewFriendRequest();
    }

    void ViewFriendList()
    {
        friendlistTab.SetActive(true);
        viewFriendRequestTab.SetActive(false);
        findFriendTab.SetActive(false);
    }

    void ViewFindFriend()
    {
        findFriendTab.SetActive(true);
        //friendlistTab.SetActive(false);
        viewFriendRequestTab.SetActive(false);
    }

}
