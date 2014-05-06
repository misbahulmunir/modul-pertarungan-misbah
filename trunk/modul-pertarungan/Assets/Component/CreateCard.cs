using UnityEngine;
using System.Collections;

public class CreateCard : MonoBehaviour {

    //// Use this for initialization
    public Texture Texture;
    public Material material;
    public int orderInLayer;
    public bool isTrigger;
    public Vector2 size;
    public Vector2 center;
    public GameObject grid;
    public UIScrollView scrollView;
	void Start () {
        GameObject obj = new GameObject("SplitfireCard");
        obj.transform.localScale = new Vector3(0.5f, 0.5f, 0f);
        obj.AddComponent("BoxCollider");
        obj.GetComponent<BoxCollider>().size = new Vector3(114f, 138f, 0f);
        obj.AddComponent("UIDragScrollView");
        obj.AddComponent("UITexture");
        obj.GetComponent<UITexture>().mainTexture = Texture;
        obj.GetComponent<UITexture>().depth = 5;

        NGUITools.AddChild(grid.gameObject, obj.gameObject);
        Destroy(obj);
       

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
