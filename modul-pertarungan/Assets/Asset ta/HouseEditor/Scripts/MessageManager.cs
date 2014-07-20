using UnityEngine;
using System.Collections;
using Holoville.HOTween;
using ModulPertarungan;
using System.Xml.Serialization;
using System.IO;
using System;
using System.Collections.Generic;

public class MessageManager : MonoBehaviour {

    public GameObject messagePanel;
    public GameObject messagePanelPosition;
    public GameObject messagePanelPositionStart;
    public GameObject newMessage;
    public GameObject messageTable;
    string message;
    
    TextReader textReader;
    MessagesFromService messages;

	// Use this for initialization
	void Start () {
        ViewMessage();
	}
	
	// Update is called once per frame
	void Update () {
	}

    void TweenObjectIn(GameObject from, GameObject to)
    {
        var parms = new TweenParms();
        parms.Prop("position", to.transform.position);
        HOTween.To(from.transform, 1f, parms);
    }


    void TweenObjectOut(GameObject from, GameObject to)
    {
        from.transform.position = to.transform.position;
    }

    void ViewMessagePanel()
    {
        ViewMessage();
        if (!GameManager.Instance().UpdatePaused)
        {
            TweenObjectIn(messagePanel, messagePanelPosition);
            GameManager.Instance().UpdatePaused = true;
        }
    }

    void ReloadGrid()
    {
        List<GameObject> messageChild = new List<GameObject>();
        foreach (Transform mChild in messageTable.transform)
        {
           Destroy(mChild.gameObject);
        }
    }

    void MessageTweenOut()
    {
        TweenObjectOut(messagePanel, messagePanelPositionStart);
        GameManager.Instance().UpdatePaused = false;
    }

    void ViewMessage()
    {
        ReloadGrid();
        WebServiceSingleton.GetInstance().ProcessRequest("get_messages", GameManager.Instance().PlayerId);
        if (WebServiceSingleton.GetInstance().queryResult > 0)
        {
            Debug.Log(WebServiceSingleton.GetInstance().DownloadFile("get_messages", GameManager.Instance().PlayerId));
            try
            {
                XmlSerializer deserializer = new XmlSerializer(typeof(MessagesFromService));
                textReader = new StreamReader(Application.persistentDataPath + "/messages_of_" + GameManager.Instance().PlayerId + ".xml");
                object obj = deserializer.Deserialize(textReader);
                MessagesFromService messagesList = (MessagesFromService)obj;
                int i = 1;
                foreach (var vmessage in messagesList.friendMessage)
                {
                    newMessage.name = "Message_" + i;
                    newMessage.transform.GetChild(0).GetComponent<UILabel>().name = "Message_Title_" + i;
                    newMessage.transform.GetChild(1).transform.GetChild(0).name = "Message_Text_" + i;
                    newMessage.transform.GetChild(0).GetComponent<UILabel>().text = vmessage.Subject;
                    newMessage.transform.GetChild(1).transform.GetChild(0).GetComponent<UILabel>().text = "From : " + vmessage.Sender + "\n \n";
                    newMessage.transform.GetChild(1).transform.GetChild(0).GetComponent<UILabel>().text += "Message:\n" + vmessage.Message;
                    i++;
                    var newMes = NGUITools.AddChild(messageTable, newMessage);
                    Debug.Log(vmessage.Message);
                }
                textReader.Close();
                messageTable.GetComponent<UITable>().Reposition();
            }
            catch (Exception e)
            {
                Debug.Log(e);
            }
        }
    }

    void DeleteMessage()
    {
    }
}
