using UnityEngine;
using System.Collections;

public class ShopCardClick : MonoBehaviour {
    public GameObject ConfirmationBoard;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnClick()
    {
        object obj = new object();
        obj = this.gameObject.name;
        ConfirmationBoard.SendMessage("ShowPurchase", obj);
        Debug.Log("KLIK");
    }
}
