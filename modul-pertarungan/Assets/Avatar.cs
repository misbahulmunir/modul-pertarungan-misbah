using UnityEngine;
using System.Collections;

public class Avatar : MonoBehaviour {

	// Use this for initialization


    private string name;

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    private string level;

    public string Level
    {
        get { return level; }
        set { level = value; }
    }

    private string job;

    public string Job
    {
        get { return job; }
        set { job = value; }
    }

    private string rank;

    public string Rank
    {
        get { return rank; }
        set { rank = value; }
    }
	void Start () {
        this.name = "UUL";
        foreach (Transform t in this.transform)
        {
            if (t.gameObject.name == "Name")
            {
                t.GetComponent<UILabel>().text = this.name;
            }
            else if (t.gameObject.name == "Job")
            {
                t.GetComponent<UILabel>().text = this.job;
            }
            else if (t.gameObject.name == "Rank")
            {
                t.GetComponent<UILabel>().text = this.Rank;
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
