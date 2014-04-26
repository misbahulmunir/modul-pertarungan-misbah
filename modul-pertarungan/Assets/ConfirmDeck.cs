using UnityEngine;
using System.Collections;
using System.Collections.Generic;
namespace ModulPertarungan
{
    public class ConfirmDeck : MonoBehaviour
    {   

        // Use this for initialization
        public GameObject grid;
        public GameObject container;
        public GameObject obj;
        public List<GameObject> lofI;
        public void OnClick()
        {
           GameManager.Instance().AllSelectedCard= new List<string>();
            foreach (Transform t in grid.transform)
            {

                GameManager.Instance().AllSelectedCard.Add(t.name.Split('(')[0]);
            }

           
            Application.LoadLevel("BeforeBattle");
            
        }
    
       
        void Start()
        {
          
        }

        // Update is called once per frame
        void Update()
        {

        }
        void instantiate()
        {
          
        }
    }
}