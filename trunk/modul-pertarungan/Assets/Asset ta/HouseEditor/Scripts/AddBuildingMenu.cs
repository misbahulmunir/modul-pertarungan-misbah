using UnityEngine;
using System.Collections;

public class AddBuildingMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		OnClick ();
	}

	Object subMenu;
	public GameObject addBuildingMenu;

	void OnClick()
	{
		RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
		if (Input.GetMouseButtonUp(0))
		{
			if (hit.collider != null)
			{
				if (hit.collider.gameObject.name.ToLower().Contains("buttonaddbuilding"))
				{
					GameObject obj = hit.collider.gameObject as GameObject;
					Debug.Log(obj.name);
					var currentPos = this.transform.position;
					var subMenuList =  Instantiate(addBuildingMenu, currentPos, Quaternion.identity);
					subMenu = subMenuList;
					Debug.Log("addbuilding");
				} else
				if (hit.collider.gameObject.name.ToLower().Contains("buttonavatar"))
				{
					Application.LoadLevel("AvatarCostumization");
				}
				if (!hit.collider.gameObject.name.ToLower().Contains("buttonadd"))
				{
					Destroy(subMenu);
				}
			} else
					Destroy(subMenu);
		}
	}
}
