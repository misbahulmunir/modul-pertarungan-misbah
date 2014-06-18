using UnityEngine;
using System.Collections;

namespace ModulPertarungan
{
    public class BackButtonScript : MonoBehaviour
    {

        // Use this for initialization
        private void OnClick()
        {
            
            Application.LoadLevel("HouseEditor");
        }

        private void Start()
        {

        }

        // Update is called once per frame
        private void Update()
        {

        }
    }
}