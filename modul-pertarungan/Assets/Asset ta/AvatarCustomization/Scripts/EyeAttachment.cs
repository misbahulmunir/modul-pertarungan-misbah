using UnityEngine;
using System.Collections;

public class EyeAttachment : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		OnClick();
	}
	
	public GameObject eyeStyle1, eyeStyle2, eyeStyle3;
	Object eChild;
	
	public void AttachEye (string styleChosen)
	{
		Destroy (eChild);
		var currentPos = this.transform.position;
		if (styleChosen == "menumata1") 
		{
			var eyeStyle =  Instantiate(eyeStyle1, currentPos, Quaternion.identity);
			eChild = eyeStyle;
			Debug.Log("eyestyle1");
		} else
			if (styleChosen == "menumata2") 
		{
			var eyeStyle =  Instantiate(eyeStyle2, currentPos, Quaternion.identity);
			eChild = eyeStyle;
			Debug.Log("eyestyle2");
		} else
			if (styleChosen == "menumata3") 
		{
			var eyeStyle =  Instantiate(eyeStyle3, currentPos, Quaternion.identity);
			eChild = eyeStyle;
			Debug.Log("eyestyle3");
		}
	}
	
	void OnClick()
	{
		RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
		if (Input.GetMouseButtonUp(0))
		{
			if (hit.collider != null)
			{
				if (hit.collider.gameObject.name.ToLower().Contains("menumata"))
				{
					GameObject objE = hit.collider.gameObject as GameObject;
					Debug.Log(objE.name);
					AttachEye(objE.name);
				}
			}
		}
	}
}
