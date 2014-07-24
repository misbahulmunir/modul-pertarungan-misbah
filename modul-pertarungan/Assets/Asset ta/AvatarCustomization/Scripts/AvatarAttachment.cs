using UnityEngine;
using System.Collections;
using System.Net;
using ModulPertarungan;
using System;
using System.IO;
using System.Xml;
using System.Collections.Generic;
using System.Xml.Serialization;

public class AvatarAttachment : MonoBehaviour {

	string hairType, eyesType, mouthType;
    public GameObject hairStyle1, hairStyle2, hairStyle3;
    public GameObject eyeStyle1, eyeStyle2, eyeStyle3;
    public GameObject mouthStyle1, mouthStyle2, mouthStyle3;
    UnityEngine.Object hChild, mChild, eChild;
    string playerName = "";
    private XmlDocument _xmlDoc;
    private XmlNodeList _nameNodes;
    List<string> avatarList;

    public List<string> AvatarList
    {
        get { return avatarList; }
        set { avatarList = value; }
    }

	// Use this for initialization
	void Start () {
        playerName = GameManager.Instance().PlayerId;
        _xmlDoc = new XmlDocument();
        avatarList = new List<string>();
        getDatabaseAvatar();
		AttachHair("menu"+getHairType());
		AttachEye("menu"+getEyesType());
		AttachMouth("menu"+getMouthType());
	}
	
	// Update is called once per frame
	void Update () {
        OnClick();
	}

    void getDatabaseAvatar()
    {
        try
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(AvatarFromService));
            TextReader textReader = new StreamReader(Application.persistentDataPath + "/player_avatar_of_" + GameManager.Instance().PlayerId + ".xml");
            object obj = deserializer.Deserialize(textReader);
            var avi = (AvatarFromService)obj;
            foreach (var s in avi.aviDetail)
            {
                avatarList.Add(s.Name);
                Debug.Log(s.Name);
            }
            textReader.Close();
        }
        catch (Exception e)
        {
            Debug.Log(e);
        }
    }

	public string getHairType()
	{
		hairType = avatarList[0];
		return hairType;
	}

	public string getEyesType()
	{
		eyesType = avatarList[1];
		return eyesType;
	}

	public string getMouthType()
	{
		mouthType = avatarList[2];
		return mouthType;
	}

    void AttachHair(string hairStyleChosen)
    {
        Destroy(hChild);
        var currentPos = this.transform.position;
        if (hairStyleChosen == "menurambut1")
        {
            var hairStyle = Instantiate(hairStyle1, currentPos, Quaternion.identity);
            hChild = hairStyle;
            avatarList[0] = "rambut1";
            Debug.Log("hairstyle1");
        }
        else
            if (hairStyleChosen == "menurambut2")
            {
                var hairStyle = Instantiate(hairStyle2, currentPos, Quaternion.identity);
                hChild = hairStyle;
                avatarList[0] = "rambut2";
                Debug.Log("hairstyle2");
            }
            else
                if (hairStyleChosen == "menurambut3")
                {
                    var hairStyle = Instantiate(hairStyle3, currentPos, Quaternion.identity);
                    hChild = hairStyle;
                    avatarList[0] = "rambut3";
                    Debug.Log("hairstyle3");
                }
    }

    void AttachEye(string eyeStyleChosen)
    {
        Destroy(eChild);
        var currentPos = this.transform.position;
        if (eyeStyleChosen == "menumata1")
        {
            var eyeStyle = Instantiate(eyeStyle1, currentPos, Quaternion.identity);
            eChild = eyeStyle;
            avatarList[1] = "mata1";
            Debug.Log("eyestyle1");
        }
        else
            if (eyeStyleChosen == "menumata2")
            {
                var eyeStyle = Instantiate(eyeStyle2, currentPos, Quaternion.identity);
                eChild = eyeStyle;
                avatarList[1] = "mata2";
                Debug.Log("eyestyle2");
            }
            else
                if (eyeStyleChosen == "menumata3")
                {
                    var eyeStyle = Instantiate(eyeStyle3, currentPos, Quaternion.identity);
                    eChild = eyeStyle;
                    avatarList[1] = "mata3";
                    Debug.Log("eyestyle3");
                }
    }

    void AttachMouth(string mouthStyleChosen)
    {
        Destroy(mChild);
        var currentPos = this.transform.position;
        if (mouthStyleChosen == "menumulut1")
        {
            var mouthStyle = Instantiate(mouthStyle1, currentPos, Quaternion.identity);
            mChild = mouthStyle;
            avatarList[2] = "mulut1";
            Debug.Log("mouthstyle1");
        }
        else
            if (mouthStyleChosen == "menumulut2")
            {
                var mouthStyle = Instantiate(mouthStyle2, currentPos, Quaternion.identity);
                mChild = mouthStyle;
                avatarList[2] = "mulut2";
                Debug.Log("mouthstyle2");
            }
            else
                if (mouthStyleChosen == "menumulut3")
                {
                    var mouthStyle = Instantiate(mouthStyle3, currentPos, Quaternion.identity);
                    mChild = mouthStyle;
                    avatarList[2] = "mulut3";
                    Debug.Log("mouthstyle3");
                }
    }

    void OnClick()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        if (Input.GetMouseButtonUp(0))
        {
            if (hit.collider != null)
            {
                if (hit.collider.gameObject.name.ToLower().Contains("menumulut"))
                {
                    GameObject objM = hit.collider.gameObject as GameObject;
                    Debug.Log(objM.name);
                    AttachMouth(objM.name);
                } 
                else if (hit.collider.gameObject.name.ToLower().Contains("menumata"))
                {
                    GameObject objE = hit.collider.gameObject as GameObject;
                    Debug.Log(objE.name);
                    AttachEye(objE.name);
                }
                else if (hit.collider.gameObject.name.ToLower().Contains("menurambut"))
                {
                    GameObject objH = hit.collider.gameObject as GameObject;
                    Debug.Log(objH.name);
                    AttachHair(objH.name);
                }
                else if (hit.collider.gameObject.name.ToLower().Contains("backbutton"))
                {
                    Application.LoadLevel("HouseEditor");
                }
                else if (hit.collider.gameObject.name.ToLower().Contains("savebutton"))
                {
                    WebServiceSingleton.GetInstance().ProcessRequest("edit_avatar", playerName + "|" + avatarList[0] + "-" + avatarList[1] + "-" + avatarList[2]);
                    Debug.Log(WebServiceSingleton.GetInstance().queryInfo);
                    WebServiceSingleton.GetInstance().ProcessRequest("get_player_avatar", playerName);
                    Debug.Log(WebServiceSingleton.GetInstance().DownloadFile("get_player_avatar", playerName));
                }
            }
        }
    }
}
