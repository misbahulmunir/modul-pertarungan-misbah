using UnityEngine;
using System.Collections;

public class ViewRequestButton : MonoBehaviour {

    public string methodName;
    public GameObject manager;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnClick()
    {
        manager.SendMessage(this.methodName);
    }

}
