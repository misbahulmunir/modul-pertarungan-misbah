using UnityEngine;
using System.Collections;

public class HairAttachment : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		OnClick ();
	}

	public GameObject hairStyle1, hairStyle2, hairStyle3;
	Object hChild;

	void AttachHair (string styleChosen)
	{
		Destroy (hChild);
		var currentPos = this.transform.position;
		if (styleChosen == "menurambut1") 
		{
			var hairStyle =  Instantiate(hairStyle1, currentPos, Quaternion.identity);
			hChild = hairStyle;
			Debug.Log("hairstyle1");
		} else
		if (styleChosen == "menurambut2") 
		{
			var hairStyle =  Instantiate(hairStyle2, currentPos, Quaternion.identity);
			hChild = hairStyle;
			Debug.Log("hairstyle2");
		} else
		if (styleChosen == "menurambut3") 
		{
			var hairStyle =  Instantiate(hairStyle3, currentPos, Quaternion.identity);
			hChild = hairStyle;
			Debug.Log("hairstyle3");
		}
	}

	void OnClick()
	{
		RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
		if (Input.GetMouseButtonUp(0))
		{
			if (hit.collider != null)
			{
				if (hit.collider.gameObject.name.ToLower().Contains("menurambut"))
				{
					GameObject objH = hit.collider.gameObject as GameObject;
					Debug.Log(objH.name);
					AttachHair(objH.name);
				}
			}
		}
	}
}
