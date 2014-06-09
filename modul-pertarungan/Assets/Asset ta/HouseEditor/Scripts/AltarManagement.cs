using UnityEngine;
using System.Collections;
using ModulPertarungan;

public class AltarManagement : MonoBehaviour {

    ModelAltar myAltar;
    QuantityManagement quantity;
    bool haveAltar = false;
    public GameObject Altar;
    public GameObject AltarExp;
    public GameObject magicdustQuantity;

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
					quantity.TotalMagicDust++;
					myAltar.ExpAltar += 30;					
					Debug.Log(myAltar.ExpAltar);
					if(myAltar.ExpAltar>myAltar.MaxAltarExp)
					{
						myAltar.ExpAltar = 0;
						myAltar.Level++;
						myAltar.MaxAltarExp = myAltar.Level * 100;
					}
					AltarExp.GetComponent<GUIText>().text = "Level " + myAltar.Level + "\n" + myAltar.ExpAltar + "/" + myAltar.MaxAltarExp;
					magicdustQuantity.GetComponent<GUIText>().text = "x "+ quantity.TotalMagicDust;
				} 
			}
		}
	}

	private void getDatabaseAltar()
	{
		//haveAltar = haveAltar;
	}
}
