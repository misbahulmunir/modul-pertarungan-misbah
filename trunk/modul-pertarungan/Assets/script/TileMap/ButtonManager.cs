using UnityEngine;
using System.Collections;

public class ButtonManager : MonoBehaviour
{
    string sceneLoader;
    string buttonNameLoader;
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
                buttonNameLoader = hit.collider.gameObject.GetComponent<Button>().ButtonName;
                sceneLoader = hit.collider.gameObject.GetComponent<Button>().SceneLoad;
                if (hit.collider.gameObject.name.ToLower().Contains(buttonNameLoader))
                {
                    Application.LoadLevel(sceneLoader);
                }
            }
        }
    }
}
