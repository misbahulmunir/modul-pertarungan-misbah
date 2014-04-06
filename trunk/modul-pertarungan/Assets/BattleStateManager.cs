using UnityEngine;
using System.Collections.Generic;
using System.Collections;

namespace ModulPertarungan
{
    public class BattleStateManager : MonoBehaviour
    {

        // Use this for initialization
        private BattleState currentstate;
        public GameObject objectLoader;
        public GameObject Cursor;
        public void SelectPawn()
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (Input.GetMouseButtonUp(0))
            {
                if (hit.collider != null)
                {
                    if (hit.collider.gameObject.name.ToLower().Contains("warlock"))
                    {
                       
                        GameObject obj= GameMenager.Instance().CurrentPawn = hit.collider.gameObject as GameObject;
                        currentstate = new ChangePlayerState(obj,objectLoader,this );
                        currentstate.Action();
                        Debug.Log(GameMenager.Instance().CurrentPawn.GetComponent<WarlockAction>().Warlock.Name);
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

                        GameObject obj = GameMenager.Instance().CurrentPawn = hit.collider.gameObject as GameObject;
                        Cursor.renderer.enabled = false;
                        obj.renderer.enabled = false;
                    }
                }
            }
        }
        public void DrawCursor()
        {
          
                Cursor.transform.position = new Vector3(GameMenager.Instance().CurrentPawn.rigidbody2D.transform.position.x, GameMenager.Instance().CurrentPawn.rigidbody2D.transform.position.y +
                    (GameMenager.Instance().CurrentPawn.gameObject.renderer.bounds.size.y / 2), 0f);
            
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
        }
    }
}