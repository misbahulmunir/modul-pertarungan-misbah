using UnityEngine;
using System.Collections.Generic;
using System.Collections;

namespace ModulPertarungan
{
    public class BattleStateManager : MonoBehaviour
    {

        // Use this for initialization
        

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
                        GameObject gobj = null;
                        CardsEffect card = hit.collider.gameObject.GetComponent<CardsEffect>();
                        GameManager.Instance().CurrentCard = card;
                        card.Effect();


                        foreach (GameObject obj in GameManager.Instance().CurrentPawn.GetComponent<PlayerAction>().CurrentHand)
                        {
                            if (hit.collider.name == obj.name + "(Clone)")
                            {
                                gobj = obj;
                                break;
                            }
                        }
                        GameManager.Instance().CurrentPawn.GetComponent<PlayerAction>().CurrentHand.Remove(gobj);
                        Destroy(hit.collider.gameObject);
                        currentstate = new ChangePlayerState(GameManager.Instance().CurrentPawn, objectLoader, this);
                        currentstate.Action();

                    }

                }
            }

        }
        public void SelectPawn()
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (Input.GetMouseButtonUp(0))
            {
                if (hit.collider != null)
                {
                    if (hit.collider.gameObject.name.ToLower().Contains("warlock"))
                    { 
                        GameObject obj= GameManager.Instance().CurrentPawn = hit.collider.gameObject as GameObject;
                        currentstate = new ChangePlayerState(obj,objectLoader,this );
                        currentstate.Action();
                    }

                }
            }
        }
        public void EndPlayerTurn()
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (Input.GetMouseButtonUp(0) )
            {
                if (hit.collider != null)
                {
                    if (hit.collider.gameObject.name.ToLower().Contains("endbutton"))
                    {
                        GameObject obj = GameManager.Instance().CurrentPawn = hit.collider.gameObject as GameObject;
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
          
                Cursor.transform.position = new Vector3(GameManager.Instance().CurrentPawn.rigidbody2D.transform.position.x, GameManager.Instance().CurrentPawn.rigidbody2D.transform.position.y +
                    (GameManager.Instance().CurrentPawn.gameObject.renderer.bounds.size.y / 2), 0f);
            
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
        }
    }
}