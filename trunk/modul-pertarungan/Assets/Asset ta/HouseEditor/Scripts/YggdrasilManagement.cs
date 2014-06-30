using UnityEngine;
using System.Collections;
using ModulPertarungan;

public class YggdrasilManagement : MonoBehaviour {

    ModelYggdrasil myYgg = new ModelYggdrasil();
    QuantityManagement quantity = new QuantityManagement();
    bool haveYggdrasil = false;
    public GameObject Yggdrasil;
    public GameObject YggdrasilExp;
    public GameObject berryQuantity;
    public MessageBoxScirpt msgBox;

	// Use this for initialization
	void Start () {
        myYgg = new ModelYggdrasil();
        myYgg.getDatabaseBuilding();
        myYgg.getYggdrasilData();
        quantity = new QuantityManagement();
        if (myYgg.Level > 0)
        {
            haveYggdrasil = true;
            var currentPos = this.transform.position;
            var yggdrasil = Instantiate(Yggdrasil, currentPos, Quaternion.identity);
            YggdrasilExp.GetComponent<GUIText>().text = "Level " + myYgg.Level + "\n" + myYgg.ExpYggdrasil + "/" + myYgg.MaxYggdrasilExp;
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
				if (hit.collider.gameObject.name.ToLower().Contains("addyggdrasil") && haveYggdrasil == false)
				{
					GameObject obj = hit.collider.gameObject as GameObject;
					Debug.Log(obj.name);
					var currentPos = this.transform.position;
					var yggdrasil =  Instantiate(Yggdrasil, currentPos, Quaternion.identity);
					Debug.Log ("add yggdrasil");
					haveYggdrasil = true;
					YggdrasilExp.GetComponent<GUIText>().text = "Level " + myYgg.Level + "\n" + myYgg.ExpYggdrasil + "/" + myYgg.MaxYggdrasilExp;
				} 
				else
				if (hit.collider.gameObject.name.ToLower().Contains("yggdrasil_"))
				{
                    if (myYgg.ProductClaimed <= myYgg.ProductMax)
                    {
                        quantity.TotalBerry++;
                        myYgg.ExpYggdrasil += 30;
                        Debug.Log(myYgg.ExpYggdrasil);
                        if (myYgg.ExpYggdrasil > myYgg.MaxYggdrasilExp)
                        {
                            myYgg.ExpYggdrasil = 0;
                            myYgg.Level++;
                            myYgg.MaxYggdrasilExp = myYgg.Level * 100;
                            myYgg.ProductMax++;
                        }
                        YggdrasilExp.GetComponent<GUIText>().text = "Level " + myYgg.Level + "\n" + myYgg.ExpYggdrasil + "/" + myYgg.MaxYggdrasilExp;
                        berryQuantity.GetComponent<GUIText>().text = "x " + quantity.TotalBerry;
                        myYgg.ProductClaimed++;
                        updateYggData();
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

    private void updateYggData()
    {
        WebServiceSingleton.GetInstance().ProcessRequest("update_building", GameManager.Instance().PlayerId + "-Yggdrasil-Yggdrasil_|" + myYgg.Level + "-" + myYgg.MaxYggdrasilExp + "-" + myYgg.ExpYggdrasil + "|" + myYgg.ProductMax + "-" + myYgg.ProductClaimed);
    }
}
