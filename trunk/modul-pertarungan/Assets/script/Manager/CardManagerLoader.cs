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
            

        }
        public void AddToGrid()
        {
            foreach (GameObject obj in listcard)
            {
                NGUITools.AddChild(grid, obj);
            }
            grid.GetComponent<UIGrid>().Reposition();
        }
       
       
    }
}
