using UnityEngine;
using System.Collections;

public class CollectCard : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter(Collider obj)
    {
        Debug.Log("Collide");
        Destroy(obj.gameObject);
    }
}
