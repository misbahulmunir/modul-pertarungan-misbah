using UnityEngine;
using System.Collections;
using System.Net;
using ModulPertarungan;
using System;
using System.IO;
using System.Xml;
using System.Collections.Generic;
using System.Xml.Serialization;

public class FriendAvatarAttachment : MonoBehaviour
{

    string hairType, eyesType, mouthType;
    public GameObject friendHairStyle1, friendHairStyle2, friendHairStyle3;
    public GameObject friendEyeStyle1, friendEyeStyle2, friendEyeStyle3;
    public GameObject friendMouthStyle1, friendMouthStyle2, friendMouthStyle3;
    public GameObject friendNameLabel;
    UnityEngine.Object hChild, mChild, eChild;
    string friendName = "";
    private XmlDocument _xmlDoc;
    private XmlNodeList _nameNodes;
    List<string> avatarList;

    public List<string> AvatarList
    {
        get { return avatarList; }
        set { avatarList = value; }
    }

    // Use this for initialization
    void Start()
    {
        friendName = GameManager.Instance().FriendName;
        Debug.Log(friendName + " visited");
        friendNameLabel.GetComponent<GUIText>().text = friendName;
        _xmlDoc = new XmlDocument();
        avatarList = new List<string>();
        getDatabaseAvatar();
        AttachHair("menu" + getHairType());
        AttachEye("menu" + getEyesType());
        AttachMouth("menu" + getMouthType());
    }

    // Update is called once per frame
    void Update()
    {
    }

    void getDatabaseAvatar()
    {
        try
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(AvatarFromService));
            TextReader textReader = new StreamReader(Application.persistentDataPath + "/player_avatar_of_" + friendName + ".xml");
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
            var hairStyle = Instantiate(friendHairStyle1, currentPos, Quaternion.identity);
            hChild = hairStyle;
            avatarList[0] = "rambut1";
            Debug.Log("hairstyle1");
        }
        else
            if (hairStyleChosen == "menurambut2")
            {
                var hairStyle = Instantiate(friendHairStyle2, currentPos, Quaternion.identity);
                hChild = hairStyle;
                avatarList[0] = "rambut2";
                Debug.Log("hairstyle2");
            }
            else
                if (hairStyleChosen == "menurambut3")
                {
                    var hairStyle = Instantiate(friendHairStyle3, currentPos, Quaternion.identity);
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
            var eyeStyle = Instantiate(friendEyeStyle1, currentPos, Quaternion.identity);
            eChild = eyeStyle;
            avatarList[1] = "mata1";
            Debug.Log("eyestyle1");
        }
        else
            if (eyeStyleChosen == "menumata2")
            {
                var eyeStyle = Instantiate(friendEyeStyle2, currentPos, Quaternion.identity);
                eChild = eyeStyle;
                avatarList[1] = "mata2";
                Debug.Log("eyestyle2");
            }
            else
                if (eyeStyleChosen == "menumata3")
                {
                    var eyeStyle = Instantiate(friendEyeStyle3, currentPos, Quaternion.identity);
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
            var mouthStyle = Instantiate(friendMouthStyle1, currentPos, Quaternion.identity);
            mChild = mouthStyle;
            avatarList[2] = "mulut1";
            Debug.Log("mouthstyle1");
        }
        else
            if (mouthStyleChosen == "menumulut2")
            {
                var mouthStyle = Instantiate(friendMouthStyle2, currentPos, Quaternion.identity);
                mChild = mouthStyle;
                avatarList[2] = "mulut2";
                Debug.Log("mouthstyle2");
            }
            else
                if (mouthStyleChosen == "menumulut3")
                {
                    var mouthStyle = Instantiate(friendMouthStyle3, currentPos, Quaternion.identity);
                    mChild = mouthStyle;
                    avatarList[2] = "mulut3";
                    Debug.Log("mouthstyle3");
                }
    }
}
