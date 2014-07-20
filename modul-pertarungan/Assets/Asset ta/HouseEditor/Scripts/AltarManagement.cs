using UnityEngine;
using System.Collections;
using ModulPertarungan;

public class AltarManagement : MonoBehaviour {

    ModelAltar myAltar;
    QuantityManagement quantity;
    FacebookHandler FH = new FacebookHandler();
    bool haveAltar = false;
    public GameObject Altar;
    public GameObject AltarExp;
    public GameObject magicdustQuantity;
    public MessageBoxScirpt msgBox;

	// Use this for initialization
    void Start()
    {
        myAltar = new ModelAltar();
        myAltar.getDatabaseBuilding();
        myAltar.getAltarData();
        quantity = new QuantityManagement();
        if (myAltar.Level > 0)
        {
            haveAltar = true;
            var currentPos = this.transform.position;
            var altar = Instantiate(Altar, currentPos, Quaternion.identity);
            AltarExp.GetComponent<GUIText>().text = "Level " + myAltar.Level + "\n" + myAltar.ExpAltar + "/" + myAltar.MaxAltarExp;
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
				if (hit.collider.gameObject.name.ToLower().Contains("addaltar") && haveAltar == false)
				{
					GameObject obj = hit.collider.gameObject as GameObject;
					Debug.Log(obj.name);
					var currentPos = this.transform.position;
					var altar =  Instantiate(Altar, currentPos, Quaternion.identity);
					Debug.Log ("add altar");
					haveAltar = true;
					AltarExp.GetComponent<GUIText>().text = "Level " + myAltar.Level + "\n" + myAltar.ExpAltar + "/" + myAltar.MaxAltarExp;
				} 
				else
				if (hit.collider.gameObject.name.ToLower().Contains("altar_"))
				{
                    if (myAltar.ProductClaimed <= myAltar.ProductMax)
                    {
                        quantity.TotalMagicDust++;
                        myAltar.ExpAltar += 30;
                        Debug.Log(myAltar.ExpAltar);
                        if (myAltar.ExpAltar > myAltar.MaxAltarExp)
                        {
                            myAltar.ExpAltar = 0;
                            myAltar.Level++;
                            myAltar.MaxAltarExp = myAltar.Level * 100;
                            myAltar.ProductMax++;

                            FH.FeedLink = "cws.yowanda.com/G?name=" + GameManager.Instance().PlayerId;
                            FH.FeedPicture = "http://cws.yowanda.com/images/img.png";
                            FH.feedLinkDescription = "Hei, sekarang Altar ku level " + myAltar.Level + " lho!";
                            FH.CallFBFeed();
                        }
                        AltarExp.GetComponent<GUIText>().text = "Level " + myAltar.Level + "\n" + myAltar.ExpAltar + "/" + myAltar.MaxAltarExp;
                        magicdustQuantity.GetComponent<GUIText>().text = "x " + quantity.TotalMagicDust;
                        myAltar.ProductClaimed++;
                        updateAltarData();
                    }
                    else
                    {
                        var obj = new object[2];
                        obj[0] = "Klaim Item Gagal";
                        obj[1] = "Item yang akan diambil sudah mencapai maksimal";
                        msgBox.SendMessage("SetMessage",obj);
                        msgBox.SendMessage("ShowMessageBox");
                    }
				} 
			}
		}
	}

    private void updateAltarData()
    {
        WebServiceSingleton.GetInstance().ProcessRequest("update_building",GameManager.Instance().PlayerId + "-Altar-Altar_|" + myAltar.Level + "-" + myAltar.MaxAltarExp + "-" + myAltar.ExpAltar + "|" + myAltar.ProductMax + "-" + myAltar.ProductClaimed);
    }
}
