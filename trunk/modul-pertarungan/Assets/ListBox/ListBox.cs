using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ListBox
{
    private List<GameObject> entryList = new List<GameObject>();
    private int _selected = 0;
    private Vector2 scrollPosition = Vector2.zero;
    //Returns the selected Entry.
    public GameObject selectedEntry;

    public ListBox()
    {

    }

    //Public functions
    public void AddEntry(GameObject Obj)
    {
        entryList.Add(Obj);
    }
    public void RemoveEntry(GameObject Obj)
    {
        entryList.Remove(Obj);
    }
    public void LoadList(List<GameObject> ListToLoad)
    {
        entryList = ListToLoad;
    }
    public void Clear()
    {
        entryList.Clear();
    }
    public void Draw(Rect Area, float ItemHeight, Color BackgroundColor, Color SelectedItemColor)
    {
        float _y = 0;
        string _s = "";
       
        //Draw the listbox.
       // GUI.color = BackgroundColor;
        scrollPosition = GUI.BeginScrollView(new Rect(0, 0, Area.width, Area.height),
        scrollPosition, new Rect(0, 0, Area.width, entryList.Count*ItemHeight+10));
        Area.height=entryList.Count*ItemHeight;
        GUILayout.BeginArea(Area, "");

        GUI.Box(new Rect(0, 0, Area.width, entryList.Count * ItemHeight), "");
        GUI.color = Color.white;

        //Check for mouse clicks for selection
        Vector2 _mpos = new Vector2(-99, -99); //Get it out of view.
        Event _ev = Event.current;
        if (_ev.type == EventType.MouseDown && Event.current.button == 0)
        {
            _mpos = _ev.mousePosition;
        }

        //Loop through to draw the entries and check for selection.
        for (int i = 0; i < entryList.Count; i += 1)
        {
            //Get the list entry's name
            _s = entryList[i].name;
            //Get the selection's area.
            Rect _entryBox = new Rect(0, _y, Area.width, ItemHeight);
            
            //Check for selection
            if (_entryBox.Contains(_mpos))
            {
                _selected = i;
                Debug.Log(i);
            }
            //Draw a box if it's selected
            if (_selected == i)
            {
                selectedEntry = entryList[i];
                GUI.color = SelectedItemColor;
                GUI.Box(_entryBox, "");
                GUI.color = Color.white;
            }
            GUI.Label(_entryBox, _s);
            _y += ItemHeight;
        }
        GUI.EndScrollView();
        GUILayout.EndArea();
    }

}
public class Entry
{
    public string name = "";

    public Entry(string Name)
    {
        name = Name;
    }
}