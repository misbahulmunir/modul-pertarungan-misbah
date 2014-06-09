using UnityEngine;
using System.Collections;
using ModulPertarungan;


public class BuildingClickManagement : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (!GameManager.Instance().UpdatePaused)
        {
            OnClick();
        }
	}

	Object menuList;
	public GameObject SubMenuHouse, SubMenuBuilding;
	public string clickedBuildingName;

	public string ClickedBuildingName {
		get {
			return clickedBuildingName;
		}
	}

	void OnClick()
	{
		RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
		if (Input.GetMouseButtonUp(0))
		{
			if (hit.collider != null)
			{
				if (!hit.collider.gameObject.name.ToLower().Contains("buttonaddbuilding") && 
				    !hit.collider.gameObject.name.ToLower().Contains("takeitems")) Destroy(menuList);

				if (hit.collider.gameObject.name.ToLower().Contains("house_"))
				{
					GameObject obj = hit.collider.gameObject as GameObject;
					Debug.Log(obj.name);
					var currentPos = this.transform.position;
					var subMenuList =  Instantiate(SubMenuHouse, currentPos, Quaternion.identity);
					menuList = subMenuList;
					clickedBuildingName = obj.name;
                } else
                if (hit.collider.gameObject.name.ToLower().Contains("colosseum"))
                {
                    GameManager.Instance().GameMode = "pvp";
                    Application.LoadLevel("PVPlogin");
                }
			} else Destroy(menuList);
		}
	}
}
