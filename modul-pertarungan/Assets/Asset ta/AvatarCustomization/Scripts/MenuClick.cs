using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MenuClick : MonoBehaviour {
	
	public GameObject hairList;
	public GameObject mouthList;
	public GameObject eyeList;
	int state = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		OnClick ();
	}

	void OnClick()
	{
		RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
		if (Input.GetMouseButtonUp(0))
		{
			if (hit.collider != null)
			{
				if (hit.collider.gameObject.name.ToLower().Contains("submenu_rambut") && state != 0)
				{
					GameObject obj = hit.collider.gameObject as GameObject;
					Debug.Log(obj.name);
					if(mouthList.transform.position.z == -2) mouthList.transform.Translate(0,0,4);
					if(eyeList.transform.position.z == -2) eyeList.transform.Translate(0,0,4);
					hairList.transform.Translate(0,0,-4);
					state = 0;
				} else
				if (hit.collider.gameObject.name.ToLower().Contains("submenu_mata") && state != 1)
				{
					GameObject obj = hit.collider.gameObject as GameObject;
					Debug.Log(obj.name);
					if(mouthList.transform.position.z == -2) mouthList.transform.Translate(0,0,4);
					if(hairList.transform.position.z == -2) hairList.transform.Translate(0,0,4);
					eyeList.transform.Translate(0,0,-4);
					state = 1;
				} else
				if (hit.collider.gameObject.name.ToLower().Contains("submenu_mulut") && state != 2)
				{
					GameObject obj = hit.collider.gameObject as GameObject;
					Debug.Log(obj.name);
					if(hairList.transform.position.z == -2) hairList.transform.Translate(0,0,4);
					if(eyeList.transform.position.z == -2) eyeList.transform.Translate(0,0,4);
					mouthList.transform.Translate(0,0,-4);
					state = 2;
				}
			}
		}
	}
}
