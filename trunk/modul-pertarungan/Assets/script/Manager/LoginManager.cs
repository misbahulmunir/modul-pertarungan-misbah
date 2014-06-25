using UnityEngine;
using System.Collections;
using  ModulPertarungan;
namespace CardWarlockSaga
{
    public class LoginManager : MonoBehaviour
    {
        public UIInput userName;
        public UIInput password;
        public MessageBoxScirpt msgBox;
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
            GameManager.Instance().PlayerId = userName.value;
            GameManager.Instance().Password = password.value;
            WebServiceSingleton.GetInstance().ProcessRequest("login", userName.value + "|" + password.value);
            if (WebServiceSingleton.GetInstance().queryResult > 0)
            {
                Application.LoadLevel("Loading");
            }
            else
            {
                var obj =new object[2];
                obj[0] = "Notification";
                obj[1] = WebServiceSingleton.GetInstance().queryInfo;
                msgBox.SendMessage("SetMessage", obj);
                msgBox.SendMessage("ShowMessageBox", obj);

            }
           
        }

        public void Register()
        {
            Application.LoadLevel("JobSelection");
        }
    }
}