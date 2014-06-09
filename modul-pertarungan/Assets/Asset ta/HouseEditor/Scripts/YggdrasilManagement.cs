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
					quantity.TotalBerry++;
					myYgg.ExpYggdrasil += 30;					
					Debug.Log(myYgg.ExpYggdrasil);
					if(myYgg.ExpYggdrasil>myYgg.MaxYggdrasilExp) 
					{
						myYgg.ExpYggdrasil = 0;
						myYgg.Level ++;
						myYgg.MaxYggdrasilExp = myYgg.Level * 100;
					}
					YggdrasilExp.GetComponent<GUIText>().text = "Level " + myYgg.Level + "\n" + myYgg.ExpYggdrasil + "/" + myYgg.MaxYggdrasilExp;
					berryQuantity.GetComponent<GUIText>().text = "x "+ quantity.TotalBerry;
				} 
			}
		}
	}
}
