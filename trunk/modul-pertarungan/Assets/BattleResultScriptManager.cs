using UnityEngine;
using System.Collections;
using Holoville.HOTween;
namespace ModulPertarungan
{
    public class BattleResultScriptManager : MonoBehaviour
    {

        // Use this for initialization
        public UILabel gold;
        public UILabel exp;
        public UILabel status;
        private bool[] checkQuestActive;
        private bool[] checkQuestCleared;
        public void Win()
        {
            //Clear();
            if (GameManager.Instance().GameMode != "pvp")
            {
                DungeonActive();
                exp.text = GameManager.Instance().PlayerExp.ToString();  
                gold.text = GameManager.Instance().PlayerGold.ToString();
            }
            status.text = "win";
        }

        public void Lose()
        {
          //  Clear();
            status.text = "LOSE";
            exp.text = "0";
            gold.text = "0";

        }
        public void DungeonActive()
        {
            //string[] split = TextureSingleton.Instance().IdButton.Split('_');
            //int id = Int32.Parse(split[1]);
            //TextureSingleton.Instance().QuestActive[id + 1] = true;
            //TextureSingleton.Instance().QuestCleared[id] = true;
            //checkQuestActive = TextureSingleton.Instance().QuestActive;
            //checkQuestCleared = TextureSingleton.Instance().QuestCleared;
        }
        public void Clear()
        {
            if (GameManager.Instance().GameMode == "pvp")
            {
                var succses = false;
                succses = NetworkSingleton.Instance().PlayerClient.Call<bool>("sendMessage", "GameEnd-" + NetworkSingleton.Instance().RoomName);
                Debug.Log(succses ? "send succes" : "send false");
                NetworkSingleton.instance = null;
                GameManager.Instance().GameMode = "";
            }
            GameManager.Instance().Enemies = null;
            GameManager.Instance().CurrentEnemy = null;
            GameManager.Instance().Players = null;
            GameManager.Instance().CurrentPawn = null;
            GameManager.Instance().GameMode = "";
        }
        public void ConfirmBattleResult()
        {
            Debug.Log("Clicked");
            Time.timeScale = 1;
            Application.LoadLevel("BeforeBattle");
        }
        public void ShowBattleResult()
        {
            var parms = new TweenParms();
            parms.Prop("position", new Vector3(0,0, 0));
            HOTween.To(this.transform,1f, parms);
        }
        void Update()
        {
            Time.timeScale = 0;
            if(this.transform.position==new Vector3(0,0,0))
            {
                Time.timeScale=0;
            }
        }

    }
}