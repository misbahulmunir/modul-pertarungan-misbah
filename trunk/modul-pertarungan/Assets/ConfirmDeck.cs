using UnityEngine;
using System.Collections;
using System.Collections.Generic;
namespace ModulPertarungan
{
    public class ConfirmDeck : MonoBehaviour
    {   

        // Use this for initialization
        public GameObject grid;

        public void OnClick()
        {
            GameManager.Instance().PlayerDeck = new List<GameObject>();

            foreach (Transform child in grid.transform)
            {

                GameManager.Instance().PlayerDeck.Add(child.gameObject);

            }
            foreach (GameObject obj in GameManager.Instance().PlayerDeck)
            {
                Debug.Log(obj.name);
            }

        }
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}