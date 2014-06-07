using UnityEngine;
using System.Collections;
using ModulPertarungan;

public class VisitFriendScript : MonoBehaviour {

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
        nama = gameObject.name.Split('_');

        manager = GameObject.Find("FriendManagementClickManager");
        manager.SendMessage(this.methodName, nama[0]);
    }
}
