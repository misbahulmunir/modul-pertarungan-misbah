using UnityEngine;
using System.Collections;

public class GoToDungeonScript : MonoBehaviour {

    string[] splitName;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnClick()
    {
        splitName = gameObject.transform.name.Split('(');
        Application.LoadLevel(splitName[0]);
    }
}
