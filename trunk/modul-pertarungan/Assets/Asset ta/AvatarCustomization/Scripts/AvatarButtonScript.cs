using UnityEngine;
using System.Collections;
using System.Net;
using ModulPertarungan;
using System;
using System.IO;
using System.Xml;
using System.Collections.Generic;

public class AvatarButtonScript : MonoBehaviour {

    string playerName = "";
    AvatarAttachment aa;
	// Use this for initialization
	void Start () {
        playerName = "zendra";
	}
	
	// Update is called once per frame
    void Update()
    {
        OnClick();
    }

    void OnClick()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        if (Input.GetMouseButtonUp(0))
        {
            if (hit.collider != null)
            {
                if (hit.collider.gameObject.name.ToLower().Contains("backbutton"))
                {
                    Application.LoadLevel("BeforeBattle");
                } else
                if (hit.collider.gameObject.name.ToLower().Contains("savebutton"))
                {
                    WebClient client = new WebClient();
                    Debug.Log(aa.AvatarList[0]);
                    string result = client.DownloadString("http://cws.yowanda.com/ClientController/4/avatar/edit_avatar/" + playerName + "/" + aa.AvatarList[0] + "/" + aa.AvatarList[1] + "/" + aa.AvatarList[2]);
                    Debug.Log(result);
                }
            }
        }
    }
}
