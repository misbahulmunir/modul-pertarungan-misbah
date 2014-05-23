using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ModulPertarungan
{
public class FacebookHandler : MonoBehaviour {

	#region FB.Init
	private bool isInit = false;
	public string name;
	public bool boolShow = false;
	ButtonHandler BH;
	
	public void CallFBInit()
	{
		FB.Init(OnInitComplete, OnHideUnity);
	}

	public void OnInitComplete()
	{
		Debug.Log("FB.Init completed: Is user logged in? " + FB.IsLoggedIn);
		isInit = true;
	}

	public void OnHideUnity(bool isGameShown)
	{
		Debug.Log("Is game showing? " + isGameShown);
	}
	#endregion

	#region FB.Login
	string email;
	public string lastResponse;
	public string responseText;
	public void CallFBLogin()
	{
		FB.Login(email, LoginCallback);
	}
	
	public void LoginCallback(FBResult result)
	{
		if (result.Error != null)
			lastResponse = "Error Response:\n" + result.Error;
		else if (!FB.IsLoggedIn)
		{
			lastResponse = "Login cancelled by Player";
		}
		else
		{
			lastResponse = "Login was successful!";
			//BH.boolGetName = true;
			FB.API("/me?fields=id", Facebook.HttpMethod.GET, Callback);
		}
		Debug.Log(lastResponse);
	}
	
	public void CallFBLogout()
	{
		FB.Logout();
	}
	#endregion

	#region FB.API
	private Texture2D lastResponseTexture;
	public string ApiQuery = "/me/friends?fields=name";
	
	public void CallFBAPI()
	{
		FB.API(ApiQuery, Facebook.HttpMethod.GET, Callback);
	}

	public void Callback(FBResult result)
	{
		lastResponseTexture = null;
		// Some platforms return the empty string instead of null.
		if (!String.IsNullOrEmpty(result.Error))
			responseText = "Error Response:\n" + result.Error;
		else if (!ApiQuery.Contains("/picture"))
		{
			responseText = result.Text;
			boolShow = true;
		}
		else
		{
			lastResponseTexture = result.Texture;
			responseText = result.Text + "\n";
		}
		name = responseText;
	}
	
	#endregion

	#region FB.Feed
	
	public string FeedToId = "";
	public string FeedLink = "";
	public string FeedLinkName = "";
	public string FeedLinkCaption = "Ayo Mainkan Card Warlock Saga!!!";
	public string FeedLinkDescription = "Card Warlock Saga bagus lho.";
	public string FeedPicture = "";
	public string FeedMediaSource = "";
	public string FeedActionName = "";
	public string FeedActionLink = "";
	public string FeedReference = "";
	public bool IncludeFeedProperties = false;
	private Dictionary<string, string[]> FeedProperties = new Dictionary<string, string[]>();
	
	public void CallFBFeed()
	{
		Dictionary<string, string[]> feedProperties = null;
		if (IncludeFeedProperties)
		{
			feedProperties = FeedProperties;
		}
		FB.Feed(
			toId: FeedToId,
			link: FeedLink,
			linkName: FeedLinkName,
			linkCaption: FeedLinkCaption,
			linkDescription: FeedLinkDescription,
			picture: FeedPicture,
			mediaSource: FeedMediaSource,
			actionName: FeedActionName,
			actionLink: FeedActionLink,
			reference: FeedReference,
			properties: feedProperties,
			callback: Callback
			);
	}
	
	#endregion

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
}