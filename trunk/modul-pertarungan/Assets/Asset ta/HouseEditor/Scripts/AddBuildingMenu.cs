using UnityEngine;
using System.Collections;

public class AddBuildingMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		OnClick ();
        SubMenuClick();
	}

	Object subMenu;
	public GameObject addBuildingMenu;
    public GameObject myProfileMenu;

	void OnClick()
	{
		RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
		if (Input.GetMouseButtonUp(0))
		{
            if (hit.collider != null)
            {
                if (hit.collider.gameObject.name.ToLower().Contains("buttonaddbuilding"))
                {
                    Destroy(subMenu);
                    GameObject obj = hit.collider.gameObject as GameObject;
                    Debug.Log(obj.name);
                    var currentPos = this.transform.position;
                    var subMenuList = Instantiate(addBuildingMenu, currentPos, Quaternion.identity);
                    subMenu = subMenuList;
                    Debug.Log("addbuilding");
                }
                else if (hit.collider.gameObject.name.ToLower().Contains("buttonmyprofile"))
                {
                    Destroy(subMenu);
                    GameObject obj = hit.collider.gameObject as GameObject;
                    Debug.Log(obj.name);
                    var currentPos = this.transform.position;
                    var subMenuList = Instantiate(myProfileMenu, currentPos, Quaternion.identity);
                    subMenu = subMenuList;
                    Debug.Log("myprofile");
                }
                else if (hit.collider.gameObject.name.ToLower().Contains("buttonmyfriend"))
                {
                    Application.LoadLevel("FriendManagementNew");
                }
            }
            else
            {
                Destroy(subMenu);
            }
		}
	}

    void SubMenuClick()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        if (Input.GetMouseButtonUp(0))
        {
            if (hit.collider != null)
            {
                if (hit.collider.gameObject.name.ToLower().Contains("buttonavatar"))
                {
                    Application.LoadLevel("AvatarCostumization");
                }
                else if (hit.collider.gameObject.name.ToLower().Contains("buttoneditdeck"))
                {
                    Application.LoadLevel("DeckEditor");
                }
                else if (hit.collider.gameObject.name.ToLower().Contains("buttoneditparty"))
                {
                    Application.LoadLevel("PartyEditor");
                }
            }
            else
            {
                Destroy(subMenu);
            }
        }
    }
}
