using System;
using System.Security.Cryptography.X509Certificates;
using Holoville.HOTween;
using UnityEngine;

namespace ModulPertarungan
{
    public class JobSelectionManager : MonoBehaviour
    {
        public UILabel jobName;
        public UILabel description;
        public UITexture characterImagePanel;
        public Texture characterImage;
        public GameObject picturePanelPosition;
        public GameObject descriptionPanePosition;
        public GameObject picturePanelPositionStart;
        public GameObject descriptionPanePositionStart;
        public GameObject picturePanel;
        public GameObject descriptionPanel;
        public GameObject inputPanel;
        public GameObject inputPanelPosisition;
        private string SelectedObject;
        public UIInput playerName;
        public UIInput email;
        public GameObject inputPanelPosisitionStart;
        public MessageBoxScirpt msgBox;
        void Start()
        {
            msgBox = GameObject.Find("MessageBox").GetComponent<MessageBoxScirpt>();
        }

        private void Update()
        {

        }

        public void SelectMagician()
        {
            CreateDescription("Magician", "");
        }

        public void SelectWarlock()
        {
            CreateDescription("Warlock", "");

        }

        public void SelectWizard()
        {
            CreateDescription("Wizard", "");
        }

        public void SelectSorcerer()
        {
            CreateDescription("Sorcerer", "");
        }

        public void SelectGrandMagus()
        {
            CreateDescription("Grand Magus", "");
        }

        public void ConfirmPlayerJob()
        {
            TweenObjectOut();
            TweenObjectIn(inputPanel, inputPanelPosisition);
        }

        public void ConfirmNameAndEmail()
        {
            if (email.value != "" && playerName.value != "")
            {
                Debug.Log(jobName.text);
                Debug.Log(playerName.value);
                var encoded_mail = System.Text.Encoding.UTF8.GetBytes(email.value);
                WebServiceSingleton.GetInstance().ProcessRequest("register", playerName.value + "-" + GameManager.Instance().PlayerFBId + "|" + jobName.text + "|" + System.Convert.ToBase64String(encoded_mail));
                Debug.Log(jobName.text);
                Debug.Log(playerName.value);
                Debug.Log(System.Convert.ToBase64String(encoded_mail));
                Debug.Log(WebServiceSingleton.GetInstance().responseFromServer);
                GameManager.Instance().PlayerId = playerName.value;
                Application.LoadLevel("Loading");
            }
            else
            {
                var obj = new object[2];
                obj[0] = "Notification";
                obj[1] = "Email or Player Name Is Null";
                msgBox.SendMessage("SetMessage", obj);
                msgBox.SendMessage("ShowMessageBox");
            }
        }

        public void CreateDescription(String jobName, string description)
        {
            TweenObjectOut();
            characterImagePanel.mainTexture = characterImage;
            this.jobName.text = jobName;
            this.description.text = description;
            TweenObjectIn(picturePanel, picturePanelPosition);
            TweenObjectIn(descriptionPanel, descriptionPanePosition);
        }
        public void TweenObjectIn(GameObject from, GameObject to)
        {
            var parms = new TweenParms();
            parms.Prop("position", to.transform.position);
            HOTween.To(from.transform, 1f, parms);
        }


        public void TweenObjectOut()
        {
            descriptionPanel.transform.position = descriptionPanePositionStart.transform.position;
            picturePanel.transform.position = picturePanelPositionStart.transform.position;
            inputPanel.transform.position = inputPanelPosisitionStart.transform.position;
        }
    }
}
