using UnityEngine;
using Holoville.HOTween;
using ModulPertarungan;
using System.Collections;
using System.Collections.Generic;

public class ButtonManagerContinent : MonoBehaviour
{    
    private string sceneLoader;
    private string buttonTagLoader;
    private Texture2D textureLoader;

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
                buttonTagLoader = hit.collider.gameObject.GetComponent<Button>().ButtonTag;
                sceneLoader = hit.collider.gameObject.GetComponent<Button>().SceneLoad;
                if (hit.collider.gameObject.tag.ToLower().Contains(buttonTagLoader))
                {
                    if (buttonTagLoader == "dungeonbutton")
                    {
                        textureLoader = hit.collider.gameObject.GetComponent<ButtonDungeon>().textureTiles;
                        TextureSingleton.Instance().TextureTiles = textureLoader.name;
                        TextureSingleton.Instance().IdButton = hit.collider.gameObject.name;
                        Application.LoadLevel(sceneLoader);
                        //Debug.Log(textureLoader.name);
                    }
                    else
                    {
                        Application.LoadLevel(sceneLoader);
                    }
                }
            }
        }
        
    }
}
