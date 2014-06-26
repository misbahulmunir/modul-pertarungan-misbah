using UnityEngine;
using System.Collections;
using ModulPertarungan;
using Holoville.HOTween;
public class ShopButtonManager : MonoBehaviour {

	// Use this for initialization
    Vector3 startPosisiton;
    UILabel CardName;
    UILabel cardEffect;
    UILabel cardCost;
	void Start () {
        startPosisiton = this.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
	  
	}
    void ShowShop()
    {
        var parms = new TweenParms();
        parms.Prop("position", new Vector3(0f,0.5f,0f));
        HOTween.To(this.transform, 1f, parms);
    }
    void CloseShop()
    {
        var parms = new TweenParms();
        parms.Prop("position", startPosisiton);
        HOTween.To(this.transform, 1f, parms);
    }

}
