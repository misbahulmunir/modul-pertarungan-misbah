using UnityEngine;
using System.Collections;

public class HoverCard : MonoBehaviour {

	// Use this for initialization
    public GameObject cardName;
    public GameObject cardCost;
    public GameObject cardEffect;
    private Ray ray;
    private RaycastHit hit;

    public void OnClick()
    {

        Debug.Log(this.gameObject.name);
    }
	void Start () {
	     

	}
	
	// Update is called once per frame
	void Update () {
       
	}
}
