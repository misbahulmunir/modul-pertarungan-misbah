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

namespace ModulPertarungan
{
public class ButtonHandler : MonoBehaviour {

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
	// Use this for initialization
	void Start () {
		FH.CallFBInit ();
		_xmlDoc = new XmlDocument();
	}
	
	// Update is called once per frame
	void Update () {

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
		if (FB.IsLoggedIn) 
		{
			FBID = splitTextName(FH.responseText);
			label1.GetComponent<UILabel> ().text = FH.lastResponse;
			//label.GetComponent<UILabel> ().text = headerText + splitTextName(FH.responseText);
			FH.boolShow = false;
			boolGetName = false;
			WebServiceSingleton.GetInstance().ProcessRequest("get_profile", FBID);
			Debug.Log(WebServiceSingleton.GetInstance().responseFromServer);
			if (WebServiceSingleton.GetInstance().queryResult>0)
			{
					string url = "http://cws.yowanda.com/files/" + "/player_profile_" + FBID + ".xml";
					string path = Application.persistentDataPath + "/player_profile_" + FBID + ".xml";
					result = WebServiceSingleton.GetInstance().DownloadFile(url, path);
					Debug.Log (result);
					TextReader textReader = new StreamReader(Application.persistentDataPath + "/player_profile_" + FBID + ".xml");
					_xmlDoc.Load(textReader);
					_nameNodes = _xmlDoc.GetElementsByTagName("Name");
					Debug.Log(_nameNodes[0].InnerXml);
			}
			else
			{
					Debug.Log ("FB belum terdaftar");
			}
		} else 
		{
			FH.CallFBLogin ();
			headerText = "Welcome, ";
			label1.GetComponent<UILabel> ().text = "Call Login";
		}
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

}
}
