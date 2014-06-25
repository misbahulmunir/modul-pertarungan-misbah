using UnityEditor;
using UnityEngine;
using System.Collections;
using System;

[ExecuteInEditMode]
public class ElementalEditor : ScriptableWizard
{
    [SerializeField]
    public Texture2D textureChanger;

    private GameObject selectedObj;
    private string selectedName;

    private void OnEnable()
    {
        textureChanger = Resources.Load("Greenland") as Texture2D;
        selectedObj = GameObject.FindWithTag("DungeonButton");
        selectedName = "";
    }

    private void OnDestroy()
    {
        Debug.Log("destroy");
    }

    private void OnSelectionChange()
    {
        UpdateSelectionHelper();
    }

    private void OnWizardCreate()
    {
        if (Selection.objects == null)
            return;
        try
        {
            selectedName = Selection.activeGameObject.name;
            selectedObj = GameObject.Find(selectedName);
            Debug.Log(selectedName);
            if (selectedName.Contains("@"))
            {
                selectedObj.GetComponent<ButtonDungeon>().textureTiles = textureChanger;
            }
            else if(selectedName == "xBackground")
            {
                selectedObj.GetComponent<SpriteRenderer>().sprite = Sprite.Create(textureChanger, new Rect(0, 0, textureChanger.width, textureChanger.height), new Vector2(0.5f,0.5f));
            }
            EditorUtility.SetDirty(selectedObj);
            Debug.Log("OK");
        }
        catch (Exception e)
        {
            EditorUtility.DisplayDialog("Warning", e.ToString(), "OK");
        }
    }

    private void UpdateSelectionHelper()
    {
        helpString = "";
        errorString = "";
        try
        {
            if (Selection.objects == null)
            {
                errorString = "Object null";
            }
            else if (Selection.objects != null)
            {
                helpString = "Object Selected: " + Selection.activeGameObject.name;
            }
        }
        catch (Exception e)
        {
            Debug.Log(e);
        }
    }
}

