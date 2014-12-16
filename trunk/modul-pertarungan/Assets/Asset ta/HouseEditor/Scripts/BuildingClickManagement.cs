using UnityEngine;
using System.Collections;
using ModulPertarungan;
using System.Collections.Generic;

public class BuildingClickManagement : MonoBehaviour {
    public List<GameObject> enemies;
    private bool[] questActived;
    private bool[] questCleared;
    private Dictionary<string, bool> buttonElemental;
    private ShopButtonManager tutorial;
    FacebookHandler FH = new FacebookHandler();
	// Use this for initialization
	void Start () {
        reloadHouse();
        GameManager.Instance().GameMode = "";
        WebServiceSingleton.GetInstance().isLoadingScreen = false;
        GameManager.Instance().UpdatePaused = false;
        tutorial = GameObject.Find("Tutorial Box").GetComponent<ShopButtonManager>();
        tutorial.SendMessage("ShowShop");
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
				    !hit.collider.gameObject.name.ToLower().Contains("buttonmyprofile")) Destroy(menuList);

                if (hit.collider.gameObject.name.ToLower().Contains("house_") && !hit.collider.gameObject.name.ToLower().Contains("button"))
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
    
    public void QuitGame()
    { if(FB.IsLoggedIn)
        FH.CallFBLogout();
        Application.Quit();
    }

    private void reloadHouse()
    {
        WebServiceSingleton.GetInstance().ProcessRequest("get_building",GameManager.Instance().PlayerId);
        //WebServiceSingleton.GetInstance().DownloadFile("get_building", GameManager.Instance().PlayerId);
    }
}
