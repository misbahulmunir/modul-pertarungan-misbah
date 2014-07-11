using UnityEngine;
using System.Collections;
using System.Net;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System;
using System.Collections.Generic;
using System.Xml;
using System.IO;
using ModulPertarungan;

public class FacebookButtonHandler : MonoBehaviour {

	FacebookHandler FH = new FacebookHandler();
	public GameObject label;
	public GameObject label1;
	string [] splitResponse;
	string response;
	bool viewFriend = false;
	string [] dummy;
	public bool boolGetName = false;
	string headerText;
	string result, FBID;
	private XmlDocument _xmlDoc;
	private XmlNodeList _nameNodes;
    public GameObject loadingBox;
    Vector3 startPos;
	// Use this for initialization
	void Start () {
		FH.CallFBInit ();
		_xmlDoc = new XmlDocument();
        startPos = loadingBox.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        if (FH.LoginSuccess == true)
        {
            loadingBox.transform.position = new Vector3(0f, 0f, 0f);
        }
        if (FB.IsLoggedIn && FH.responseText != null)
        {
            ChangeScene();
            loadingBox.transform.position = startPos;
        }
	}

	string splitTextName(string text)
	{
		splitResponse = text.Split('"');
		return splitResponse[3];
	}

	void FBShare()
	{
		FH.CallFBFeed ();
		Debug.Log ("FB Share");
	}

	void FBLogout()
	{
		FH.CallFBLogout ();
		label1.GetComponent<UILabel> ().text = "";
		label.GetComponent<UILabel> ().text = "";
		Debug.Log ("FB Logout");
	}

	void FBInit()
	{
		FH.CallFBInit ();
		Debug.Log ("FB Init");
	}

	void FBLogin()
	{
	    FH.CallFBLogin ();
		headerText = "Welcome, ";
		//label1.GetComponent<UILabel> ().text = "Call Login";
		Debug.Log ("FB Login");
	}

	void FBApi()
	{
		if (FH.boolShow == true) 
		{
			label1.GetComponent<UILabel> ().text = "API Called";
			label.GetComponent<UILabel> ().text = headerText + "\n"; 
			splitResponse = FH.responseText.Split('"');
			for(int i = 5; i<splitResponse.Length; i=i+8)
			{
				label.GetComponent<UILabel> ().text = label.GetComponent<UILabel> ().text + splitResponse[i] + "\n";
			}
			FH.boolShow = false;
		}
		FH.CallFBAPI ();
		headerText = "FriendList: \n";
		label1.GetComponent<UILabel> ().text = "Call API";
		Debug.Log ("FB Api");
	}

    void ChangeScene()
    {
        FBID = splitTextName(FH.responseText);
        //label1.GetComponent<UILabel> ().text = FH.lastResponse;
        //label.GetComponent<UILabel> ().text = headerText + splitTextName(FH.responseText);
        FH.boolShow = false;
        boolGetName = false;
        Debug.Log(FH.lastResponse);
        WebServiceSingleton.GetInstance().ProcessRequest("get_name_by_fb", FBID);
        Debug.Log(WebServiceSingleton.GetInstance().responseFromServer);
        GameManager.Instance().PlayerFBId = FBID;
        if (WebServiceSingleton.GetInstance().queryResult > 0)
        {
            GameManager.Instance().PlayerId = WebServiceSingleton.GetInstance().queryInfo;
            Debug.Log(WebServiceSingleton.GetInstance().queryInfo);
            Application.LoadLevel("Loading");
        }
        else
        {
            Debug.Log("FB belum terdaftar");
            Application.LoadLevel("JobSelection");
        }
    }

}
