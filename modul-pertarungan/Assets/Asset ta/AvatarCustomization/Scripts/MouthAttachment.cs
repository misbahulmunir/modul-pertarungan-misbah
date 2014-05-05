using UnityEngine;
using System.Collections;

public class MouthAttachment : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		OnClick();
	}

	public GameObject mouthStyle1, mouthStyle2, mouthStyle3;
	Object mChild;
	
	void AttachMouth (string styleChosen)
	{
		Destroy (mChild);
		var currentPos = this.transform.position;
		if (styleChosen == "menumulut1") 
		{
			var mouthStyle =  Instantiate(mouthStyle1, currentPos, Quaternion.identity);
			mChild = mouthStyle;
			Debug.Log("mouthstyle1");
		} else
			if (styleChosen == "menumulut2") 
		{
			var mouthStyle =  Instantiate(mouthStyle2, currentPos, Quaternion.identity);
			mChild = mouthStyle;
			Debug.Log("mouthstyle2");
		} else
			if (styleChosen == "menumulut3") 
		{
			var mouthStyle =  Instantiate(mouthStyle3, currentPos, Quaternion.identity);
			mChild = mouthStyle;
			Debug.Log("mouthstyle3");
		}
	}
	
	void OnClick()
	{
		RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
		if (Input.GetMouseButtonUp(0))
		{
			if (hit.collider != null)
			{
				if (hit.collider.gameObject.name.ToLower().Contains("menumulut"))
				{
					GameObject objM = hit.collider.gameObject as GameObject;
					Debug.Log(objM.name);
					AttachMouth(objM.name);
				}
			}
		}
	}
}
