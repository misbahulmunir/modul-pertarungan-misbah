using UnityEngine;
using System.Collections;
using System.Collections.Generic;
namespace ModulPertarungan
{

    public class ScoreScript : MonoBehaviour
    {
        public GameObject Statuslabel;
        public GameObject GoldLabel;
        public GameObject ExpLabel;
        public List<GameObject>label;
        private int score = 0;
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
           
            if (GameManager.Instance().GameStatus == "win")
            {
                Statuslabel.GetComponent<UILabel>().text = "WIN";
                if (score < GameManager.Instance().PlayerExp)
                {
                    score += 1;
                    ExpLabel.GetComponent<UILabel>().text = score.ToString();
                }
                GoldLabel.GetComponent<UILabel>().text = GameManager.Instance().PlayerGold.ToString();


            }
            else
            {
                
                Statuslabel.GetComponent<UILabel>().text = "LOSE";
                ExpLabel.GetComponent<UILabel>().text = "0";
                GoldLabel.GetComponent<UILabel>().text = "0";
                foreach (GameObject obj in label)
                {
                    obj.active = false;
                }
            }
            if (Input.GetMouseButtonDown(0))
            {
                Application.LoadLevel("Battle");
            }
        }
    }
}
