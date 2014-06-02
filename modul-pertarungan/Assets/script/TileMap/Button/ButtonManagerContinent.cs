using UnityEngine;
using Holoville.HOTween;
using ModulPertarungan;
using System.Collections;
using System.Collections.Generic;

public class ButtonManagerContinent : MonoBehaviour
{    
    private string sceneLoader;
    private string buttonNameLoader;
    private string textureLoader;

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
                buttonNameLoader = hit.collider.gameObject.GetComponent<ButtonContinent>().ButtonName;
                sceneLoader = hit.collider.gameObject.GetComponent<ButtonContinent>().SceneLoad;
                textureLoader = hit.collider.gameObject.GetComponent<ButtonContinent>().TextureTiles;
                if (hit.collider.gameObject.name.ToLower().Contains(buttonNameLoader))
                {
                    TextureSingleton.Instance().TextureTiles = textureLoader;
                    Application.LoadLevel(sceneLoader);                    
                }
            }
        }
        
    }
}
