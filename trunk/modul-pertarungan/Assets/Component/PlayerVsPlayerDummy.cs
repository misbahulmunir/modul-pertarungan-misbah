using UnityEngine;
using System.Collections;

namespace ModulPertarungan
{
    public class PlayerVsPlayerDummy : MonoBehaviour
    {

        public void OnClick()
        {
            //Application.LoadLevel("OnlineBattle");
            //NetworkSingleton.Instance().HostPlayer = "Boncu";
            //NetworkSingleton.Instance().JoinPlayer = "Misbah";
            GameManager.Instance().GameMode = "pvp";
            Application.LoadLevel("PVPRecord");
        }

        // Use this for initialization
        private void Start()
        {
            
            
        }

        // Update is called once per frame
        private void Update()
        {

        }
    }
}