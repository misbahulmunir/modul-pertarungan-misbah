using UnityEngine;
using System.Collections;

public class MineManagement : MonoBehaviour {

	// Use this for initialization
	void Start () {
		haveMine = false;
	}
	
	// Update is called once per frame
	void Update () {
		OnClick ();
	}
	
	ModelMine myMine = new ModelMine();
	bool haveMine;
	public GameObject Mine;
	public GameObject MineExp;
	
	void OnClick()
	{
		RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
		if (Input.GetMouseButtonUp(0))
		{
			if (hit.collider != null)
			{
				if (hit.collider.gameObject.name.ToLower().Contains("addmine") && haveMine == false)
				{
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
					myMine.ExpMine += 30;					
					Debug.Log(myMine.ExpMine);
					if(myMine.ExpMine>myMine.MaxMineExp) 
					{
						myMine.ExpMine = 0;
						myMine.Level++;
						myMine.MaxMineExp = myMine.Level * 100;
					}
					MineExp.GetComponent<GUIText>().text = "Level " + myMine.Level + "\n" + myMine.ExpMine + "/" + myMine.MaxMineExp;
				} 
			}
		}
	}
}
