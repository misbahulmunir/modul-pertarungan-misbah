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
    public GameObject friendlistPanel;
    public GameObject friendRemoveButton;
    public GameObject friendVisitButton;

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
        friendlistPanel.GetComponent<UIGrid>().Reposition();
	}

    void DownloadXML()
    {
        WebServiceSingleton.GetInstance().ProcessRequest("get_partial_profile", friendSearchInputLabel.GetComponent<UILabel>().text);
        Debug.Log(WebServiceSingleton.GetInstance().DownloadFile("get_partial_profile", friendSearchInputLabel.GetComponent<UILabel>().text));
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
                textReader.Dispose();
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

        WebServiceSingleton.GetInstance().ProcessRequest("send_friend_request", GameManager.Instance().PlayerId + "|" + friendSearchInputLabel.GetComponent<UILabel>().text);
        Debug.Log(WebServiceSingleton.GetInstance().queryInfo);
        if (WebServiceSingleton.GetInstance().queryResult > 0)
        {
            friendSearchResultLabel.GetComponent<UILabel>().text += "\nStatus: " + WebServiceSingleton.GetInstance().queryInfo;
        }
        else
        {
            friendSearchResultLabel.GetComponent<UILabel>().text = "Player doesn't exist";

        }
    }

    void RefreshGrid(GameObject gridObj)
    {
        foreach (Transform objGrid in gridObj.transform)
        {
            Destroy(objGrid.gameObject);
        }
    }

    public void ViewFriendRequest()
    {
        viewFriendRequestTab.SetActive(true);
        friendlistTab.SetActive(false);
        findFriendTab.SetActive(false);
        RefreshGrid(friendRequestPanel);
        WebServiceSingleton.GetInstance().ProcessRequest("get_friend_request", GameManager.Instance().PlayerId);
        if (WebServiceSingleton.GetInstance().queryResult > 0)
        {
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
        }
    }

    void ReloadFriendRequestXML()
    {
        WebServiceSingleton.GetInstance().ProcessRequest("get_friend_request", GameManager.Instance().PlayerId);
        Debug.Log(WebServiceSingleton.GetInstance().DownloadFile("get_friend_request", GameManager.Instance().PlayerId));
    }

    void ReloadFriendlistXML()
    {
        WebServiceSingleton.GetInstance().ProcessRequest("get_friend_list", GameManager.Instance().PlayerId);
        Debug.Log(WebServiceSingleton.GetInstance().DownloadFile("get_friend_list", GameManager.Instance().PlayerId));
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

    void RemoveFriend(object value)
    {
        nama = value as string;
        Debug.Log(nama);
        WebServiceSingleton.GetInstance().ProcessRequest("remove_friend", GameManager.Instance().PlayerId + "|" + nama);
        ReloadFriendlistXML();
        ViewFriendList();
    }

    void ViewFriendList()
    {
        friendlistTab.SetActive(true);
        viewFriendRequestTab.SetActive(false);
        findFriendTab.SetActive(false);

        RefreshGrid(friendlistPanel);
        WebServiceSingleton.GetInstance().ProcessRequest("get_friend_list", GameManager.Instance().PlayerId);
        Debug.Log(WebServiceSingleton.GetInstance().DownloadFile("get_friend_list", GameManager.Instance().PlayerId));
        if (WebServiceSingleton.GetInstance().queryResult > 0)
        {
            try
            {
                XmlSerializer deserializer = new XmlSerializer(typeof(FriendListFromService));
                textReader = new StreamReader(Application.persistentDataPath + "/friends_of_" + GameManager.Instance().PlayerId + ".xml");
                object obj = deserializer.Deserialize(textReader);
                FriendListFromService friendlist = (FriendListFromService)obj;
                foreach (var player in friendlist.players)
                {
                    friendRequestLabel.GetComponent<UILabel>().text = player.Name + "   " + player.Job + "   Rank " + player.Rank + "   Level " + player.Level;
                    var objL = NGUITools.AddChild(friendlistPanel, friendRequestLabel);
                    objL.name = player.Name + "_label";
                    var objV = NGUITools.AddChild(friendlistPanel, friendVisitButton);
                    objV.name = player.Name + "_nvisit_button";
                    var objB = NGUITools.AddChild(friendlistPanel, friendRemoveButton);
                    objB.name = player.Name + "_remove_button";
                }
                textReader.Close();
            }
            catch (Exception e)
            {
                Debug.Log(e);
            }
        }
    }

    void ViewFindFriend()
    {
        findFriendTab.SetActive(true);
        friendlistTab.SetActive(false);
        viewFriendRequestTab.SetActive(false);
    }

    void VisitFriend(object value)
    {
        nama = value as string;
        Debug.Log("visit " + nama);
        GameManager.Instance().FriendName = nama;
        WebServiceSingleton.GetInstance().ProcessRequest("get_player_avatar", nama);
        Debug.Log(WebServiceSingleton.GetInstance().DownloadFile("get_player_avatar", nama));
        WebServiceSingleton.GetInstance().ProcessRequest("get_profile", nama);
        Debug.Log(WebServiceSingleton.GetInstance().DownloadFile("get_partial_profile", nama));
        WebServiceSingleton.GetInstance().ProcessRequest("get_player_deck", nama);
        Debug.Log(WebServiceSingleton.GetInstance().DownloadFile("get_player_deck", nama));
        Application.LoadLevel("FriendProfile");
    }

    void BackButton()
    {
        Application.LoadLevel("HouseEditor");
    }
}
