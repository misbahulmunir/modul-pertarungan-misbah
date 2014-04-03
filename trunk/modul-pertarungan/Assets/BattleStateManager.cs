using UnityEngine;
using System.Collections.Generic;
using System.Collections;

namespace ModulPertarungan
{
    public class BattleStateManager : MonoBehaviour
    {

        // Use this for initialization
        private BattleState currentstate;
        public void SelectPawn()
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (Input.GetMouseButtonUp(0))
            {
                if (hit.collider != null)
                {
                    if (hit.collider.gameObject.name.ToLower().Contains("pawn"))
                    {
                        Debug.Log("kena");
                        GameObject obj= GameMenager.Instance().CurrentPawn = hit.collider.gameObject as GameObject;
                        currentstate = new ChangePlayerState(obj, GameObject.Find("Objcetloader"));
                        currentstate.Action();
                    }

                }
            }
        }
        void Start()
        {
           // currentstate = new FirstHandState(GameMenager.Instance().CurrentPawn);
        }

        // Update is called once per frame
        void Update()
        {
            SelectPawn();
        }
    }
}