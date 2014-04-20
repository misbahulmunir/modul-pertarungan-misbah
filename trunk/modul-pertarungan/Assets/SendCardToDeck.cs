using UnityEngine;
using System.Collections;

public class SendCardToDeck : MonoBehaviour {

	// Use this for initialization
    public GameObject grid;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision obj)
    {
        Debug.Log("Collide");
        Destroy(obj.gameObject);
    }
}
