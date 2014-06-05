using UnityEngine;
using System.Collections;

public class TestAnimationScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        this.GetComponent<Animator>().SetBool(
          "IsAttack", true);
	}
	
	// Update is called once per frame
	void Update () {
       
	}
}
