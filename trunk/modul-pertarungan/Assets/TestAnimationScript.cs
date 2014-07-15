using UnityEngine;
using System.Collections;

public class TestAnimationScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {
        this.GetComponent<Animator>().SetBool("IsAttack", true);
	}
}
