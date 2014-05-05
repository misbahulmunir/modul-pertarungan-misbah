using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace ModulPertarungan
{
    public class PartyEditorButtonManager : MonoBehaviour
    {

        public GameObject grid;
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        private void ConfirmParty()
        {
            GameManager.Instance().PartyId = new List<string>();
            foreach (Transform T in grid.transform)
            {
                if (T.GetComponent<Avatar>().PlayerName != null)
                {
                    GameManager.Instance().PartyId.Add(T.GetComponent<Avatar>().PlayerName);
                }
            }
            Application.LoadLevel("BeforeBattle");
        }
    }
}
