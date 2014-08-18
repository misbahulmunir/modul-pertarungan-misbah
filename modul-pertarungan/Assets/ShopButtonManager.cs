using UnityEngine;
using System.Collections;
using ModulPertarungan;
using Holoville.HOTween;
namespace ModulPertarungan
{
public class ShopButtonManager : MonoBehaviour {

	// Use this for initialization
  
    void Start () {
        this.startPosisiton = this.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
	 
	}
  

    void ShowShop()
    {
        var parms = new TweenParms();
        parms.Prop("position", new Vector3(0f, 0.5f, 0f));
        HOTween.To(this.transform, 1f, parms);
        GameManager.Instance().UpdatePaused = true;
    }
    void CloseShop()
    {
        var parms = new TweenParms();
        parms.Prop("position", startPosisiton);
        HOTween.To(this.transform, 1f, parms);
        GameManager.Instance().UpdatePaused = false;
    }

    public object startPosisiton { get; set; }
}
}
