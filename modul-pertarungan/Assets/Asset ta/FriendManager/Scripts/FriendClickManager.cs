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
    int posY;
    TextReader textReader;
    PartialProfileFromService players;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void DownloadXML()
    {
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
    }

    void ViewFriendRequest()
    {
        for (int i = 0; i < 10; i++)
        {
            friendRequestLabel.GetComponent<UILabel>().text = i.ToString();
            GameObject obj = NGUITools.AddChild(friendRequestPanel, friendRequestLabel);
        }
    }
}
