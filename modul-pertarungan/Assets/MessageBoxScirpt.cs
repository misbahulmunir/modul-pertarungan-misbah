using UnityEngine;
using System.Collections;
using Holoville.HOTween;

public class MessageBoxScirpt : MonoBehaviour
{

    // Use this for initialization
    public UILabel notification;
    public UILabel message;
    Vector3 startPosition;
    void Start()
    {
        startPosition = this.transform.position;
    }
    public void SetMessage(object[] parameter)
    {
        notification.text = parameter[0] as string;
        message.text = parameter[1] as string;
    }

    public void ShowMessageBox()
    {
        StartCoroutine(show());
    }
     public   IEnumerator show()
    {
        var parms = new TweenParms();
        parms.Prop("position", new Vector3(0f, 0f, 1f));
        yield return StartCoroutine(HOTween.To(this.transform, 0f, parms).WaitForCompletion());
    }
    public void CloseMessageBox()
    {
        var parms = new TweenParms();
        parms.Prop("position", startPosition);
        HOTween.To(this.transform, 1f, parms);
    }
}
