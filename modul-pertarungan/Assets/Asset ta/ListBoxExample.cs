using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic; //For List<T>.

public class ListBoxExample : MonoBehaviour
{
    public ListBox _myListBox = new ListBox();
    public List<GameObject> allCard;
    //[MenuItem("Window/List Box Example")]
    //public static void Launch()
    //{
    //    GetWindow(typeof(ListBoxExample)).Show();

    //}
    void Start()
    {
        _myListBox.LoadList(allCard);

    }
    //void Update()
    //{
    //    Repaint();
    //}
    public void OnGUI()
    {
        _myListBox.Draw(new Rect(10, 10, 120, 320), 18, Color.white, Color.blue);
        if (_myListBox.selectedEntry != null)
        {
            Debug.Log("selected item" + _myListBox.selectedEntry.name);
            GUI.Label(new Rect((Screen.width/2)+150, (Screen.height/2)+15, 300, 30), "Selected item: " + _myListBox.selectedEntry.name);
        }
    }
}
