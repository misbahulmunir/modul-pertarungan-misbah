using UnityEngine;
using System.Collections;
using ModulPertarungan;

public class MineManagement : MonoBehaviour {

    ModelMine myMine = new ModelMine();
    QuantityManagement quantity = new QuantityManagement();
    FacebookHandler FH = new FacebookHandler();
    bool haveMine;
    public GameObject Mine;
    public GameObject MineExp;
    public GameObject gemQuantity;
    public MessageBoxScirpt msgBox;
    public GameObject subMenuDestroyer;

	// Use this for initialization
	void Start () {
        myMine = new ModelMine();
        myMine.getDatabaseBuilding();
        myMine.getMineData();
        quantity = new QuantityManagement();
        if (myMine.Level > 0)
        {
            haveMine = true;
            var currentPos = this.transform.position;
            var mine = Instantiate(Mine, currentPos, Quaternion.identity);
            MineExp.GetComponent<GUIText>().text = "Level " + myMine.Level + "\n" + myMine.ExpMine + "/" + myMine.MaxMineExp;
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (!GameManager.Instance().UpdatePaused)
        {
            OnClick();
        }
	}
	
	
	void OnClick()
	{
		RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
		if (Input.GetMouseButtonUp(0))
		{
			if (hit.collider != null)
			{
				if (hit.collider.gameObject.name.ToLower().Contains("addmine") && haveMine == false)
                {
                    subMenuDestroyer = GameObject.Find("SubMenuAddBuilding(Clone)");
                    Destroy(subMenuDestroyer);
					GameObject obj = hit.collider.gameObject as GameObject;
					Debug.Log(obj.name);
					var currentPos = this.transform.position;
					var mine =  Instantiate(Mine, currentPos, Quaternion.identity);
					Debug.Log ("add mine");
					haveMine = true;
					MineExp.GetComponent<GUIText>().text = "Level " + myMine.Level + "\n" + myMine.ExpMine + "/" + myMine.MaxMineExp;
				} 
				else
				if (hit.collider.gameObject.name.ToLower().Contains("mine_"))
				{
                    if (myMine.ProductClaimed <= myMine.ProductMax)
                    {
                        quantity.TotalGem++;
                        myMine.ExpMine += 30;
                        Debug.Log(myMine.ExpMine);
                        if (myMine.ExpMine > myMine.MaxMineExp)
                        {
                            myMine.ExpMine = 0;
                            myMine.Level++;
                            myMine.MaxMineExp = myMine.Level * 100;
                            myMine.ProductMax++;

                            FH.FeedLink = "cws.yowanda.com/G?name=" + GameManager.Instance().PlayerId;
                            FH.FeedPicture = "http://cws.yowanda.com/images/img.png";
                            FH.feedLinkDescription = "Hei, sekarang Mine ku level " + myMine.Level + " lho!";
                            FH.CallFBFeed();
                        }
                        MineExp.GetComponent<GUIText>().text = "Level " + myMine.Level + "\n" + myMine.ExpMine + "/" + myMine.MaxMineExp;
                        gemQuantity.GetComponent<GUIText>().text = "x " + quantity.TotalGem;
                        myMine.ProductClaimed++;
                        updateMineData();
                    }
                    else
                    {
                        var obj = new object[2];
                        obj[0] = "Klaim Item Gagal";
                        obj[1] = "Item yang akan diambil sudah mencapai maksimal";
                        msgBox.SendMessage("SetMessage", obj);
                        msgBox.SendMessage("ShowMessageBox");
                    }
				} 

			}
		}
	}

    private void updateMineData()
    {
        WebServiceSingleton.GetInstance().ProcessRequest("update_building", GameManager.Instance().PlayerId + "-Mine-Mine_|" + myMine.Level + "-" + myMine.MaxMineExp + "-" + myMine.ExpMine + "|" + myMine.ProductMax + "-" + myMine.ProductClaimed);
    }
}
