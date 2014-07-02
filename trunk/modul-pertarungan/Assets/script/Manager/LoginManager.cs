using UnityEngine;
using System.Collections;
using ModulPertarungan;
using System.Threading;

namespace CardWarlockSaga
{
    public class LoginManager : MonoBehaviour
    {
        public UIInput userName;
        public UIInput password;
        public MessageBoxScirpt msgBox;
        public GameObject loadingBox;
        private Thread thread;
        private Vector3 loadingpos;
        // Use this for initialization
        private void Awake()
        {
            WebServiceSingleton.GetInstance().ProcessRequest("get_player_ranking", "");
            if (WebServiceSingleton.GetInstance().queryResult <= 0)
            {
                msgBox = GameObject.Find("MessageBox").GetComponent<MessageBoxScirpt>();
                var obj = new object[2];
                obj[0] = "Notification";
                obj[1] = "Unable to connect to server";
                msgBox.SendMessage("SetMessage", obj);
                msgBox.SendMessage("ShowMessageBox", obj);

            }
        }
        private void Start()
        {

            loadingpos = GameObject.Find("Loadingbox").transform.position;
        }

        // Update is called once per frame
        private void Update()
        {

        }

    

        void ConfirmId()
        {
            GameManager.Instance().PlayerId = userName.value;
            GameManager.Instance().Password = password.value;
            loadingBox.transform.position = new Vector3(0f, 0f, 0f);
           
                StartCoroutine(Login());
            
        }
        public IEnumerator Login()
        {
           
            WebServiceSingleton.GetInstance().ProcessRequest("login", userName.value + "|" + password.value);

                if (WebServiceSingleton.GetInstance().queryResult > 0)
                {
                    Application.LoadLevel("Loading");
                }
                else
                {
                    var obj = new object[2];
                    obj[0] = "Notification";
                    obj[1] = WebServiceSingleton.GetInstance().queryInfo;
                    msgBox.SendMessage("SetMessage", obj);
                    msgBox.SendMessage("ShowMessageBox");
                    loadingBox.transform.position = loadingpos;

                }
                
                yield return new WaitForSeconds(0.5f);
            
        }
        public void Register()
        {
            Application.LoadLevel("JobSelection");
        }
    }
}