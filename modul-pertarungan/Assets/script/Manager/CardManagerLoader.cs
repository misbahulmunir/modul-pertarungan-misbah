using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
namespace ModulPertarungan
{
    public class CardManagerLoader : MonoBehaviour
    {
        public List<GameObject> listcard;
        public GameObject grid;

       
        void Start()
        {

            AddToGrid();
        }


        void Update()
        {
            grid.GetComponent<UIGrid>().Reposition();

        }
        public void AddToGrid()
        {
            foreach (GameObject obj in listcard)
            {
                GameObject attachobj= AttachComponent(obj);
                NGUITools.AddChild(grid, attachobj);
            }
        }
        public GameObject AttachComponent(GameObject obj)
        {
            obj.AddComponent("UIDragScrollView");
            obj.AddComponent("UIDragDropItem");
            obj.GetComponent<UIDragDropItem>().restriction = UIDragDropItem.Restriction.Vertical;
            return obj;
        }
       
    }
}
