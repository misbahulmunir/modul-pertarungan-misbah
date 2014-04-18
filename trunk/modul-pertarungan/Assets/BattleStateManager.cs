using UnityEngine;
using System.Collections.Generic;
using System.Collections;

namespace ModulPertarungan
{
    public class BattleStateManager : MonoBehaviour
    {

        // Use this for initialization

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
        public void SelectCard()
        {

            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (Input.GetMouseButtonUp(0))
            {
                if (hit.collider != null)
                {
                    if (hit.collider.gameObject.name.ToLower().Contains("card"))
                    {

                        CardsEffect card = hit.collider.gameObject.GetComponent<CardsEffect>();
                        GameManager.Instance().CurrentCard = card;
                        currentstate = new CardExcutionState(GameManager.Instance().CurrentPawn, this, hit.collider.gameObject);


                    }

                }
            }

        }

        public void SelectPawn()
        {
            if (!(this.currentstate is CardExcutionState))
            {
                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
                if (Input.GetMouseButtonUp(0))
                {
                    if (hit.collider != null)
                    {
                        if (hit.collider.gameObject.name.ToLower().Contains("warlock"))
                        {
                            GameObject obj = GameManager.Instance().CurrentPawn = hit.collider.gameObject as GameObject;
                            currentstate = new ChangePlayerState(obj, objectLoader, this);
                            currentstate.Action();
                        }

                    }
                }
            }
        }

        public void EndPlayerTurn()
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (Input.GetMouseButtonUp(0))
            {
                if (hit.collider != null)
                {
                    if (hit.collider.gameObject.name.ToLower().Contains("endbutton"))
                    {
                        GameObject obj = hit.collider.gameObject as GameObject;
                        EndButton = obj;
                        Cursor.renderer.enabled = false;
                        obj.renderer.enabled = false;
                        currentstate = new EnemyState(GameManager.Instance().Players, GameManager.Instance().Enemies, this);
                        currentstate.Action();
                    }
                }
            }
        }
        public void DrawCursor()
        {
            if(GameManager.Instance().CurrentPawn!=null)
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
                //Application.LoadLevel("AfterBattle");
                
            }
            else if (GameManager.Instance().Players.Count <=0)
            {
                GameManager.Instance().GameStatus="lose";
               // Application.LoadLevel("AfterBattle");
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
            SelectCard();
            CheckWinorLose();
        }
        void OnGUI()
        {

            if (currentstate is CardExcutionState)
            {
                GUI.Box(new Rect((Screen.width / 2) - 50, (Screen.height / 2) - 75, 100, 150), "Execute Effect");
                if (GUI.Button(new Rect((Screen.width / 2) - 50, (Screen.height / 2) - 25, 100, 50), "Yes"))
                {
                    currentstate.Action();
                }

                if (GUI.Button(new Rect((Screen.width / 2) - 50, ((Screen.height / 2) - 25)+50, 100, 50), "No"))
                {
                    GameObject obj = GameManager.Instance().CurrentPawn;
                    currentstate = new ChangePlayerState(obj, objectLoader, this);
                    currentstate.Action();
                }
            }
        }
    }
}