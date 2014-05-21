using UnityEngine;
using System.Collections;

public class ButtonQuest : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        OnClick();
    }
    void OnClick()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        if (Input.GetMouseButtonUp(0))
        {
            if (hit.collider != null)
            {
                if (hit.collider.gameObject.name.ToLower().Contains("questbutton"))
                {
                    //Application.LoadLevel("Quest");
                    Debug.Log("goto Quest");
                }
            }
        }
    }
}
