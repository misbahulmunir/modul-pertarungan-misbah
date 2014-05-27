﻿using UnityEngine;
using System.Collections;
using ModulPertarungan;

public class AcceptFriendButton : MonoBehaviour {

    string[] nama;
    public GameObject manager;
    public string methodName;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnClick()
    {
        nama = gameObject.transform.parent.name.Split('_');
        //WebServiceSingleton.GetInstance().ProcessRequest("accept_friend_request", GameManager.Instance().PlayerId + "|" + nama[0]);
        
        manager = GameObject.Find("FriendManagementClickManager");
        manager.SendMessage(this.methodName, nama[0]);
    }
}
