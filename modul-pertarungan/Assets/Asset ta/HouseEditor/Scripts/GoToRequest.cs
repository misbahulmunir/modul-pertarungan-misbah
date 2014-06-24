using UnityEngine;
using System.Collections;

public class GoToRequest : MonoBehaviour {
    string[] nama;
    public GameObject manager;
    public string methodName;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnClick()
    {
        nama = gameObject.transform.name.Split('_');

        manager = GameObject.Find("MyTradeRequestManager");
        manager.SendMessage(this.methodName, nama[0]);
    }
}
