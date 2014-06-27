using UnityEngine;
using System.Collections;
namespace ModulPertarungan
{
    public class Avatar : MonoBehaviour
    {

        // Use this for initialization

        private string playerName;

        public string PlayerName
        {
            get { return playerName; }
            set { playerName = value; }
        }

        private string level;

        public string Level
        {
            get { return level; }
            set { level = value; }
        }

        private string job;

        public string Job
        {
            get { return job; }
            set { job = value; }
        }

        private string rank;

        public string Rank
        {
            get { return rank; }
            set { rank = value; }
        }

        private void Start()
        {
            //this.name = "UUL";
            foreach (Transform t in this.transform)
            {
                if (t.gameObject.name == "Name")
                {
                    t.GetComponent<UILabel>().text = this.playerName;
                }
                else if (t.gameObject.name == "Job")
                {
                    t.GetComponent<UILabel>().text = this.job;
                }
                else if (t.gameObject.name == "Rank")
                {
                    t.GetComponent<UILabel>().text = this.Rank;
                }
                else if (t.gameObject.name == "Level")
                {
                    t.GetComponent<UILabel>().text = this.level;
                }
            }
        }

        // Update is called once per frame
        private void Update()
        {

        }
    }
}