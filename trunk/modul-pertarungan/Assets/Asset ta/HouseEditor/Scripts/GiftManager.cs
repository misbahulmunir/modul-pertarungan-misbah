using UnityEngine;
using System.Collections;
using ModulPertarungan;
using Holoville.HOTween;

public class GiftManager : MonoBehaviour {
    
    Vector3 startPosition;
    Vector3 startInfoPos;
    public GameObject giftPanel;
    public GameObject failedLabel;
    public GameObject giftInfo;
    public GameObject codeInput;
    public GameObject giftReceived;
    FacebookHandler FH = new FacebookHandler();

	// Use this for initialization
	void Start () {
        startPosition = giftPanel.transform.position;
        failedLabel.GetComponent<UILabel>().text = "";
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void ShowGiftPanel()
    {
        var parms = new TweenParms();
        parms.Prop("position", new Vector3(0f, 0.5f, 0f));
        HOTween.To(giftPanel.transform, 1f, parms);
        startInfoPos = giftInfo.transform.position;
        GameManager.Instance().UpdatePaused = true;
    }
    void CloseGiftPanel()
    {
        failedLabel.GetComponent<UILabel>().text = "";
        var parms = new TweenParms();
        parms.Prop("position", startPosition);
        HOTween.To(giftPanel.transform, 1f, parms);
        startInfoPos = giftInfo.transform.position;
        GameManager.Instance().UpdatePaused = false;
    }
    void ShowGiftInfo()
    {
        var parms = new TweenParms();
        parms.Prop("position", new Vector3(0f, 0.5f, 0f));
        HOTween.To(giftInfo.transform, 1f, parms);
    }
    void CloseGiftInfo()
    {
        failedLabel.GetComponent<UILabel>().text = "";
        var parms = new TweenParms();
        parms.Prop("position", startInfoPos);
        HOTween.To(giftInfo.transform, 1f, parms);
    }

    void RedeemCode()
    {
        failedLabel.GetComponent<UILabel>().text = "";
        WebServiceSingleton.GetInstance().ProcessRequest("claim_gift", GameManager.Instance().PlayerId + "|" + codeInput.GetComponent<UILabel>().text);
        if (WebServiceSingleton.GetInstance().queryResult == 1)
        {
            failedLabel.GetComponent<UILabel>().text = "";
            giftReceived.GetComponent<UILabel>().text = WebServiceSingleton.GetInstance().queryInfo;
            ShowGiftInfo();
        }
        else
        {
            failedLabel.GetComponent<UILabel>().text = WebServiceSingleton.GetInstance().queryInfo;
        }
    }

    void ShareGift()
    {
        failedLabel.GetComponent<UILabel>().text = "";
        WebServiceSingleton.GetInstance().ProcessRequest("share_gift", GameManager.Instance().PlayerId);
        if (WebServiceSingleton.GetInstance().queryResult == 1)
        {
            FH.FeedLink = "cws.yowanda.com/G?name=" + GameManager.Instance().PlayerId;
            FH.FeedPicture = "http://cws.yowanda.com/images/img.png";
            FH.feedLinkDescription = "A Gift from the Night!";
            FH.CallFBFeed();
        }
        else
        {
            failedLabel.GetComponent<UILabel>().text = WebServiceSingleton.GetInstance().queryInfo;
        }
    }
}
