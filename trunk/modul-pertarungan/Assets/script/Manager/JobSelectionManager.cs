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
        void Start()
        {

        }

        private void Update()
        {

        }

        public void SelectMagician()
        {  TweenObjectOut();
           characterImagePanel.mainTexture = characterImage;
           TweenObjectIn();
        }

        public void SelectWarlock()
        {
            TweenObjectOut();
            characterImagePanel.mainTexture = characterImage;
            TweenObjectIn();
        }

        public void SelectWizard()
        {

        }

        public void SelectSorcerer()
        {

        }

        public void SelectGrandMagus()
        {

        }

        public void TweenObjectIn()
        {
            var parms= new TweenParms();
            parms.Prop("position", picturePanelPosition.transform.position);
            HOTween.To(picturePanel.transform, 1f, parms);
            parms = new TweenParms();
            parms.Prop("position", descriptionPanePosition.transform.position);
            HOTween.To(descriptionPanel.transform, 1f, parms);
        }

        public void TweenObjectOut()
        {
            descriptionPanel.transform.position = descriptionPanePositionStart.transform.position;
            picturePanel.transform.position = picturePanelPositionStart.transform.position;
        }
    }
}
