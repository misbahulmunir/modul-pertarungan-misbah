using UnityEngine;
using System.Collections;
using  ModulPertarungan;
namespace CardWarlockSaga
{
    public class LoginManager : MonoBehaviour
    {
        public UIInput userName;
        // Use this for initialization
        private void Start()
        {

        }

        // Update is called once per frame
        private void Update()
        {

        }


        public void ConfirmId()
        {   
            GameManager.Instance().PlayerId = userName.GetComponent<UIInput>().value;
            Application.LoadLevel("Loading");
           
        }

        public void Register()
        {
            Application.LoadLevel("JobSelection");
        }
    }
}