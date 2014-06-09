using UnityEngine;
using System.Collections;

public class TestParticle : MonoBehaviour {

	// Use this for initialization
	void Start () {
	   
	}
	
	// Update is called once per frame
	void Update () {
	  GameObject.Find("Explosion03b").transform.GetChild(0).GetComponent<ParticleSystem>().Play();
	}
}
