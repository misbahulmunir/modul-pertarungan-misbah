using UnityEngine;
using System.Collections.Generic;
using System.Collections;

namespace ModulPertarungan
{
    public class BattleStateManager : MonoBehaviour
    {

        // Use this for initialization
        private GameObject hitObj;
        private GUIStyle style;
        private BattleState currentstate;

        public BattleState Currentstate
        {
            get { return currentstate; }
            set { currentstate = value; }
        }
        public GameObject objectLoader;
        public GameObject Cursor;
        private GameObject endButton;

        public GameObject EndButton
        {
            get { return endButton; }
            set { endButton = value; }
        }



        public void SelectPawn()
        {
            if (!(this.currentstate is CardExcutionState) && !(this.currentstate is PvpEnemyState))
            {
                hitObj = HitCollider();
                if (hitObj != null && hitObj.GetComponent<PlayerAction>()!=null&&hitObj.GetComponent<PlayerAction>().IsEnemy==false)
                {
                    GameObject obj = GameManager.Instance().CurrentPawn = hitObj;
                    currentstate = new ChangePlayerState(obj, objectLoader, this);
                    currentstate.Action();
                }
            }
        }

        public void EndPlayerTurn()
        {
            hitObj = HitCollider();
            if (hitObj != null && hitObj.name.ToLower().Contains("endbutton"))
            {
                EndButton = hitObj;
                Cursor.renderer.enabled = false;
                hitObj.renderer.enabled = false;
                if (GameManager.Instance().GameMode != "pvp")
                {
                    currentstate = new EnemyState(GameManager.Instance().Players, GameManager.Instance().Enemies, this);
                    currentstate.Action();
                }
                else
                {
                    currentstate = new PvpEnemyState(GameManager.Instance().Players, GameManager.Instance().Enemies, this);
                    currentstate.Action();
                }
            }
        }

        public void DrawCursor()
        {
            if (GameManager.Instance().CurrentPawn != null)
                Cursor.transform.position = new Vector3(GameManager.Instance().CurrentPawn.rigidbody2D.transform.position.x, GameManager.Instance().CurrentPawn.rigidbody2D.transform.position.y +
                    (GameManager.Instance().CurrentPawn.gameObject.renderer.bounds.size.y / 2), 0f);

        }

        public void CheckWinorLose()
        {
            if (GameManager.Instance().Enemies.Count <= 0)
            {
                GameManager.Instance().GameStatus = "win";
                GameManager.Instance().PlayerExp = 100;
                GameManager.Instance().PlayerGold = 100;
                Application.LoadLevel("AfterBattle2");

            }
            else if (GameManager.Instance().Players.Count <= 0)
            {
                GameManager.Instance().GameStatus = "lose";
                Application.LoadLevel("AfterBattle2");
            }

        }
        void Start()
        {
            // currentstate = new FirstHandState(GameMenager.Instance().CurrentPawn);
        }

        // Update is called once per frame
        void Update()
        {

            DrawCursor();
            EndPlayerTurn();
            SelectPawn();
          //  CheckWinorLose();
        }
        void OnGUI()
        {
            if (!(currentstate is CardExcutionState)) return;
            GUI.Box(new Rect((Screen.width / 2) - 50, (Screen.height / 2) - 75, 100, 150), "Execute Effect");
            if (GUI.Button(new Rect((Screen.width / 2) - 50, (Screen.height / 2) - 25, 100, 50), "Yes"))
            {   Debug.Log("kena");
                currentstate.Action();
            }

            if (!GUI.Button(new Rect((Screen.width/2) - 50, ((Screen.height/2) - 25) + 50, 100, 50), "No")) return;
            var obj = GameManager.Instance().CurrentPawn;
            currentstate = new ChangePlayerState(obj, objectLoader, this);
            currentstate.Action();
        }
        public GameObject HitCollider()
        {
            GameObject obj = null;
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (Input.GetMouseButtonUp(0))
            {
                if (hit.collider != null)
                {
                    obj = hit.collider.gameObject;
                }
            }
            return obj;
        }
    }
}